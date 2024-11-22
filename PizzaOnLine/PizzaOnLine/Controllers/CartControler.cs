using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaOnLine.Models;
using System.Web.Mvc;

namespace PizzaOnLine.Controllers
{
    public class CartController : Controller
    {
        PizzaContext db = new PizzaContext();

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            Pizza pizza = db.Pizzas.FirstOrDefault(p => p.PizzaId == productId);
            if (pizza != null)
            {
                GetCart().AddItem(pizza, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            Pizza pizza = db.Pizzas.FirstOrDefault(p => p.PizzaId == productId);
            if (pizza != null)
            {
                GetCart().RemoveLine(pizza);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}
