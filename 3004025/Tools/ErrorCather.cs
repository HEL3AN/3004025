namespace _3004025
{
    class ErrorCather
    {
        public static string errorMessage = "Error!";
        public static void ErrorMessage(string Message)
        {
            if(Message.Length > 0)
                errorMessage = Message;
            
            Console.WriteLine(errorMessage);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        public static void ErrorMessageWithOutClosed(string Message)
        {
            if (Message.Length > 0)
                errorMessage = Message;

            Console.WriteLine(errorMessage);
        }
    }
}
