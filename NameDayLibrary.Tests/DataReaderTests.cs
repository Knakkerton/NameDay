using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NameDayLibrary.Tests
{
    public class DataReaderTests
    {
        [Theory]
        [InlineData("2.9.")]
        [InlineData("11.10.")]
        public void GetNameDayPeople_ShouldWorkValidValues(string x)
        {
            string filename = "nimet.csv";
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\NameDay\bin\Debug", @"datafiles\", filename);
            DataReader dr = new DataReader();

            List<Person> actual = dr.GetNameDayPeople(x,filepath);

            Assert.True(actual.Count > 0);
        }


        [Fact]
        public void GetFileLines_ShouldThrowException()
        {
            DataReader dr = new DataReader();

            Assert.Throws<FileNotFoundException>(() => dr.GetFileLines(""));
        }
    }


}
