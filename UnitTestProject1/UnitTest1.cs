using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class PhoneDirectoryTests
    {
        [TestMethod]
        public void TestAddSubscriber()
        {
            PhoneDirectory directory = new PhoneDirectory();
            Subscriber subscriber = new Subscriber("John Doe", "123-456-7890");

            directory.AddToList(subscriber);
            ListNode head = directory.GetHead();

            Assert.IsNotNull(head);
            Assert.AreEqual(subscriber, head.Subscriber);
        }

        [TestMethod]
        public void TestCalculateCallCost()
        {
            PhoneDirectory directory = new PhoneDirectory();
            Subscriber subscriber = new Subscriber("John Doe", "123-456-7890");
            directory.AddToList(subscriber);

            TimeSpan callDuration = TimeSpan.FromMinutes(10);
            double expectedCost = callDuration.TotalMinutes * 0.1; 
            double actualCost = directory.CalculateCallCost("123-456-7890", callDuration);

            Assert.AreEqual(expectedCost, actualCost);
        }
    }
}
