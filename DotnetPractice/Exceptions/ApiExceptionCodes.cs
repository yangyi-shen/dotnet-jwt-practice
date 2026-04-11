namespace DotnetPractice.Exceptions
{
    public static class ApiExceptionCodes
    {
        public static readonly ApiExceptionCode USER_ALREADY_EXISTS = new ApiExceptionCode(
            1001,
            "User already exists"
        );
        public static readonly ApiExceptionCode USER_NOT_FOUND = new ApiExceptionCode(
            2001,
            "User not found"
        );
        public static readonly ApiExceptionCode USER_INVALID = new ApiExceptionCode(
            3001,
            "User data is invalid"
        );
    }
}
