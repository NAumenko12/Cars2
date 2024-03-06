using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carss
{
    public abstract class Car
    {
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public int Distance { get; set; }
        public int CurrentSpeed { get; set; }

        public Car(string name, int maxSpeed, int distance)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            Distance = distance;
            CurrentSpeed = 0;
        }

        public abstract void Move();
    }

    public class SportsCar : Car
    {
        public SportsCar(string name, int maxSpeed, int distance) : base(name, maxSpeed, distance) { }

        public override void Move()
        {
            Accelerate();
            Distance += CurrentSpeed;
        }

        public void Accelerate()
        {
            if (CurrentSpeed < MaxSpeed)
            {
                CurrentSpeed += 20;
                if (CurrentSpeed > MaxSpeed)
                {
                    CurrentSpeed = MaxSpeed;
                }
            }
        }
    }

    public class Truck : Car
    {
        public Truck(string name, int maxSpeed, int distance) : base(name, maxSpeed, distance) { }

        public override void Move()
        {
            Accelerate();
            Distance += CurrentSpeed;
        }

        public void Accelerate()
        {
            if (CurrentSpeed < MaxSpeed)
            {
                CurrentSpeed += 5;
                if (CurrentSpeed > MaxSpeed)
                {
                    CurrentSpeed = MaxSpeed;
                }
            }
        }
    }

    public abstract class CarFactory
    {
        public abstract Car CreateCar(string name, int maxSpeed, int distance);
    }

    public class SportsCarFactory : CarFactory
    {
        public override Car CreateCar(string name, int maxSpeed, int distance)
        {
            return new SportsCar(name, maxSpeed, distance);
        }
    }

    public class TruckFactory : CarFactory
    {
        public override Car CreateCar(string name, int maxSpeed, int distance)
        {
            return new Truck(name, maxSpeed, distance);
        }
    }
}
