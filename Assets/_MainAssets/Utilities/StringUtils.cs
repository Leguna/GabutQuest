namespace Utilities
{
    public class StringUtils
    {
        public static string FormatTime(float timeInSecond)
        {
            var minutes = timeInSecond / 60;
            var seconds = timeInSecond % 60;

            return $"{minutes:00}:{seconds:00}";
        }
    }
}