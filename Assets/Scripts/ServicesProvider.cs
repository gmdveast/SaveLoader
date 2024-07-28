using System.Collections.Generic;

public class ServicesProvider
{
    public IReadOnlyList<IService> Services { get; private set; }

    public ServicesProvider(IService[] services) 
    {
        Services = services;
    }
}