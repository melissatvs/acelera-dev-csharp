using System.Collections.Generic;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public interface IAccelerationService    
    {
        Acceleration FindById(int id);
        IList<Acceleration> FindByCompanyId(int companyId);
        Acceleration Save(Acceleration acceleration);
    }
}
