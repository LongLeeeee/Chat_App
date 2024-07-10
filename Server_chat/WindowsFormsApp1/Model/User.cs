using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class User
    {
        public string userID { get; set; }
        public string userName { get; set; }
        public DateTime creationDate { get; set; }
        public string pwd { get; set; }
        public string email { get; set; }
    }
}
