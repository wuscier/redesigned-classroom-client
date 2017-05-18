using System;

namespace Common.Helper
{
    public class BmsMessage : ReturnMessage
    {
        public bool HasError { get; set; }
        public object Data { get; set; }


        public static BmsMessage GenerateError(string error, string status = "-1")
        {
            return new BmsMessage()
            {
                HasError = true,
                Message = error,
                Status = status,
                Data = null
            };
        }

        public static BmsMessage GenerateNormal(string data)
        {
            return new BmsMessage()
            {
                Data = data,
                HasError = false,
                Message = null,
                Status = "0"
            };
        }
    }
}
