using System;
using System.Collections.Generic;
using System.Linq;
using VContainer;

public class GameContext
{
    private HashSet<IService> services;

    [Inject]
    public void Construct(ServicesProvider servicesProvider)
    {
        services = servicesProvider.Services.ToHashSet();
    }

    public T GetService<T>()
    {
        foreach (var service in services)
        {
            if (service is T result)
            {
                return result;
            }
        }

        throw new Exception($"Service {typeof(T).Name} is not found!");
    }
}