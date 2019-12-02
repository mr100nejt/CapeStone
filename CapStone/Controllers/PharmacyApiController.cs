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
        public string GetAll(int id)
        {
            return "value";
        }

        // POST: api/Pharmacy
        public void Post([FromBody]Pharmacy value)
        {
           //add

        }

        // PUT api/values/5
        public void Put([FromBody]Pharmacy value)
        {
            // Update 


            var distinctItems = db.Pharmacy.Distinct(new DistinctItemComparer());
            foreach (var item in distinctItems)
            {
                db.Pharmacy.Remove(item);
            }



        }
        class DistinctItemComparer : IEqualityComparer<Pharmacy>
        {

            public bool Equals(Pharmacy phrm1, Pharmacy phrm2)
            {
                return phrm1.MemberId == phrm2.MemberId &&
                       phrm1.MemberFirstName == phrm2.MemberFirstName;
            }
            public int GetHashCode(Pharmacy obj)
            {
                return obj.MemberId.GetHashCode() ^
                       obj.MemberFirstName.GetHashCode() ^
                       obj.MemberLastName.GetHashCode();

            }
        }
    }
}