namespace InsuranceAppWebApi.Domain
{
    public class InsuranceCompany
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Insurance Insurance { get; set; }
        public int InsuranceId { get; set; }
    }
}
