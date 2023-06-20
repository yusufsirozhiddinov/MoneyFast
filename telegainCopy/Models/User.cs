using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telegainCopy.Models
{
    public class User
    {
        public int id { get; set; }
        [Required]
        public int earned_from_partners { get; set; }
        public int total { get; set; }
        public int tg_subs { get; set; }
        public int tg_bots { get; set; }
        public int tg_groups { get; set; }
        public int tg_links { get; set; }
        public int tg_posts { get; set; }
        public DateTime registrationDate { get; set; }
        public int AdBalance { get; set; }
        public int chat_id { get; set; }


    }
}
