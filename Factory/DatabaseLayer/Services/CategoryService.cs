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
    public class CategoryService : ICategoryService
    {
        private readonly OnlineAuctionDbContext _DbContext;
        public CategoryService(OnlineAuctionDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public IEnumerable<GetCategoryDto> GetAll()
        {
            var CategoryDomainList = _DbContext.Categories.ToList();
            var CategoryDtoList = new List<GetCategoryDto>();
            foreach (var category in CategoryDomainList)
            {
                CategoryDtoList.Add(new GetCategoryDto()
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName
                });
            }
            return CategoryDtoList;
        }

        public GetCategoryDto GetById(int id)
        {
            var categoryDomainModel = _DbContext.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (categoryDomainModel == null)
            {
                return null;
            }
            var categoryDto = new GetCategoryDto()
            {
                CategoryId = categoryDomainModel.CategoryId,
                CategoryName = categoryDomainModel.CategoryName
            };
            return categoryDto;
        }

        public void Add(InputCategoryDto AddCategory)
        {
            var categoryDomainModel = new Category()
            {
                 CategoryId = AddCategory.CategoryId,
                CategoryName = AddCategory.CategoryName
            };
            _DbContext.Categories.Add(categoryDomainModel);
            _DbContext.SaveChanges();
        }

        public Category UpdateDetails(int id, InputCategoryDto UpdateCategory)
        {
            var categoryDomainModel = _DbContext.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (categoryDomainModel == null)
            {
                return null;
            }

            categoryDomainModel.CategoryId = UpdateCategory.CategoryId;
            categoryDomainModel.CategoryName = UpdateCategory.CategoryName;
            _DbContext.SaveChanges();

            return categoryDomainModel;
        }

        public Category Delete(int id)
        {
            var categoryDomainModel = _DbContext.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (categoryDomainModel == null)
            {
                return null;
            }
            _DbContext.Categories.Remove(categoryDomainModel);
            _DbContext.SaveChanges();
            return categoryDomainModel;
        }
    }
}
