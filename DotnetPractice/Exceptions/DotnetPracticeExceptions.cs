namespace DotnetPractice.Exceptions
{
    public static class DotnetPracticeExceptionCodes
    {
        public static readonly DotnetPracticeExceptionCode USER_ALREADY_EXISTS =
            new DotnetPracticeExceptionCode(1001, "User already exists");
        public static readonly DotnetPracticeExceptionCode USER_NOT_FOUND =
            new DotnetPracticeExceptionCode(2001, "User not found");
        public static readonly DotnetPracticeExceptionCode USER_INVALID =
            new DotnetPracticeExceptionCode(3001, "User data is invalid");
    }
}
