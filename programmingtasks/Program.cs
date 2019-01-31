using System;

namespace programmingtasks
{
    public class OldShipException : System.Exception {
        public OldShipException(){}
        public OldShipException(int yearBuilt): 
        base(String.Format("The ship is over 20 years old: {0} years old", DateTime.Now.Year - yearBuilt)){}
    }

    class Vessel {
        private string name;
        private int yearBuilt;
        public Vessel(string Name, int Year){
            if(string.IsNullOrEmpty(Name)){
                throw new ArgumentNullException("Name can not be NULL");
            }
            this.name = Name;
            
            if(Year >= DateTime.Now.Year - 20)
                this.yearBuilt = Year;
            else
                throw new OldShipException(Year);
        }

        public string GetName(){
            return this.name;
        }
        public int GetYearBuilt(){
            return this.yearBuilt;
        }


        public string GetVesselInfo(){
           return string.Format("name {10}, year built: {1}", 1, name, yearBuilt);
        }

        public override string ToString() {
            return $"Vessel: {name}";
        }

    }

    class Ferry : Vessel { 
        public int passengers;
        public int Passengers{
            get{return passengers;} 
            set{passengers = value;}
        }

        public Ferry(string Name, int Year, int passengers): base(Name, Year){
            this.passengers = passengers;
        }


    }
    
    class Tugboat : Vessel {
        private double maxForce;

        public Tugboat(string Name, int Year, int MaxForce): base(Name, Year){
            this.maxForce = MaxForce;
        }
    }
    class Submarine : Vessel {
        private double maxDepth;

        public Submarine(string Name, int Year, double MaxDepth): base(Name, Year){
            this.maxDepth = MaxDepth;
        }

    }

    class Speed {
        
    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Vessel aVessel = new Vessel("Vess", 1998);

            Console.WriteLine(aVessel.ToString());

        }
    }
}
