﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using ValidateId.Bussines.Interfaces.Basket;
using ValidateId.Domain.DTOs.Basket;

namespace ValidateIdAPI.Controllers
{
    [ApiController]
    [Route("api/validateid")]
    public class ShoppingCartController : ControllerBase
    {
        #region Class variables

        private readonly ILogger<ShoppingCartController> _logger;
        private readonly IBasketService _basketService;

        #endregion

        #region Class constrctors

        public ShoppingCartController(ILogger<ShoppingCartController> logger,
                                      IBasketService basketService)
        {
            _logger = logger;
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
        }

        #endregion

        #region Controller endpoints

        [HttpPost]
        public ActionResult<AdduserBasketResponse> AddItem([FromBody] AddUserBasketRequest shoppingBasket)
        {
            AdduserBasketResponse shoppingBasketAddedToUser;
            try
            {
                var userId = new Random();
                shoppingBasket.User.Id = userId.Next(1, 999);
                shoppingBasketAddedToUser = _basketService.AddShoppingBasketToUser(shoppingBasket);
            }
            catch (Exception error)
            {
                _logger.LogError($"Error ocurred during add basket to user operation {error.Message}");
                throw new Exception(error.Message);
            }
            return Ok(shoppingBasketAddedToUser);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            /* Example of log
             * [BASKET CREATED]: Created[<"01-03-2021">], UserID
               [ITEM ADDED TO SHOPPING CART]: Added[<"01-03-2021">], UserID, ProductID, Quantity[, Price[<€12.00>]
             */
            GetAllProductsResponse baskets = new();
            try
            {
                baskets = _basketService.GetAllShoppingBaskets();
                foreach (var product in baskets.Poducts)
                {
                    _logger.LogTrace($"[BASKET CREATED]: Created[<{product.CreationDate}>], {product.User.Id}");
                    _logger.LogTrace($"[ITEM ADDED TO SHOPPING CART]: Added[<{product.CreationDate}>], {product.User.Id}, {product.Id}, {product.Quantity}, [, Price[<{product}>]");
                }
            }
            catch (Exception error)
            {
                _logger.LogError($"Error ocurred during get all baskets operation {error.Message}");
                throw new Exception(error.Message);
            }
            return Ok(baskets);
        }

        #endregion
    }
}
