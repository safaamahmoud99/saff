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
    [Authorize]
    public class WishListProductsController : ControllerBase
    {
        private readonly WishListProductAppService _wishListProductAppService;

        public WishListProductsController(WishListProductAppService wishListProductAppService)
        {
            _wishListProductAppService= wishListProductAppService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<WishListProductViewModel>> GetwishListProducts(string wishlistId)
        {
            return _wishListProductAppService.GetAllWishListProducts(wishlistId);
        }
        [HttpGet("{id}")]
        public ActionResult<WishListProductViewModel> GetWishListProduct(int id)
        {

            var wishListProduct =_wishListProductAppService.GetWishListProduct(id);
            return wishListProduct;
        }

         [HttpPost]
        public async Task<ActionResult<WishListProductViewModel>> PostWishListProductAsync(int id)
        {
            string username = User.Identity.Name;
            bool found = _wishListProductAppService.CheckWishListProductExists(id);
            try
            {
                if(found==false)
                {
                   await _wishListProductAppService.CreateWishListProduct(username, id);

                    return Ok();
                }
                return Ok("Product Found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteWishListProduct(int id)
        {
            _wishListProductAppService.DeletWishListProduct(id);

            return NoContent();
        }
       private bool WishListProductExists(int id)
        {
            return _wishListProductAppService.CheckWishListProductExists(id);
        }
    }
}
