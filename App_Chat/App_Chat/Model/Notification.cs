using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Chat.Model
{
    public class Notification
    {
        public User receiver { get; set; }
        public User sender { get; set; }
        public DateTime sendDate { get; set; }
        public string content { get; set; }
    }
}
