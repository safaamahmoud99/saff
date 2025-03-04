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
    public class SuppliersController : ControllerBase
    {
        private readonly SupplierAppService _supplierAppService;

        public SuppliersController(SupplierAppService supplierAppService)
        {
            _supplierAppService = supplierAppService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<SupplierViewModel>> Getsuppliers()
        {
            return _supplierAppService.GetAllSuppliers();
           
        }
        [HttpGet("{id}")]
        public ActionResult<SupplierViewModel> GetSuppliers(int id)
        {
            var suppliers = _supplierAppService.GetSupplier(id);  

            if (suppliers == null)
            {
                return NotFound();
            }

            return suppliers;
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult PutSuppliers(int id, SupplierViewModel supplierViewModel)
        {         
            try
            {
                _supplierAppService.UpdateSupplier(supplierViewModel);
                return Ok(supplierViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }
        [HttpPost]
        public ActionResult<SupplierViewModel> PostSuppliers(SupplierViewModel supplierViewModel)
        {
            _supplierAppService.CreateSupplier(supplierViewModel);
            return CreatedAtAction("GetSuppliers", supplierViewModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteSuppliers(int id)
        {
            var suppliers = _supplierAppService.DeleteSupplier(id);
            return NoContent();
        }

        private bool SuppliersExists(int id)
        {
            return _supplierAppService.CheckSupplierExists(id); 
        }
        [HttpGet("count")]
        public IActionResult SuppliersCount()
        {
            return Ok(_supplierAppService.CountEntity());
        }
        [HttpGet("{pageSize}/{pageNumber}")]
        public IActionResult GetSupplierByPage(int pageSize, int pageNumber)
        {
            return Ok(_supplierAppService.GetPageRecords(pageSize, pageNumber));
        }
    }
}
