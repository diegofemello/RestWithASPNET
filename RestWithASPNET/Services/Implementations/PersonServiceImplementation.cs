using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RestWithASPNET.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySQLContext _context;

        public PersonServiceImplementation(MySQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        

        public Person FindByID(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Diego",
                LastName = "Mello",
                Address = "Rio de Janeiro",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {

            return person;
        }
        
    }
}
