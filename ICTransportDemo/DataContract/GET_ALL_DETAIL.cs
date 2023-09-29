namespace ICTransportDemo.DataContract
{
    public class GET_ALL_DETAIL
    {
        public CUSTOMER_DETAIL customer { get; set; }
        public List<VEHICLE_DETAIL> vehicles { get; set; }
        public List<GET_ALL_DETAIL> jobHeaders { get; set; }
    }
    public class VEHICLE_DETAIL
    {
        public string license_No { get; set; }
        public string seq { get; set; }
        public string brand_No { get; set; }
        public string model_No { get; set; }
        public string chassis_No { get; set; }
        public string color { get; set; }
        public DateTime effective_Date { get; set; }
        public DateTime expire_Date { get; set; }
        public int service_Price { get; set; }
        public string service_No { get; set; }
        public string contract_No { get; set; }
        public string customer_Id { get; set; }
        public string contract_Type { get; set; }
        public string std_Pmp { get; set; }
        public string employee_Id { get; set; }
        public string active_Flag { get; set; }
    }
    public class JOBHEADER
    {
        public string job_Id { get; set; }
        public string license_No { get; set; }
        public string customer_Id { get; set; }
        public string summary { get; set; }
        public string action { get; set; }
        public object result { get; set; }
        public object transfer_To { get; set; }
        public DateTime fix_Date { get; set; }
        public DateTime close_Date { get; set; }
        public string email_Customer { get; set; }
        public object invoice_No { get; set; }
        public string owner_Id { get; set; }
        public string create_By { get; set; }
        public DateTime create_Date { get; set; }
        public string update_By { get; set; }
        public DateTime update_Date { get; set; }
        public object ref_HJob_Id { get; set; }
        public string status { get; set; }
        public string type_job { get; set; }
        public string job_Status { get; set; }
        public DateTime receive_Date { get; set; }
        public DateTime travel_Date { get; set; }
        public DateTime job_Date { get; set; }
        public object qt_Id { get; set; }
    }
}
