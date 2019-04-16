using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using meetapp.Models;

namespace meetapp.Controllers
{

    public class BusinessOwnerController : ApiController
    {
        // POST api/values
        //public void Post([FromBody]string value)
        public void Post([FromBody]BusinessOwner bo)
        {
            bo.insert();
        }

        [HttpGet]
        [Route("api/businessOwner/ValidMail")]
        public bool ValidMail(string email)
        {
            BusinessOwner bo = new BusinessOwner();
            return bo.ValidMail(email);

        }


        [HttpGet]
        [Route("api/businessOwner/login")]
        public bool login(string mail, string password)
        {
            BusinessOwner bo = new BusinessOwner();
            return bo.GetBusinessOwner(mail, password);
        }

        [HttpGet]
        [Route("api/businessOwner/details")]
        public BusinessOwner bo(string mail)
        {
            BusinessOwner p = new BusinessOwner();
            return p.GetDetails(mail);

        }

        [HttpPut]
        [Route("api/businessOwner/update")]
        public void PutUpdate([FromBody]BusinessOwner bo)
        {
            bo.PutUpdate();
        }

        //[HttpPost]
        //[Route("api/person/filter")]
        //public IEnumerable<Person> useFilter(Filter filter)
        //{
        //    Person p = new Person();
        //    return p.Filter(filter);
        //}

        //[HttpGet]
        //[Route("api/persons")]
        //public IEnumerable<Person> Get()
        //{
        //    Person p = new Person();
        //    return p.GetPersonList();
        //}

        //1-active 0-non active
        //[HttpPut]
        //[Route("api/persons")]
        //public void Put(int Active, int PersonId)
        //{
        //    Person p = new Person();
        //    p.UpdateActive(Active, PersonId);

        //}





        //[HttpGet]
        //[Route("api/person/validMail")]
        //public bool ValidMail(string mail)
        //{
        //    Person p = new Person();
        //    return p.ValidMail(mail);

        //}
    }
}
