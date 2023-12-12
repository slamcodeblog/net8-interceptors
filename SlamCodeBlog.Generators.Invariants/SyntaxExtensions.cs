using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SlamCodeBlog.Invariants;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace SlamCodeBlog.Generators.Invariants
{
    internal static class SyntaxExtensions
    {
        private const string InvariantAttributeName = nameof(InvariantAttribute);

        internal static ImmutableList<ClassDeclarationSyntax> GetInvariantAttributesDeclarations(this Compilation compilation) =>
              compilation.SyntaxTrees.SelectMany(tree => tree.GetRoot().DescendantNodes())
                .Where(node => node.IsKind(SyntaxKind.ClassDeclaration))
                .OfType<ClassDeclarationSyntax>()
                .Where(ExtendsInvariantAttribute)
                .ToImmutableList();

        private static bool ExtendsInvariantAttribute(ClassDeclarationSyntax syntax) =>
            syntax.BaseList?.Types.OfType<SimpleBaseTypeSyntax>().Any(type => type.Type.ToString() == InvariantAttributeName) ?? false;

        internal static ImmutableList<MethodDeclarationSyntax> GetMethodsUsingInvariants(this Compilation compilation)
        {
            var invariantAttributes = GetInvariantAttributesDeclarations(compilation)
                .SelectMany(att =>
                {
                    var identifier = att.Identifier.ToString();

                    return new string[] { identifier, identifier.Substring(0, identifier.LastIndexOf("Attribute")) };
                })
                .ToImmutableList();
            return compilation.SyntaxTrees.SelectMany(tree => tree.GetRoot().DescendantNodes())
                .Where(node => node.IsKind(SyntaxKind.MethodDeclaration))
                .OfType<MethodDeclarationSyntax>()
                .Where(mth => IsUsingInvariantAttribute(mth, invariantAttributes))
                .ToImmutableList();
        }

        internal static bool IsInvariantAttribute(this AttributeSyntax attribute) => attribute.Name.ToString() == InvariantAttributeName;

        internal static bool IsUsingInvariantAttribute(this MemberDeclarationSyntax memberDeclaration) =>
            memberDeclaration.AttributeLists.SelectMany(list => list.Attributes).Any(IsInvariantAttribute);

        internal static bool IsUsingInvariantAttribute(this MemberDeclarationSyntax memberDeclaration, IEnumerable<string> invariantAttributeNames) =>
            memberDeclaration.AttributeLists.SelectMany(list => list.Attributes)
                .Any(att => invariantAttributeNames.Any(name => name == att.Name.ToString()));
    }
}
