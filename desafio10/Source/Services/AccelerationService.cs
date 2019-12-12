using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class AccelerationService : IAccelerationService
    {
        private CodenationContext context;
        public AccelerationService(CodenationContext context)
        {
            this.context = context;
        }

        public IList<Acceleration> FindByCompanyId(int companyId)
        {
            return context.Candidates.
                Where(x => x.CompanyId == companyId).
                Select(x => x.Acceleration).
                Distinct().
                ToList();
        }

        public Acceleration FindById(int id)
        {
            return context.Accelerations.Find(id);
        }

        public Acceleration Save(Acceleration acceleration)
        {
            var state = acceleration.Id == 0 ? EntityState.Added : EntityState.Modified;
            context.Entry(acceleration).State = state;
            context.SaveChanges();
            return acceleration;
        }
    }
}
