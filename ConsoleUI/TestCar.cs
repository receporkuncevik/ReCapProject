using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class TestCar
    {
        public static void ListCarWithDetail()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName + " -- " + car.BrandName + " -- " + car.ColorName + " -- " + car.DailyPrice);
            }
        }

        public static void ListCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Id + " -- " + car.Name);
            }
        }

        public static void AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("Lütfen bir Araba ekleyiniz");
            Console.Write("Araba İsmi: ");
            string carName = Console.ReadLine();
            Console.Write("Araba Fiyati: ");
            decimal carPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Araba Model Yılı: ");
            int carYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Araba Açıklaması: ");
            string carDescription = Console.ReadLine();

            Car car1 = new Car();
            car1.BrandId = 1;
            car1.ColorId = 2;
            car1.DailyPrice = carPrice;
            car1.Name = carName;
            car1.ModelYear = carYear;
            car1.Description = carDescription;

            carManager.Add(car1);
        }

        public static void DeleteCar(int id)
        {
            try
            {
                CarManager carManager = new CarManager(new EfCarDal());
                var silinecekAraba = carManager.GetById(id);
                carManager.Delete(silinecekAraba.Data);
            }
            catch (Exception)
            {

                throw new Exception("Araba Silinemedi");
            }
        }

        public static void UpdateCar(int id)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var updateCar = carManager.GetById(id);

            Console.Write("Araba İsmi: ");
            string carName = Console.ReadLine();
            Console.Write("Araba Fiyati: ");
            decimal carPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Araba Model Yılı: ");
            int carYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Araba Açıklaması: ");
            string carDescription = Console.ReadLine();

            updateCar.Data.BrandId = 2;
            updateCar.Data.ColorId = 1;
            updateCar.Data.DailyPrice = carPrice;
            updateCar.Data.Name = carName;
            updateCar.Data.ModelYear = carYear;
            updateCar.Data.Description = carDescription;

            carManager.Update(updateCar.Data);

        }

    }
}
