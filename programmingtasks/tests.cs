using Xunit;
using System;

namespace programmingtasks
{
    // All tests for the Vessel class
    public class Vesseltests
    {
        // Test if the name field in the vessel is ok
        [Theory]
        [InlineData("Vess")]
        [InlineData("NULL")]
        public void testNameField(string name){
            Speed sp = new Speed(50);
            Vessel aVessel = new Vessel(name, 2018, sp);
            Assert.Equal(name, aVessel.GetName());
        }
        
        // Confirm that function throws an exeption if name is NULL.
        [Fact]
        public void nameCanNotbeNULL(){
            Vessel aVessel;
            Speed sp = new Speed(50);
            Assert.Throws<ArgumentNullException>(() => aVessel = new Vessel("", 2012, sp));
        }

        // Test if the year field on the vessel is ok
        [Theory]
        [InlineData(2005)]
        [InlineData(1999)]
        public void testYearField(int year){
            Speed sp = new Speed(50);
            Vessel aVessel = new Vessel("a name", year, sp);
            Assert.Equal(year, aVessel.GetYearBuilt());
        }

        // Throw exception if the ship is to old
        [Theory]
        [InlineData(1920)]
        [InlineData(1998)]
        public void testOldShipException(int year){
            Vessel aVessel;
            Speed sp = new Speed(50);
            Assert.Throws<OldShipException>(() => aVessel = new Vessel("a name", year, sp));
        }
        // Test if the speed is stored at the Vessel
        [Fact]
        public void testGetSpeed(){
            Speed sp = new Speed(50);
            Vessel aVessel = new Vessel("a name", 2006, sp);
            Assert.Equal(sp, aVessel.GetSpeed());
        }
    }

    // All tests for an Ferry is here
    public class FerryTests
    {
        // Test if the passengers field is ok
        [Fact]
        public void testPassengersField(){
            int passengers = 200;
            int passengers2 = 300;
            Speed sp = new Speed(50);
            Ferry aFerry = new Ferry("Fer", 2000, sp, passengers);

            Assert.Equal(passengers, aFerry.passengers);

            // Since it is not a private variable, we can change it
            aFerry.passengers = passengers2;
            Assert.Equal(passengers2, aFerry.passengers);

        }

        // Check if the GetVesselInfo print is correct
        [Theory]
        [InlineData("Ferry nr 1", 2001, 100)]
        [InlineData("Ferry nr 2", 2003, 300)]
        public void testGetVesselInfo(string name, int year,  int passengers){
            Speed sp = new Speed(50);
            Ferry aFerry = new Ferry(name, year, sp, passengers);
            var info = string.Format("Type of vessel: Ferry, name: {0}, year built: {1}, maximum speed: {2}|{3}, number of passengers: {4}",name, year, sp.ToString("KN"), sp.ToString("MS"), passengers);
            Assert.Equal(info, aFerry.GetVesselInfo());
        }

    }
    
    // All tests for the Tugboats are here
    public class TugboatTests
    {
        // Test if the max Force field is ok
        [Theory]
        [InlineData(200)]
        [InlineData(93.3)]
        public void testMaxForceField(double maxForce){
            Speed sp = new Speed(50);
            Tugboat aTugboat = new Tugboat("Fer", 2000, sp, maxForce);
            Assert.Equal(maxForce, aTugboat.GetMaxForce());
        }   

        // Check if the GetVesselInfo print is correct
        [Theory]
        [InlineData("Tugboat nr 1", 2001, 100.93)]
        [InlineData("Tugboat nr 2", 2003, 300)]
        public void testGetVesselInfo(string name, int year,  int passengers){
            Speed sp = new Speed(50);
            Tugboat aTugboat = new Tugboat(name, year, sp, passengers);
            var info = string.Format("Type of vessel: Tugboat, name: {0}, year built: {1}, maximum speed: {2}|{3}, maximum force: {4}",name, year, sp.ToString("KN"), sp.ToString("MS"), passengers);
            Assert.Equal(info, aTugboat.GetVesselInfo());
        }
    }
    // All tests for the Submarines are here
    public class SubmarineTests
    {
        // Test if the max depth field is ok
        [Theory]
        [InlineData(200)]
        [InlineData(93.3)]
        public void testMaxDepthField(double maxDepth){
            Speed sp = new Speed(50);
            Submarine aSubmarine = new Submarine("Fer", 2000, sp, maxDepth);
            Assert.Equal(maxDepth, aSubmarine.GetMaxDepth());
        }

        // Check if the GetVesselInfo print is correct
        [Theory]
        [InlineData("Submarine nr 1", 2001, 100.93)]
        [InlineData("Submarine nr 2", 2003, 300)]
        public void testGetVesselInfo(string name, int year, int passengers){
            Speed sp = new Speed(50);
            Submarine aSubmarine = new Submarine(name, year, sp, passengers);
            var info = string.Format("Type of vessel: Submarine, name: {0}, year built: {1}, maximum speed: {2}|{3}, maximum depth: {4}",name, year, sp.ToString("KN"),sp.ToString("MS"), passengers);
            Assert.Equal(info, aSubmarine.GetVesselInfo());
        }
    }

    public class SpeedTests
    {
        // Test if speed can go below zero
        [Fact]
        public void speedCanNotBeBelowZero(){
            Speed sp;
            Assert.Throws<ArgumentOutOfRangeException>(() => sp = new Speed(-1));
        }

        // We can only use "MS" or "KN" when using the ToString method on Speed
        [Fact]
        public void haveToUseKNorMS(){
            double number = 50;
            Speed sp = new Speed(number);
            Assert.Throws<FormatException>(() => sp.ToString("fail"));
        }

        // Check if the m/s print is correct
        [Fact]
        public void testToStringMSFormat(){
            double number = 50;
            Speed sp = new Speed(number);
            double KNtoMS = number * 1.852 / 3.6;
            Assert.Equal(String.Format("{0:0.00} m/s", KNtoMS), sp.ToString("MS"));
        }
        
        // Check if the knots print is correct
        [Fact]
        public void knotsIsTheDefault(){
            double number = 50;
            Speed sp = new Speed(number);
            double KNtoMS = number * 1.852 / 3.6;
            Assert.Equal(String.Format("{0:0.00} knots", number), sp.ToString());
        }
    }

}
