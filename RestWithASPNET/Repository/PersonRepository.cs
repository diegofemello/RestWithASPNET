using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using RestWithASPNET.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(MySQLContext context) : base(context) { }

        public Person Disable(long id)
        {
            if (!_context.Persons.Any(p => p.Id.Equals(id))) return null;
            var user = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if (user != null) 
            {
                user.Enabled = false;
                try
                {
                    _context.Entry(user).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return user;
        }

        public List<Person> FindByName(string firstName, string lastName)
        {
            var stringFirst = string.IsNullOrWhiteSpace(firstName);
            var stringLast = string.IsNullOrWhiteSpace(lastName);


            if (!stringFirst && !stringLast)
            {
                return _context.Persons.Where(
                    p => p.FirstName.Contains(firstName) &&
                    p.LastName.Contains(lastName)).ToList();
            }
            else if (stringFirst && !stringLast)
            {
                return _context.Persons.Where(
                    p => p.LastName.Contains(lastName)).ToList();
            }
            else if (!stringFirst && stringLast)
            {
                return _context.Persons.Where(
                    p => p.FirstName.Contains(firstName)).ToList();
            }
            return null;

        }
    }
}
