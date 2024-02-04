using System.Collections.Generic;
using Base;
using UnityEngine;

public sealed class InitialController : MonoBehaviour
{
    private static InitialController _instance;
    private static bool _isInstanceActive = false;

    [SerializeField] private UIManager uiManager;
    public SoundManager soundManager;

    private List<IManager> managerPrefabs = new List<IManager>();

    public static InitialController Instance => _instance;

    private InitialController()
    {
    }

    private void Awake()
    {
        if (_isInstanceActive)
        {
            enabled = false;
            return;
        }

        _isInstanceActive = true;
        _instance = this;

        DontDestroyOnLoad(gameObject);
        RegisterManagers();
        InitializeManagers();
    }

    private void RegisterManagers()
    {
        managerPrefabs.Add(uiManager);
        Register.Add(uiManager);

        managerPrefabs.Add(soundManager);//aax
        Register.Add(soundManager); //aax
    }

    private void InitializeManagers()
    {
        managerPrefabs.ForEach(e => e.Init());
    }

    private void DisposeManagers()
    {
        managerPrefabs.ForEach(e => e.Dispose());
        managerPrefabs.Clear();
        Register.Remove(uiManager);

        Register.Remove(soundManager);//aax
    }

    private void OnDestroy()
    {
        _isInstanceActive = false;
        DisposeManagers();
    }
}





//using System;
//using System.Collections.Generic;
//using Base;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.Serialization;

//public sealed class InitialController : MonoBehaviour 
//{
//    private InitialController() { }

//    private static InitialController _instance;

//    [SerializeField] private UIManager uiManager;

//    private List<IManager> managerPrefabs = new List<IManager>();


//    public static InitialController GetInstance()
//    {
//        if (_instance == null)
//        {
//            _instance = new InitialController();
//        }
//        return _instance;
//    }

//    private void Awake()
//    {
//        DontDestroyOnLoad(gameObject);
//        RegisterManagers();
//        InitializeManagers();
//    }

//    private void RegisterManagers()
//    {
//        managerPrefabs.Add(uiManager);
//        Register.Add(uiManager);
//    }

//    private void InitializeManagers()
//    {
//        managerPrefabs.ForEach(e => e.Init());
//    }

//    private void DisposeManagers()
//    {
//        managerPrefabs.ForEach(e => e.Dispose());
//        managerPrefabs.Clear();
//        Register.Remove(uiManager);
//    }

//    private void OnDestroy()
//    {
//        DisposeManagers();
//    }
//}