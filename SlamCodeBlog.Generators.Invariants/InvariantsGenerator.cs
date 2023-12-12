using Microsoft.CodeAnalysis;

namespace SlamCodeBlog.Generators.Invariants
{
    [Generator]
    public class InvariantGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            var compilationProvider = context.CompilationProvider;

            context.RegisterSourceOutput(
                compilationProvider,
                static (context, compilation) =>
                {
                    var methodsData = compilation.GetMethodsUsingInvariants();
                });
        }
    }
}
