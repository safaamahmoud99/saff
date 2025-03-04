﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Models;
using BL.AppService;
using BL.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace WEP_APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ReviewAppService _reviewAppService;

        public ReviewsController(ReviewAppService reviewAppService)
        {
            _reviewAppService = reviewAppService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ReviewViewModel>> Getreviews(int productid)
        {
            return _reviewAppService.GetAllReviews(productid);
        }
        [HttpGet("{id}")]
        public ActionResult<ReviewViewModel> GetReview(int id)
        {
            var review = _reviewAppService.GetReview(id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }
        [Authorize]
        [HttpPut("{id}")]
        public  IActionResult PutReview(int id , ReviewViewModel newreview)
        {
            _reviewAppService.UpdateReview(id, newreview);
            return Ok();
        }
        [Authorize]
        [HttpPost]
        public ActionResult<ReviewViewModel> PostReview(ReviewViewModel review)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try 
                {
                    _reviewAppService.CreateReview(review);
                    return CreatedAtAction("GetReview", review);

                }
               catch(Exception ex)
                {
                    return BadRequest(ex.Message);

                }
            }
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteReview(int id)
        {
           _reviewAppService.DeletReview(id);
            return NoContent();
        }
        [HttpGet("count")]
        public IActionResult ReviewCount()
        {
            return Ok(_reviewAppService.CountEntity());
        }
        [HttpGet("{pageSize}/{pageNumber}")]
        public IActionResult GetReviewByPage(int pageSize, int pageNumber)
        {
            return Ok(_reviewAppService.GetPageRecords(pageSize, pageNumber));
        }

    }
}
