using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vue2Spa.Models.DB;


namespace Vue2Spa.Controllers
{
    [Route("api/[controller]")]
    public class GroupsController : Controller
    {

        private readonly POSDBContext _context;

        public GroupsController(POSDBContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public ActionResult GetAllGroups()
        {

            try
            {
                var Groups = (from a in _context.Groups

                                select new
                                {
                                    GroupId = a.GroupId,
                                    GroupDes = a.GroupDes,
                                    TypeId = a.TypeId,
                                    IsReversabel = a.IsReversabel,
                                    DaysReverse = a.DaysReverse,
                                    Discount = a.Discount

                                }).ToList();
                var result = new
                {
                    ErrorCode = 0,
                    Groups = Groups
                };
                return Ok(result);

            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }



        }

        [HttpPost("[action]")]
        public ActionResult Edit([FromBody] Groups group)
        {
           

            try
            {
                if (group.Discount < 0)
                    return Json(new { ErrorCode = 55, Message = " التخفيض غير صحيح " });
                else if (group.DaysReverse < -1)
                    return Json(new { ErrorCode = 55, Message = " أيام الترجيع غير صحيحة" });

                using (var db = _context)
                {
                    var entity = db.Groups.Find(group.GroupId);
                    if (entity == null)
                    {
                        return Ok();
                    }

                    db.Entry(entity).CurrentValues.SetValues(group);
                    db.SaveChanges();

                

                }
                return Json(new { ErrorCode = 0 });

            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }


        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
