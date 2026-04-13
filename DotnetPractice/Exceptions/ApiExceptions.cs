namespace DotnetPractice.Exceptions
{
    public static class ApiExceptions
    {
        public static readonly ApiExceptionDetails UNEXPECTED_ERROR = new(
            0000,
            "An unexpected error occurred"
        );
        public static readonly ApiExceptionDetails USER_ALREADY_EXISTS = new(
            1001,
            "User already exists"
        );
        public static readonly ApiExceptionDetails CATEGORY_ALREADY_EXISTS = new(
            1002,
            "Category already exists"
        );
        public static readonly ApiExceptionDetails USER_NOT_FOUND = new(2001, "User not found");
        public static readonly ApiExceptionDetails USER_INVALID = new(3001, "User data is invalid");
        public static readonly ApiExceptionDetails CATEGORY_INVALID = new(
            3002,
            "Category data is invalid"
        );
    }
}
