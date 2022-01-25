using CubeGamesCase_DAL.Data;
using CubeGamesCase_Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CubeGamesCase.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        //[Authorize]
        public IActionResult Index()
        {
            List<Category> objList = _db.Categories.ToList();
            return View(objList);
        }
        public IActionResult Update_Insert(int? id)
        {
            Category obj = new Category();
            if (id == null)
            {
                return View(obj);
            }
            obj = _db.Categories.FirstOrDefault(a => a.CategoryId==id);
            if(obj==null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] //Client isteklerinin gerçekten site önyüzünden geldiğini anlamak için güvenlik amaçlı kullanıldı.

        public IActionResult Update_Insert(Category obj)
        {
            if (ModelState.IsValid)
            {
                if(obj.CategoryId == 0)
                {
                    //Create
                    _db.Categories.Add(obj);
                }
                else
                {
                    //Update
                    _db.Categories.Update(obj);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }
        public IActionResult Delete(int id)
        {
            var objDb = _db.Categories.FirstOrDefault(a => a.CategoryId == id);
            _db.Categories.Remove(objDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
