using System;
using System.Globalization;
using System.Collections.Generic;

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
        private Speed speed;

        public Vessel(string Name, int Year, Speed Velocity){
            // Check is name is NULL
            if(string.IsNullOrEmpty(Name)){
                throw new ArgumentNullException("Name can not be NULL");
            }
            this.name = Name;
            
            // The year built should be max 20 years ago
            if(Year >= DateTime.Now.Year - 20)
                this.yearBuilt = Year;
            else
                throw new OldShipException(Year);

            this.speed = Velocity;
            // Count number of vessels
            numOfVessels++;
        }

        public string GetName(){
            return this.name;
        }
        public int GetYearBuilt(){
            return this.yearBuilt;
        }

        public Speed GetSpeed(){
            return this.speed;
        }

        static int numOfVessels = 0;
        
        public static int getNumOfVessels(){
            return numOfVessels;
        } 

        // All info from Vessel
        public virtual string GetVesselInfo(){
           return string.Format("name: {0}, year built: {1}, maximum speed: {2}|{3}", name, yearBuilt, speed.ToString("KN"), speed.ToString("MS"));
        }

        // Essential info from Vessel
        public override string ToString() {
            return $" {name}, {yearBuilt}";
        }

    }

    class Ferry : Vessel { 
        public int passengers;
        public int Passengers{
            get{return passengers;} 
            set{passengers = value;}
        }

        public Ferry(string Name, int Year, Speed Velocity, int passengers): base(Name, Year, Velocity){
            this.passengers = passengers;
        }

        // Added all info from Ferry to the function
        public override string GetVesselInfo(){
            var s = base.GetVesselInfo();
            return string.Format("Type of vessel: {0}, {1}, number of passengers: {2}",this.GetType().Name, s, passengers);
        }
        // Added essential info from Ferry to the function
        public override string ToString() {
            var s = base.ToString();
            return $"Ferry: {s}, {passengers}";
        }

    }
    
    class Tugboat : Vessel {
        private double maxForce;

        public Tugboat(string Name, int Year, Speed Velocity, double MaxForce): base(Name, Year, Velocity){
            this.maxForce = MaxForce;
        }
        public double GetMaxForce(){
            return this.maxForce;
        }

        // Added all info from Tugboat to the function
        public override string GetVesselInfo(){
            var s = base.GetVesselInfo();
            return string.Format("Type of vessel: {0}, {1}, maximum force: {2}",this.GetType().Name, s, maxForce);
        }
        // Added essential info from Tugboat to the function
        public override string ToString() {
            var s = base.ToString();
            return $"Tugboat: {s}, {maxForce}";
        }
    }

    class Submarine : Vessel {
        private double maxDepth;

        public Submarine(string Name, int Year, Speed Velocity, double MaxDepth): base(Name, Year, Velocity){
            this.maxDepth = MaxDepth;
        }
        public double GetMaxDepth(){
            return this.maxDepth;
        }
        
        // Added all info from Submarine to the function
        public override string GetVesselInfo(){
            var s = base.GetVesselInfo();
            return string.Format("Type of vessel: {0}, {1}, maximum depth: {2}", this.GetType().Name, s, maxDepth);
        }
        // Added essential info from Submarine to the function
        public override string ToString() {
            var s = base.ToString();
            return $"Submarine: {s}, {maxDepth}";
        }
    }

    public class Speed : IFormattable
    {
        private double velocity;
        
        public Speed(double vel){
            // Can not have negative speed
            if(vel < 0)
                throw new ArgumentOutOfRangeException("The speed can not be negative.");
            
            this.velocity = vel;
        }

        // Since knots is defalt, just return the velocity
        public double KN{
            get { return this.velocity; }
        }
        // Convert Knots to m/s before returning
        public double MS{
            get { return this.velocity*1.852/3.6; }
        }
        
        public override string ToString(){
            return this.ToString("KN", CultureInfo.CurrentCulture);
        }

        public string ToString(string format){
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if(String.IsNullOrEmpty(format)) format = "KN";
            if(formatProvider == null) formatProvider = CultureInfo.CurrentCulture;

            // Switch between the different cases dependent of what the format is
            switch(format.ToUpperInvariant()){
                case "KN":
                    return KN.ToString("F2", formatProvider) + " knots";
                case "MS":
                    return MS.ToString("F2", formatProvider) + " m/s";    
                default:
                    throw new FormatException(String.Format("{0} is not supported, try 'KN' for knop or 'MS' for m/s")); 
            
            }
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            List<Vessel> vesselList = new List<Vessel>();

            // Different speeds for the types
            Speed sp = new Speed(10);
            Speed sp2 = new Speed(20.03);
            Speed sp3 = new Speed(30.82);
         
            // created 5 of each vesseltype
            Ferry fer1 = new Ferry("Lickety Split", 2005, sp, 300);
            Ferry fer2 = new Ferry("Greased Lightning", 2012, sp, 250);
            Ferry fer3 = new Ferry("Flying Lady", 2003, sp, 400);
            Ferry fer4 = new Ferry("Blew By Ya", 2009, sp, 600);
            Ferry fer5 = new Ferry("Breaking Waves", 2018, sp, 100);
            Tugboat tug1 = new Tugboat("Loon-A-Sea", 1999, sp2, 70.01);
            Tugboat tug2 = new Tugboat("Sleeping With Oars", 2000, sp2, 60.23);
            Tugboat tug3 = new Tugboat("What's up Dock", 2019, sp2, 30.11);
            Tugboat tug4 = new Tugboat("Your Place Oar Mine", 2004, sp2, 80.10);
            Tugboat tug5 = new Tugboat("Silver Bullet", 2005, sp2, 75.50);
            Submarine sub1 = new Submarine("Terminator", 2019, sp3, 170.32);
            Submarine sub2 = new Submarine("Summer Wind", 2016, sp3, 200.12);
            Submarine sub3 = new Submarine("Ocean Breeze", 2002, sp3, 160.32);
            Submarine sub4 = new Submarine("Called in Sick", 2000, sp3, 182.42);
            Submarine sub5 = new Submarine("Sail Away", 2013, sp3, 190.80);

            // Added all to an list of vessels
            vesselList.Add(fer1);
            vesselList.Add(fer2);
            vesselList.Add(fer3);
            vesselList.Add(fer4);
            vesselList.Add(fer5);
            vesselList.Add(tug1);
            vesselList.Add(tug2);
            vesselList.Add(tug3);
            vesselList.Add(tug4);
            vesselList.Add(tug5);
            vesselList.Add(sub1);
            vesselList.Add(sub2);
            vesselList.Add(sub3);
            vesselList.Add(sub4);
            vesselList.Add(sub5);
            Console.WriteLine("Number of Vessels " + Vessel.getNumOfVessels() + "\n");
         
            Console.WriteLine("The ToString method");
            foreach(var vessel in vesselList){
                Console.WriteLine(vessel.ToString());
            }
            Console.WriteLine("\nThe GetVesselInfo() method");
            foreach(var vessel in vesselList){
                Console.WriteLine(vessel.GetVesselInfo());
            }
            Console.WriteLine("\nPrinting some speed values in m/s and knots");
            Console.WriteLine("Tug3 speed in knots: " + tug3.GetSpeed().ToString());
            Console.WriteLine("Tug3 speed in m/s: " + tug3.GetSpeed().ToString("MS"));

        }
    }
}
