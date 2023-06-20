using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telegainCopy.Models.Orders
{
    public class PostOrder
    {
        public int id { get; set; }
        public int order_id { get; set; }
        public string link { get; set; }
        public int chat_id { get; set; }
        public int amount { get; set; }
        public string status { get; set; }
    }
}
