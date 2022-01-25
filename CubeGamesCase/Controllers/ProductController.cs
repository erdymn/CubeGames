using CubeGamesCase_DAL.Data;
using CubeGamesCase_Model.Models;
using CubeGamesCase_Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace CubeGamesCase.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        //[Authorize]
        public IActionResult Index()
        {
            List<Product> objList = _db.Products.ToList();

            //CategoryName gözükmesi için kullanılan döngü.
            foreach (var obj in objList)
            {
                obj.Category = _db.Categories.FirstOrDefault(x => x.CategoryId == obj.CategoryId);
            }
            return View(objList);
        }
        public IActionResult Update_Insert(int? id)
        {
            ProductViewModel obj = new ProductViewModel();

            obj.CategoryList = _db.Categories.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            });

            if (id == null)
            {
                return View(obj);
            }

            //Edit bölümü
            obj.Product = _db.Products.FirstOrDefault(x => x.ProductId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] //Client isteklerinin gerçekten site önyüzünden geldiğini anlamak için güvenlik amaçlı kullanıldı.

        public IActionResult Update_Insert(ProductViewModel obj)
        {
           
                if (obj.Product.ProductId == 0)
                {
                    //Create
                    _db.Products.Add(obj.Product);
                }
                else
                {
                    //Update
                    _db.Products.Update(obj.Product);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            
            
        }
        public IActionResult Delete(int id)
        {
            var objDb = _db.Products.FirstOrDefault(a => a.ProductId == id);
            _db.Products.Remove(objDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
