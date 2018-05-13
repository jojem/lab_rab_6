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
        public int weight = 0;
        private int year;

        public Machine(string model, string engine, int weight, int year)
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
            get { return model + " " + weight + " " + engine; }
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
      
    }

    class Auto: Machine
    {

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

        }
    }
}
