﻿using BL.Bases;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repository
{
    public class CartRepository : BaseRepository<Cart>
    {
        private DbContext EC_DbContext;
        public CartRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        public List<Cart> GetAllCart()
        {
            return GetAll().ToList();
        }

        public bool InsertCart(Cart cart)
        {
            return Insert(cart);
        }
        public void UpdateCart(Cart cart)
        {
            Update(cart);
        }
        public void DeleteCart(int id)
        {
            Delete(id);
        }
        public bool CheckCartExists(Cart cart)
        {
            return GetAny(l => l.UserID == cart.UserID);
        }
        public Cart GetCartById(string id)
        {
            return GetWhere(l => l.UserID == id).AsNoTracking()
                .Include(s => s.cartProducts)
                .FirstOrDefault();
        }
        public Cart GetOCartById(string id)
        {
            return GetFirstOrDefault(l => l.UserID == id);
        }
    }
}
