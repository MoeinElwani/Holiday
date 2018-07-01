using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vue2Spa.Models.DB;
namespace Vue2Spa.Controllers
{
    [Produces("application/json")]
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        private readonly POSDBContext _context;

        public CustomersController(POSDBContext context)
        {
            _context = context;
        }
        [HttpGet("[action]")]
        public ActionResult GetActiveCustomers()
        {
            try
            {
                var Customers = (from  a in _context.Customers
                                 
                                 select new
                                 {
                                     cusId = a.CusId,
                                     phone = a.Phone,
                                     company = a.SalesmanId,
                                     cusName = a.CusName,
               

                                 }).ToList();
                var result = new
                {
                    ErrorCode = 0,
                    Customers = Customers
                };
                return Ok(result);


            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }

        }
        [HttpGet("[action]")]
        public ActionResult GetActiveCustomersTop()
        {
            try
            {
                var Customers = (from a in _context.Customers

                                 select new
                                 {
                                     cusId = a.CusId,
                                     phone = a.Phone,
                                     company = a.SalesmanId,
                                     cusName = a.CusName,


                                 }).Take(4).ToList();
                var result = new
                {
                    ErrorCode = 0,
                    Customers = Customers
                };
                return Ok(result);


            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }

        }

        [HttpGet("[action]")]
        public ActionResult SearshCostomer([FromQuery(Name = "name")] string name, [FromQuery(Name = "comid")] string comid, [FromQuery(Name = "phone")] string phone)
        {
            try
            {
                if (name == null)
                {
                    var Customers = (from a in _context.Customers
                                     where  a.Phone.Contains(phone)
                                     select new
                                     {
                                         cusId = a.CusId,
                                         phone = a.Phone,
                                         company = a.SalesmanId,
                                         cusName = a.CusName,


                                     }).Take(3).ToList();
                    var result = new
                    {
                        ErrorCode = 0,
                        Customers = Customers
                    };
                    return Ok(result);
                }
                else if (phone ==null)
                {
                    var Customers = (from a in _context.Customers
                                     where a.CusName.Contains(name) 
                                     select new
                                     {
                                         cusId = a.CusId,
                                         phone = a.Phone,
                                         company = a.SalesmanId,
                                         cusName = a.CusName,


                                     }).Take(3).ToList();
                    var result = new
                    {
                        ErrorCode = 0,
                        Customers = Customers
                    };
                    return Ok(result);
                }
                else
                {
                    var Customers = (from a in _context.Customers
                                     where a.CusName.Contains(name) && a.Phone.Contains(phone)
                                     select new
                                     {
                                         cusId = a.CusId,
                                         phone = a.Phone,
                                         company = a.SalesmanId,
                                         cusName = a.CusName,


                                     }).Take(3).ToList();
                    var result = new
                    {
                        ErrorCode = 0,
                        Customers = Customers
                    };
                    return Ok(result);
                }


            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }

        }
        [HttpPost("[action]")]
        public ActionResult AddCustomer([FromBody] Customers customer)
        {

         
            try
            { 

                using (var db = _context)
                {
                    var c =( from a in db.Customers where a.Phone == customer.Phone && a.CusName == customer.CusName select a).ToList();
                    
                    if (c.Count>0)
                        return Json(new { ErrorCode = 0 });

                    customer.CusgroupId = 0;customer.CusCompanyId = 0;
                    db.Customers.Add(customer);
                    db.SaveChanges();

                }
                return Json(new { ErrorCode = 0 });

            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }


        }

    }
}
