using System;

namespace Microsoft.Extensions.DependencyInjection.Exceptions
{
    public class AlreadyRegisteredNameForServiceTypeException : Exception
    {
        public AlreadyRegisteredNameForServiceTypeException(string name, string serviceType, string alredyRegisteredImplementationType) 
            : base($"The name {name} has already been registered for serviceType {serviceType} for the implementationType {alredyRegisteredImplementationType}")
        {
        }
    }
}