namespace ProjectManagementSystem.Helpers
{
    public class ResponseHelper<T> where T : class
    {
        public T Model { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public ResponseHelper(T model, string message, bool isSuccess)
        {
            Model = model;
            Message = message;
            IsSuccess = isSuccess;
        }
    }
}
