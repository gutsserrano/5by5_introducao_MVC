﻿using Models;
using Repositories;
using Services;

namespace Controllers
{
    public class CarController
    {
        private CarService _carService;

        public CarController()
        {
            _carService = new CarService();
        }

        public bool Insert(Car car)
        {
            return _carService.Insert(car);
        }

        public bool Update(Car car)
        {
            return _carService.Update(car);
        }

        public bool Delete(int id)
        {
            return _carService.Delete(id);
        }

        public List<Car> GetAll()
        {
            return _carService.GetAll();
        }

        public Car Get(int id)
        {
            return _carService.Get(id);
        }
    }
}
