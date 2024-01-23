using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lvl : MonoBehaviour
{
    public Button lvlButton;
    public string lvlName;
    private void Start()
    {
        lvlButton.onClick.AddListener(GoToLvl);
    }
    void GoToLvl()
    {
        if(lvlName == "Restart")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene(lvlName);
        }
    }
}
