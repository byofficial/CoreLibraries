﻿using Microsoft.AspNetCore.Mvc;

namespace RateLimit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(new { Id = 1, Name = "Kalem", Price = 20 });
        }

        [HttpGet("{name}")]
        public IActionResult GetProduct(string name)
        {
            return Ok(name);
        }

        [HttpPut]
        public IActionResult IpdateProduct()
        {
            return Ok();
        }
    }
}