﻿using LMSData.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LMSDBContext _context;
        public UserController(LMSDBContext context)
        {
            //_context = new LMSDBContext();
            _context = context;
        }

        [HttpGet]
        public List<User> Get()
        {
            return _context.Users.ToList();
        }


        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _context.Users.Find(id);
        }

        [HttpPost]
        public void Post([FromBody] User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        [HttpPut]
        public User Put([FromBody]User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }


    }
}
