using System.Net;

namespace EducaFacil.CrossCutting.Extensions
{
    public class RetornoApi<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        private T _dataSingle;
        private List<T> _dataList;
        public T Data
        {
            get
            {
                if (_dataList != null && _dataList.Count == 1)
                    return _dataList[0];
                return _dataSingle;
            }
            set
            {

                if (value is List<T> dataList)
                {
                    _dataList = dataList;
                }
                else
                {
                    _dataSingle = value;
                }
            }
        }
        public List<string> Errors { get; set; } = new List<string>();

        public RetornoApi(HttpStatusCode statusCode, bool success)
        {
            StatusCode = statusCode;
            Success = success;
        }

        public RetornoApi(HttpStatusCode statusCode, bool success, T data) : this(statusCode, success)
        {
            Data = data;
        }

        public RetornoApi(HttpStatusCode statusCode, bool success, List<string> errors) : this(statusCode, success)
        {
            Errors = errors;
        }

        public RetornoApi(HttpStatusCode statusCode, bool success, T data, List<string> errors) : this(statusCode, success, data)
        {
            Errors = errors;
        }

        public RetornoApi()
        {
        }

        // Novo construtor com a mensagem
        public RetornoApi(HttpStatusCode statusCode, bool success, string msg) : this(statusCode, success)
        {
            Message = msg;
        }
    }

}
