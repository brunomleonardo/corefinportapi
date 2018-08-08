using System.Collections.Generic;

namespace FinPort.Core.DtoModels
{
    public class JResponseEntity<T> where T : class
    {
        public T Data { get; set; }
        public bool Status { get; set; }
        public string AccessToken { get; set; }
        public string Message { get; set; }
        public List<T> DataList { get; set; }
    }
}