
using System.Collections.Generic;

public class SaveLoadersProvider
{
    public IReadOnlyList<ISaveLoader> SaveLoaders { get; private set; }

    public SaveLoadersProvider(ISaveLoader[] saveLoaders)
    {
        SaveLoaders = saveLoaders;
    }
}