using HTTPMethods.Fake;
using HTTPMethods.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HTTPMethods.Controllers
{
    //[Route("api/Users")]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private List<User> _users = FakeData.GetUsers(200);

        [HttpGet]
        public List<User> Get()
        {
            return _users;
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        [HttpPost]
        public User Post([FromBody] User user)
        {
            _users.Add(user);
            return user;
        }

        [HttpPut]
        public User Put([FromBody] User user)
        {
            var EditorUser = _users.FirstOrDefault(u => u.Id == user.Id);

            EditorUser.Firstname = user.Firstname;
            EditorUser.Lastname = user.Lastname;
            EditorUser.Address = user.Address;

            return EditorUser;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var DeletedUser = _users.FirstOrDefault(u => u.Id == id);
            _users.Remove(DeletedUser);
        }
    }
}
