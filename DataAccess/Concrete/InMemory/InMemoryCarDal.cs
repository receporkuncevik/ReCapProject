using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=2,ColorId=1,ModelYear=2015,DailyPrice=75000,Description="Hatasız."},
                new Car{Id=2,BrandId=1,ColorId=3,ModelYear=2021,DailyPrice=175000,Description="Dosta Gider."},
                new Car{Id=3,BrandId=3,ColorId=5,ModelYear=2018,DailyPrice=90000,Description="Öğretmenden."},
                new Car{Id=4,BrandId=4,ColorId=4,ModelYear=2019,DailyPrice=120000,Description="Doktordan temiz kullanılmış"},
                new Car{Id=5,BrandId=5,ColorId=3,ModelYear=2020,DailyPrice=145000,Description="Ne olursan ol yine gel."}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
