namespace SystemDot.Web.WebApi.ModelState
{
    using System;

    public static class StringExtensions
    {
        public static string ToCamelCase(this string toConvert)
        {
            return Char.ToLowerInvariant(toConvert[0]) + toConvert.Substring(1);
        }
    }
}