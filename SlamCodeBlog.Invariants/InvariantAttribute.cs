using System;

namespace SlamCodeBlog.Invariants
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class InvariantAttribute : Attribute
    {
        public InvariantAttribute(string invariantMethodPath)
        {
            InvariantMethodPath = invariantMethodPath;
        }

        public string InvariantMethodPath { get; }
    }
}
