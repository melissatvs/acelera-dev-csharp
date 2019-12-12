using System.Collections.Generic;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public interface IUserService    
    {
        User FindById(int id);
        IList<User> FindByAccelerationName(string name);
        IList<User> FindByCompanyId(int companyId);
        User Save(User user);
    }
}
