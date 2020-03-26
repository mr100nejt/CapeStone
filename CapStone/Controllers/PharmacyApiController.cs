using CapStone.Models;
using Microsoft.AspNet.Identity;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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
        public Pharmacy Get(int id)
        {

            {
                Pharmacy phrmList = db.Pharmacy.Where(e => e.specialId == id).FirstOrDefault();

                return phrmList;
            }

        }

        // GET: api/Pharmacy/5
        public string edit(int id)// no longer linked to account-1/28/2020
        {
            var targetData = db.Pharmacy.Where(e => e.MemberId == id).FirstOrDefault();
            var currentUserId = User.Identity.GetUserId();
            var currentUser = db.Users.Where(e => e.Id == currentUserId).FirstOrDefault();
            var number = currentUser.PhoneNumber;
            if (targetData.Watch == true)
            {
                number = "+1" + number;
                const string accountSid = ApiKeys.TwilioAccountNumber;
                const string authToken = ApiKeys.TwilioApiKey;
                TwilioClient.Init(accountSid, authToken);
                var message = MessageResource.Create(
                body: "The data with id" + " " + id + "has been changed",
                from: new Twilio.Types.PhoneNumber("+12622179385"),
                to: new Twilio.Types.PhoneNumber(number)
              );
                Console.WriteLine(message.Sid);

            }
            return "value";
        }



        // POST: api/Pharmacy
        public void Post(int id)
        {
            var targetData = db.Pharmacy.Where(e => e.MemberId == id);
            foreach (var item in targetData)
            {
                item.Watch = true;
            }

        }

        // PUT api/values/5
        public void Put([FromBody]Pharmacy value)
        {
            // Update 
            db.Pharmacy.ToCsv();
            db.SaveChanges();
           //Download the CSV file.
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=SqlExport.csv");
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.ContentType = "application/text";
            HttpContext.Current.Response.Output.Write(db.Pharmacy);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
            var duplicates = db.Pharmacy.GroupBy(s => new { s.MemberId, s.MemberFirstName, s.MemberLastName }).SelectMany(grp => grp.Skip(1)); ;
            db.Pharmacy.RemoveRange(duplicates);
            db.SaveChanges();
        }




    }
}

  

