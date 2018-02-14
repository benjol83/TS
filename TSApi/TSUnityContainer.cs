using DataAdapter;
using DataModel;
using System;
using System.Collections.Generic;
using Unity;
using Unity.Injection;

namespace TSApi
{
    public class TSUnityContainer
    {
        internal static Lazy<IUnityContainer> luc = new Lazy<IUnityContainer>(() => ConstructContainer(), true);

        /// <summary>
        /// Get the singleton DIC instance  
        /// </summary>
        /// <returns></returns>
        public static IUnityContainer GetContainer()
        {
            return luc.Value;
        }

        /// <summary>
        /// Construct Dependency Injection Container
        /// </summary>
        /// <returns></returns>
        private static IUnityContainer ConstructContainer()
        {
            var myContainer = new UnityContainer();

            // this is a fake storage to store all of the issues in
            // dictionary instead of DB
            var fakeStorage = new Dictionary<string, Issue>();

            myContainer.RegisterType<IStorage, LocalStorage>(new InjectionConstructor(fakeStorage));

            return myContainer;
        }
    }
}