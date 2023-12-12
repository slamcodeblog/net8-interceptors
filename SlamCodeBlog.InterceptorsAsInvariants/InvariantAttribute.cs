namespace SlamCodeBlog.InterceptorsAsInvariants
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class InvariantAttribute(string invariantPath) : Attribute
    {
    }
}
