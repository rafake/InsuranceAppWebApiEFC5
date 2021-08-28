using System;
using System.Collections.Generic;

namespace InsuranceAppWebApi.Domain
{
    public class Insuree
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime birthDate { get; set; }
        public DateTime InsuranceDate { get; set; }
        public List<Insurance> Insurances { get; set; } = new List<Insurance>();
        public Partner Partner { get; set; }
    }
}
