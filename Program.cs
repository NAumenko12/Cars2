using Carss;
namespace CarRace
{
    public class Program
    {
        static void Main()
        {
            CarFactory sportsCarFactory = new SportsCarFactory();
            Car car1 = sportsCarFactory.CreateCar("Car1", 150, 0);

            CarFactory truckFactory = new TruckFactory();
            Car car2 = truckFactory.CreateCar("Truck1", 120, 0);

            List<Car> cars = new List<Car>
             {
            car1,
            car2
             };

            while (true)
            {
                Console.Clear();
                foreach (var car in cars)
                {
                    car.Move();
                    Console.WriteLine($"Car: {car.Name}, Speed: {car.CurrentSpeed}, Distance: {car.Distance}");
                }

                if (cars.TrueForAll(c => c.Distance >= 1000))
                {
                    Console.WriteLine("\nRace finished!");
                    cars.Sort((x, y) => y.Distance.CompareTo(x.Distance));
                    for (int i = 0; i < cars.Count; i++)
                    {
                        Console.WriteLine($"Position {i + 1}: {cars[i].Name}");
                    }
                    break;
                }

                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
