using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenActivator : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    public bool _loadScreen = true;
    private void Awake() 
    {   
        loadingScreen.SetActive(_loadScreen);
    }
}
