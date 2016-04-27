using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nalarium.Test
{
    public class Order
    {
        [Display(Name = "Order.OrderId", Description = "Order Order Id")]
        public string OrderId { get; set; }

        [Display(Name = "Order.LookupCode", Description = "Order Order Lookup Code")]
        public string LookupCode { get; set; }

        [Display(Name = "Order.ExpectedDate", Description = "Expected Date", Order = 1)]
        [DisplayFormat(DataFormatString = "M/D/yyyy")]
        public DateTime ExpectedDate { get; set; }

        [Display(Name = "Order.StatusName", Description = "Status")]
        public string StatusName { get; set; }

        [Display(Name = "Order.StatusId", Description = "Status Id")]
        public string StatusId { get; set; }
    }

    [TestClass]
    public class PropertyReader
    {
        [TestMethod]
        public void GetPropertyList()
        {
            //var expected = new List<string>
            //{
            //    "OrderId",
            //    "LookupCode",
            //    "ExpectedDate",
            //    "StatusName",
            //    "StatusId"
            //};

            var result = Nalarium.Reflection.PropertyReader.GetPropertyList(typeof(Order)).Select(p => p.Name);

            Assert.AreEqual(5, result.Count());
        }
    }
}
