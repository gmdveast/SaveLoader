using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<GameContext>(Lifetime.Singleton);

        builder.Register<MoneyStorage>(Lifetime.Singleton)
            .AsImplementedInterfaces()
            .AsSelf();

        builder.Register<MoneySaveLoader>(Lifetime.Singleton)
            .AsImplementedInterfaces()
            .AsSelf();

        builder.Register<ServicesProvider>(container =>
        {
            return new ServicesProvider(new IService[]
            {
                container.Resolve<MoneyStorage>()
            });
        }, Lifetime.Singleton);

        builder.Register<SaveLoadersProvider>(container =>
        {
            return new SaveLoadersProvider(new ISaveLoader[]
            {
                container.Resolve<MoneySaveLoader>()
            });
        }, Lifetime.Singleton);

        builder.Register<GameRepository>(Lifetime.Singleton);
    }
}