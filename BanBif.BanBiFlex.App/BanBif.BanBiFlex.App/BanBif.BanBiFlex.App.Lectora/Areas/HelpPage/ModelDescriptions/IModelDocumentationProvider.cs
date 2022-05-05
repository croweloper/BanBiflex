using System;
using System.Reflection;

namespace BanBif.BanBiFlex.App.Lectora.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}