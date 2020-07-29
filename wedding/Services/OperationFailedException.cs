using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text;
using wedding.Services.Extensions;

namespace wedding.Services
{
    [Serializable]
    public class OperationFailedException : Exception
    {
        // Without this constructor, deserialization will fail
        protected OperationFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ErrorCode = (ErrorCode)info.GetInt32("ErrorCode");
            ErrorCategory = (ErrorCategory)info.GetInt32("ErrorCategory");
        }

        public OperationFailedException(ErrorCode errorCode, ErrorCategory errorCategory, string format,
            params object[] args)
            : base(format?.With(args))
        {
            ErrorCode = errorCode;
            ErrorCategory = errorCategory;
            Debug.Assert(errorCode != 0);
        }

        public OperationFailedException(ErrorCode errorCode, string format, params object[] args)
            : this(errorCode, ErrorCategory.Critical, format, args)
        {
        }

        public OperationFailedException(string format, params object[] args)
            : this(ErrorCode.InternalError, format, args)
        {
        }

        public ErrorCode ErrorCode { get; }

        public ErrorCategory ErrorCategory { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"ERROR CODE: {ErrorCode}, ERROR CATEGORY: {ErrorCategory}");
            sb.AppendLine(base.ToString());
            return sb.ToString();
        }
    }
    
}
