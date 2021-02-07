using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class TestColor
    {
        public static void ListColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Id + " -- " + color.Name);
            }
        }

        public static void AddColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color newColor = new Color();
            Console.Write("Marka Giriniz:");
            newColor.Name = Console.ReadLine();
            colorManager.Add(newColor);
        }

        public static void UpdateColor(int id)
        {
            try
            {
                ColorManager colorManager = new ColorManager(new EfColorDal());
                var updatedColor = colorManager.GetById(id);
                Console.WriteLine("Markanın Adını Giriniz: ");
                updatedColor.Name = Console.ReadLine();
                colorManager.Update(updatedColor);

                Console.WriteLine("Renk Başarıyla Güncellendi");
            }
            catch (Exception)
            {
                throw new Exception("Renk Güncellenemedi");
            }

        }

        public static void DeleteBrand(int id)
        {
            try
            {
                ColorManager colorManager = new ColorManager(new EfColorDal());
                var deletedColor = colorManager.GetById(id);
                colorManager.Delete(deletedColor);
                Console.WriteLine("Seçilen Renk Başarıyla Silindi");
            }
            catch (Exception)
            {
                throw new Exception("Renk Silinemedi");
            }

        }
    }
}
