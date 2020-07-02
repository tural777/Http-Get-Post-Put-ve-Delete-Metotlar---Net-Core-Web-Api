using Bogus;
using HTTPMethods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HTTPMethods.Fake
{
    public static class FakeData
    {
        private static List<User> _users;

        public static List<User> GetUsers(int count)
        {
            if (_users == null)
                _users = new Faker<User>()
                    .RuleFor(u => u.Id, f => f.IndexFaker + 1)
                    .RuleFor(u => u.Firstname, f => f.Name.FirstName())
                    .RuleFor(u => u.Lastname, f => f.Name.LastName())
                    .RuleFor(u => u.Address, f => f.Address.FullAddress())
                    .Generate(count);

            return _users;
        }
    }
}
