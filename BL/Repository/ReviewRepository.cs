﻿using BL.Bases;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repository
{
    public class ReviewRepository :BaseRepository<Review>
    {
        private ApplicationDbContext EC_DbContext;
        public ReviewRepository(ApplicationDbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        public IEnumerable<Review> GetAllReview(int productid)
        {
            return EC_DbContext.reviews.Where(r=>r.ProductID== productid);
        }

        public bool InsertReview(Review Review)
        {
            return Insert(Review);
        }
        public void UpdateReview(Review Review)
        {
            Update(Review);
        }
        public void DeleteReview(int id)
        {
            Delete(id);
        }
        public bool CheckReviewExists(Review Review)
        {
            return GetAny(b => b.ID == Review.ID);
        }
        public Review GetReviewById(int id)
        {
            return GetFirstOrDefault(b => b.ID == id);
        }
    }
}
