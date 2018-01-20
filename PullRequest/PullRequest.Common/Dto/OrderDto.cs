using MicroServices.Common;
using System;

namespace Sales.Common.Dto
{
    public class OrderDto : ReadObject
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public bool IsPaidFor { get; set; }
        public int Version { get; set; }
    }
}