using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSApi;
using TSApi.Controllers;
using Unity;

namespace TSTest
{

    class TestHelper
    {
        public static IUnityContainer GetTestcontainer()
        {
            // override the TSUnityContainer with blank test container to avoid
            // initialization with real instance
            TSUnityContainer.luc = new Lazy<IUnityContainer>(() => new UnityContainer());

            return TSUnityContainer.GetContainer();
        }
    }
}
