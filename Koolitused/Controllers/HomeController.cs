using Koolitused.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity.Owin;
using System.Drawing;
using System.Net;
using System.Data.Entity.Infrastructure;

namespace Koolitused.Controllers
{
    public class HomeController : Controller
    {
        private readonly GuestContext guestDb;
        private readonly ApplicationDbContext appDb;
        public HomeController(GuestContext guestDb, ApplicationDbContext appDb)
        {
            this.guestDb = guestDb;
            this.appDb = appDb;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Teie taotluse kirjelduse lehekülg.";

            return View();
        }
        [Authorize]
        public ActionResult Roll()
        {
            IList<string> roles = new List<string> { "Roll ei ole maaratud" };
            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                                        .GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByEmail(User.Identity.Name);

            if (user != null)
                roles = userManager.GetRoles(user.Id);

            // Передача roles в качестве Model в представление
            return View(roles);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Teie kontaktleht.";

            return View();
        }

        /* Opilane */

        [Authorize(Roles = "admin")]
        public ActionResult Opilane()
        {
            IEnumerable<Opilane> opilased = guestDb.Opilased;
            return View(opilased);
        }
        public ActionResult Loo_opilane()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Loo_opilane(Opilane opilane)
        {
            if (ModelState.IsValid)
            {
                guestDb.Opilased.Add(opilane);
                guestDb.SaveChanges();
                return RedirectToAction("Opilane");
            }

            return View(opilane);
        }
        [HttpGet]
        public ActionResult Kustuta_opilane(int id)
        {
            Opilane o = guestDb.Opilased.Find(id);
            if (o == null)
            {
                return HttpNotFound();
            }
            return View(o);
        }
        [HttpPost, ActionName("Kustuta_opilane")]
        public ActionResult Kustutakinnitatud_opilane(int id)
        {
            Opilane o = guestDb.Opilased.Find(id);
            if (o == null)
            {
                return HttpNotFound();
            }

            guestDb.Opilased.Remove(o);
            guestDb.SaveChanges();
            return RedirectToAction("Opilane");
        }
        [HttpGet]
        public ActionResult Redigeeri_opilane(int? id)
        {
            Opilane o = guestDb.Opilased.Find(id);
            if (o == null)
            {
                return HttpNotFound();
            }
            return View(o);
        }
        [HttpPost, ActionName("Redigeeri_opilane")]
        public ActionResult Redigeerikinnitatud_opilane(Opilane opilane)
        {
            if (ModelState.IsValid)
            {
                guestDb.Entry(opilane).State = EntityState.Modified;
                guestDb.SaveChanges();
                return RedirectToAction("Opilane");
            }

            return View(opilane);
        }

        /* Opetaja */

        [Authorize(Roles = "admin")]
        public ActionResult Opetaja()
        {
            IEnumerable<Opetaja> opetajad = guestDb.Opetajad;
            return View(opetajad);
        }
        [HttpGet]
        public ActionResult Loo_opetaja()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Loo_opetaja(Opetaja opetaja)
        {
            guestDb.Opetajad.Add(opetaja);
            guestDb.SaveChanges();
            return RedirectToAction("Opetaja");
        }
        [HttpGet]
        public ActionResult Kustuta_opetaja(int id)
        {
            Opetaja ops = guestDb.Opetajad.Find(id);
            if (ops == null)
            {
                return HttpNotFound();
            }
            return View(ops);
        }
        [HttpPost, ActionName("Kustuta_opetaja")]
        public ActionResult Kustutakinnitatud_opetaja(int id)
        {
            Opetaja ops = guestDb.Opetajad.Find(id);
            if (ops == null)
            {
                return HttpNotFound();
            }
            guestDb.Opetajad.Remove(ops);
            guestDb.SaveChanges();
            return RedirectToAction("Opetaja");
        }
        [HttpGet]
        public ActionResult Redigeeri_opetaja(int? id)
        {
            Opetaja ops = guestDb.Opetajad.Find(id);
            if (ops == null)
            {
                return HttpNotFound();
            }
            return View(ops);
        }
        [HttpPost, ActionName("Redigeeri_opetaja")]
        public ActionResult Redigeerikinnitatud_opetaja(Opetaja opetaja)
        {
            guestDb.Entry(opetaja).State = EntityState.Modified;
            guestDb.SaveChanges();
            return RedirectToAction("Opetaja");
        }

        /* Kursused */

        [Authorize(Roles = "admin")]
        public ActionResult Koolitused()
        {
            IEnumerable<Koolituss> koolitused = guestDb.Koolitused;
            return View(koolitused);
        }
        [HttpGet]
        public ActionResult Lisa_koolitus()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Lisa_koolitus(Koolituss koolituss)
        {
            if (ModelState.IsValid)
            {
                guestDb.Koolitused.Add(koolituss);
                guestDb.SaveChanges();
                return RedirectToAction("Koolitused");
            }

            return View(koolituss);
        }
        [HttpGet]
        public ActionResult Redigeeri_koolitus(int? id)
        {
            Koolituss koolituss = guestDb.Koolitused.Find(id);
            if (koolituss == null)
            {
                return HttpNotFound();
            }
            return View(koolituss);
        }
        [HttpPost, ActionName("Redigeeri_koolitus")]
        public ActionResult Redigeerikinnitatud_koolitus(Koolituss koolituss)
        {
            if (ModelState.IsValid)
            {
                guestDb.Entry(koolituss).State = EntityState.Modified;
                guestDb.SaveChanges();
                return RedirectToAction("Koolitused");
            }

            return View(koolituss);
        }
        [HttpGet]
        public ActionResult Kustuta_koolitus(int id)
        {
            Koolituss koolituss = guestDb.Koolitused.Find(id);
            if (koolituss == null)
            {
                return HttpNotFound();
            }
            return View(koolituss);
        }
        [HttpPost, ActionName("Kustuta_koolitus")]
        public ActionResult Kustutakinnitatud_koolitus(int id)
        {
            Koolituss koolituss = guestDb.Koolitused.Find(id);
            if (koolituss == null)
            {
                return HttpNotFound();
            }

            guestDb.Koolitused.Remove(koolituss);
            guestDb.SaveChanges();
            return RedirectToAction("Koolitused");
        }

        /* Reg. kursusele */

        [HttpGet, Authorize]
        public ActionResult RegKursile()
        {
            IEnumerable<RegKursile> registrations = guestDb.RegKursid.Include(r => r.Course).ToList();

            return View(registrations);
        }
        [HttpGet]
        public ActionResult Loo_RegKursile()
        {
            IEnumerable<Koolituss> availableCourses = guestDb.Koolitused.ToList();
            ViewBag.Courses = new SelectList(availableCourses, "Id", "Koolitusnimetus");

            return View();
        }
        [HttpPost]
        public ActionResult Loo_RegKursile(RegKursile registration)
        {
            if (ModelState.IsValid)
            {
                registration.UserEmail = User.Identity.Name;
                int selectedCourseId = registration.CourseId;
                Koolituss selectedCourse = guestDb.Koolitused.FirstOrDefault(c => c.Id == selectedCourseId);
                if (selectedCourse == null)
                {
                    ModelState.AddModelError("CourseId", "Invalid course selected");
                    return View(registration);
                }
                registration.Course = selectedCourse;

                guestDb.RegKursid.Add(registration);
                guestDb.SaveChanges();

                return RedirectToAction("RegKursile");
            }

            IEnumerable<Koolituss> availableCourses = guestDb.Koolitused.ToList();
            ViewBag.Courses = new SelectList(availableCourses, "Id", "Koolitusnimetus");

            return View(registration);
        }
        [HttpGet]
        public ActionResult Muuda_RegKursile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RegKursile regkursid = guestDb.RegKursid.Find(id);

            if (regkursid == null)
            {
                return HttpNotFound();
            }

            IEnumerable<Koolituss> availableCourses = guestDb.Koolitused.ToList();
            ViewBag.Courses = new SelectList(availableCourses, "Id", "Koolitusnimetus");

            return View(regkursid);
        }
        [HttpPost]
        public ActionResult Muuda_RegKursile(RegKursile updatedRegistration)
        {
            if (ModelState.IsValid)
            {
                int selectedCourseId = updatedRegistration.CourseId;
                Koolituss selectedCourse = guestDb.Koolitused.FirstOrDefault(c => c.Id == selectedCourseId);

                if (selectedCourse == null)
                {
                    ModelState.AddModelError("CourseId", "Invalid course selected");
                    return View(updatedRegistration);
                }
                RegKursile originalRegistration = guestDb.RegKursid.Find(updatedRegistration.Id);

                if (originalRegistration == null)
                {
                    return HttpNotFound();
                }

                originalRegistration.FirstName = updatedRegistration.FirstName;
                originalRegistration.LastName = updatedRegistration.LastName;
                originalRegistration.CourseId = updatedRegistration.CourseId;
                originalRegistration.Course = selectedCourse;

                guestDb.Entry(originalRegistration).State = EntityState.Modified;
                guestDb.SaveChanges();

                return RedirectToAction("RegKursile");
            }

            IEnumerable<Koolituss> availableCourses = guestDb.Koolitused.ToList();
            ViewBag.Courses = new SelectList(availableCourses, "Id", "Koolitusnimetus");

            return View(updatedRegistration);
        }
        [HttpGet]
        public ActionResult Kustuta_RegKursile(int id)
        {
            RegKursile regkursid = guestDb.RegKursid.Find(id);
            if (regkursid == null)
            {
                return HttpNotFound();
            }
            return View(regkursid);
        }
        [HttpPost, ActionName("Kustuta_RegKursile")]
        public ActionResult Kustutakinnitatud_RegKursile(int id)
        {
            RegKursile regkursid = guestDb.RegKursid.Find(id);
            if (regkursid == null)
            {
                return HttpNotFound();
            }

            guestDb.RegKursid.Remove(regkursid);
            guestDb.SaveChanges();
            return RedirectToAction("RegKursile");
        }

        /* Minu kursused */
        [Authorize]
        public ActionResult MinuKursused()
        {
            string userEmail = User.Identity.Name;

            IEnumerable<RegKursile> userCourses = guestDb.RegKursid
                .Where(r => r.UserEmail == userEmail)
                .ToList();

            return View(userCourses);
        }
    }
}