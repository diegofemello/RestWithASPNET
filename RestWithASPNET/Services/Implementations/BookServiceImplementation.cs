using RestWithASPNET.Data.Converter.Implementations;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using RestWithASPNET.Repository;
using System.Collections.Generic;

namespace RestWithASPNET.Services.Implementations
{
    public class BookServiceImplementation : IBookService
    {

        private readonly IRepository<Book> _repository;

        private readonly BookConverter _converter;

        public BookServiceImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        // Method responsible for returning all people,
        public List<BookVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        // Method responsible for returning one person by ID
        public BookVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        // Method responsible to crete one new person
        public BookVO Create(BookVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        // Method responsible for updating one person
        public BookVO Update(BookVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        // Method responsible for deleting a person from an ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
