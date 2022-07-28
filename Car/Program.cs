namespace BuilderDesignPattern;

public class Program
{
    class Car
    {
        public string? Type { get; set; }
        public string? Model { get; set; }
        public double Engine { get; set; }
        public string? Make { get; set; }
        public string? BrakeType { get; set; }
        public int Seats { get; set; }
        public int CargoSpace { get; set; }
        public int FuelCapacity { get; set; }
        public bool HasGPS { get; set; }
        public bool HasTripComputer { get; set; }

        public override string ToString()
=> @$"
        Model {Model}
        Engine {Engine}
        Make {Make}
        Brake Type {BrakeType}
        Seats {Seats}
        Cargo Space {CargoSpace}
        Fuel Capacity {FuelCapacity}
        HasGPS {HasGPS}
        HasTripComputer {HasTripComputer}
      ";

        public Car GetResult()
        {
            return new Car();
        }

    }
    interface IBuilder
    {
        Car Car { get; set; }
        IBuilder SetSeats(int number);
        IBuilder SetFuelCapacity(int fuel);
        IBuilder SetCargoSpace(int cargo);
        IBuilder SetModel(string model);
        IBuilder SetBrakeTye(string brakeType);
        IBuilder SetMake(string make);
        IBuilder SetEngine(double engine);
        IBuilder SetTripComputer();
        IBuilder SetGPS();
        void Reset();
        Car Build();
    }
    class CarBuilder : IBuilder
    {
        public Car Car { get; set; } = new Car() { Type = "Automatic Car" };

        public Car GetResult()
        {
            return Car;
        }

        public void Reset() => Car = new Car();


        public IBuilder SetEngine(double engine)
        {
            Car.Engine = engine;
            return this;
        }

        public IBuilder SetFuelCapacity(int fuel)
        {
            Car.FuelCapacity = fuel;
            return this;
        }

        public IBuilder SetCargoSpace(int cargo)
        {
            Car.CargoSpace = cargo;
            return this;
        }

        public IBuilder SetGPS()
        {
            Car.HasGPS = true;
            return this;
        }

        public IBuilder SetBrakeTye(string brakeType)
        {
            Car.BrakeType = brakeType;
            return this;
        }

        public IBuilder SetMake(string make)
        {
            Car.Make = make;
            return this;
        }

        public IBuilder SetModel(string model)
        {
            Car.Model = model;
            return this;
        }

        public IBuilder SetSeats(int seats)
        {
            Car.Seats = seats;
            return this;
        }

        public IBuilder SetTripComputer()
        {
            Car.HasTripComputer = true;
            return this;
        }
        public Car Build() => Car;

    }
    class CarManualBuilder : IBuilder
    {
        public Car Car { get; set; } = new Car { Type = "Manual Car" };

        public Car GetResult()
        {
            return Car;
        }

        public void Reset() => Car = new Car();


        public IBuilder SetEngine(double engine)
        {
            Car.Engine = engine;
            return this;
        }

        public IBuilder SetBrakeTye(string brakeType)
        {
            Car.BrakeType = brakeType;
            return this;
        }

        public IBuilder SetGPS()
        {
            Car.HasGPS = true;
            return this;
        }

        public IBuilder SetCargoSpace(int cargo)
        {
            Car.CargoSpace = cargo;
            return this;
        }

        public IBuilder SetFuelCapacity(int fuel)
        {
            Car.FuelCapacity = fuel;
            return this;
        }

        public IBuilder SetMake(string make)
        {
            Car.Make = make;
            return this;
        }

        public IBuilder SetModel(string model)
        {
            Car.Model = model;
            return this;
        }

        public IBuilder SetSeats(int seats)
        {
            Car.Seats = seats;
            return this;
        }

        public IBuilder SetTripComputer()
        {
            Car.HasTripComputer = true;
            return this;
        }
        public Car Build() => Car;
    }
    class Director
    {
        public void MakeSUV(IBuilder builder)
        {
            builder.Reset();
            builder.SetMake("Toyota");
            builder.SetModel("Corola");
            builder.Reset();
            builder.SetBrakeTye("2-Wheel Disc");            
            builder.SetSeats(5);
            builder.SetFuelCapacity(45);
            builder.SetEngine(2.0);
            builder.SetCargoSpace(20);
            builder.SetTripComputer();
            builder.SetGPS();
        }
        public void MakeSportCars(IBuilder builder)
        {
            builder.Reset();
            builder.SetMake("Aston Martin");
            builder.SetModel("DBX 707");
            builder.SetBrakeTye("4-Wheel Disc");
            builder.SetSeats(2);
            builder.SetCargoSpace(30);
            builder.SetEngine(3.5);
            builder.SetFuelCapacity(60);
            builder.SetTripComputer();
            builder.SetGPS();
        }
    }
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;

        Director director = new Director();
        CarBuilder builder = new CarBuilder();
        director.MakeSportCars(builder);
        Car car = builder.GetResult();
        Console.WriteLine(car);


        IBuilder builder1 = new CarBuilder();
        Car carAutomatic = builder1
            .SetMake("Toyota RAV4")
            .SetModel("A-class")
            .SetEngine(3.5)
            .SetFuelCapacity(65)
            .SetGPS()
            .SetCargoSpace(28)
            .SetSeats(5)
            .SetBrakeTye("4 - Wheel Disc")
            .Build();
        Console.WriteLine(carAutomatic);

        IBuilder builder2 = new CarManualBuilder();
        Car carManual = builder2
            .SetMake("Lada")
            .SetModel("Niva")
            .SetSeats(5)
            .SetCargoSpace(15)
            .SetBrakeTye("4 - Wheel Disc")
            .SetEngine(1.6)
            .SetFuelCapacity(42)
            .Build();
        Console.WriteLine(carManual);
    }
}