using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class ChallengeService : IChallengeService
    {
        CodenationContext db;
        public ChallengeService(CodenationContext context)
        {
            db = context;
        }

        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {
            return db.Candidates.Where(x => x.AccelerationId == accelerationId && x.UserId == userId).Select(s => s.Acceleration.Challenge).Distinct().ToList();
        }

        public Models.Challenge Save(Models.Challenge challenge)
        {
            Models.Challenge Result;

            if (challenge.Id == 0)
            {
                db.Challenges.Add(challenge);

                Result = challenge;
            }
            else
            {
                Result = db.Challenges.First(x => x.Id == challenge.Id);

                Result.Name = challenge.Name;
                Result.Slug = challenge.Slug;
                Result.CreateAt = challenge.CreateAt;
            }

            db.SaveChanges();

            return Result;
        }
    }
}