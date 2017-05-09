using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom
{
    public class MessageItem
    {
        public MessageItem(string msg, MessageType msgType)
        {
            Message = msg;
            MessageType = msgType;
        }

        public string Message { get; set; }
        public MessageType MessageType { get; set; }
    }
}
