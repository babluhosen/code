using Code.Data;
using Code.Models;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace Code.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IEnumerable<Catagory> GetCatagorys()
        {
            return _db.Catagories.ToList();
        }
        public Catagory product(int id)
        {
            var p = _db.Catagories.SingleOrDefault(s => s.Id == id);
            if (p == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }  
            return p;
        }
        [HttpPost]
        public Catagory createc(Catagory p)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _db.Catagories.Add(p);
            _db.SaveChanges();
            return p;
        }
        [HttpPut]
       public  void Update(int id,Catagory p)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var exupdate = _db.Catagories.SingleOrDefault(u => u.Id == id);
            if (exupdate == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
;            }
            exupdate.Name = p.Name;
            exupdate.Displayorder = p.Displayorder;
            _db.SaveChanges();
           
        }
        [HttpDelete]
        public void deleup(int id)
        {
            var p = _db.Catagories.SingleOrDefault(d => d.Id == id);
            if (p == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _db.Catagories.Remove(p);
           
        }
       
        
    }
  
}
