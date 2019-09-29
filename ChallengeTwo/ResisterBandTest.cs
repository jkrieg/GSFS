using ChallengeOne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeTwo
{
    [TestClass]
    public class ResisterBandTest
    {
        [TestMethod]
        public void WillReturnNullIfInvalidName()
        {
            Assert.IsNull(ResisterBand.Parse("asdfasdfasdf"));

            //It can be argued that the two instances below should return none rather than null.
            Assert.IsNull(ResisterBand.Parse(""));
            Assert.IsNull(ResisterBand.Parse(null));
        }
        [TestMethod]
        public void WillReturnNone()
        {
            var names = new string[] { "None", "M" };
            foreach (var name in names)
            {
                Assert.AreEqual(ResisterBand.Parse(name), ResisterBand.None);
            }
        }
        [TestMethod]
        public void WillReturnPink()
        {
            var names = new string[] { "Pink", "PK" };
            foreach (var name in names)
            {
                Assert.AreEqual(ResisterBand.Parse(name), ResisterBand.Pink);
            }
        }
        [TestMethod]
        public void WillReturnSilver()
        {
            var names = new string[] { "Silver", "SR", "K" };
            foreach (var name in names)
            {
                Assert.AreEqual(ResisterBand.Parse(name), ResisterBand.Silver);
            }
        }
        [TestMethod]
        public void WillReturnGold()
        {
            var names = new string[] { "Gold", "GD", "J" };
            foreach (var name in names)
            {
                Assert.AreEqual(ResisterBand.Parse(name), ResisterBand.Gold);
            }
        }
        [TestMethod]
        public void WillReturnBlack()
        {
            var names = new string[] { "Black", "BK" };
            foreach (var name in names)
            {
                Assert.AreEqual(ResisterBand.Parse(name), ResisterBand.Black);
            }
        }
        [TestMethod]
        public void WillReturnBrown()
        {
            var names = new string[] { "Brown", "BN", "F" };
            foreach (var name in names)
            {
                Assert.AreEqual(ResisterBand.Parse(name), ResisterBand.Brown);
            }
        }
        [TestMethod]
        public void WillReturnRed()
        {
            var names = new string[] { "Red", "RD", "G" };
            foreach (var name in names)
            {
                Assert.AreEqual(ResisterBand.Parse(name), ResisterBand.Red);
            }
        }
        [TestMethod]
        public void WillReturnOrange()
        {
            var names = new string[] { "Orange", "OG", "W" };
            foreach (var name in names)
            {
                Assert.AreEqual(ResisterBand.Parse(name), ResisterBand.Orange);
            }
        }
        [TestMethod]
        public void WillReturnYellow()
        {
            var names = new string[] { "Yellow", "YE", "P" };
            foreach (var name in names)
            {
                Assert.AreEqual(ResisterBand.Parse(name), ResisterBand.Yellow);
            }
        }
        [TestMethod]
        public void WillReturnGreen()
        {
            var names = new string[] { "Green", "GN", "D" };
            foreach (var name in names)
            {
                Assert.AreEqual(ResisterBand.Parse(name), ResisterBand.Green);
            }
        }
        [TestMethod]
        public void WillReturnBlue()
        {
            var names = new string[] { "Blue", "BU", "C" };
            foreach(var name in names)
            {
                Assert.AreEqual(ResisterBand.Parse(name), ResisterBand.Blue);
            }
        }
        [TestMethod]
        public void WillReturnViolet()
        {
            var names = new string[] { "Violet", "VT", "B" };
            foreach(var name in names)
            {
                Assert.AreEqual(ResisterBand.Parse(name), ResisterBand.Violet);
            }
        }
        [TestMethod]
        public void WillReturnGrey()
        {
            var names = new string[] { "Gray", "Grey", "GY", "L", "A" };
            foreach(var name in names)
            {
                Assert.AreEqual(ResisterBand.Parse(name), ResisterBand.Grey);
            }
        }
        [TestMethod]
        public void WillReturnWhite()
        {
            var names = new string[] { "White", "WH" };
            foreach(var name in names)
            {
                Assert.AreEqual(ResisterBand.Parse(name), ResisterBand.White);
            }
        }
    }
}
