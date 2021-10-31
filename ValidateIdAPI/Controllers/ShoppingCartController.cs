using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
                    Units = shoppingBasket.Products
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
            /* Example of log
             * [BASKET CREATED]: Created[<"01-03-2021">], UserID
               [ITEM ADDED TO SHOPPING CART]: Added[<"01-03-2021">], UserID, ProductID, Quantity[, Price[<€12.00>]
             */
            GetAllProductsResponse baskets = new();
            try
            {
                baskets = _basketService.GetAllShoppingBaskets();
                foreach(var product in baskets.Poducts)
                {
                }
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
