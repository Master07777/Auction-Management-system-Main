using Factory.DatabaseLayer.Context;
using Factory.DatabaseLayer.Dto;
using Factory.DatabaseLayer.Models;
using Factory.DatabaseLayer.Services.Interface.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.DatabaseLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly OnlineAuctionDbContext _DbContext;

        public ProductService(OnlineAuctionDbContext context)
        {
            _DbContext = context;
        }

        public IEnumerable<GetProductDto> GetAll()
        {
            var productsDomain = _DbContext.Products.ToList();
            var productsDtoList = new List<GetProductDto>();
            foreach (var product in productsDomain)
            {
                productsDtoList.Add(new GetProductDto()
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    SellerId = product.SellerId,
                    BasePrice = product.BasePrice,
                    ExpectedPrice = product.ExpectedPrice
                });
            }

            return productsDtoList;
        }

        public GetProductDto GetById(int id)
        {
            var product = _DbContext.Products.FirstOrDefault(x => x.ProductId == id);
            if (product == null)
            {
                return null;
            }
            var productDto = new GetProductDto()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                CategoryId = product.CategoryId,
                SellerId = product.SellerId,
                BasePrice = product.BasePrice,
                ExpectedPrice = product.ExpectedPrice
            };
            return productDto;
        }

        public void Add(InputProductDto AddProduct)
        {
            var productDomain = new Product()
            {

                Name = AddProduct.Name,
                CategoryId = AddProduct.CategoryId,
                SellerId = AddProduct.SellerId,
                BasePrice = AddProduct.BasePrice,
                ExpectedPrice = AddProduct.ExpectedPrice
            };
            _DbContext.Products.Add(productDomain);
            _DbContext.SaveChanges();
        }

        public Product UpdateDetails(int id, InputProductDto UpdateProduct)
        {
            var productDomainModel = _DbContext.Products.FirstOrDefault(x => x.ProductId == id);
            if (productDomainModel == null)
            {
                return null;
            }
            productDomainModel.Name = UpdateProduct.Name;
            productDomainModel.CategoryId = UpdateProduct.CategoryId;
            productDomainModel.SellerId = UpdateProduct.SellerId;
            productDomainModel.BasePrice = UpdateProduct.BasePrice;
            productDomainModel.ExpectedPrice = UpdateProduct.ExpectedPrice;

            _DbContext.SaveChanges();

            /* var productDto = new GetProductDto()
             {

                 Name = productDomainModel.Name,
                 CategoryId = productDomainModel.CategoryId,
                 SellerId = productDomainModel.SellerId,
                 BasePrice = productDomainModel.BasePrice,
                 ExpectedPrice = productDomainModel.ExpectedPrice
             };*/
            return productDomainModel;
        }

        public Product Delete(int id)
        {
            var product = _DbContext.Products.FirstOrDefault(x => x.ProductId == id);
            if (product == null)
            {
                return null;
            }
            _DbContext.Products.Remove(product);
            _DbContext.SaveChanges();
            return product;


        }

    }
}
