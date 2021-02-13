using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice>0 && car.Description.Length>2)//Both turns true
            {
                _carDal.Add(car);
                Console.WriteLine("Car Id:" + car.Id + "Added with" + car.DailyPrice + "Daily Price succesful");
            }
            else if (car.DailyPrice <= 0 && car.Description.Length > 2)
            {
                Console.WriteLine("Hata!!!! Lütfen Daily Price değerini 0'dan büyük giriniz.");

            }
            else if (car.DailyPrice > 0 && car.Description.Length <=2)
            {
                Console.WriteLine("Hata!!!! Lütfen Description  değerini 2'dan büyük giriniz.");
            }
            else
            {
                Console.WriteLine("Hataa!!! Description ve daily price alanları hatalı");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
