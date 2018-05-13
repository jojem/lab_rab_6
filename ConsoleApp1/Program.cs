using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr6_jo_hierarchy

{
    class Machine
    {
        public string model = "not name", engine = "not specified";
        public double weight = 1.0;
        public int year = 2018;

        public Machine(string model, string engine, 
            double weight, int year)
        {
            this.model = model;
            this.engine = engine;
            this.weight = weight;
            this.year = year;
        }

     
        public Machine(string model)
        {
            this.model = model;
        }

        public Machine()
        {

        }

        public virtual string Info_mach
        {
            get { return model + " >>>   " + weight + " tons, engine: " 
                    + engine + ", " + year + ", " + YearsOld + " years old" ; }
        }

        public int YearsOld
        {
            get { return DateTime.Now.Year - year; }
            set
            {
                year = DateTime.Now.Year - value;
            }
        }
    }

    class Helicopter: Machine
    {
        public enum Armament
        {
            armed,
            unarmed,
            armament_not_defined
        }
        
        public Armament armament;

        public Helicopter()
            :base()
        {
            armament = Armament.armament_not_defined;
        }

        public Helicopter(string model)
            : base(model)
        {
            armament = Armament.armament_not_defined;
        }

        public Helicopter(string model, string engine, double weight,
            int year, Armament armament)
            :base(model, engine, weight, year)
        {
            this.armament = armament;
        }

        public override string Info_mach
        {
            get
            {
                return base.Info_mach + ", " + armament.ToString();
            }
        }
    }

    class Auto: Machine
    {
        public enum Transmission
        {
            auto, 
            mechanical,
            unknown_transmission
        }

        public Transmission transmission;

        public Auto(string model, string engine, double weight, int year,
            Transmission transmission)
            :base(model, engine, weight, year)
        {
            this.transmission = transmission;
        }

        public Auto(string model)
            : base(model)
        {
            transmission = Transmission.unknown_transmission;
        }

        public Auto()
            : base()
        {
            transmission = Transmission.unknown_transmission;
        }

        public override string Info_mach
        {
            get { return base.Info_mach + ", transmission: " + transmission.ToString(); }
        }
    }


    class Car: Auto
    {
        public enum Classification
        {
            hatchback,
            sedan,
            classification_not_defined
        }

        public Classification classification;

        public Car()
            : base()
        {
            classification = Classification.classification_not_defined;
        }

        public Car(string model)
            : base(model)
        {
            classification = Classification.classification_not_defined;
        }

        public Car(string model, string engine, double weight, int year, Transmission transmission, Classification classification )
            : base(model, engine, weight, year, transmission)
        {
            this.classification = classification;
        }

        public override string Info_mach
        {
            get { return base.Info_mach + ", " + classification.ToString(); }
        }
    }

    class Lorry: Auto
    {
        public double capacity;

        public Lorry()
            : base()
        {
            capacity = 1.0;
        }

        public Lorry(string model)
            : base(model)
        {
            capacity = 1.0;
        }

        public Lorry(string model, string engine, double weight, int year, Transmission transmission, double capacity )
            : base(model, engine, weight, year, transmission)
        {
            this.capacity = capacity;
        }

        public override string Info_mach
        {
            get { return base.Info_mach + ", Lifting capacity: " + capacity.ToString() + " tons"; }
        }
    }
    


    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Vehicle";
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();

            Machine[] mas = new Machine[5];

            mas[0] = new Machine("Tayota");
            mas[1] = new Lorry("BELAZ", "diesel", 360.0,
                2013, Auto.Transmission.auto, 800);
            mas[2] = new Helicopter("Ka-50", "turbocharged", 10, 1991, Helicopter.Armament.armed);
            mas[3] = new Helicopter("Mi-38", "gasturbine", 8.3, 2015, Helicopter.Armament.unarmed);
            mas[4] = new Car("Hyundai Solaris", "gas", 1.5, 2010, Auto.Transmission.auto, Car.Classification.sedan);

            for (int i = 0; i < mas.Length; i++)
            {
                Console.WriteLine($"==> {mas[i].GetType().Name} ");
                Console.WriteLine(mas[i].Info_mach);
                Console.WriteLine("______________________________");
            }

            Console.ReadKey();


            Machine first = new Machine("Granta");
            Console.WriteLine("==> " + first.GetType().Name);
            Console.WriteLine(first.Info_mach);
            Console.WriteLine("______________________________");
            Console.ReadKey();

            Helicopter second = new Helicopter("Mi-8");
            Console.WriteLine("==> " + second.GetType().Name);
            Console.WriteLine(second.Info_mach);
            Console.WriteLine("______________________________");
            Console.ReadKey();

            Auto third = new Auto("Lada 21-10", "gas", 1.2, 2007, Auto.Transmission.mechanical);
            Console.WriteLine("==> " + third.GetType().Name);
            Console.WriteLine(third.Info_mach);
            Console.WriteLine("______________________________");
            Console.ReadKey();

            Car fourth = new Car("Lada KALINA", "diesel", 1.2,
                2011, Auto.Transmission.auto, Car.Classification.hatchback);
            Console.WriteLine("==> " + fourth.GetType().Name);
            Console.WriteLine(fourth.Info_mach);
            Console.WriteLine("______________________________");
            Console.ReadKey();
        }
    }
}
