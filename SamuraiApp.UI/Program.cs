using InsuranceApp.Data;
using InsuranceApp.Domain;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SamuraiApp.UI
{
    class Program
    {
        private static InsuranceContext _context = new InsuranceContext();

        private static void Main(string[] args)
        {
            //AddInsurancesByName("Życie jest ważne", "OC firmy", "Nowa Jakość ubezpieczeń", "Ubezpiecz się");
            //AddVariousTypes();
            GetInsurances();
            //AddInsuranceCompanyToExistingInsuranceNotTracked(5);
            //RetrieveAndUpdateInsurance();
            //RetrieveAndUpdateMultipleInsurances();
            //GetInsurances();
            //QueryAggregates();
            //QueryFilters();
            //string[] insurees = new string[4] { "John", "Jeremy", "Jane", "Bob" };
            //AddInsurees(insurees);
            //EagerLoadInsurancesWithCompanies();
            ProjectSomeProperties();
            Console.Write("Press any key...");
            Console.ReadKey();
        }

        private static void AddInsurancesByName(params string[] names)
        {
            foreach (string name in names)
            {
                _context.Insurances.Add(new Insurance { Name = name });
            }
            _context.SaveChanges();
        }

        private static void AddVariousTypes()
        {
            _context.Insurances.AddRange(
                new Insurance { Name = "Poważne choroby" },
                new Insurance { Name = "Poważniejsze choroby" }
                );
            _context.InsuranceCompanies.AddRange(
                new InsuranceCompany { Text = "Allianz", InsuranceId = 1 },
                new InsuranceCompany { Text = "NN", InsuranceId = 2 }
                );
            _context.SaveChanges();
        }

        private static void GetInsurances()
        {
            var insurances = _context.Insurances
                .TagWith("ConsoleApp.Program.GetInsurances method")
                .ToList();
            Console.WriteLine($"Insurances count is {insurances.Count}");
            foreach (var insurance in insurances)
            {
                Console.WriteLine(insurance.Name);
            }
        }

        private static void QueryFilters()
        {
            var insurances = _context.Insurances.Where(i => i.Name == "OC").ToList();
        }

        private static void QueryAggregates()
        {
            var insurance = _context.Insurances.Where(i => i.Name == "OC").FirstOrDefault();
        }

        private static void RetrieveAndUpdateInsurance()
        {
            var insurance = _context.Insurances.Where(i => i.Name == "OC").FirstOrDefault();
            insurance.Name += "/AC";
            _context.SaveChanges();
        }

        private static void RetrieveAndUpdateMultipleInsurances()
        {
            var insurances = _context.Insurances.Skip(3).Take(5).ToList();
            Console.WriteLine("Insurances to Edit: ");
            foreach(Insurance insurance in insurances)
            {
                Console.WriteLine(insurance.Name);
                insurance.Name += "_PZU";
                Console.WriteLine(insurance.Name);
                _context.SaveChanges();
            }
        }

        private static void AddInsurees(string[] names)
        {
            foreach (string name in names)
            {
                _context.Insurees.Add(new Insuree { Name = name });
            }
            _context.SaveChanges();
        }

        private static void AddInsuranceCompanyToExistingInsuranceNotTracked(int insuranceId)
        {
            var insurance = _context.Insurances.Find(insuranceId);

            insurance.InsuranceCompanies.Add(new InsuranceCompany { Text = "Aviva" });

            using(var newContext = new InsuranceContext())
            {
                newContext.Insurances.Update(insurance);
                newContext.SaveChanges();
            }
        }

        private static void EagerLoadInsurancesWithCompanies()
        {
            var insurancesWithCompanies = _context.Insurances.Include(i => i.InsuranceCompanies).ToList();
        }

        private static void ProjectSomeProperties()
        {
            var someProperties = _context.Insurances.Select(i => new { i.Id, i.InsuranceCompanies, i.Insurees }).ToList();
        }
    }
}
