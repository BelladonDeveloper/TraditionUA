using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour, IManager
{
    public Text languageText;
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject levelsMenu;
    public GameObject creditsMenu;
    public GameObject tutorialMenu;

    public Button resumeButton;
    public Button newGameButton;
    public Button continueButton;
    public Button exitButton;

    private string currentSceneName;

    public void Init()
    {
        Debug.Log("I am initialized");
    }

    private void Start()
    {
        resumeButton.onClick.AddListener(OpenSettings);
        
        currentSceneName = SceneManager.GetActiveScene().name;

        if (PlayerPrefs.HasKey("Language"))
        {
            //SetLanguage(PlayerPrefs.GetString("Language"));
        }
        else
        {
            //SetLanguage("English");
        }

        UpdateMenus();
    }

    private void OpenSettings()
    {
        Register.Get<UIManager>().Show(UIPopupType.POPUP1);
    }

    public void UpdateMenus()
    {
        resumeButton.gameObject.SetActive(false);
        newGameButton.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);

        if (currentSceneName == "MainMenu")
        {
            newGameButton.gameObject.SetActive(true);
            continueButton.gameObject.SetActive(true);
            exitButton.gameObject.SetActive(true);

            if (PlayerPrefs.HasKey("LastSaved"))
            {
                resumeButton.gameObject.SetActive(true);
            }
        }
        else if (currentSceneName == "SettingsMenu")
        {
            exitButton.gameObject.SetActive(true);
        }
        else if (currentSceneName == "LevelsMenu")
        {
            exitButton.gameObject.SetActive(true);
        }
        else if (currentSceneName == "CreditsMenu")
        {
            exitButton.gameObject.SetActive(true);
        }
        else if (currentSceneName == "TutorialMenu")
        {
            exitButton.gameObject.SetActive(true);
        }
    }

    public void SetScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SetLanguage(string language)
    {
        languageText.text = language;
        PlayerPrefs.SetString("Language", language);
        PlayerPrefs.Save();
    }

    public void LoadLastSaved()
    {
        if (PlayerPrefs.HasKey("LastSaved"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("LastSaved"));
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Dispose()
    {
        Debug.Log("I am Disposed");
    }
}

