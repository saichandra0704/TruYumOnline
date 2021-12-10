using System.Collections.Generic;

using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;

using TruYumOnline.Models;



namespace TruYumOnline.Controllers

{



    public class AdminController : Controller

    {

        // GET: Admin 

        public ActionResult GetMenuItems()

        {

            IEnumerable<MenuItem> menuitems;

            HttpResponseMessage httpResponse = GlobalVariables.webApiClient.GetAsync("MenuItems").Result;

            menuitems = httpResponse.Content.ReadAsAsync<IEnumerable<MenuItem>>().Result;

            return View(menuitems);

        }



        // GET: Admin/Edit/5 

        public ActionResult EditMenuItem(int id)

        {

            HttpResponseMessage httpResponse = GlobalVariables.webApiClient.GetAsync("MenuItems/" + id.ToString()).Result;

            return View(httpResponse.Content.ReadAsAsync<MenuItem>().Result);

        }



        // POST: Admin/Edit/5 

        [HttpPost]

        public ActionResult EditMenuItem(int id, MenuItem menuItem)

        {

            try

            {

                HttpResponseMessage httpResponse = GlobalVariables.webApiClient.PutAsJsonAsync("MenuItems/" + menuItem.MeId, menuItem).Result;

                TempData["SuccessMessage"] = "Updated Successfully";

                return RedirectToAction(nameof(GetMenuItems));

            }

            catch

            {

                return View();

            }

        }



        // GET: Admin/Create 

        public ActionResult CreateMenuItem()

        {

            return View(new MenuItem());

        }



        // POST: Admin/Create 

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult CreateMenuItem(MenuItem menuItem)

        {

            try

            {

                HttpResponseMessage httpResponse = GlobalVariables.webApiClient.PostAsJsonAsync("MenuItems", menuItem).Result;

                TempData["SuccessMessage"] = "Added Successfully";

                return RedirectToAction(nameof(GetMenuItems));

            }

            catch

            {

                return View();

            }

        }



        // GET: Admin/Delete/5 

        public ActionResult DeleteMenuItem(int id)

        {

            HttpResponseMessage httpResponse = GlobalVariables.webApiClient.GetAsync("MenuItems/" + id.ToString()).Result;

            return View(httpResponse.Content.ReadAsAsync<MenuItem>().Result);

        }



        // POST: Admin/Delete/5 

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult DeleteMenuItem(int id, MenuItem menuItem)

        {

            try

            {

                HttpResponseMessage httpResponse = GlobalVariables.webApiClient.DeleteAsync("MenuItems/" + id.ToString()).Result;

                TempData["SuccessMessage"] = "Deleted Successfully";

                return RedirectToAction(nameof(GetMenuItems));

            }

            catch

            {

                return View();

            }

        }

    }

}