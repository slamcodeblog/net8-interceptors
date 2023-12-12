// See https://aka.ms/new-console-template for more information

using SlamCodeBlog.InterceptorsAsInvariants.Authorization;

var user = new User(false);

Runner.DoRun(user);

class Runner
{
    [AuthorizedUserInvariant]
    public static void DoRun(User user) => Console.WriteLine("Hello, World!");
}
