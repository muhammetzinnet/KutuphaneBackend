using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [SecuredOperation("category.add, admin")]
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(Category category)
        {
            IResult result = BusinessRules.Run(CheckIfCategoryNameExists(category.CategoryName));
            if (result != null)
            {
                return result;
            }
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        private IResult CheckIfCategoryNameExists(object categoryName)
        {
            var result = _categoryDal.GetAll(c => c.CategoryName == categoryName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CategoryNameAlreadyExists);
            }

            return new SuccessResult(Messages.CategoryNameListed);
        }

        [SecuredOperation("category.delete, admin")]
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Delete(Category category)
        {
            IResult result = BusinessRules.Run(CheckIfCategoryNameExists(category.CategoryName));
            if (result != null)
            {
                return result;
            }
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.CategoryListed);
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == categoryId));
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IDataResult<List<Category>> GetByKind()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        [SecuredOperation("category.update, admin")]
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Update(Category category)
        {
            IResult result = BusinessRules.Run(CheckIfCategoryNameExists(category.CategoryName));
            if (result != null)
            {
                return result;
            }
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
        
    }
}
