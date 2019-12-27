namespace Assets.Scripts.Utils
{
    public static class StringUtilities
    {

        public static string Preview(this string text)
        {
            var preview = text.Replace('\t', ' ').Split('\n')[0];
            return preview.Length > 20 ? preview.Substring(0, 20) : preview;
        }

    }
}
