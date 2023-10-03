using ISEECENTERAPI.DataContract;

namespace ICTransportDemo.DataContract
{
    public class GET_ALL_DETAIL
    {
        public CUSTOMER_DETAIL customer { get; set; }
        public List<VEHICLE_DETAIL> vehicles { get; set; }
        public List<JOBHEADER> jobHeaders { get; set; }
        public List<EMAILHISTORY> emailHistory { get; set; }
        public List<VEHICLECUS> vehicleCus { get; set; }
        public List<NOTIFICATIONEMAIL> notiemail { get; set; }
    }
}
