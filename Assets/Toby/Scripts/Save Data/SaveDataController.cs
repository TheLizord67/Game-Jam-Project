using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Overlays;
using UnityEngine;

public class SaveDataController : MonoBehaviour
{
    public static SaveDataController Instance;

    public string fileName;

    public SaveDataAsset defaultData;

    private SaveData _currentData;
    public ref SaveData CurrentData => ref _currentData;

    public GameObject tutorial;
    public void Awake()
    {
        Instance = this;
        Load();
    }

    public void OnDestroy()
    {
        Save();
    }
    public void Save()
    {
        Serializer.Save(_currentData, $"{Application.persistentDataPath}/SaveData", fileName);
    }

    public void Load()
    {
        _currentData = Serializer.Load($"{Application.persistentDataPath}/SaveData", fileName, defaultData.value);
    }
}
