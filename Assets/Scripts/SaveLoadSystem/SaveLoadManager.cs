using System.Linq;
using UnityEngine;
using VContainer;

public sealed class SaveLoadManager : MonoBehaviour
{
    private ISaveLoader[] saveLoaders;
    private GameRepository gameRepository;
    private GameContext gameContext;

    [Inject]
    public void Construct(
        SaveLoadersProvider saveLoadersProvider, 
        GameRepository gameRepository,
        GameContext gameContext)
    {
        this.saveLoaders = saveLoadersProvider.SaveLoaders.ToArray();
        this.gameRepository = gameRepository;
        this.gameContext = gameContext;
    }

    private void Start()
    {
        this.Load();
    }

    public void Load()
    {
        this.gameRepository.LoadState();

        foreach (var saveLoader in this.saveLoaders)
        {
            saveLoader.LoadGame(this.gameRepository, gameContext);
        }
    }

    public void Save()
    {
        foreach (var saveLoader in this.saveLoaders)
        {
            saveLoader.SaveGame(this.gameRepository, gameContext);
        }
            
        this.gameRepository.SaveState();
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            this.Save();
        }
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            this.Save();
        }
    }

    private void OnApplicationQuit()
    {
        this.Save();
    }
}