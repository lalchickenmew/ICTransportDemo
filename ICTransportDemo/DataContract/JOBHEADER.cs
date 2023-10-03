namespace ICTransportDemo.DataContract
{
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
