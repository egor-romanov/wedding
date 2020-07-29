namespace wedding.Services.Extensions
{
    public static class StringExtensions
    {
        public static string With(this string format, params object[] args) =>
            args.Length == 0 ? format : string.Format(format, args);
    }
}
