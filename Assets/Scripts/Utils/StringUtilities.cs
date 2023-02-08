namespace Assets.Scripts.Utils
{
    /**
     * String extensions
     */
    public static class StringUtilities
    {
        /**
         * Creates a preview version of the string.
         * A preview string is just the string before the first line break without tabs and only the first 20 chars
         */
        public static string Preview(this string text)
        {
            var preview = text.Replace('\t', ' ').Split('\n')[0];
            return preview.Length > 20 ? preview.Substring(0, 20) : preview;
        }

    }
}
