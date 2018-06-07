using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vue2Spa.Models.DB;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Vue2Spa.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class POSController : Controller
    {
        private readonly POSDBContext _context;
        private readonly POSDBContext _context2;
        public POSController(POSDBContext context)
        {
            _context = context;
            _context2 = context;
        }


        [HttpGet("[action]")]                                                
        public ActionResult GetSalesById([FromQuery(Name = "InvoiceId")] int InvoiceId = 0)
        {
    
            try
            {
                var Sales = (from a in _context.Sales
                             join b in _context.Master on a.ItemId equals b.ItemId
                             where a.InvoiceId == InvoiceId
                             select new {
                                 id=a.Id,
                                 itemname=b.ItemName,
                                 qyt=a.Qyt,
                                 cost=a.Cost,
                                 price=a.Price,
                                 total=a.Total,
                                 invoiceId = a.InvoiceId,
                                 itemId = a.ItemId,
                                 DisAmount = a.DisAmount,

                             });
                            
                var result = new
                {
                   
                    ErrorCode = 0,
                    Sales = Sales
                };
                return Ok(result);


            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }
        }
        
        [HttpPost("[action]")]
        public ActionResult RemoveSaleFromTicket([FromBody]  Sales sale)
        {

            try
            {
                using (var db = _context)
                {
                    var item = db.Master.Find(sale.ItemId);
                    if (item == null)
                    {
                        return Json(new { ErrorCode = 100, Message = "خطأ  في أيجاد الصنف" });
                    }
                   

                    item.InStock = item.InStock + sale.Qyt;
                    item.Soldqyt = item.Soldqyt - sale.Qyt;

                    db.Entry(item).CurrentValues.SetValues(item);
                    db.Sales.Remove(sale);

                    db.SaveChanges();
                }
                return Json(new { ErrorCode = 0 });

            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }


        }
        

        [HttpPost("[action]")]
        public ActionResult EditSaleQuantity([FromBody]  Sales sale)
        {

            try
            {
                using (var db = _context)
                {
                    var item = db.Master.Find(sale.ItemId);
                    if (item == null)
                    {
                        return Json(new { ErrorCode = 100, Message = "خطأ  في أيجاد الصنف" });
                    }

                    var oldsale = db.Sales.Find(sale.Id);
                    if (oldsale == null)
                    {
                        return Json(new { ErrorCode = 101, Message = "خطأ  في تعديل الكمية" });
                    }

                    if (sale.Qyt > oldsale.Qyt)
                    {
                        item.InStock = item.InStock - (sale.Qyt - oldsale.Qyt);
                        item.Soldqyt = item.Soldqyt + (sale.Qyt - oldsale.Qyt);
                        oldsale.Qyt = oldsale.Qyt   + (sale.Qyt - oldsale.Qyt);


                        oldsale.Total = (oldsale.Price - oldsale.DisAmount) * oldsale.Qyt;


                        if (item.InStock<0)
                            return Json(new { ErrorCode = 101, Message = "لا يوجد مخزون لهدا الصنف" });
                    }
                    else if (sale.Qyt < oldsale.Qyt)
                    {
                        item.InStock = item.InStock + (oldsale.Qyt-sale.Qyt );
                        item.Soldqyt = item.Soldqyt - (oldsale.Qyt - sale.Qyt);
                        oldsale.Qyt = oldsale.Qyt - (oldsale.Qyt - sale.Qyt);
                        oldsale.Total = (oldsale.Price - oldsale.DisAmount) * oldsale.Qyt;
                    }



                    db.Entry(item).CurrentValues.SetValues(item);
                    db.Entry(oldsale).CurrentValues.SetValues(oldsale);
                    db.SaveChanges();
                }
                return Json(new { ErrorCode = 0 });

            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }


        }

        
        //[HttpPost("[action]")]
        //public ActionResult OpenExistTicket([FromBody] Tickets ticketB)
        //{
            
        //    try
        //    {
        //        Tickets ticket = new Tickets();
            
        //        var ticketq =(Tickets) (from a in _context.Tickets where a.InvoiceId == ticketB.InvoiceId
        //                                                        && a.Posted == false &&  a.OperId==ticketB.OperId select a);
        //        if (ticket == null)
        //        {
        //            return Json(new { ErrorCode = 2, Message="الفاتورة غير موجودة" });

        //        }
        //        ticket.=
        //        return Json(new { ErrorCode = 0, ticket });

        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
        //    }


        //}

        [HttpGet("[action]")]
        public ActionResult CreateNewticket()
        {
            Tickets ticket = new Tickets();
            ticket.OperId = 33;
            ticket.BranchId = 1;
            ticket.InvoiceTypeId=1;
            ticket.PaymentId = 1;
            ticket.Posted = false;
            ticket.Total = 0;
            ticket.Dis = 0;
            try
            {
                using (var db = _context)
                {

                    db.Tickets.Add(ticket);

                    db.SaveChanges();
                }
                return Json(new { ErrorCode = 0, ticket });

            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }


        }
        

            [HttpGet("[action]")]
        public ActionResult GetsSuspendedTicket()
        {
            
            try
            {
              
                    var tickets = (from a in _context.Tickets
                                   where a.OperId == 33 && a.Posted==false
                                   select a
                                   );
                    
             

                
                return Json(new { ErrorCode = 0, tickets });

            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }


        }

        [HttpPost("[action]")]
        public ActionResult SubmitTicket([FromBody] Tickets ticket)
        {
            try
            {
                using (var db = _context)
                {
                    var tkt = db.Tickets.Find(ticket.InvoiceId);
                    if (tkt == null)
                    {
                        return Json(new { ErrorCode = 100, Message = "خطأ  في أيجاد الفاتورة" });
                    }
                    //tkt.Time = new DateTimeOffset(7,);
                    tkt.Total = ticket.Total;
                    tkt.Posted = ticket.Posted;
                    tkt.Dis = ticket.Dis;
                    db.Entry(tkt).CurrentValues.SetValues(tkt);
                    db.SaveChanges();
                }
                return Json(new { ErrorCode = 0, ticket });

            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }


        }

        [HttpPost("[action]")]
        public ActionResult ChangePayment([FromBody] Tickets ticket)
        {
            try
            {
                using (var db = _context)
                {
                   var tkt = db.Tickets.Find(ticket.InvoiceId);
                    if (tkt == null)
                    {
                        return Json(new { ErrorCode = 100, Message = "خطأ  في أيجاد الفاتورة" });
                    }
                    tkt.PaymentId = ticket.PaymentId;
                    db.Entry(tkt).CurrentValues.SetValues(tkt);
                    var Sales = (from a in _context.Sales                               
                                 where a.InvoiceId == ticket.InvoiceId
                                 select a);

                    foreach (var sale in Sales)
                    {
                       
                        var master = db.Master.SingleOrDefault(b => b.ItemId == sale.ItemId);
                        if (master == null)
                        {
                            return Json(new { ErrorCode = 22, Message = "خطأ في تعديل الأصناف " });

                        }
                        sale.Price = PaymentPrice(master,(int)ticket.PaymentId, db);
                        sale.DisAmount = Discount(master, (float)sale.Price, db);
                        sale.Total = (sale.Price - sale.DisAmount) * sale.Qyt;
                    }
                   

                    db.SaveChanges();
                }
                return Json(new { ErrorCode = 0, ticket });

            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }


        }

        [HttpPost("[action]")]
        public ActionResult AddItemToTicket([FromBody]  JObject body)
        {
            dynamic itemsB = body;

            int payment = (int)itemsB.payment;

            string json2 = JsonConvert.SerializeObject(itemsB.sale, Formatting.Indented);
            Sales sale = JsonConvert.DeserializeObject<Sales>(json2);

            Master item;
            try
            {
                using (var db = _context)
                {
                     item = db.Master.Find(sale.ItemId);
                    if (item == null)
                    {
                        return Json(new { ErrorCode = 100, Message = "خطأ  في أيجاد الصنف" });
                    }
                    else if (item.InStock - sale.Qyt <0)
                    {

                        return Json(new { ErrorCode = 101, Message = "لا يوجد مخزون لهدا الصنف" });
                    }

                    item.InStock = item.InStock - sale.Qyt;
                    item.Soldqyt = item.Soldqyt + sale.Qyt;
                    db.Entry(item).CurrentValues.SetValues(item);

                    sale.Price = PaymentPrice(item, payment , db);
                    sale.DisAmount = Discount(item, (float)sale.Price, db);
                    sale.Total =( sale.Price - sale.DisAmount) * sale.Qyt;
                    db.Sales.Add(sale);
                    db.SaveChanges();
           
                }

               
                using (var db = _context2)
                {
                   
                }
                  
                return Json(new { ErrorCode = 0 });

            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }


        }

        public float PaymentPrice(Master item,int paymentid , POSDBContext db)
        {
            double Discount = 0;
            try
            {

               
                    Discount = (double)(from i in db.ItemPrices where i.PaymentId == paymentid && i.ItemId==item.ItemId select i.Price).SingleOrDefault();
                    
              
                return (float)Discount;

            }
            catch (Exception )
            {
                return -1;
            }
            
        }
        public float Discount(Master item,float price , POSDBContext db)
        {
            double Discount = 0;
            try
            {
                if (item.Discount == -1)
                    return 0;
                else if (item.Discount > 0)
                    return price * ((float)item.Discount / 100);
                else

                {
                    Discount = (double)(from i in db.Groups where i.GroupId == item.GroupId select i.Discount).SingleOrDefault();
                    return price * ((float)Discount / 100);
                }
            }
            catch (Exception )
            {
                return -1;
            }

        }
    }
}
