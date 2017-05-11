using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class Classroom
    {
        public static Classroom NullClassroom => new Classroom();

        public string Id { get; set; }
        public string SchoolRoomNum { get; set; }
        public string SchoolRoomImei { get; set; }
        public string SchoolRoomName { get; set; }
        public string SchoolRoomAddress { get; set; }
        public string PhysicalChannelOuterId { get; set; }
        public string PlayStreamUrl { get; set; }
        public string PushStreamUrl { get; set; }
        public string RemotePlayStreamUrl { get; set; }
        public string RemotePushStreamUrl { get; set; }
        public string Token { get; set; }
        public string Remark { get; set; }
        public string CreateTime { get; set; }
    }
}
