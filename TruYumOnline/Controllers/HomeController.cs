using System.Diagnostics;

using System.Linq;

using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;

using TruYumOnline.Models;



namespace TruYumOnline.Controllers

{

    [Route("Home")]

    public class HomeController : Controller

    {

        private readonly ILogger<HomeController> _logger;



        public HomeController(ILogger<HomeController> logger)

        {

            _logger = logger;

        }



        [AllowAnonymous]

        [Route("Login")]

        [HttpGet]

        public IActionResult Index()

        {

            UserRecord user = new UserRecord();

            return View(user);

        }



        [AllowAnonymous]

        [Route("Login")]

        [HttpPost]

        public ActionResult Index(UserRecord user)

        {

            HttpResponseMessage httpResponse = GlobalVariables.webApiClient.PostAsJsonAsync("Auth/Login", user).Result;

            var validUser = httpResponse.Content.ReadAsAsync<UserRecord>().Result;



            //var d = httpResponse.Headers.GetValues("token");



            if (validUser == null)

            {

                //if (validUser.UsRole.Equals("Admin"))

                //{

                    //return RedirectToAction("GetMenuItems", "Admin");

                //}

                //else

                //{

                    return RedirectToAction("GetActiveMenuItems", "Customer");
                //
                //}



            }

            else

            {

                ModelState.Clear();

                ModelState.AddModelError(string.Empty, "Username or Password is Incorrect");

                return View();

            }

        }



        [AllowAnonymous]

        [Route("Signup")]

        [HttpGet]

        public ActionResult Signup()

        {

            UserRecord user = new UserRecord();

            return View(user);

        }



        [AllowAnonymous]

        [Route("Signup")]

        //Method to Insert User Credentials to Database   

        [HttpPost]

        public ActionResult Signup(UserRecord user)

        {

            HttpResponseMessage httpResponse = GlobalVariables.webApiClient.PostAsJsonAsync("Auth/Signup", user).Result;



            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)

            {

                return RedirectToAction("Index");

            }

            else if (httpResponse.StatusCode == System.Net.HttpStatusCode.Conflict)

            {

                ModelState.Clear();

                ModelState.AddModelError("Username", "Username Already Exist");

                return View();

            }

            else

                return View();

        }



        public IActionResult Privacy()

        {

            return View();

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()

        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        }

    }

}