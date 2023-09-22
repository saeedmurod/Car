using Car;

CarDatabase honda = CarDatabase.Instance;
honda.AddCar("Honda", "Civic", 1, 8000);
while (true)
{
    Console.WriteLine("Enter a command (count types, count all, average price, average price type, exit):");
    string command = Console.ReadLine().ToLower();

    switch (command)
    {
        case "count types":
            Console.WriteLine($"Number of car brands: {CarDatabase.Instance.CountTypes()}");
            break;
        case "count all":
            Console.WriteLine($"Total number of cars: {CarDatabase.Instance.CountAll()}");
            break;
        case "average price":
            Console.WriteLine($"Average cost of a car: {CarDatabase.Instance.AveragePrice():C}");
            break;
        case "average price type":
            Console.WriteLine("Enter the car brand:");
            string brand = Console.ReadLine();
            decimal averagePrice = CarDatabase.Instance.AveragePriceByBrand(brand);
            Console.WriteLine($"Average cost of {brand} cars: {averagePrice:C}");
            break;
        case "exit":
            return;
        default:
            Console.WriteLine("Invalid command.");
            break;
    }
}