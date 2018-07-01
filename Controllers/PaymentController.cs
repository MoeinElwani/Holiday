using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vue2Spa.Models.DB;




namespace Vue2Spa.Controllers
{
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private readonly POSDBContext _context;

        public PaymentController(POSDBContext context)
        {
            _context = context;
            //if (HttpContext.Session.GetString("_Name") == null)
            //    _context = context;
        }
     
        [HttpGet("[action]")]
        public ActionResult GetAllPAyments() {

            try
            {
                var Payments = (from a in _context.PaymentInfo
                               
                             select new
                             {
                                 paymentId = a.PaymentId,
                                 PaymentDes = a.PaymentDes,
                                 Status = a.Status,
                                 discount = a.Discount,
                                 currId= a.CurrId,
                                 paymentType=a.PaymentType

                             }).ToList();
                var result = new
                {
                    ErrorCode = 0,
                    Payments = Payments
                };
                return Ok(result);

            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }



        }
     
     
        [HttpGet("[action]")]
        public ActionResult GetActivePayments()
        {

            try
            {
                var Payments = (from a in _context.PaymentInfo
                                where a.Status==true
                                select new
                                {
                                    paymentId = a.PaymentId,
                                    PaymentDes = a.PaymentDes,
                                    Status = a.Status,
                                    discount = a.Discount,
                                    currId = a.CurrId,
                                    paymentType = a.PaymentType

                                }).ToList();
                var result = new
                {
                    ErrorCode = 0,
                    Payments = Payments
                };
                return Ok(result);

            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }



        }


        [HttpPost("[action]")]
        public ActionResult Edit([FromBody] PaymentInfo payment)
        {
            int total = 0;
            try
            {
                if(payment.Discount<0)
                    return Json(new { ErrorCode = 88, Message="التخفيض غير صحيح" });

              
                using (var db =  _context)
                {
                    var entity = db.PaymentInfo.Find(payment.PaymentId);
                    if (entity == null)
                    {
                        return Ok();
                    }

                    db.Entry(entity).CurrentValues.SetValues(payment);
                    db.SaveChanges();
                 
                        var ItemPrice = (from m in db.Master
                                         join p in db.ItemPrices 
                                         on m.ItemId equals p.ItemId
                                         where p.PaymentId == payment.PaymentId  select new { items = m, itemprice = p }
                                         ).ToList();

                    if (ItemPrice != null) {
                        foreach  ( var i in ItemPrice )
                        {
                            i.itemprice.Price = i.items.ItemPrice - ( (payment.Discount/100) * i.items.ItemPrice);


                        }

                        total= db.SaveChanges();

                    }

                }
                return Json(new { ErrorCode = 0, Message= total });

            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }
           
        
        }

    }
}
