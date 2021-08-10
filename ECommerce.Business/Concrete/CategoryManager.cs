using ECommerce.Business.Abstract;
using ECommerce.Business.Constants.Messages;
using ECommerce.Business.ValidationRules.FluentValidation;
using ECommerce.Core;
using ECommerce.Core.Aspects.Autofac.ValidationAspect;
using ECommerce.Core.Success;
using ECommerce.Data.Abstract;
using ECommerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ECommerce.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal =  categoryDal;
        }

        [ValidationAspect(typeof(CategoryValidator),Priority =1)]
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(CategoryMessage.CategoryAddedSuccessfully);
        }

        [ValidationAspect(typeof(CategoryValidator), Priority = 1)]
        public IResult Update(Category category)
        {
            Expression<Func<Category, bool>> updateFilterExpression = x => x.Id == category.Id;
            _categoryDal.Update(category, updateFilterExpression);
            return new SuccessResult(CategoryMessage.CategoryUpdatedSuccessfully);
        }
        public IResult Delete(Category category)
        {
            Expression<Func<Category, bool>> deleteFilterExpression = x => x.Id == category.Id;
            _categoryDal.Delete(category, deleteFilterExpression);
            return new SuccessResult(CategoryMessage.CategoryDeletedSuccessfully);
        }
        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }
        public IDataResult<Category> GetById(string categoryId)
        {
            Expression<Func<Category, bool>> getfilterExpression = x => x.Id == categoryId;
            return new SuccessDataResult<Category>(_categoryDal.Get(getfilterExpression));
        }
    }
}
