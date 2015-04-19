using System.Reflection;
using Ninject.Extensions.Factory;

namespace CommandPatternAlejandro
{
    public class CommandHandlerFactoryInstaceProvider : StandardInstanceProvider
    {
        protected override string GetName(MethodInfo methodInfo, object[] arguments)
        {
            if (methodInfo.Name == "CreateByName" && arguments.Length==1 && arguments[0] is string)
            {
                return (string) arguments[0];
            }

            return base.GetName(methodInfo, arguments);
        }
    }
}