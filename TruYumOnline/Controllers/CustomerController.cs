using System;

using System.Collections.Generic;

using System.Net.Http;

using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

using TruYumOnline.Models;



namespace TruYumOnline.Controllers

{

    public class CustomerController : Controller

    {

        // GET: Customer 

        public ActionResult GetActiveMenuItems()

        {

            IEnumerable<MenuItem> menuitems;

            HttpResponseMessage httpResponse = GlobalVariables.webApiClient.GetAsync("Carts/CustomerMenuItems").Result;

            menuitems = httpResponse.Content.ReadAsAsync<IEnumerable<MenuItem>>().Result;

            return View(menuitems);

        }



        // Get: Customer/AddtoCart 

        [HttpGet("{id}")]

        public ActionResult AddtoCart(int id)

        {

            try

            {

                HttpResponseMessage httpResponse = GlobalVariables.webApiClient.PostAsJsonAsync("Carts", new Cart() { CtUsId = 1001, CtPrId = id }).Result;

                TempData["SuccessMessage"] = "Added to cart Successfully";

                return RedirectToAction(nameof(GetActiveMenuItems));

            }

            catch

            {

                return View();

            }

        }



        [HttpGet]

        public ActionResult<IEnumerable<Cart>> ShowCart()

        {

            try

            {

                HttpResponseMessage httpResponse = GlobalVariables.webApiClient.GetAsync("Carts/" + 1001.ToString()).Result;

                var cartitems = httpResponse.Content.ReadAsAsync<IEnumerable<Cart>>().Result;

                decimal total = 0;

                foreach (var x in cartitems)

                {

                    total += x.CtPr.MePrice;

                }

                ViewBag.Total = total;

                return View(cartitems);

            }

            catch

            {

                return View();

            }

        }



        // GET: Customer/Delete/5 

        [Route("DeleteItem")]

        [HttpPost("{id}")]

        public ActionResult DeleteItem(int id, Cart c)

        {

            try

            {

                HttpResponseMessage httpResponse = GlobalVariables.webApiClient.DeleteAsync("Carts/" + id.ToString()).Result;

                TempData["SuccessMessage"] = "Deleted Successfully";

                return RedirectToAction(nameof(ShowCart));

            }

            catch

            {

                return View();

            }

        }



        // GET: Customer/Details/5 

        public ActionResult Details(int id)

        {

            return View();

        }



        //// GET: Customer/Create 

        //public ActionResult AddtoCart() 

        //{ 

        //    return View(new ); 

        //} 



        // GET: Customer/Edit/5 

        public ActionResult Edit(int id)

        {

            return View();

        }



        // POST: Customer/Edit/5 

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Edit(int id, IFormCollection collection)

        {

            try

            {

                // TODO: Add update logic here 



                return RedirectToAction(nameof(Index));

            }

            catch

            {

                return View();

            }

        }

    }

}