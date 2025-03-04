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
    public class OrderDetailsAppservice : BaseAppService
    {
        public OrderDetailsAppservice(IUnitOfWork theUnitOfWork) : base(theUnitOfWork)
        {

        }
      

        public List<OrderDetails> GetAllOrderDetailsbyOrderID()
        {

            return Mapper.Map<List<OrderDetails>>(TheUnitOfWork.Orderdetails.GetAll());
        }
        


        public bool SaveNewOrderDetail(OrderDetailsViewModel orderProductViewModel)
        {

            bool result = false;
            var orderProduct = Mapper.Map<OrderDetails>(orderProductViewModel);
            if (TheUnitOfWork.Orderdetails.Insert(orderProduct))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }

        public OrderDetailsViewModel GetOrderDetailsbyID(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            return Mapper.Map<OrderDetailsViewModel>(TheUnitOfWork.Orderdetails.GetById(id));
        }
        public bool UpdateOrderDetails(OrderDetailsViewModel orderDetailViewModel)
        {
            if (orderDetailViewModel == null)
                throw new ArgumentNullException();
        
            var orderDetails = Mapper.Map<OrderDetails>(orderDetailViewModel);
            TheUnitOfWork.Orderdetails.Update(orderDetails);
            TheUnitOfWork.Commit();

            return true;
        }

        public bool DeleteOrderDetails(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            bool result = false;
            TheUnitOfWork.Offer.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }



    }
}
