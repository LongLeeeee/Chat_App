using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Chat.Model
{
    public class Message
    {
        public User userSend { get; set; }
        public string content { get; set; }
        public DateTime dateSend { get; set; }
    }
    public class MessageGroup : Message
    {
        public string groupName { get; set; }
        public List<User> receiverList { get; set; }
    }
    public class MessageFriend : Message
    {
        public User userReceive { get; set; }
    }
}
