﻿using AutoMapper;
using BL.Bases;
using BL.DTOs;
using BL.Hubs;
using BL.interfaces;
using DAL.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppService
{
   public  class ReviewAppService : BaseAppService
    {
        private IHubContext<ReviewHub, ITypedClientReview> _hubContext;
        public ReviewAppService(IUnitOfWork theUnitOfWork, IHubContext<ReviewHub, ITypedClientReview> hubContext) : base(theUnitOfWork)
        {
            this._hubContext = hubContext;
        }
        public List<ReviewViewModel> GetAllReviews(int productid)
        {
            return Mapper.Map<List<ReviewViewModel>>(TheUnitOfWork.Review.GetAllReview(productid));
        }
        public ReviewViewModel GetReview(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            return Mapper.Map<ReviewViewModel>(TheUnitOfWork.Review.GetReviewById(id));
        }
        public void UpdateReview(int id, ReviewViewModel newreview)
        {
            var review = TheUnitOfWork.Review.GetReviewById(id);

            review.Comment = newreview.Comment;
            review.Rating = newreview.Rating;

            TheUnitOfWork.Review.UpdateReview(review);
            TheUnitOfWork.Commit();

        }
        public bool CreateReview(ReviewViewModel reviewViewModel)
        {
            bool result=false;
            Review review = Mapper.Map<Review>(reviewViewModel);
            if (TheUnitOfWork.Review.InsertReview(review))
            {
                result = TheUnitOfWork.Commit() > new int();
                _hubContext.Clients.All.BroadcastMessage(reviewViewModel).Wait();
            }
            return result;
        }
        public bool DeletReview(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            bool result = false;
            TheUnitOfWork.Review.DeleteReview(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
        public int CountEntity()
        {
            return TheUnitOfWork.Review.CountEntity();
        }
        public IEnumerable<ReviewViewModel> GetPageRecords(int pageSize, int pageNumber)
        {
            return Mapper.Map<List<ReviewViewModel>>(TheUnitOfWork.Review.GetPageRecords(pageSize, pageNumber));
        }
    }
}
