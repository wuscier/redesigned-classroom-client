using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Common.Contract;
using Common.Helper;
using Common.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Service
{
    public class ClassroomBms : IBms
    {


        public async Task<BmsMessage> GetClassroomAsync(string imei)
        {
            string requestUrl = $@"SupperSchool/AuthenticationClassRoom?classRoomImei={imei}";

            BmsMessage bmsMessage = await Request(requestUrl);

            if (!bmsMessage.HasError)
            {
                JObject jObject = JObject.Parse(bmsMessage.Data.ToString());
                string sClassroom = jObject.SelectToken("classroom").ToString();

                Classroom classroom = JsonConvert.DeserializeObject<Classroom>(sClassroom);

                bmsMessage.Data = classroom;
            }

            return bmsMessage;
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
                httpClient.BaseAddress = new Uri("http://114.112.74.10:81");

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
                    bmsMessage = BmsMessage.GenerateError(ex.Message);
                    return bmsMessage;
                }


                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();


                    JObject jObject = JObject.Parse(result);
                    string status = jObject.SelectToken("status").ToString();
                    string message = jObject.SelectToken("message").ToString();

                    if (status != "0")
                    {
                        bmsMessage = BmsMessage.GenerateError(message, status);
                    }
                    else
                    {
                        bmsMessage = BmsMessage.GenerateNormal(result);
                    }
                }
                else
                {

                    bmsMessage = BmsMessage.GenerateError(response.ReasonPhrase,
                        response.StatusCode.ToString());
                }

                return bmsMessage;
            }
        }
    }
}
