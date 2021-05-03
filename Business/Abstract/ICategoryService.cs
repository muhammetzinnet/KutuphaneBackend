using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(int categoryId);
        IDataResult<List<Category>> GetByKind();

        IResult Add(Category category);
        IResult Delete(Category category);
        IResult Update(Category category);
    }
}
