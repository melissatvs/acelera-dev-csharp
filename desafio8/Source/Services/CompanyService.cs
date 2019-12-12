using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class CompanyService : ICompanyService
    {
        CodenationContext db;

        public CompanyService(CodenationContext context)
        {
            db = context;
        }

        public IList<Company> FindByAccelerationId(int accelerationId)
        {
            return db.Candidates.Where(c => c.AccelerationId == accelerationId).Select(ca => ca.Company).ToList();
        }

        public Company FindById(int id)
        {
            return db.Companies.First(c => c.Id == id);
        }

        public IList<Company> FindByUserId(int userId)
        {
            return db.Candidates.Where(c => c.UserId == userId).Select(ca => ca.Company).Distinct().ToList();
        }

        public Company Save(Company company)
        {
            Company Result;

            if (company.Id == 0)
            {
                db.Companies.Add(company);

                Result = company;
            }
            else
            {
                Result = FindById(company.Id);

                Result.Name = company.Name;
                Result.Slug = company.Slug;
                Result.CreateAt = company.CreateAt;
            }

            db.SaveChanges();

            return Result;
        }
    }
}