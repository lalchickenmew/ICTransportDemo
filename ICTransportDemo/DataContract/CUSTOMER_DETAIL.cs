using NuGet.Protocol;

namespace ICTransportDemo.DataContract
{


    public class CUSTOMER_DETAIL
    {
        public long customer_id { get; set; }
        public string fname { get; set; }
        public string cust_type { get; set; }
        public string address { get; set; }
        public string district_name_tha { get; set; }
        public string sub_district_name_tha { get; set; }
        public string province_name_tha { get; set; }
        public string zip_Code { get; set; }
        public string phone_No { get; set; }
        public string email { get; set; }
        public List<VEHICLECUS> vehicleCus { get; set; }
    }

   

   
}
