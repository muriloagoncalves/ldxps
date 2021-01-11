
using SimpleInjector;

namespace LDXPS.Common
{
    public class AppContainer
    {
        private static readonly AppContainer instance = new AppContainer();
        private static readonly Container container = new Container();

        private AppContainer()
        {
        }

        public static AppContainer Instance => instance;

        public Container Container => container;

        public static Container ObterContainer()
        {
            var cont = new Container();
            cont.RegisterSingleton<Servico, Servico>();

            return cont;
        }
    }
}
