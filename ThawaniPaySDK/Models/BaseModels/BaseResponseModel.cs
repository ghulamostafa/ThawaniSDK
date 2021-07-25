namespace ThawaniPaySDK.Models.BaseModels
{
    public abstract class BaseResponseModel<T>
    {
        public bool success { get; internal set; }
        public int code { get; internal set; }
        public string description { get; internal set; }
        public T data { get; internal set; }
        public BaseResponseModel()
        {

        }
    }

    public abstract class BaseResponseModel
    {
        public bool success { get; internal set; }
        public int code { get; internal set; }
        public string description { get; internal set; }
        public object data { get; internal set; }

        public BaseResponseModel()
        {

        }
    }

    public class BaseResponseObjectModel
    {
        public bool success { get; internal set; }
        public int code { get; internal set; }
        public string description { get; internal set; }
    }
}
