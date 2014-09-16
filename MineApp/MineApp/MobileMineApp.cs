using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Resources;
using System.IO;
using System.Collections.Generic;
using MineApp.Models;
using Xamarin.Forms;
using System.Linq;
using MineApp.Services;

namespace MineApp
{
	public static class MobileMineApp
	{

        static Assembly _reflectionAssembly;
        internal static IDictionary<Type, Type> TypeMap;
        internal static readonly MethodInfo GetDependency;

        static MobileMineApp()
        {
            TypeMap = new Dictionary<Type, Type> 
            {
                {typeof(Spot), typeof(SpotRepository)}
                //{typeof(Contact), typeof(ContactRepository)},
                //{typeof(Opportunity), typeof(OpportunityRepository)},
                //{typeof(Account), typeof(AccountRepository)},
            };

            GetDependency = typeof(DependencyService)
                .GetRuntimeMethods()
                .Single((method) =>
                    method.Name.Equals("Get"));
        }
        public static void Init(Assembly assembly)
        {
            System.Threading.Interlocked.CompareExchange(ref _reflectionAssembly, assembly, null);
        }

        public static Stream LoadResource(String name)
        {
            return _reflectionAssembly.GetManifestResourceStream(name);
        }
	}
}
