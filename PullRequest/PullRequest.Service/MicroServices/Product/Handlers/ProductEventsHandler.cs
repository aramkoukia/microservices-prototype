using MicroServices.Common;
using Sales.Service.MicroServices.Product.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Service.MicroServices.Product.Handlers
{
    public class ProductEventsHandler : Aggregate,
        IHandle<ProductCreated>,
        IHandle<ProductPriceChanged>
    {
        public void Apply(ProductCreated @event)
        {
            var view = ServiceLocator.ProductView;
            view.Add(@event.Id, @event.Price);
        }

        public void Apply(ProductPriceChanged @event)
        {
            var view = ServiceLocator.ProductView;
            var product = view.GetById(@event.Id);
            product.Price = @event.NewPrice;
        }
    }
}
