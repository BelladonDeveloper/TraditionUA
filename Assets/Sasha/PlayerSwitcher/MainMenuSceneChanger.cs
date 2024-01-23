using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneChanger : MonoBehaviour
{
    private Level _level;

    public void Start()
    {
        _level = this.gameObject.GetComponent<Level>();
    }

    public void ChangeScene()
    {
        Register.Get<UIManager>().Hide(UIPopupType.LevelChanger);
        SceneManager.LoadScene(_level.CurrentLevel);
    }
}
