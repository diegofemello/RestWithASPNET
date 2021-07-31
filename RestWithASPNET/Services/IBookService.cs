using RestWithASPNET.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNET.Services
{
    public interface IBookService
    {
        BookVO Create(BookVO book);
        BookVO FindByID(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}