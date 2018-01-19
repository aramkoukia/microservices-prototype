using MicroServices.Common;
using System;

namespace PullRequest.Common.Dto
{
    public class OrderDto : ReadObject
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public bool IsPaidFor { get; set; }
        public int Version { get; set; }
    }
}