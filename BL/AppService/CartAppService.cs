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
    public class CartAppService:BaseAppService
    {

        public CartAppService(IUnitOfWork theUnitOfWork) : base(theUnitOfWork)
        {

        }
        public List<CartViewModel> GetAllCarts()
        {
            return Mapper.Map<List<CartViewModel>>(TheUnitOfWork.Cart.GetAllCart());
        }
        public CartViewModel GetCart(string cartid)
        {
            
            return Mapper.Map<CartViewModel>(TheUnitOfWork.Cart.GetCartById(cartid));
        }
        
        public Cart GetCartByUser(String id)
        {
            if (id == null)
                throw new ArgumentNullException();
            return TheUnitOfWork.Cart.GetCartById(id);
        }
        public bool CreateUserCart(string userId)
        {
            bool result = false;
            Cart userCart = new Cart() { UserID = userId };
            if (TheUnitOfWork.Cart.Insert(userCart))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool DeleteCart(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            bool result = false;
            TheUnitOfWork.Cart.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
        public bool DeleteCartByUser(string id)
        {
            if (id == null)
                throw new ArgumentNullException();
            bool result = false;

            TheUnitOfWork.Cart.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

    }
}
