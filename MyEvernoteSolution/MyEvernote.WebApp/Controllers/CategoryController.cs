using MyEvernoteBusinessLayer;
using MyEvernoteEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyEvernote.WebApp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        /*public ActionResult Select(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CategoryManager cm = new CategoryManager();
            Category cat=cm.GetCategoryById(id.Value); // id nullable olduğu için .Value demeliyiz...

            if(cat==null)
            {
                return HttpNotFound();
            }

            TempData["mm"] = cat.Notes;

            return RedirectToAction("Home","Index");

        }*/
    }
}