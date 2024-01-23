using Base;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour, IManager
{
    public Button settingsButton;
    public Button newGameButton;
    public Button continueButton;
    public Button levelChanger;
    public Button exitButton;

    private string currentSceneName;

    public void Init()
    {
        Debug.Log("I am initialized");
    }

    private void Start()
    {
        settingsButton.onClick.AddListener(OpenSettings);
        levelChanger.onClick.AddListener(ShowLevelChanger);
        exitButton.onClick.AddListener(ExitGame);
        
        currentSceneName = SceneManager.GetActiveScene().name;

        UpdateMenus();
    }

    private void ShowLevelChanger()
    {
        Register.Get<UIManager>().Show(UIPopupType.LevelChanger);
    }

    private void OpenSettings()
    {
        Register.Get<UIManager>().Show(UIPopupType.POPUP1);
    }

    private void UpdateMenus()
    {
        settingsButton.gameObject.SetActive(false);
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
                settingsButton.gameObject.SetActive(true);
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

    private void ExitGame()
    {
        Application.Quit();
    }

    public void Dispose()
    {
        Debug.Log("I am Disposed");
        settingsButton.onClick.RemoveAllListeners();
        levelChanger.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
    }
}

