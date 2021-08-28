using System;

namespace InsuranceAppWebApi.Domain
{
    public class InsureeInsurance
    {
        public int InsureeId { get; set; }
        public int InsuranceId { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
