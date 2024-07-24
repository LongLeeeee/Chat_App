using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
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
        public List<string> receiver_id_list { get; set; }
    }
    public class MessageFriend : Message
    {
        public User userReceive { get; set; }
    }
    public class MessageImageForFriend : MessageFriend
    {
        public string filename { get; set; }
    }
    public class MessageImageForGroup : MessageGroup
    {
        public string filename { get; set; }
    }
    public class MessageFileForFriend : MessageFriend
    {
        public string filename { get; set; }
        public long fileSize { get; set; }
    }
    public class MessageFileForGroup : MessageGroup
    {
        public string filename { get; set; }
        public long fileSize { get; set; }
    }
}
