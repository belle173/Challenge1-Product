using System.Collections.Generic;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;


namespace newapi
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderHandler _OrderHandler = new OrderHandler();

        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("/order")]
        public IEnumerable < Order > order()
        {
            return _OrderHandler.GetOrder();
        }
        
    }
}