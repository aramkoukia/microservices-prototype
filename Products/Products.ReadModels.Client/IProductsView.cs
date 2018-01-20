using System;
using System.Collections.Generic;
using Products.Common.Dto;

namespace Products.ReadModels.Client
{
    public interface IProductsView
    {
        ProductDto GetById(Guid id);
        IEnumerable<ProductDto> GetProducts();
        void Initialise();
        void Reset();
        void UpdateLocalCache(ProductDto newValue);
    }
}