using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class Group
    {
        public string groupName { get; set; }
        public User creator { get; set; }
        public DateTime creationDate { get; set; }
    }
}
