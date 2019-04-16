using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace meetapp.Models
{
    public class Algorithm
    {

        //List<double> LatArr { get; set; }
        //List<double> LngArr { get; set; }
        //List<double> Result { get; set; }

        public Algorithm()
        {
        }

        public List<double> GetInitialCenterPoint(OriginPoints originPoints)
        {
            //public double[] X = new double[] { 67, 54, 98 };
            //public double[] Y = new double[] { 32, 12, 45 };
            //public double[] weights = new double[] { 32, 12, 45 };


            List<double> X_List = new List<double>();
            X_List = originPoints.LatList;

            List<double> Y_List = new List<double>();
            Y_List = originPoints.LngList;

            List<double> weightedAvg = new List<double>();
            double sumX = X_List.Sum();
            double sumY = Y_List.Sum();

            double avgX = sumX / X_List.Count;
            double avgY = sumY / Y_List.Count;

            weightedAvg.Add(avgX);
            weightedAvg.Add(avgY);

            return weightedAvg;

            //for (int i = 0; i< Xarr.Count(); i++)
            //    {
            //    _wavg += ((_number[i] * _weight[i]) / (_weights.Sum());

            //    }
        }


    }

    //public class caller
    //{
    //    public static void Main(string[] args)
    //    {
    //        Algorithm test = new Algorithm();
    //        test.LatArr = new double[] { 32.240830, 32.779370, 32.071270 };
    //        test.LonArr = new double[] { 35.014100, 34.979770, 34.781700 };
    //        //test.Result = new double[2];
    //        test.Result= Algorithm.AveragePoint(test.LatArr, test.LonArr);
    //}
    //}

}