namespace ProjectManagementSystem.Helpers
{
    public static class PageViewHelper
    {
        public static string GetPageViewHelper(string viewName, string featureName)
        {
            return $"~/Features/{featureName}/Views/{viewName}.cshtml";
        }
    }
}
