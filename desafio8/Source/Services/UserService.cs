using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {
        CodenationContext db;

        public UserService(CodenationContext context)
        {
            db = context;
        }

        public IList<User> FindByAccelerationName(string name)
        {                          
            return db.Candidates.Where(c => c.Acceleration.Name == name).Select(s => s.User).ToList();
        }

        public IList<User> FindByCompanyId(int companyId)
        {
            return db.Candidates.Where(c => c.CompanyId == companyId).Select(s => s.User).Distinct().ToList();
        }

        public User FindById(int id)
        {
            return db.Users.First(c => c.Id == id);
        }

        public User Save(User user)
        {
            User Result;

            if (user.Id == 0)
            {                
                db.Users.Add(user);

                Result = user;
            }
            else
            {
                Result = FindById(user.Id);

                Result.FullName = user.FullName;
                Result.Email = user.Email;
                Result.Nickname = user.Nickname;
                Result.Password = user.Password;                
                Result.CreateAt = user.CreateAt;                
            }

            db.SaveChanges();

            return Result;
        }
    }
}
