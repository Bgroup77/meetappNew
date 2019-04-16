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
    public class AlgorithmController : ApiController
    {
        // GET: Algorithm
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //[HttpGet]
        //[Route("api/algorithm/GetInitialCenterPoint")]
        //public double[] GetInitialCenterPoint(double[] LatArr, double[] LngArr)
        //{
        //    Algorithm algo = new Algorithm();
        //    return algo.GetInitialCenterPoint(LatArr, LngArr);
        //}

        [HttpPost]
        [Route("api/algorithm/PutOriginPoints")]
        public IEnumerable<double> PutOriginPoints(OriginPoints originPoints)
        {
            Algorithm algo = new Algorithm();
            return algo.GetInitialCenterPoint(originPoints);
        }

        //[HttpPut]
        //[Route("api/algorithm/PutOriginPoints")]
        //public void PutOriginPoints([FromBody] Algorithm algo)
        //{
        //    algo.GetInitialCenterPoint(LatArr, LngArr);
        //}
    }
}