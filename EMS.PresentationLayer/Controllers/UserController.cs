using EMS.BusinessLogicLayer;
using EMS.DataAccessLayer;
using EMS.Entities;
using EMS.PresentationLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EMS.PresentationLayer.Controllers
{
    public class UserController : Controller
    {
        private readonly UserBAL userBAL;
        public UserController(EMSDBContext eMSDBContext)
        {
            userBAL = new UserBAL(eMSDBContext);
        }
        // GET: UserController
        // GET: UserController For Displaying 
        public ActionResult Index()
        {
            var users = userBAL.GetAllUsers().Select(user => new Models.User
            {
                Id = user.Id,
                Name = user.Name,
                Address = user.Address,
                Age = user.Age,
                Email = user.Email
            }).ToList();

            return View(users);
        }


        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.User userRequest)
        {
            try
            {
                Entities.UserMaster request = new Entities.UserMaster();
                request.Id = 0;
                request.Name = userRequest.Name;
                request.Address = userRequest.Address;
                request.Age = userRequest.Age;
                request.Email = userRequest.Email;

               var result= userBAL.InsertUser(request);

             //   request.Name = collection;

                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var user=userBAL.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            var userModel = new Models.User
            {
                Id= user.Id,
                Name= user.Name,
                Address= user.Address,
                Age= user.Age,
                Email= user.Email
            };
           // return RedirectToAction("List", "Students");

           return View(userModel);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Models.User userRequest)
        {
            if (id != userRequest.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Fetch the existing user from the database
                    var user = userBAL.GetUserById(id);
                    if (user == null)
                    {
                        return NotFound();
                    }

                    // Update the user properties
                    user.Name = userRequest.Name;
                    user.Address = userRequest.Address;
                    user.Age = userRequest.Age;
                    user.Email = userRequest.Email;

                    // Update the user in the database
                    userBAL.UpdateUser(user);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log the exception (not shown here for brevity)
                    return View();
                }
            }

            return View(userRequest);
        }

       
      // GET: UserController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var user = await userBAL.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userModel = new User
            {
                Id = user.Id,
                Name = user.Name,
                Address = user.Address,
                Age = user.Age,
                Email = user.Email
            };

            return View(userModel);
        }
        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(User userRequest)
        {
            var result = await userBAL.DeleteUserAsync(userRequest.Id);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(userRequest);
        }
    }
}
