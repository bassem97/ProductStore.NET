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
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this._productService = productService;
            this._categoryService = categoryService;
        }
        // GET: ProductController
        [HttpPost]
        public ActionResult Index(string search)
        {
            List<Product> listProduct;
            if (!string.IsNullOrEmpty(search))
            {
                listProduct = _productService.GetMany(p => p.Label == search).ToList();
            }
            else
            {
                listProduct = _productService.GetMany().ToList();
            }
            return View(listProduct);
        }
        [HttpGet]
        public ActionResult Index()
        {
            List<Product> listProduct = _productService.GetMany().ToList();
            
            return View(listProduct);
        }
        public ActionResult Index2()
        {
            List<Product> listProduct = _productService.GetMany().ToList();
            
            return View(listProduct);
        }
        
        
        
        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            if (_productService.GetById(id) == null)
            {
                return NotFound();
            }
            return View(_productService.GetById(id));
           
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            List<Category> listCategory = _categoryService.GetMany().ToList();
            ViewBag.Categories = new SelectList(listCategory, "CategoryId", "Name");

            return View();
        }

        // POST: Product/Create
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
                _productService.Add(product);
                _productService.Commit();
                return RedirectToAction(nameof(Index));
                // OR
                // return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/{id}
        public ActionResult Edit(int id)
        {
            Product product = _productService.GetById(id);
            ViewBag.Categories = new SelectList(_categoryService.GetMany().ToList(), "CategoryId", "Name");
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product,IFormFile imageFile )
        {
            var productToUpdate = _productService.GetById(id);
            if (imageFile != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", imageFile.FileName);
                var stream = new FileStream(path,FileMode.Create);
                imageFile.CopyTo(stream);
                product.Image = imageFile.FileName;
            }
            productToUpdate.Category = product.Category;
            productToUpdate.Clients = product.Clients;
            productToUpdate.Description = product.Description;
            productToUpdate.Image = product.Image;
            productToUpdate.Label = product.Label;
            productToUpdate.Providers = product.Providers;
            productToUpdate.Quantity = product.Quantity;
            productToUpdate.Price = product.Price;
            productToUpdate.DateProd = product.DateProd;
            productToUpdate.ProductId = product.ProductId;
            productToUpdate.PackagingType = product.PackagingType;
            productToUpdate.CategoryId = product.CategoryId;
            
           
            _productService.Update(product);
            _productService.Commit();
            return View(product);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_productService.GetById(id));
        }
        
        

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _productService.Delete(_productService.GetById(id));
                _productService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(_productService.GetById(id));
            }
        }
    }
}
