using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telegainCopy.Models.Orders
{
    public class ExtendedOrder
    {
        public int id { get; set; }
        public int order_id { get; set; }
        public int chat_id { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int amount { get; set; }
        public string link { get; set; }
        public string check_type { get; set; }
    }
}
