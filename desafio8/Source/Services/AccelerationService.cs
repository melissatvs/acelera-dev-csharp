using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class AccelerationService : IAccelerationService
    {
        CodenationContext db;
        public AccelerationService(CodenationContext context)
        {
            db = context;
        }

        public IList<Acceleration> FindByCompanyId(int companyId)
        {
            return db.Candidates.Where(x => x.CompanyId == companyId).Select(c => c.Acceleration).Distinct().ToList();
        }

        public Acceleration FindById(int id)
        {
            return db.Accelerations.First(x => x.Id == id);
        }

        public Acceleration Save(Acceleration acceleration)
        {
            Acceleration Result;

            if (acceleration.Id == 0)
            {
                db.Accelerations.Add(acceleration);

                Result = acceleration;
            }
            else
            {
                Result = FindById(acceleration.Id);

                Result.Name = acceleration.Name;
                Result.Slug = acceleration.Slug;
                Result.ChallengeId = acceleration.ChallengeId;
                Result.CreateAt = acceleration.CreateAt;
            }

            db.SaveChanges();

            return Result;
        }
    }
}
