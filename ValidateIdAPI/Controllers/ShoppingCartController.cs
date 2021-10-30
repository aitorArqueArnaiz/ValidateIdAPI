using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValidateId.Bussines.Interfaces.Basket;
using ValidateId.Domain.DTOs.Basket;
using ValidateId.Domain.Entities;

namespace ValidateIdAPI.Controllers
{
    [ApiController]
    [Route("api/validateid")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ILogger<ShoppingCartController> _logger;
        private readonly IBasketService _basketService;

        public ShoppingCartController(ILogger<ShoppingCartController> logger, 
            IBasketService basketService)
        {
            _logger = logger;
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
        }

        [HttpPost]
        public ActionResult<AdduserBasketResponse> AddItem([FromBody] ShoppingBasket shoppingBasket)
        {
            AdduserBasketResponse shoppingBasketAddedToUser;
            try
            {
                AddUserBasketRequest addShoppingBasketRequest = new AddUserBasketRequest()
                {
                    CreationDate = shoppingBasket.Basket.CreationDate,
                    Units = shoppingBasket.Basket.Units,
                    Total = shoppingBasket.Basket.Total
                };
                shoppingBasketAddedToUser = _basketService.AddShoppingBasketToUser(addShoppingBasketRequest);
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
