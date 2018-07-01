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
        public ActionResult addbybarcode([FromQuery(Name = "barcode")] string barcode)
        {

            try
            {
                var item = (from a in _context.Master
                            where (a.Barcode3 == barcode ||  a.Codebar== barcode || a.Barcode4== barcode) && a.StopSaleF==true
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

        [HttpGet("[action]")]
        public ActionResult SearshByName([FromQuery(Name = "name")] string name,  [FromQuery(Name = "from")] int from = 0, [FromQuery(Name = "to")] int to = 4, [FromQuery(Name = "qtype")] int qtype = 1)
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
                if (qtype == 1)
                {
                    var Items = (from m in _context.Master
                                 where m.ItemName.Contains(name) && m.InStock>0
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
                                 where m.ItemName.Contains(name)
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
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }





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
                                 id = a.Id,
                                 itemname = b.ItemName,
                                 qyt = a.Qyt,
                                 cost = a.Cost,
                                 price = a.Price,
                                 total = a.Total,
                                 invoiceId = a.InvoiceId,
                                 itemId = a.ItemId,
                                 disAmount = a.DisAmount,
                                 RuturnQuantity = 0,
                                 ReturenQantity=a.ReturenQantity,
                                 Codebar = b.Codebar
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
            ticket.OperId = 56;
            ticket.BranchId = 1;
            ticket.InvoiceTypeId=1;
            ticket.PaymentId = 1;
            ticket.Posted = false;
            ticket.Total = 0;
            ticket.Dis = 0;
            ticket.CusId = -1;
            ticket.Note = "";
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
                                    where a.Posted==false
                                   select a
                                   );
                    
             

                
                return Json(new { ErrorCode = 0, tickets });

            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }


        }
        
               [HttpGet("[action]")]
        public ActionResult GetReversalTicktes([FromQuery(Name = "InvoiceId")] int InvoiceId=0)
        {

            try
            {

                var tickets = (from a in _context.Tickets
                               where   a.InvoiceTypeId==2 && a.ParentId== InvoiceId
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
                    var Sales = (from a in _context.Sales
                                 join b in _context.Master on a.ItemId equals b.ItemId
                                 where a.InvoiceId == ticket.InvoiceId
                                 select b).ToList();
                    foreach (Master m   in Sales)
                    {
                        m.LastSoldDate = DateTime.Now;
                    }

                        //tkt.Time = new DateTimeOffset(7,);
                    tkt.Total = ticket.Total;
                    tkt.Posted = ticket.Posted;
                    tkt.Dis = ticket.Dis;
                    tkt.Time = DateTime.Now;
                    tkt.Note = ticket.Note;
                    tkt.CusId = ticket.CusId;

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


                    if (item.StopSaleF == false)
                    {
                        return Json(new { ErrorCode = 100, Message = "الصنف موقوف" });
                    }

                    else if (item.InStock - sale.Qyt <0)
                    {

                        return Json(new { ErrorCode = 101, Message = "لا يوجد مخزون لهدا الصنف" });
                    }

                    item.InStock = item.InStock - sale.Qyt;
                    item.Soldqyt = item.Soldqyt + sale.Qyt;
                 //   item.LastSoldDate =  DateTime.Now;
                    db.Entry(item).CurrentValues.SetValues(item);
                    sale.ReturenQantity = 0;
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

        

        [HttpGet("[action]")]
        public ActionResult OpenExistTicket([FromQuery(Name = "InvoiceId")] int InvoiceId = 0)
        {

            try
            {
                var Ticket = (from a in _context.Tickets                            
                             where a.InvoiceId == InvoiceId && a.Posted==true
                             select a).SingleOrDefault();
                if (Ticket==null)
                    return Json(new { ErrorCode = 2, Message = "الفاتورة غير موجودة" });

             
                return Json(new { ErrorCode = 0, Ticket = Ticket });


            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }
        }

        [HttpPost("[action]")]
        public ActionResult SubmitRuturn([FromBody] JObject body)
        {
            try
            {
                dynamic itemsB = body;
                int invoiceId = itemsB.sales[0].invoiceId;

               
                float  total=0;
                Sales oldsale;
                using (var db = _context)
                {
                    var ticket = db.Tickets.SingleOrDefault(b => b.InvoiceId == invoiceId && b.Posted==true );

                    foreach (dynamic sale in itemsB.sales)
                    {
                        if (sale.ruturnQuantity > 0)
                        {
                            int itemId = (int)sale.itemId;

                            var item = db.Master.SingleOrDefault(b => b.ItemId == itemId);

                            if (item == null || ticket == null)
                            {
                                return Json(new { ErrorCode = 22, Message = "خطأ في المعالجة " });
                            }

                            var isreversabel = Isreversabel(item, ticket, db);
                            if (isreversabel != "Done")
                                return Json(new { ErrorCode =55, Message = isreversabel });

                            oldsale = db.Sales.Find((int)sale.id);
                            if( (int)sale.ruturnQuantity >oldsale.Qyt - oldsale.ReturenQantity )
                                return Json(new { ErrorCode = 555, Message = "لا يمكن ترجيع الكمية المطلوبة" });

                            total = total + ((float)sale.price - (float)sale.disAmount) * (int)sale.ruturnQuantity;
                        }     
                    }
                    Tickets ticketR = new Tickets();
                   
                    ticketR.OperId = 33;
                    ticketR.BranchId = 1;
                    ticketR.InvoiceTypeId = 2;
                    ticketR.PaymentId = ticket.PaymentId;
                    ticketR.Posted = true;
                    ticketR.Time = DateTime.Now;
                    ticketR.Total = total*-1;
                    ticketR.ParentId = ticket.InvoiceId;
                    ticketR.CusId = (int)itemsB.ticket.cusId;
                    ticketR.Note= (string)itemsB.ticket.note;
                    db.Tickets.Add(ticketR);
                    db.SaveChanges();
                   
                    foreach (dynamic sale in itemsB.sales)
                    {
                        if (sale.ruturnQuantity > 0)
                        {
                            int itemId = (int)sale.itemId;
                            var item = db.Master.SingleOrDefault(b => b.ItemId == itemId);
                            item.InStock = item.InStock +(int) sale.ruturnQuantity;
                            item.Soldqyt = item.Soldqyt - (int)sale.ruturnQuantity;
                            db.Entry(item).CurrentValues.SetValues(item);
                            
                            Sales newsale = new Sales();
                            newsale.InvoiceId = ticketR.InvoiceId;
                            newsale.ItemId = itemId;
                            newsale.Price =(float) sale.price- (float)sale.disAmount;
                            newsale.Qyt =(int) sale.ruturnQuantity * -1;
                            newsale.Total = newsale.Qyt * newsale.Price;
                            newsale.Cost = (float)sale.cost;


                            oldsale = db.Sales.Find((int)sale.id);
                            oldsale.ReturenQantity = oldsale.ReturenQantity+(int)sale.ruturnQuantity ;
                            db.Entry(oldsale).CurrentValues.SetValues(oldsale);

                            db.Sales.Add(newsale);

                        }
                    }



                    db.SaveChanges();
                }
                return Json(new { ErrorCode = 0 , Message = "تم ترجيع الأصناف"});
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
        public string Isreversabel(Master item,Tickets ticket, POSDBContext db)
        {
        
            try
            {
                if (item.DaysReverse == -1)
                    return " الصنف " + item.ItemName + " غير قابل للترجيع ";
                else if (item.DaysReverse > 0)
                {
                    TimeSpan ts = DateTime.Now - ticket.CreatedDate;
                    int NumberOfDays =(int) ts.TotalDays;

                    if(NumberOfDays > item.DaysReverse)
                     return " الصنف " + item.ItemName + " غير قابل للترجيع بعد " + item.DaysReverse + " يوم ";
                }
                else
                {
                    Groups g  = (from i in db.Groups where i.GroupId == item.GroupId select i).SingleOrDefault();
                    if( g.DaysReverse==0)
                        return " الأصناف في المجموعة  " + g.GroupDes + " غير قابلة للترجيع بعد " ;


                    TimeSpan ts = DateTime.Now - ticket.CreatedDate;
                    int NumberOfDays = (int)ts.TotalDays;

                    if (NumberOfDays >g.DaysReverse)
                        return " الأصناف في المجموعة  " + g.GroupDes + " غير قابلة للترجيع بعد " + g.DaysReverse +" يوم ";
                }

                return "Done";
            }
            catch (Exception)
            {
                return "error";
            }

        }
    }
}
