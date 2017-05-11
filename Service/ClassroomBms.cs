using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Common.Contract;
using Common.Helper;
using Common.Model;
using Newtonsoft.Json;

namespace Service
{
    public class ClassroomBms : IBms
    {


        public async Task<Classroom> GetClassroomAsync(string imei)
        {
            string requestUrl = $@"SupperSchool/AuthenticationClassRoom?classRoomImei={imei}";

            BmsMessage bmsMessage = await Request(requestUrl);

            if (bmsMessage.Status == "-1" || bmsMessage.Data == null)
            {
                return Classroom.NullClassroom;
            }

            Classroom classroom = JsonConvert.DeserializeObject<Classroom>(bmsMessage.Data.ToString());

            return classroom;
        }

        public Task<List<Classroom>> GetClassroomsAsync()
        {
            return null;
        }

        public Task<TimeTable> GetClassTableInfoAsync(string classroomId)
        {
            return null;
        }

        public Task<BmsMessage> GetLogoAsync()
        {
            return null;
        }

        public Task<BmsMessage> RegisterLiveStreamAsync(CourseLiveStream courseLiveStream)
        {
            return null;
        }

        public Task<BmsMessage> SendLiveStreamStatusAsync()
        {
            return null;
        }

        public Task<BmsMessage> StartServerRecordAsync(Course course)
        {
            return null;
        }

        public Task<BmsMessage> StopServerRecordAsync(Course course)
        {
            return null;
        }

        public Task<BmsMessage> UpdateMeetingIdOfCourseAsync(Course course)
        {
            return null;
        }

        private async Task<BmsMessage> Request(string requestUrl, HttpContent content = null)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("114.112.74.10:81");

                HttpResponseMessage response;
                BmsMessage bmsMessage;

                try
                {
                    response = content == null
                        ? await httpClient.GetAsync(requestUrl)
                        : await httpClient.PostAsync(requestUrl, content);
                }
                catch (Exception ex)
                {
                    return new BmsMessage()
                    {
                        Status = "-1",
                        Message = ex.Message
                    };
                }

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    bmsMessage = JsonConvert.DeserializeObject<BmsMessage>(result);
                }
                else
                {
                    bmsMessage = new BmsMessage()
                    {
                        Status = response.StatusCode.ToString(),
                        Message = response.ReasonPhrase
                    };
                }

                return bmsMessage;
            }
        }
    }
}
