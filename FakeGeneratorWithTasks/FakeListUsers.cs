using Bogus;
using System.Collections.Generic;

namespace FakeGeneratorWithTasks
{
    public class FakeListUsers
    {
        public List<User> GetUsers(int usersCount)
        {
            var userId = 1;
            var personsFaker = new Faker<User>()
                .CustomInstantiator(f => new User(userId++))
                .RuleFor(o => o.FirstName, f => f.Name.FirstName())
                .RuleFor(o => o.LastName, f => f.Name.LastName())
                .RuleFor(o => o.BirthDate, f => f.Date.Past(20))
                .RuleFor(o => o.Salary, f => f.Random.Decimal(100, 50000))
                ;
            var persons = personsFaker.Generate(usersCount);
            return persons;
        }
    }
}