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
    public class ProductManager : IProductService
    {        
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator), Priority = 1)]
        public IResult Add(Product product)
        {            
            _productDal.Add(product);
            return new SuccessResult(ProductMessage.ProductAddedSuccessfully);
        }

        [ValidationAspect(typeof(ProductValidator), Priority = 1)]
        public IResult Update(Product product)
        {
            Expression<Func<Product, bool>> updateFilterExpression = x => x.Id == product.Id;
            _productDal.Update(product, updateFilterExpression);
            return new SuccessResult(ProductMessage.ProductUpdatedSuccessfully);
        }

        public IResult Delete(Product product)
        {
            Expression<Func<Product, bool>> deleteFilterExpression = x => x.Id == product.Id;
            _productDal.Delete(product, deleteFilterExpression);
            return new SuccessResult(ProductMessage.ProductDeletedSuccessfully);
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }

        public IDataResult<Product> GetById(string productId)
        {
            Expression<Func<Product, bool>> getfilterExpression = x => x.Id == productId;
            return new SuccessDataResult<Product>(_productDal.Get(getfilterExpression));
        }
    }
}
