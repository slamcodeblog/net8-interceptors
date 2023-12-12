using SlamCodeBlog.Invariants;

namespace SlamCodeBlog.InterceptorsAsInvariants.Authorization
{
    public sealed class AuthorizedUserInvariantAttribute : InvariantAttribute
    {
        public AuthorizedUserInvariantAttribute() : base("SlamCodeBlog.InterceptorsAsInvariants.Authorization.Invariants.UserIsAuthorized")
        {
        }
    }
}
