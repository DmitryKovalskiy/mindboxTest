using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketToRide
{
    public class CartOrder
    {
        static void  Main()
        { }
        public static List<TicketCard> Order(List<TicketCard> source)
        {
            List<TicketCard> result = new List<TicketCard>();

            foreach (var item in source)
            {
                result = new List<TicketCard>();
                var cloneSource = source.Where(c => true).ToList();
                result.Add(item);
                var root = item;
                while (HasNext(cloneSource, root))
                {
                    root = GetNext(cloneSource, root);
                    result.Add(root);
                }
                if (source.Count == result.Count)
                    return result;
            }
            return result;
        }

        private static TicketCard GetNext(List<TicketCard> source, TicketCard item)
        {
            var result = source.Where(c => c.Departure == item.Arrival).First();
            source.Remove(result);
            return result;
        }

        private static bool HasNext(List<TicketCard> source, TicketCard item)
        {
            return source.Any(c => c.Departure == item.Arrival);
        }
    }

   public class TicketCard
    {
        public string Departure { get; set; }
        public string Arrival { get; set; }
    }
}
