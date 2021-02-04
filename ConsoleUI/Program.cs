using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {   
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car();
            car1.BrandId = 1;
            car1.ColorId = 2;
            car1.DailyPrice = 150000;
            car1.Description = "Chevrolet Camaro";
            car1.ModelYear = 2019;

            carManager.Add(car1);
            
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description + " " + car.DailyPrice + "TL");
            }
        }
    }
}
