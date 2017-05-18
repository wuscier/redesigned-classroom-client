using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Helper;
using Common.Model;

namespace Common.Contract
{
    public interface IBms
    {
        Task<BmsMessage> GetLogoAsync();
        Task<List<Classroom>> GetClassroomsAsync();
        Task<BmsMessage> GetClassroomAsync(string imei);
        Task<TimeTable> GetClassTableInfoAsync(string classroomId);
        Task<BmsMessage> UpdateMeetingIdOfCourseAsync(Course course);
        Task<BmsMessage> StartServerRecordAsync(Course course);
        Task<BmsMessage> StopServerRecordAsync(Course course);
        Task<BmsMessage> RegisterLiveStreamAsync(CourseLiveStream courseLiveStream);
        Task<BmsMessage> SendLiveStreamStatusAsync();
    }
}
