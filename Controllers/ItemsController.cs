using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vue2Spa.Models.DB;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace POS.Holiday.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private readonly POSDBContext _context;

        public ItemsController(POSDBContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public ActionResult GetAllItems([FromQuery(Name = "from")] int from = 0, [FromQuery(Name = "to")] int to = 4)
        {
            var quantity = to - from;

            // We should also avoid going too far in the list.
            if (quantity <= 0)
            {
                return BadRequest("You cannot have the 'to' parameter higher than 'from' parameter.");
            }
            else if (from < 0)
            {
                return BadRequest("You cannot go in the negative with the 'from' parameter");
            }
            try
            {
                var Items = (from a in _context.Master
                             join c in _context.Groups on a.GroupId equals c.GroupId
                             select new
                             {
                                 ItemName = a.ItemName,
                                 ItemID = a.ItemId,
                                 ItemGroup = c.GroupDes,
                                 ItemGroupID = a.GroupId


                             }).ToList().Skip(from).Take(quantity).ToArray();

                var Totali = (from a in _context.Master

                              select new
                              {

                              }).ToList();
                //Forecasts = allForecasts.Skip(from).Take(quantity).ToArray()

                var result = new
                {
                    Total = Totali.Count,
                    ErrorCode = 0,
                    Items = Items
                };
                return Ok(result);


            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }
        }
          
        [HttpGet("[action]")]
        public ActionResult SearshByName([FromQuery(Name = "name")] string name , [FromQuery(Name = "dapid")] int dapid, [FromQuery(Name = "grpid")] int grpid, [FromQuery(Name = "typeid")] int typeid, [FromQuery(Name = "from")] int from = 0, [FromQuery(Name = "to")] int to = 4)
    {
            var quantity = to - from;

            // We should also avoid going too far in the list.
            if (quantity <= 0)
            {
                return BadRequest("You cannot have the 'to' parameter higher than 'from' parameter.");
            }
            else if (from < 0)
            {
                return BadRequest("You cannot go in the negative with the 'from' parameter");
            }
            try
            {
                if (name is null )
                {
                    if (dapid == -1)
                    {
                        var Items = (from m in _context.Master
                                     where  m.GroupId == grpid
                                     select m).ToList();
                        var result = new
                        {

                            ErrorCode = 0,
                            Items = Items.Skip(from).Take(quantity).ToArray(),
                            Count = Items.Count,
                        };
                        return Ok(result);
                    }
                    else
                    {
                        if (typeid != -1)
                        {
                            var Items = (from m in _context.Master
                                         where  m.GroupId == grpid && m.DepId == dapid && m.TypeId == typeid
                                         select m).ToList();
                            var result = new
                            {
                                Count = Items.Count,
                                ErrorCode = 0,
                                Items = Items.Skip(from).Take(quantity).ToArray()
                            };
                            return Ok(result);
                        }
                        else
                        {
                            var Items = (from m in _context.Master
                                         where  m.GroupId == grpid && m.DepId == dapid
                                         select m).ToList();
                            var result = new
                            {
                                Count = Items.Count,
                                ErrorCode = 0,
                                  Items = Items.Skip(from).Take(quantity).ToArray()
                            };
                            return Ok(result);
                        }

                    }
                }
                else
                { 
                if (dapid == -1)
                {
                    var Items = (from m in _context.Master
                                 where m.ItemName.Contains(name) && m.GroupId==grpid
                                 select m).ToList();
                    var result = new
                    {
                        Count = Items.Count,
                        ErrorCode = 0,
                          Items = Items.Skip(from).Take(quantity).ToArray()
                    };
                    return Ok(result);
                }
                else 
                {
                    if (typeid != -1)
                    {
                        var Items = (from m in _context.Master
                                     where m.ItemName.Contains(name) && m.GroupId == grpid && m.DepId==dapid && m.TypeId==typeid
                                     select m).ToList();
                        var result = new
                        {
                            Count = Items.Count,
                            ErrorCode = 0,
                              Items = Items.Skip(from).Take(quantity).ToArray()
                        };
                        return Ok(result);
                    }
                    else
                    {
                        var Items = (from m in _context.Master
                                     where m.ItemName.Contains(name) && m.GroupId == grpid && m.DepId == dapid  
                                     select m).ToList();
                        var result = new
                        {
                            Count = Items.Count,
                            ErrorCode = 0,
                            Items = Items.Skip(from).Take(quantity).ToArray()
                        };
                        return Ok(result);
                    }

                }
                }
            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }



        

        }
    
        [HttpGet("[action]")]
        public ActionResult GetAllDepartment()
        {

            try
            {
                var Departments = (from a in _context.Departments

                              select new
                              {
                                  DepId = a.DepId,
                                  DepDesc = a.DepDesc,
                                
                              }).ToList();
                var result = new
                {
                    ErrorCode = 0,
                    Departments = Departments
                };
                return Ok(result);

            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }



        }

        [HttpGet("[action]")]
        public ActionResult GetTypebyDepartments([FromQuery(Name = "depId")] int depId)
        {           
            try
            {
                var Types = (from a in _context.Types
                             where a.DepId== depId
                             select new
                                   {
                                       DepId = a.DepId,
                                       TypeId = a.TypeId,
                                       TypeDesc = a.TypeDesc

                                   }).ToList();
                var result = new
                {
                    ErrorCode = 0,
                    Types = Types
                };
                return Ok(result);

            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }



        }

        [HttpGet("[action]")]
        public ActionResult GetitemById( [FromQuery(Name = "itemId")] int itemId)
        {

            try
            {
                var item = (from a in _context.Master
                            where a.ItemId== itemId
                            select new
                                   {
                                       id = 0,
                                       
                                       qyt = 0,
                                       cost = a.Cost,
                                       price = a.ItemPrice,
                                       total = 0,
                                       invoiceId = 0,
                                       itemId = a.ItemId,

                                   }).SingleOrDefault();

                if (item == null)
                {
                    return Json(new { ErrorCode = 22, Message = "الصنف غير موجود " });
                }

                Sales i = new Sales();
                i.Id = 0;
                i.Qyt = item.qyt;
                i.Cost = item.cost;
                i.Price = item.price;
                i.Total = item.total;
                i.InvoiceId = item.invoiceId;
                i.ItemId = item.itemId;


                var result = new
                {
                    ErrorCode = 0,
                    item = i
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }





        }
        
       [HttpPost("[action]")]
        public ActionResult ProcessItems([FromBody] JObject body)
        {
            if (body == null)
            {
                return Json(new { ErrorCode = 22, Message = "خطأ في البيانات " });
            }
            try
            {
                dynamic itemsB = body;
                int Process = (int)itemsB.process;
                short number = (short)itemsB.number; ;
                int Rows = 0;
                using (var db = _context)
                {
                    foreach (dynamic item in itemsB.items)
                    {
                        int id = (int)item.itemId;
                        var result = db.Master.SingleOrDefault(b => b.ItemId == id);
                        if (result == null)
                        {
                            return Json(new { ErrorCode = 22, Message = "خطأ في المعالجة " });

                        }
                        switch (Process)
                        {
                            case 1: result.Discount = number; break;
                            case -1: result.Discount = -1; break;
                            case 10: result.Discount = 0; break;

                            case 2: result.DaysReverse = number; break;
                            case -2: result.DaysReverse = -1; break;
                            case 20: result.DaysReverse = 0; break;
                            default:
                               return Json(new { ErrorCode = 22, Message = "خطأ في البيانات " });
                               
                        }
                    }
                    Rows = db.SaveChanges();
                }
                return Json(new { ErrorCode = 0, Rows });
            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }
        }

    }
}
