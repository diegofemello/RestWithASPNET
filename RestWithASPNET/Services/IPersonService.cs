using RestWithASPNET.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNET.Services
{
    public interface IPersonService
    {
        PersonVO Create(PersonVO person);
        PersonVO FindByID(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}