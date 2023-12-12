namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    sealed file class InterceptsLocationAttribute(string filePath, int line, int column) : Attribute
    {
    }

    public static class Interceptors
    {
        [InterceptsLocation(
            "C:\\Users\\schlaffeck\\Source\\Repos\\slamcodeblog\\net8-interceptors\\SlamCodeBlog.InterceptorsAsInvariants\\Program.cs",
            7,
            8)]
        public static void DoRunIntercepted(User user)
        {
           if(!user.Authenticated)
                throw new ArgumentException("User must be authenticated.");

            Console.WriteLine("Do run intercepted!");
        }
    }
}
