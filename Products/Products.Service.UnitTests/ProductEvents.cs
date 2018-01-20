using MicroServices.Common;
using Products.Common.Events;
using Products.Service.MicroServices.Products.Domain;
using System;
using System.Linq;
using Xunit;

namespace Products.Service.UnitTests
{
    public class ProductEvents
    {
        [Fact]
        public void Should_generate_productcreated_event_when_creating_a_new_product()
        {
            var p = new Product(Guid.NewGuid(), "name", "description", 1.2m);
            var events = p.GetUncommittedEvents();

            Assert.NotEmpty(events);
            Assert.Equal(1, events.Count());
            Assert.IsType<ProductCreated>(events.First());
        }

        [Fact]
        public void Should_change_name_when_a_namechanged_event_is_applied()
        {
            var p = new Product(Guid.NewGuid(), "name", "description", 1.2m);
            var e = new ProductNameChanged(p.Id, "new Name");
            p.AsDynamic().Apply(e);

            Assert.Equal("new Name", p.Name);
        }

    }
}
