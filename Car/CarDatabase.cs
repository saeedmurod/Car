using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    public class CarDatabase
    {
        private static CarDatabase instance;
        private readonly Dictionary<string, List<Car>> data;

        private CarDatabase()
        {
            data = new Dictionary<string, List<Car>>();
        }

        public static CarDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CarDatabase();
                }
                return instance;
            }
        }

        public void AddCar(string brand, string model, int quantity, decimal cost)
        {
            if (!data.ContainsKey(brand))
            {
                data[brand] = new List<Car>();
            }

            data[brand].Add(new Car { Model = model, Quantity = quantity, Cost = cost });
        }

        public int CountTypes()
        {
            return data.Count;
        }

        public int CountAll()
        {
            return data.Values.Sum(brandData => brandData.Sum(car => car.Quantity));
        }

        public decimal AveragePrice()
        {
            int totalQuantity = data.Values.SelectMany(brandData => brandData).Sum(car => car.Quantity);
            decimal totalPrice = data.Values.SelectMany(brandData => brandData).Sum(car => car.Quantity * car.Cost);

            if (totalQuantity == 0)
            {
                return 0;
            }

            return totalPrice / totalQuantity;
        }

        public decimal AveragePriceByBrand(string brand)
        {
            if (data.ContainsKey(brand))
            {
                var brandData = data[brand];
                int totalQuantity = brandData.Sum(car => car.Quantity);
                decimal totalPrice = brandData.Sum(car => car.Quantity * car.Cost);

                if (totalQuantity == 0)
                {
                    return 0;
                }

                return totalPrice / totalQuantity;
            }

            return 0;
        }

        public IEnumerable<string> GetBrands()
        {
            return data.Keys;
        }
    }
}
