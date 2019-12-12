using System;
using System.Collections.Generic;
using Xunit;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using System.Linq;

namespace Codenation.Challenge
{
    public class UserServiceTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Return_Right_User_When_Find_By_Id(int id)
        {
            var fakeContext = new FakeContext("UserById");
            fakeContext.FillWith<User>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var expected = fakeContext.GetFakeData<User>().Find(x => x.Id == id);

                var service = new UserService(context);
                var actual = service.FindById(id);

                Assert.Equal(expected, actual, new UserIdComparer());
            }
        }

        /*[Theory]
        [InlineData("Velvet Grass")]
        [InlineData("Progesterone")]
        [InlineData("Temazepam")]
        public void Should_Return_Right_User_When_Find_By_Acceleration(string name)
        {
            var fakeContext = new FakeContext("UserByAccelerationName");
            fakeContext.FillWith<User>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {

                //int accelerationId = fakeContext.GetFakeData<Acceleration>().Find(x => x.Name == name).Id;
                //List<Candidate> candidates = fakeContext.GetFakeData<Candidate>().FindAll(x => x.AccelerationId == accelerationId);
                //List<User> expected = candidates.Select(c => c.User).ToList();

                List<User> expected =
                    fakeContext
                    .GetFakeData<Candidate>()
                    .FindAll(x => x.AccelerationId == fakeContext.GetFakeData<Acceleration>().Find(a => a.Name == name).Id)
                    .Select(c => c.User)
                    .ToList();

                var service = new UserService(context);
                var actual = service.FindByAccelerationName(name);

                Assert.Equal(expected, actual);
            }
        }*/

        [Fact]
        public void Should_Add_New_User_When_Save()
        {
            var fakeContext = new FakeContext("SaveNewUser");

            var fakeUser = new User();
            fakeUser.FullName = "full name";
            fakeUser.Email = "email";
            fakeUser.Nickname = "nickname";
            fakeUser.Password = "pass";
            fakeUser.CreateAt = DateTime.Today;

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var service = new UserService(context);
                var actual = service.Save(fakeUser);

                Assert.NotEqual(0, actual.Id);
            }
        }

    }
}
