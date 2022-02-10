using System;
using System.Collections.Generic;


namespace UserManagementModelNS.Factories
{
    public abstract class BaseFactory
    {
        protected Dictionary<Type, Type> InterfaceToClass = new Dictionary<Type, Type>();

        public void Register<TInterface, TImplementation>()
        {
            InterfaceToClass[typeof(TInterface)] = typeof(TImplementation);
        }

        public virtual TInterface Create<TInterface>(params object[] parameters)
        {
            if (InterfaceToClass.ContainsKey(typeof(TInterface)))
                return (TInterface)Activator.CreateInstance(InterfaceToClass[typeof(TInterface)], parameters);
            else
                return (TInterface)Activator.CreateInstance(typeof(TInterface), parameters);
        }
    }
}
