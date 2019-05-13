using CSDNTest.Models;
using CSDNTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSDNTest.Controllers
{
    public class XXTestController : Controller
    {
        OrderService orderServcie = new OrderService();
        // GET: XXTest
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateOrderInfo(OrderInformation state)
        {
            var data = orderServcie.UpdateOrderInfos(state);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}