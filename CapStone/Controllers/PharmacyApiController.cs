using CapStone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace CapStone.Controllers
{
    public class PharmacyController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: api/Pharmacy
        public IEnumerable<Pharmacy> Get()
        {
           
            {
                List<Pharmacy> phrmList = db.Pharmacy.ToList();

                return phrmList;
            }
          
        }

        // GET: api/Pharmacy/5
        public string edit(int id)
        {
            var targetData = db.Pharmacy.Where(e => e.MemberId == id).FirstOrDefault();
            var currentUserId = User.Identity.GetUserId();
            var currentUser = db.Users.Where(e => e.Id == currentUserId).FirstOrDefault();
            var number = currentUser.PhoneNumber;
            if(targetData.Watch == true)
            {
               
               
                number = "+1" + number;
                const string accountSid =   ApiKeys.TwilioAccountNumber;
                const string authToken =ApiKeys.TwilioApiKey;
                TwilioClient.Init(accountSid, authToken);
                var message = MessageResource.Create(
                body:"The data with id"+" " + id + "has been changed",
                from: new Twilio.Types.PhoneNumber("+12622179385"),
                to: new Twilio.Types.PhoneNumber(number)
                );
                Console.WriteLine(message.Sid);
               
            }
            return "value";
        }
            
        

        // POST: api/Pharmacy
        public void Post(int id )
        {
            var targetData = db.Pharmacy.Where(e => e.MemberId == id);
            foreach(var item in targetData)
            {
                item.Watch = true; 
            }

        }

        // PUT api/values/5
        public void Put([FromBody]Pharmacy value)
        {
            // Update 
            DistinctItemComparer compae = new DistinctItemComparer();
            foreach(var item in db.Pharmacy)
            {
                  var distinctItems = db.Pharmacy.Where(e => e.MemberId == item.MemberId );
                foreach (var i in distinctItems)
                {
                    db.Pharmacy.Remove(i);
                }
            }
        
      
            db.SaveChanges();


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
                       obj.MemberFirstName.GetHashCode();
                       

            }
        }
    }
}