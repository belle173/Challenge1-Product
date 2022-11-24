using System.Collections.Generic;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using System;

namespace newapi
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

         private ProductHandler _ProductHandler = new ProductHandler();
        
        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("/product")]
        public IEnumerable <Product> Test()
        {
            return _ProductHandler.GetProduct();
        }
       
        
        
    }
}