using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool PauseGame;

    public GameObject pausePanel;
    public GameObject settingsPanel;
    public Button resumeButton;
    public Button settingsButton;
    public Button quitButton;
    public Button backButton;

    public Slider volumeSlider;
    public Toggle muteToggle;
    public AudioClip[] musicTracks = new AudioClip[8];
    private AudioSource audioSource;


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                ResumeGame();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Start()
    {
        resumeButton.onClick.AddListener(ResumeGame);
        settingsButton.onClick.AddListener(OpenSettings);
        quitButton.onClick.AddListener(QuitToMainMenu);
        backButton.onClick.AddListener(GoBack);

      
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
        }

        audioSource = GetComponent<AudioSource>();
        PlayRandomTrack();
    }

    public void ResumeGame()
    {
        // Продовжити гру
        pausePanel.SetActive(false);
        Time.timeScale = 1f; // Відновити час
        PauseGame = false;

    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;

    }

    public void OpenSettings()
    {
        // Відкрити панель налаштувань
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void QuitToMainMenu()
    {
        // Повернутися в основне меню
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void GoBack()
    {
        // Повернутися назад до меню паузи
        settingsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    
    public void ChangeVolume(float volume)
    {

        Debug.Log("Гучність: " + volume);
    }

    public void MuteAllSounds(bool isMuted)
    {
        Debug.Log("Mute All Sounds: " + isMuted);
    }

    private void PlayRandomTrack()
    {
        if (musicTracks.Length > 0)
        {
            int randomIndex = Random.Range(0, musicTracks.Length);
            //audioSource.clip = musicTracks[randomIndex];
            //audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Немає треків для відтворення.");
        }
    }
}
