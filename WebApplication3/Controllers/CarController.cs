using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Models.ViewModels;

namespace WebApplication3.Controllers
{
    public class CarController : Controller
    {
        private static List<Car> cars = new()
        {
            new Car { Id = 1,Make = "Hyundai",Model = "Elantra",Price = 28000,Year = 2020,Color = "Silver",EngineSize = 1600},
            new Car {Id = 2, Make = "Ford", Model = "Mustang", Price = 45000, Year = 2023, Color = "Black", EngineSize = 2500},
            new Car {Id = 3, Make = "Chevrolet", Model = "Camaro", Price = 42000, Year = 2022, Color = "Yellow", EngineSize = 3000},
            new Car {Id = 4, Make = "BMW", Model = "3 Series", Price = 40000, Year = 2021, Color = "Blue", EngineSize = 2000},
            new Car {Id = 5, Make = "Toyota", Model = "Supra", Price = 45000, Year = 2012, Color = "Dark", EngineSize = 10000},
            new Car {Id = 6, Make = "Toyota", Model = "Camry", Price = 25000, Year = 2022, Color = "Silver", EngineSize = 2000},
            new Car {Id = 7, Make = "BMW", Model = "X5", Price = 65000, Year = 2023, Color = "White", EngineSize = 3500},
            new Car {Id = 8, Make = "Honda", Model = "Accord", Price = 28000, Year = 2021, Color = "Red", EngineSize = 1800},
            new Car {Id = 9, Make = "Ford", Model = "Mustang GT", Price = 50000, Year = 2022, Color = "Red", EngineSize = 5000},
            new Car {Id = 10, Make = "Mercedes-Benz", Model = "C-Class", Price = 45000, Year = 2020, Color = "White", EngineSize = 2500},
        };

        public IActionResult Index()
        {
            return View(cars);
        }

        [HttpGet]
        public IActionResult AddCar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCar(AddCarViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var car = new Car()
                {
                    Id = cars[cars.Count - 1].Id + 1,
                    Make = vm.Make,
                    Model = vm.Model,
                    Year = vm.Year,
                    Price = vm.Price,
                    Color = vm.Color,
                    EngineSize = vm.EngineSize,

                };
                cars.Add(car);
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult DeleteCar(int Id)
        {

            var car = cars.FirstOrDefault(car => car.Id == Id);
            if (car != null)
                cars.Remove(car);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult SearchCars(string carName)
        {
            if (string.IsNullOrWhiteSpace(carName))
                return RedirectToAction("Index");

            List<Car> searchCar = new();

            foreach (var item in cars)
            {
                if (item.Model.ToLower().Contains(carName.ToLower()) || item.Make.ToLower().Contains(carName.ToLower()))
                {
                    searchCar.Add(item);
                }
            }
            return View(searchCar);
        }
    }
}
