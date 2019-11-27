using CapStone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CapStone.Controllers
{
    public class PharmacyController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: api/Pharmacy
        public IEnumerable<Pharmacy> Get()
        {
            var pharm = db.Pharmacy.ToArray();

            return pharm; 
        }

        // GET: api/Pharmacy/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pharmacy
        public void Post([FromBody]Pharmacy value)
        {
            // Create movie in db logic
            
        }

        // PUT api/values/5

    }
}