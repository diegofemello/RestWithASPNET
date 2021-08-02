using RestWithASPNET.Data.Converter.Implementations;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Repository;
using System.Collections.Generic;

namespace RestWithASPNET.Services.Implementations
{
    public class UserServiceImplementation : IUserService
    {

        private readonly IUserRepository _repository;

        private readonly UserConverter _converter;

        public UserServiceImplementation(IUserRepository repository)
        {
            _repository = repository;
            _converter = new UserConverter();
        }

        public List<UserVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public UserVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public UserVO Create(UserVO user)
        {
            var userEntity = _converter.Parse(user);
            userEntity = _repository.Create(userEntity);
            return _converter.Parse(userEntity);
        }

        public UserVO Update(UserVO user)
        {
            var userEntity = _converter.Parse(user);
            userEntity = _repository.Update(userEntity);
            return _converter.Parse(userEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}