using Products.Common.Dto;
using Products.ReadModels.Client;
using Sales.Service.MicroServices.Product.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sales.Service.Tests
{
    public class Products
    {
        readonly IProductsView ProductsProductView;
        readonly ProductView productView;

        public Products()
        {
            ProductsProductView = new FakeProductsProductView();
            productView = new ProductView(ProductsProductView);
        }

        [Fact]
        public void Should_retrieve_a_list_of_all_products_via_Products_client_when_view_is_created()
        {
            Assert.Equal(2, productView.GetAll().Count());
        }

        [Fact]
        public void Should_retrieve_product_when_given_a_known_product_id()
        {
            var id = productView.GetAll().First().Id;
            var p = productView.GetById(id);
            Assert.Equal(id, p.Id);
        }
    }

    public class FakeProductsProductView : IProductsView
    {
        private readonly List<ProductDto> products = new List<ProductDto>();

        public FakeProductsProductView()
        {
            products.Add(new ProductDto
            {
                Id = Guid.NewGuid(),
                Name = "FW",
                DisplayName = "Flat White",
                Description = "Great Coffee",
                Price = 3.60m,
                Version = 1,
            });
            products.Add(new ProductDto
            {
                Id = Guid.NewGuid(),
                Name = "BB",
                DisplayName = "Banana Bread",
                Description = "Delicious, slightly toasted goodness",
                Price = 4.70m,
                Version = 1,
            });
        }

        public ProductDto GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            return products.AsEnumerable();
        }

        public void Initialise()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void UpdateLocalCache(ProductDto newValue)
        {
            throw new NotImplementedException();
        }
    }
}
