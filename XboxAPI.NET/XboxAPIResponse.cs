namespace XboxAPI.NET
{
    public class XboxAPIResponse<T> where T : class
    {
        public int AttemptedRequests { get; set; }
        public T ResponseObject { get; set; }

        public XboxAPIResponse(int attemptedRequests, T responseObject)
        {
            this.AttemptedRequests = attemptedRequests;
            this.ResponseObject = responseObject;
        }
    }
}
