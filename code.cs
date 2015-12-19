using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnderstandingLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> myCars = new List<Car>() {
                new Car() { Make="BMW", Model="550i", Color=CarColor.Blue, StickerPrice=55000, Year=2009 },
                new Car() { Make="Toyota", Model="4Runner", Color=CarColor.White, StickerPrice=35000, Year=2010 },
                new Car() { Make="BMW", Model="745li", Color=CarColor.Black, StickerPrice=75000, Year=2008 },
                new Car() { Make="Ford", Model="Escape", Color=CarColor.White, StickerPrice=28000, Year=2008 },
                new Car() { Make="BMW", Model="550i", Color=CarColor.Black, StickerPrice=57000, Year=2010 }
            };
            // (LINQ method syntax style) selecting from a collection - BMW's from yr 2010
            var _bmws = myCars.Where(p => p.Year == 2010).Where(p => p.Make == "BMW");

            //(LINQ method syntax style) order collection by Year
            var _orderedCars = myCars.OrderByDescending(p => p.Year);

            //(LINQ method syntax style) sum all sticker prices
            var sum = myCars.Sum(p => p.StickerPrice);

            //(LINQ querery syntax) selecting from a collection- BMW's from yr 2010 or 2008
            var bmws = from car in myCars
                       where car.Make == "BMW"
                       && car.Year == 2010
                       select new { car.Make, car.Model, car.Year }; //new data type

            //(LINQ querery syntax) myCars listed from oldest to newest
            var orderedCarsOld = from car in myCars
                              orderby car.Year
                              select car;

            //(LINQ querery syntax) myCars listed from newest to oldest
            var orderedCarsNew = from car in myCars
                              orderby car.Year descending
                              select car;

            foreach (var car in orderedCarsOld)
            {
                Console.WriteLine("{0} {1} - {2}", car.Make, car.Model, car.Year);
            }

            Console.ReadLine();

        }
    }

    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double StickerPrice { get; set; }
        public CarColor Color { get; set; }
    }

    enum CarColor
    {
        White,
        Black,
        Red,
        Blue,
        Yellow
    }

}
