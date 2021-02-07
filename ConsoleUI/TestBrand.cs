using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class TestBrand
    {

        public static void ListBrands()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Id + " -- " + brand.Name);
            }
        }

        public static void AddBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand newBrand = new Brand();
            Console.Write("Marka Giriniz:");
            newBrand.Name = Console.ReadLine();
            brandManager.Add(newBrand);
        }

        public static void UpdateBrand(int id)
        {
            try
            {
                BrandManager brandManager = new BrandManager(new EfBrandDal());
                var updatedBrand = brandManager.GetById(id);
                Console.WriteLine("Markanın Adını Giriniz: ");
                updatedBrand.Name = Console.ReadLine();
                brandManager.Update(updatedBrand);

                Console.WriteLine("Marka Başarıyla Güncellendi");
            }
            catch (Exception)
            {
                throw new Exception("Marka Güncellenemedi");
            }
            
        }

        public static void DeleteBrand(int id)
        {
            try
            {
                BrandManager brandManager = new BrandManager(new EfBrandDal());
                var deletedBrand = brandManager.GetById(id);
                brandManager.Delete(deletedBrand);
                Console.WriteLine("Seçilen Marka Başarıyla Silindi");
            }
            catch (Exception)
            {
                throw new Exception("Marka Silinemedi");
            }
            
        }

    }
}
