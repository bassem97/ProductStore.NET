using BJ.Domain;
using BJ.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BJ.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        // GET: ProductController
        [HttpPost]
        public ActionResult Index(string search)
        {
            List<Product> listProduct;
            if (!string.IsNullOrEmpty(search))
            {
                listProduct = productService.GetMany(p => p.Label == search).ToList();
            }
            else
            {
                listProduct = productService.GetMany().ToList();
            }
            return View(listProduct);
        }
        [HttpGet]
        public ActionResult Index()
        {
            List<Product> listProduct = productService.GetMany().ToList();
            
            return View(listProduct);
        }
        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View(productService.GetById(id));
           
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            List<Category> listCategory = categoryService.GetMany().ToList();
            ViewBag.Categories = new SelectList(listCategory, "CategoryId", "Name");

            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, IFormFile ImageFile)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",ImageFile.FileName);
                Stream stream = new FileStream(path, FileMode.Create);
                ImageFile.CopyTo(stream);
                product.Image = ImageFile.FileName;
                productService.Add(product);
                productService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(productService.GetById(id));
        }

        // POST: ProductController/Edit/5
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(productService.GetById(id));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                productService.Delete(productService.GetById(id));
                productService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(productService.GetById(id));
            }
        }
    }
}
