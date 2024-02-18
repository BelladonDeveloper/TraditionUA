using Base;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private float transitionTime;

    [SerializeField] private InitialController initialController;
    [SerializeField] private MenuData menuData;
    //Buttons
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button galleryButton;
    [SerializeField] private Button informationButton;
    [SerializeField] private Button exitButton;
    //SettingsButtons
    [SerializeField] private Button settingsBack;
    //InformationButtons
    [SerializeField] private Button informationBack;
    //ExitButtons
    [SerializeField] private Button exitBackButton;
    [SerializeField] private Button exitBackBG;
    [SerializeField] private Button exitYes;
    
    

    [SerializeField] private GameObject SettingsScreen;
    [SerializeField] private GameObject GalleryScreen;
    [SerializeField] private GameObject QuitScreen;
    [SerializeField] private GameObject InformationScreen;
    [SerializeField] private Image TransitionScreen;


    private void Start()
    {
        Subscribe();
    }
    private void OnDestroy()
    {
        UnSubscribe();
    }
    //Play
    private void PlayButton()
    {
        StartGame();
    }
    private void StartGame()
    {
        //initialController.soundManager.PlayMusic(Music.None,false);
        SceneManager.LoadScene(menuData.level+1);
    }
    //Settings
    private void SettingsButton()
    {
        Click();
        Transition(() => SettingsScreen.SetActive(true));
    }
    private void SettingsBack()
    {
        Click();
        Transition(() => SettingsScreen.SetActive(false));
    }
    //Gallery
    private void GalleryButton()
    {
        Click();
        Transition(() => GalleryScreen.SetActive(true));
    }
    //Information
    private void InformationButton()
    {
        Click();
        Transition(() => InformationScreen.SetActive(true));
    }
    private void InformationBack()
    {
        Click();
        Transition(() => InformationScreen.SetActive(false));
    }
    //Exit
    private void ExitButton()
    {
        Click();
        QuitScreen.SetActive(true);
    }
    private void ExitBack()
    {
        Click();
        QuitScreen.SetActive(false);
    }
    private void Quit()
    {
        Application.Quit();
    }
    //
    public void Transition(Action function)
    {
        Sequence Transition1 = DOTween.Sequence();

        TransitionScreen.gameObject.SetActive(true);

        Transition1.Append(TransitionScreen.DOFade(1f, transitionTime/2));
        
        Transition1.OnComplete(() => 
        {
            function?.Invoke();
            Part2();
        });
        Transition1.Play();
    }
    private void Part2()
    {
        Sequence Transition2 = DOTween.Sequence();
        Transition2.Append(TransitionScreen.DOFade(0f, transitionTime/2));
        Transition2.OnComplete(() => TransitionScreen.gameObject.SetActive(false));
        Transition2.Play();
    }
    //
    private void Subscribe()
    {
        playButton.onClick.AddListener(PlayButton);
        settingsButton.onClick.AddListener(SettingsButton);
        galleryButton.onClick.AddListener(GalleryButton);
        informationButton.onClick.AddListener(InformationButton);
        exitButton.onClick.AddListener(ExitButton);
        //Settings Buttons
        settingsBack.onClick.AddListener(SettingsBack);
        //Information Buttons
        informationBack.onClick.AddListener(InformationBack);
        //Exit Buttons
        exitBackButton.onClick.AddListener(ExitBack);
        exitBackBG.onClick.AddListener(ExitBack);
        exitYes.onClick.AddListener(Quit);
    }
    private void UnSubscribe()
    {
        playButton.onClick.RemoveListener(PlayButton);
        settingsButton.onClick.RemoveListener(SettingsButton);
        galleryButton.onClick.RemoveListener(GalleryButton);
        informationButton.onClick.RemoveListener(InformationButton);
        exitButton.onClick.RemoveListener(ExitButton);
        //Settings Buttons
        settingsBack.onClick.RemoveListener(SettingsBack);
        //Information Buttons
        informationBack.onClick.RemoveListener(InformationBack);
        //Exit Buttons
        exitBackButton.onClick.RemoveListener(ExitBack);
        exitBackBG.onClick.RemoveListener(ExitBack);
        exitYes.onClick.RemoveListener(Quit);
    }
    //Click Sound
    private void Click()
    {
        //initialController.soundManager.PlaySound(Sound.Click);
    }
    
}

