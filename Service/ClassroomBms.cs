using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Autofac;
using Common.Contract;
using Common.Helper;
using Common.Model;
using Newtonsoft.Json;

namespace Service
{
    public class ClassroomBms : IBms
    {


        public Task<Classroom> GetClassroomAsync(string imei)
        {
            throw new NotImplementedException();
        }

        public Task<List<Classroom>> GetClassroomsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TimeTable> GetClassTableInfoAsync(string classroomId)
        {
            throw new NotImplementedException();
        }

        public Task<BmsMessage> GetLogoAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BmsMessage> RegisterLiveStreamAsync(CourseLiveStream courseLiveStream)
        {
            throw new NotImplementedException();
        }

        public Task<BmsMessage> SendLiveStreamStatusAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BmsMessage> StartServerRecordAsync(Course course)
        {
            throw new NotImplementedException();
        }

        public Task<BmsMessage> StopServerRecordAsync(Course course)
        {
            throw new NotImplementedException();
        }

        public Task<BmsMessage> UpdateMeetingIdOfCourseAsync(Course course)
        {
            throw new NotImplementedException();
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
