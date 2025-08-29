namespace ProjectManagementSystem.Helpers
{
    public static class MessageHelper
    {
        public static (string message, bool isSuccess, T data) GetDuplicateMessage<T>(T model, params string[] propertyNames)
        {
            var values = propertyNames.Select(prop =>
            {
                var propInfo = typeof(T).GetProperty(prop);
                var value = propInfo?.GetValue(model)?.ToString() ?? "null";
                return $"{prop} {value}";
            });

            string message = $"{typeof(T).Name} with {string.Join(" and ", values)} already present";
            return (message, false, model);
        }

        public static (string message, bool isSuccess, T model) GetSuccessErrorMessage<T>(bool isSuccess, T model, MessageTypeEnum messageTypeEnum= MessageTypeEnum.Created)
        {
            string action = messageTypeEnum.ToString().ToLower(); // e.g. "created", "deleted"

            string message = isSuccess
                ? $"Record {action} successfully."
                : $"Unable to {action} record.";

            return (message, isSuccess, model);
        }
    }
}
