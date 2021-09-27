using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project1.Business;
using System;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class SimpleInterestCalculatorTests
    {
        [TestMethod]
        public void TestGetPaymentPlanGivenValidTestDataThenTheTotalAmountIsCalculatedCorrectly()
        {
            int amount = 3000;
            int interest = 5;
            int term = 1;

            var paymentPlan = new SimpleInterestCalculator().GetPaymentPlan(amount, interest, term);
            var firstPayment = paymentPlan.First();

            Assert.AreEqual(12.5, firstPayment.Interest);
            Assert.AreEqual(250, firstPayment.Principal);
            Assert.AreEqual(262.5, firstPayment.Total);
        }

        [TestMethod]
        public void TestGetPaymentPlanGivenValidTestDataThenTheNumberOfPaymentsIsCorrect()
        {
            int amount = 3000;
            int interest = 5;
            int term = 1;

            var paymentPlan = new SimpleInterestCalculator().GetPaymentPlan(amount, interest, term);

            Assert.AreEqual(12, paymentPlan.Count());
        }

        [TestMethod]
        public void TestGetPaymentPlanGivenValidTestDataThenTheBalanceOfTheLastPaymentIsZero()
        {
            int amount = 3000;
            int interest = 5;
            int term = 1;

            var paymentPlan = new SimpleInterestCalculator().GetPaymentPlan(amount, interest, term);

            Assert.AreEqual(0, paymentPlan.Last().Balance);
        }

        [TestMethod]
        public void TestGetPaymentPlanGivenValidTestDataThenTheTotalAmountIsTheSumOfInterestAndPrincipalForEachPayment()
        {
            int amount = 3000;
            int interest = 5;
            int term = 1;

            var paymentPlan = new SimpleInterestCalculator().GetPaymentPlan(amount, interest, term);

            Assert.IsTrue(paymentPlan.All(pp => pp.Total == pp.Interest + pp.Principal));
        }

        [TestMethod]
        public void TestGetPaymentPlanGivenValidTestDataThenTheInterestIsTheSameForEachPayment()
        {
            int amount = 3000;
            int interest = 5;
            int term = 1;

            var paymentPlan = new SimpleInterestCalculator().GetPaymentPlan(amount, interest, term);

            var interestForFirstPayment = paymentPlan.First().Interest;

            Assert.IsTrue(paymentPlan.All(pp => pp.Interest == interestForFirstPayment));
        }

        [TestMethod]
        public void TestGetPaymentPlanGivenValidTestDataThenThePrincipalIsTheSameForEachPayment()
        {
            int amount = 3000;
            int interest = 5;
            int term = 1;

            var paymentPlan = new SimpleInterestCalculator().GetPaymentPlan(amount, interest, term);

            var principalForFirstPayment = paymentPlan.First().Principal;

            Assert.IsTrue(paymentPlan.All(pp => pp.Principal == principalForFirstPayment));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetPaymentPlanGivenNegativeAmountThenArgumentExceptionIsThrown()
        {
            int amount = -1000;
            int interest = 5;
            int term = 1;

            new SimpleInterestCalculator().GetPaymentPlan(amount, interest, term);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetPaymentPlanGivenNegativeTermThenArgumentExceptionIsThrown()
        {
            int amount = 1000;
            int interest = 5;
            int term = -5;

            new SimpleInterestCalculator().GetPaymentPlan(amount, interest, term);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetPaymentPlanGivenNegativeInterestThenArgumentExceptionIsThrown()
        {
            int amount = 1000;
            double interest = -3.5;
            int term = 1;

            new SimpleInterestCalculator().GetPaymentPlan(amount, interest, term);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetPaymentPlanGivenInterestThatIsGreaterThanOneHundredThenArgumentExceptionIsThrown()
        {
            int amount = 1000;
            double interest = 110;
            int term = 1;

            new SimpleInterestCalculator().GetPaymentPlan(amount, interest, term);
        }
    }
}
