using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        private readonly List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car() {
                    CarId = 1, BrandId = 1, ColorId = 2, ModelYear = 1982, DailyPrice = 200000, Description = "Klasik"},
                new Car() {
                    CarId = 2, BrandId = 2, ColorId = 3, ModelYear = 2005, DailyPrice = 500000,Description = "Kazalı"},
                new Car() {
                    CarId = 3, BrandId = 3, ColorId = 1, ModelYear = 2012, DailyPrice = 350000, Description = "Dizel"
                },
            };
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.CarId == id);
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            if (carToUpdate == null) return;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }
    }
}
