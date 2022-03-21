using Code.Data;
using Code.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.OData.Query.SemanticAst;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Controllers
{
    public class CodexController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CodexController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
     public IActionResult Create(string Name, int DisplayOrder,Catagory obj)
        {
            if (ModelState.IsValid) { 
                Models.Catagory Obj = new Models.Catagory();
                Obj.Name = Name;
                Obj.Displayorder = DisplayOrder;
                _db.Catagories.Add(Obj);
                _db.SaveChanges();
                return RedirectToAction("Indexs");
            }
            return View(obj);
        }  
        public IActionResult Indexs()
        {
            IEnumerable<Catagory> obj = _db.Catagories.ToList();
            return View(obj);
        }
        #region Edit Deleted
        [HttpGet]
        public IActionResult Edit(int ?id)
        {
            var getobj = _db.Catagories.Find(id);
            if (getobj == null)
            {
                getobj = new Catagory();
            }
            return View(getobj);
        }
        [HttpPost]
        public IActionResult Edit(Catagory cata,string Name, int DisplayOrder)
        {
            var getupdate = _db.Catagories.Find(cata.Id);
            if (getupdate == null)
            {
                Catagory objeidt = new Catagory();
                objeidt.Name = Name;
                objeidt.Displayorder = DisplayOrder;
                _db.Catagories.Add(objeidt);
                _db.SaveChanges();
            }
            else
            {
                getupdate.Id = cata.Id;
                getupdate.Name = Name;
                getupdate.Displayorder = DisplayOrder;
                _db.SaveChanges();
            }
            return View(new Catagory());
        }
        public IActionResult Deleted(int? DeleteId)
        {
                var del = _db.Catagories.Find(DeleteId);
                _db.Catagories.Remove(del);
                _db.SaveChanges();
                return RedirectToAction("Indexs");
            
            
        }
        #endregion Edit Deleted
       
     
     public IActionResult branchdropdown()
        {
            Branch obj = new Branch();
            obj.Branchlist = ViewData.Select(x => new bank { BankId =obj.BranchId , BankName = obj.BranchCode }).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult bankInfo(string BankName)
        {
            bank objs = new bank();
            objs.BankName = BankName;
            _db.Banks.Add(objs);
            _db.SaveChanges();
            return View();
        }
       

       
        public IActionResult ArthOper()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ArthOper(decimal ItemPrice,decimal ItemQuantity,decimal Discount, decimal Total)
        {
            Arthmeticoperation ob = new Arthmeticoperation();
            ob.ItemPrice = ItemPrice;
            ob.ItemQuantity = ItemQuantity;
            ob.Discount = Discount;
           
            ob.Total = ItemPrice * ItemQuantity - Discount;
            _db.Arthmeticoperations.Add(ob);
            _db.SaveChanges();
            
            return View();
        }
        public IActionResult productlist()
        {
            IEnumerable<Arthmeticoperation> obj = _db.Arthmeticoperations.ToList();
            return View(obj);
        }
      public IActionResult searchlist( string Searching)
        {
            var list = _db.Catagories.Where(c => c.Name.Contains(Searching) || Searching == null).ToList();
            return View(list);
        }

    }
}
