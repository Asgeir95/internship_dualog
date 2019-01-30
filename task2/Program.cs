using System;

namespace task2
{
    // class Ferry : Vessel { .. }
    //class Tugboat : Vessel { .. }
    //class Submarine : Vessel { .. }

    class Vessel {
        private string name;
        private string yearBuilt;

        public Vessel(string Name, string Year){
            this.name = Name;
            this.yearBuilt = Year;
        }

        public string GetName();
        public string GetYearBuilt();

        public override string ToString() {
            return $"Vessel: {name}";
        }

        


    }

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
