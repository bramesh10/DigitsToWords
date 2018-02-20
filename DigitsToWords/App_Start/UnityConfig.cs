using DigitsToWords.Services;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace DigitsToWords
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IChequeService, ChequeService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}