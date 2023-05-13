using System;

namespace AuthenticationService.Exceptions
{
    public class CustomException:Exception
    {
        private readonly string message;
        public CustomException(string message)
        {
            this.message = message;
        }
    }
}
