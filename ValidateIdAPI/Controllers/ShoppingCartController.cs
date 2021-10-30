using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValidateId.Bussines.Interfaces.Basket;
using ValidateId.Bussines.Services.Basket;
using ValidateId.Domain.Entities;

namespace ValidateIdAPI.Controllers
{
    [ApiController]
    [Route("api/validateid")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ILogger<ShoppingCartController> _logger;
        private readonly IBasket _basketService;

        public ShoppingCartController(ILogger<ShoppingCartController> logger, 
            IBasket basketService)
        {
            _logger = logger;
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
        }

        [HttpPost]
        public ActionResult<ShoppingBasket> AddItem([FromBody] ShoppingBasket shoppingBasket)
        {
            ShoppingBasket shoppingBasketAddedToUser;
            try
            {
                shoppingBasketAddedToUser = _basketService.AddShoppingBasketToUser(shoppingBasket);
            }
            catch(Exception error)
            {
                _logger.LogError($"Error ocurred during add basket to user operation {error.Message}");
                throw new Exception(error.Message);
            }
            return Ok(shoppingBasketAddedToUser);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<ShoppingBasket> baskets = new() { };
            try
            {
                baskets = _basketService.GetAllShoppingBaskets();
            }
            catch(Exception error)
            {
                _logger.LogError($"Error ocurred during get all baskets operation {error.Message}");
                throw new Exception(error.Message);
            }
            return Ok(baskets);
        }
    }
}
