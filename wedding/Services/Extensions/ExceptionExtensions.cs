using System;
using System.Text;

namespace wedding.Services.Extensions
{
    public static class ExceptionExtensions
    {
        public static string GetErrorMessage(this Exception err, params object[] args)
        {
            var errString = new StringBuilder();
            if (args.Length > 0)
                foreach (var a in args)
                    errString.AppendLine("{0}".With(a));
            errString.AppendLine(err.ToString());
            return errString.ToString();
        }
    }
}