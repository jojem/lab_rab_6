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
        public double weight = 0.0;
        public int year = 2018;

        public Machine(string model, string engine, 
            int weight, int year)
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
            get { return model + " " + weight + " tons, engine: " + engine + ", " + year + ", " + YearsOld + " years old" ; }
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

    class Helicop: Machine
    {
        public enum Armament
        {
            armed,
            unarmed,
            armanent_not_defined
        }
        
        public Armament armament;

        public Helicop()
            :base()
        {
            armament = Armament.armanent_not_defined;
        }

        public Helicop(string model)
            : base(model)
        {
            armament = Armament.armanent_not_defined;
        }

        public Helicop(string model, string engine, int weight,
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

        public Auto(string model, string engine, int weight, int year,
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
            get { return base.Info_mach + ", " + transmission.ToString(); }
        }
    }


    class Car: Auto
    {

    }

    class Lorry: Auto
    {

    }
    


    class Program
    {
        static void Main(string[] args)
        {
            Machine[] mas = new Machine[5];



            Machine first = new Machine("Granta");
            Console.WriteLine(first.Info_mach);
            Console.ReadKey();

            Helicop second = new Helicop("Mi-8");
            Console.WriteLine(second.Info_mach);
            Console.ReadKey();

            Auto third = new Auto("Lada", "gas", 100, 2007, Auto.Transmission.auto);
            Console.WriteLine(third.Info_mach);
            Console.ReadKey();
        }
    }
}
