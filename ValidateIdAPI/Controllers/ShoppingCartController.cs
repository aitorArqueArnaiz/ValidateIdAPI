using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ValidateId.Domain.Entities;

namespace ValidateIdAPI.Controllers
{
    [ApiController]
    [Route("api/validateid")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ILogger<ShoppingCartController> _logger;

        public ShoppingCartController(ILogger<ShoppingCartController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<bool> AddItem([FromBody] ShoppingBasket shoppingBasket)
        {
            return Ok();
        }

        [HttpGet]
        public ActionResult<bool> LogShoppingBaskets ()
        {
            return Ok();
        }
    }
}
