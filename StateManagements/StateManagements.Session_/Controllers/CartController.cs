using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using StateManagements.Session_.SessionService;

namespace StateManagements.Session_.Controllers;
public class CartController : Controller
{
    private readonly StateManagementsContext _context;
    private const string CART_KEY = "_cart";
    public CartController(StateManagementsContext context)
    {
        this._context = context;


        //_context.Categories.Add(new Category()
        //{
        //    Name = "Beverages",
        //    Description = "Test",
        //    Products = new List<Product>
        //    {
        //        new Product{ Name = "Black Gray Hooded Jacket", UnitPrice = 0, UnitsInStock = 0  },
        //        new Product{ Name = "Dark Olive Padded Jacket", UnitPrice = 0, UnitsInStock = 0  },
        //        new Product{ Name = "Black Bomber Jacket", UnitPrice = 0, UnitsInStock = 0  },
        //        new Product{ Name = "Full Sleeve Balloon Jacket", UnitPrice = 0, UnitsInStock = 0  },
        //        new Product{ Name = "Double Collar Jacket", UnitPrice = 0, UnitsInStock = 0  }
        //    }
        //});
        //_context.SaveChanges();

    }

    [HttpPost]
    public async Task<IActionResult> Add(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
            return BadRequest();

        var carts = HttpContext.Session.Get<List<Cart>>(CART_KEY) ?? new List<Cart>();

        var existingCart = carts.FirstOrDefault(x => x.Id == id);
        if (existingCart == null)
        {
            var cart = new Cart
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.UnitPrice
            };
            carts.Add(cart);
        }
        else
            existingCart.Count++;

        HttpContext.Session.Set<List<Cart>>(CART_KEY, carts);

        return Json(data: carts);
    }

    [HttpPost]
    public IActionResult Remove(int id)
    {
        var carts = HttpContext.Session.Get<List<Cart>>(CART_KEY) ?? new List<Cart>();
        var existingCart = carts.FirstOrDefault(c => c.Id == id);
        if(existingCart is not null)
        {
            carts.Remove(existingCart);
            existingCart.Count--;
        }

        HttpContext.Session.Set<List<Cart>>(CART_KEY, carts);
        return Json(data: carts);
    }

    public IActionResult Index()
    {
        return Json(new { Name = "Dilqo" });
    }
}

