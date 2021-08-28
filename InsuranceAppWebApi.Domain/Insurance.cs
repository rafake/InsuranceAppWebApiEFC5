using System.Collections.Generic;

namespace InsuranceAppWebApi.Domain
{
    public class Insurance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<InsuranceCompany> InsuranceCompanies { get; set; } = new List<InsuranceCompany>();
        public List<Insuree> Insurees { get; set; } = new List<Insuree>();
    }
}
