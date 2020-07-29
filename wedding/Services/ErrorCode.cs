namespace wedding.Services
{
    /// <summary>
    ///     less zero    - user visible errors, localized, displayed on client side
    ///     greater zero - internal errors
    /// </summary>
    public enum ErrorCode
    {
        Success = 0,
        InternalError = -1,
        UnexpectedError = -10,
        NumberOfAllowedSessionsExceeded = -11,
        ConsoleVMwareToolError = -12,
        LabNotFound = -13
    }
}
