using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TicketToRide;
namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<TicketCard> source = new List<TicketCard>();

            source.Add(new TicketCard() { Departure = "Москва", Arrival = "Париж" });
            source.Add(new TicketCard() { Departure = "Кельн", Arrival = "Москва" });
            source.Add(new TicketCard() { Departure = "Мельбурн ", Arrival = "Кельн" });

            List<TicketCard> result = new List<TicketCard>();

            result.Add(new TicketCard() { Departure = "Мельбурн ", Arrival = "Кельн" });
            result.Add(new TicketCard() { Departure = "Кельн", Arrival = "Москва" });
            result.Add(new TicketCard() { Departure = "Москва", Arrival = "Париж" });

            var methodResult = CartOrder.Order(source);

            Assert.AreEqual(result.Count, methodResult.Count);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(result[i].Arrival, methodResult[i].Arrival);
                Assert.AreEqual(result[i].Departure, methodResult[i].Departure);
            }
        }
    }
}
