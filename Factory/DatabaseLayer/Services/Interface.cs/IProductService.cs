using Factory.DatabaseLayer.Models;
using Factory.DatabaseLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.DatabaseLayer.Services.Interface.cs
{
    public interface IProductService
    {

        public IEnumerable<GetProductDto> GetAll();

        public GetProductDto GetById(int id);

        public void Add(InputProductDto AddProduct);

        public Product UpdateDetails(int id, InputProductDto UpdateProduct);

        public Product Delete(int id);

    }
}
