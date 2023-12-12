namespace SlamCodeBlog.InterceptorsAsInvariants.Authorization
{
    public static class Invariants
    {
        public static void UserIsAuthorized(User user) 
        { 
           if(!user.Authenticated)
                throw new ArgumentException("User must be authenticated.");
        }

    }
}
