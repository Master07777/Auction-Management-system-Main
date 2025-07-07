using Factory.DatabaseLayer.Models;
using Factory.DatabaseLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.DatabaseLayer.Services.Interface.cs
{
    public interface ICategoryService
    {
        public IEnumerable<GetCategoryDto> GetAll();
        public GetCategoryDto GetById(int id);
        public void Add(InputCategoryDto AddCategory);
        public Category UpdateDetails(int id, InputCategoryDto UpdateCategory);
        public Category Delete(int id);
    }
}
