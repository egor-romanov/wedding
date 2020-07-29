using System;
namespace wedding.Services
{
    
    public class ServiceResult
    {
        [Obsolete("For serialization purposes only")]
        public ServiceResult()
        {
        }

        public ServiceResult(ErrorCode errorCode, ErrorCategory errorCategory, string message, string stackTrace = null)
        {
            ErrorCode = errorCode;
            ErrorCategory = errorCategory;
            Message = message;
            StackTrace = stackTrace;
        }

        public ServiceResult(Exception exception)
            : this(ErrorCode.InternalError, ErrorCategory.Critical, exception.Message, exception.StackTrace)
        {
            if (!(exception is OperationFailedException ofe))
                return;

            ErrorCode = ofe.ErrorCode;
            ErrorCategory = ofe.ErrorCategory;
        }

        public ErrorCode ErrorCode { get; set; }
        public ErrorCategory ErrorCategory { get; set; }

        public string Message { get; set; }
        public string StackTrace { get; set; }

        public bool IsError => ErrorCode != 0;

        public static ServiceResult Success => new ServiceResult(ErrorCode.Success, ErrorCategory.None, null);

        public void CheckSuccess()
        {
            if (IsError)
                throw new OperationFailedException(ErrorCode, Message);
        }
    }

    public class ServiceResult<T> : ServiceResult
    {
#pragma warning disable CS0618 // Type or member is obsolete
        public ServiceResult(T data) => Data = data;
#pragma warning restore CS0618 // Type or member is obsolete

        public ServiceResult(ErrorCode errorCode, ErrorCategory errorCategory, string message, string stackTrace = null)
            : base(errorCode, errorCategory, message, stackTrace)
        {
        }

        public ServiceResult(Exception exception)
            : base(exception)
        {
        }


        [Obsolete("For serialization purposes only")]
        public ServiceResult()
        {
        }

        //public T Result
        //{
        //    get
        //    {
        //        CheckSuccess();

        //        return Data;
        //    }
        //}

        public T Data { get; set; }
    }
}

