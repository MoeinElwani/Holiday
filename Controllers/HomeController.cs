using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Vue2Spa.Models.DB;


//using System.Web.SessionState.HttpSessionState;
namespace Vue2Spa.Controllers
{
 
    public class HomeController : Controller
    {
        private readonly POSDBContext _context;
        const string SessionName = "_Name";
        const string SessionAge = "_Age";


        public HomeController(POSDBContext context)
        {
            _context = context;
           
        }
        public IActionResult Index()
        {
            HttpContext.Session.SetString(SessionName, "Jarvik");
            HttpContext.Session.SetInt32(SessionAge, 24);

            ViewBag.Name = HttpContext.Session.GetString(SessionName);
            ViewBag.Age = HttpContext.Session.GetInt32(SessionAge);
            return View();
        }

        public IActionResult Error()
        {
          
            return View();
        }
        [Produces("application/json")]
        [Route("api/[controller]")]
        [HttpPost("[action]")]
        //[AllowAnonymous]
        public ActionResult Login([FromBody] JObject body)
        {
            dynamic itemsB = body;
            int userId = (int)itemsB.userId;
            string Password = (string)itemsB.password; ;
            try
            {
                var db = _context;
                var CurrentUser = (from u in db.CasherInfo
                                   select u
                                   ).SingleOrDefault();


                if (CurrentUser == null)
                {
                    return Json(new { ErrorCode = 990, Message = "المستخدم غير موجود" });
                }
                else if (CurrentUser.IsActiveAccount != true)
                {
                    return Json(new { ErrorCode = 991, Message = "المستخدم موقوف" });
                }
                else if (CurrentUser.Password != Password)
                {                 
                    return Json(new { ErrorCode = 999, Message = " الرقم السري غير صحيح" });
                }
                db.SaveChanges();

                HttpContext.Session.SetString(SessionName, "Jarvik");
                HttpContext.Session.SetInt32(SessionAge, 24);

                return Json(new { ErrorCode = 0, Message = "Login Success" });

            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 1, Message = ex.Message.ToString() });
            }

        }

        [Route("api/[controller]")]
        [HttpGet("[action]")]
        [Produces("application/json")]
        public ActionResult GetSelesInvoices()
        {

            try
            {
                var Tickets = (from a in _context.Tickets
                               join b in _context.PaymentInfo on a.PaymentId equals b.PaymentId
                              select new
                              {
                                  InvoiceId = a.InvoiceId,
                                  PaymentDes = b.PaymentDes,
                                  Total = a.Total,
                                  Dis = a.Dis,
                                  Date = a.Date,
                                  CreatedDate = a.CreatedDate,
                                  Time = a.Time
                              }).ToList();
                var result = new
                {
                    ErrorCode = 0,
                    Tickets = Tickets
                };
                return Ok(result);

            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }



        }
    }
}
