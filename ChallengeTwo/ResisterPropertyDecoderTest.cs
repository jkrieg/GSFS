using ChallengeOne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChallengeTwo
{
    [TestClass]
    public class ResisterPropertyDecoderTest
    {
        [TestMethod]
        public void ReceivesExceptionIfParameterNamesAreInvalid()
        {
            try
            {
                var propertyDecoder = new ResisterPropertyDecoder();
                propertyDecoder.CalculateOhmValue("", "asdfasdf", "brandBColor", "White");
                Assert.Fail();
            }
            catch(Exception exc)
            {
            }

        }
        [TestMethod]
        public void ReceivesExceptionIfParameterBandsAreInappropriate()
        {
            try
            {
                var propertyDecoder = new ResisterPropertyDecoder();
                propertyDecoder.CalculateOhmValue("PK", "RD", "WH", "OG");
                Assert.Fail();
            }
            catch(Exception exc)
            {

            }

            try
            {
                //Tolerance value fault
                var propertyDecoder = new ResisterPropertyDecoder();
                propertyDecoder.CalculateOhmValue("WH", "VT", "BK", "PK");
                Assert.Fail();
            }
            catch (Exception exc)
            {

            }
            try
            {
                //Multiplier value fault
                var propertyDecoder = new ResisterPropertyDecoder();
                propertyDecoder.CalculateOhmValue("BK", "BN", "None", "RD");
                Assert.Fail();
            }
            catch (Exception exc)
            {

            }
        }
        [TestMethod]
        public void ProducesNumericResultForCorrectBandConfiguration()
        {
            var propertyDecoder = new ResisterPropertyDecoder();
            Assert.AreEqual(propertyDecoder.CalculateOhmValue("GN", "BU", "BN", "BN"), 560); //560 ohms +/- 1%
        }
        [TestMethod]
        public void WillNotOverflowOnCalcuation()
        {
            try
            {
                var propertyDecoder = new ResisterPropertyDecoder();
                propertyDecoder.CalculateOhmValue("WH", "WH", "WH", "M");
            }
            catch(ArithmeticException exc)
            {
                Assert.Fail();
            }
            catch (Exception exc)
            {

            }
        }
    }
}
