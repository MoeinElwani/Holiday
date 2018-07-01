using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vue2Spa.Models.DB;

namespace Vue2Spa.Controllers
{
    [Produces("application/json")]
    [Route("api/Main")]
    public class MainController : Controller
    {
        private readonly POSDBContext _context;

        public MainController(POSDBContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public ActionResult GetSelesInvoices([FromQuery(Name = "from")] int from = 0, [FromQuery(Name = "to")] int to = 4, [FromQuery(Name = "year")] int year = 0, [FromQuery(Name = "month")] int month = 0, [FromQuery(Name = "day")] int day = 0)
       {


            var quantity = to - from;


            try
            {
                var Tickets = (from a in _context.Tickets
                               join b in _context.PaymentInfo on a.PaymentId equals b.PaymentId
                               join c in _context.CasherInfo on a.OperId equals c.OperId
                               where a.CreatedDate.Day == day
                               && a.CreatedDate.Month == month + 1
                               && a.CreatedDate.Year == year && a.Posted == true && a.InvoiceTypeId == 1
                               select new
                               {
                                   InvoiceId = a.InvoiceId,
                                   PaymentDes = b.PaymentDes,
                                   Total = a.Total,
                                   Dis = a.Dis,
                                   Date = a.Date,
                                   CreatedDate = a.CreatedDate,
                                   Time = a.Time,
                                   User = c.UserName,
                                    ParentId = a.ParentId,
                                   InvoiceTypeId = a.InvoiceTypeId
                               });
                var result = new
                {
                    Count = Tickets.Count(),
                    ErrorCode = 0,
                    Tickets = Tickets.ToList().Skip(from).Take(quantity).ToArray(),

                };
                return Ok(result);

            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }



        }

        [HttpGet("[action]")]
        public ActionResult GetReturnInvoices([FromQuery(Name = "from")] int from = 0, [FromQuery(Name = "to")] int to = 4, [FromQuery(Name = "year")] int year = 0, [FromQuery(Name = "month")] int month = 0, [FromQuery(Name = "day")] int day = 0)
        {


            var quantity = to - from;


            try
            {
                var Tickets = (from a in _context.Tickets
                               join b in _context.PaymentInfo on a.PaymentId equals b.PaymentId
                               join c in _context.CasherInfo on a.OperId equals c.OperId
                               where a.CreatedDate.Day == day
                               && a.CreatedDate.Month == month + 1
                               && a.CreatedDate.Year == year && a.Posted == true && a.InvoiceTypeId == 2
                               select new
                               {
                                   InvoiceId = a.InvoiceId,
                                   PaymentDes = b.PaymentDes,
                                   Total = a.Total,
                                   Dis = a.Dis,
                                   Date = a.Date,
                                   CreatedDate = a.CreatedDate,
                                   Time = a.Time,
                                   User = c.UserName,
                                   ParentId = a.ParentId,
                                   InvoiceTypeId = a.InvoiceTypeId
                               });
                var result = new
                {
                    Count = Tickets.Count(),
                    ErrorCode = 0,
                    Tickets = Tickets.ToList().Skip(from).Take(quantity).ToArray(),

                };
                return Ok(result);

            }
            catch (Exception ex)
            {
                return Json(new { ErrorCode = 2, Message = ex.Message.ToString() });
            }



        }

        [HttpGet("[action]")]
        public ActionResult GetSuspendedInvoice([FromQuery(Name = "from")] int from = 0, [FromQuery(Name = "to")] int to = 4, [FromQuery(Name = "year")] int year = 0, [FromQuery(Name = "month")] int month = 0, [FromQuery(Name = "day")] int day = 0)
        {


            var quantity = to - from;


            try
            {
                var Tickets = (from a in _context.Tickets
                               join b in _context.PaymentInfo on a.PaymentId equals b.PaymentId
                               join c in _context.CasherInfo on a.OperId equals c.OperId
                               where  a.Posted == false 
                               select new
                               {
                                   InvoiceId = a.InvoiceId,
                                   PaymentDes = b.PaymentDes,
                                   Total = a.Total,
                                   Dis = a.Dis,
                                   Date = a.Date,
                                   CreatedDate = a.CreatedDate,
                                   Time = a.Time,
                                   User = c.UserName,
                                   ParentId = a.ParentId,
                                   InvoiceTypeId = a.InvoiceTypeId
                               });
                var result = new
                {
                    Count = Tickets.Count(),
                    ErrorCode = 0,
                    Tickets = Tickets.ToList().Skip(from).Take(quantity).ToArray(),

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
