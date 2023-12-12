namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    sealed file class InterceptsLocationAttribute(string filePath, int line, int column) : Attribute
    {
    }

    public static class Interceptors
    {
        [InterceptsLocation(
            "C:\\Projects\\Own\\repos\\SlamCodeBlog\\SlamCodeBlog.InterceptorsAsInvariants\\SlamCodeBlog.InterceptorsAsInvariants\\Program.cs", 
            3,
            8)]
        public static void DoRunIntercepted() => Console.WriteLine("Do run intercepted!");
    }
}
