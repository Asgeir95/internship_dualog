using Xunit;
using System;

namespace programmingtasks
{
    public class Vesseltests
    {
        [Theory]
        [InlineData("Vess")]
        [InlineData("NULL")]
        public void testNameField(string name){
            Vessel aVessel = new Vessel(name, 2018);
            Assert.Equal(name, aVessel.GetName());
        }
        
        [Fact]
        public void nameCanNotbeNULL(){
            Vessel aVessel;
            Assert.Throws<ArgumentNullException>(() => aVessel = new Vessel("", 2012));
        }

        [Theory]
        [InlineData(2005)]
        [InlineData(1999)]
        public void testYearField(int year){
            Vessel aVessel = new Vessel("a name", year);
            Assert.Equal(year, aVessel.GetYearBuilt());
        }

        [Theory]
        [InlineData(1920)]
        [InlineData(1998)]
        public void testOldShipException(int year){
            Vessel aVessel;
            Assert.Throws<OldShipException>(() => aVessel = new Vessel("a name", year));
        }
    }

    public class FerryTests
    {
        [Fact]
        public void testPassengersField(){
            int passengers = 200;
            Ferry aFerry = new Ferry("Fer", 2000, passengers);
        }
    }
}
