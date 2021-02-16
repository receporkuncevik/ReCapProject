using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new Result(true, "Kullanıcı Başarıyla eklendi.");
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new Result(true, "Kullanıcı Başarıyla silindi.");
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),"Kullanıcılar Başarıyla Listelendi.");
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId),"İstenilen Kullanıcı Başarıyla getirildi.");
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new Result(true, "Kullanıcı Başarıyla güncellendi.");
        }
    }
}
