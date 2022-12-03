using RiaChristoforidouBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace RiaChristoforidouBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }
        public ActionResult CreateRecipe()
        {
            ViewBag.CategoryId = new SelectList(_context.Categories.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRecipe(Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CategoryId = new SelectList(_context.Categories.ToList(), "Id", "Name");
                return View(recipe);
            }
            if (recipe.ImageFile == null)
            {
                recipe.Thumbnail = "na_image.jpg";
            }
            else
            {
                recipe.Thumbnail = Path.GetFileName(recipe.ImageFile.FileName);
                string fullPath = Path.Combine(Server.MapPath("~/img/"), recipe.Thumbnail);
                recipe.ImageFile.SaveAs(fullPath);
            }
            _context.Recipes.Add(recipe);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult InsertNewCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertNewCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            if (category.ImageFile == null)
            {
                category.Thumbnail = "na_image.jpg";
            }
            else
            {
                category.Thumbnail = Path.GetFileName(category.ImageFile.FileName);
                string fullPath = Path.Combine(Server.MapPath("~/img/"), category.Thumbnail);
                category.ImageFile.SaveAs(fullPath);
            }
            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult EditCategory(int id)
        {
           var category = _context.Categories.SingleOrDefault(c => c.Id == id);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory(Category category)
        {
           if(category.ImageFile == null)
            {
                var categoryInDb = _context.Categories.Where(c => c.Id == category.Id).FirstOrDefault();
                category.Thumbnail = categoryInDb.Thumbnail;
                
            }
            if(category.ImageFile != null)
            {
                category.Thumbnail = Path.GetFileName(category.ImageFile.FileName);
                string fullPath = Path.Combine(Server.MapPath("~/img/"), category.Thumbnail);
                category.ImageFile.SaveAs(fullPath);
                _context.Entry(category).State = EntityState.Modified;
            }
            
            
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ViewCategory(int id)
        {
            var recipes = _context.Recipes.Where(c => c.CategoryId == id).Include(c => c.Category).ToList();
            return View(recipes);
        }
        public ActionResult ViewSingleRecipe(Recipe recipe)
        {
            var recipeInDb = _context.Recipes.Where(r => r.Id == recipe.Id).Include(c=> c.Category).SingleOrDefault();
            return View(recipeInDb);
        }
        public ActionResult ConfirmDeleteRecipe(int id)
        {
            
            ViewData["idToDelete"] = id;
            return View();
        }
        public ActionResult EditRecipe(int id)
        {
            var recipe = _context.Recipes.Where(r => r.Id == id).SingleOrDefault();
            ViewBag.CategoryId = new SelectList(_context.Categories.ToList(), "Id", "Name",recipe.CategoryId);
            
            return View(recipe);
        }
        [HttpPost]
        public ActionResult EditRecipe(Recipe recipe)
        {
            if (recipe.ImageFile == null)
            {
                var categoryInDb = _context.Recipes.Where(c => c.Id == recipe.Id).FirstOrDefault();
                recipe.Thumbnail = categoryInDb.Thumbnail;

            }
            if (recipe.ImageFile != null)
            {
                recipe.Thumbnail = Path.GetFileName(recipe.ImageFile.FileName);
                string fullPath = Path.Combine(Server.MapPath("~/img/"), recipe.Thumbnail);
                recipe.ImageFile.SaveAs(fullPath);
                _context.Entry(recipe).State = EntityState.Modified;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteRecipe(int id)
        {
       
            var deleteRecipe = _context.Recipes.Where(r => r.Id == id).SingleOrDefault();
            _context.Recipes.Remove(deleteRecipe);
            _context.SaveChanges();
            return  RedirectToAction("Index");
        }
        public ActionResult SearchQuery(string query)
        {
            var recipes = _context.Recipes.Include(c=> c.Category).ToList();
            //foreach (var recipe in recipes)
            //{
            //    if (recipe.Title.Contains("α"))
            //    {
            //        recipe.Title = "ά";
            //    }
            //}
            return View(recipes.Where(x => x.Title.Contains(query)));

        }

    }
}