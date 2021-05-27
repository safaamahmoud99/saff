﻿using AutoMapper;
using BL.Bases;
using BL.DTOs;
using BL.interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppService
{
   public  class WishListProductAppService : BaseAppService
    {

        public WishListProductAppService(IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
       
        public List<WishListProductViewModel> GetAllWishListProducts()
        {
            return Mapper.Map<List<WishListProductViewModel>>(TheUnitOfWork.WishListProduct.GetAll());
        }
        public WishListProductViewModel GetWishListProduct(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            return Mapper.Map<WishListProductViewModel>(TheUnitOfWork.WishListProduct.GetWishListProductById(id));
        }
        public bool CreateWishListProduct(int id)
        {
            bool result = false;
            WishListProduct WishListProduct = new WishListProduct() { ID = id };
            if (TheUnitOfWork.WishListProduct.InsertWishListProduct(WishListProduct))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool DeletWishListProduct(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            bool result = false;
            TheUnitOfWork.WishListProduct.DeleteWishListProduct(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
    }
}
