using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobith_forma
{
    internal class AvailabilityResponse
    {

        public bool success { get; set; }
        public Data data { get; set; }  



    }


    public class Data
    {
        public List<Availability> availability { get; set; }
        public Fare fare { get; set; }

        //public Train train { get; set; }
    }


    public class Availability
    {
        public string date { get; set; }
        public string status { get; set; }
        public string availabilityText { get; set; }
        public string rawStatus { get; set; }
    }


    public class Fare
    {
        public int baseFare { get; set; }
        public int reservationCharge { get; set; }
        public int serviceTax { get; set; }
        public int superfastCharge { get; set; }
        public int totalFare { get; set; }
    }


    //public class Train
    //{
    //    public int distance { get; set; }
    //    public string from { get; set; }
    //    public string fromStationName { get; set; }
    //    public string quota { get; set; }
    //    public string to { get; set; }
    //    public string toStationName { get; set; }
    //    public string trainName { get; set; }
    //    public string trainNo { get; set; }
    //    public string travelClass { get; set; }
    //}
}
