using Ninject.Modules;
using SimplifiedSlotMachine.Common.Services;
using SimplifiedSlotMachine.Services.Contracts;
using SimplifiedSlotMachine.Services.Providers;

namespace SimplifiedSlotMachine.Services.Container
{
    public class DIContainer : NinjectModule
    {
        public override void Load()
        {
            Bind<IWriter>().To<Writer>();
            Bind<IGenerator>().To<Generator>();
            Bind<IFactory>().To<GameFactory>();
            Bind<IRNDCalculator>().To<RNDCalculator>();
            Bind<IPlayGame>().To<PlayGame>();
            Bind<IRequestTranslator>().To<RequestTranslator>();
        }
    }
}