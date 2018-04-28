using System.Text.RegularExpressions;

namespace Traceless.TExtension.Tools
{
    public static class StringHelper
    {
        public static string[] GetMidStrings(this string sourceString, string startString, string endString)
        {
            Regex regex = new Regex(string.Concat(new string[]
            {
                "(?<=(",
                startString,
                "))[.\\s\\S]*?(?=(",
                endString,
                "))"
            }), RegexOptions.Multiline | RegexOptions.Singleline);
            MatchCollection matchCollection = regex.Matches(sourceString);
            bool flag = matchCollection.Count > 0;
            string[] result;
            if (flag)
            {
                string[] array = new string[matchCollection.Count];
                for (int i = 0; i < matchCollection.Count; i++)
                {
                    array[i] = matchCollection[i].Value;
                }
                result = array;
            }
            else
            {
                result = null;
            }
            return result;
        }
    }
}
