using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TelegramBotAspNetCore.Controllers
{
    public class DefaultMessageController : Controller
    {
        // GET: DefaultMessageController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DefaultMessageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DefaultMessageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DefaultMessageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DefaultMessageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DefaultMessageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DefaultMessageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DefaultMessageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
