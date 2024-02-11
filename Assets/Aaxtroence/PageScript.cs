using System;
using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PageScript : MonoBehaviour
{
    private int level;
    [SerializeField] private Menu menu;
    [SerializeField] private MenuData menuData;
    //
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private Button backButton;
    //
    [SerializeField] private int totalPages;
    [SerializeField] private int localPage;
    //
    [SerializeField] private GameObject GalleryScreen;
    [SerializeField] private GameObject PickLevelScreen;
    //
    [SerializeField] private Button[] Pictures;
    [SerializeField] private TMP_Text[] PictureTexts;
    //
    [SerializeField] private Texture2D[] PicturePrefabs;
    [SerializeField] private Texture2D PictureStandartPrefab;
    //
    [SerializeField] private TMP_Text leftPageText;
    [SerializeField] private TMP_Text rightPageText;
    //Pick Level Screen Buttons
    [SerializeField] private Button PLSPlayButton;
    [SerializeField] private Button PLSCancelButton;
    [SerializeField] private Button PLSCancelBG;
    //PLS Text
    [SerializeField] private TMP_Text PLSText;
    
    private int SelectedLevel;

    private void Start() 
    {
        Subscribe();
        PickLevelScreenSubscribe();

        level = menuData.level + 1;
        totalPages = (int)Math.Ceiling((float)level / 8);
        localPage = 1;

        UpdatePage();

        

    }
    private void OnDestroy() 
    {
        UnSubscribe();
    }

    private void LeftButton()
    {
        Click();
        localPage-=1;
        UpdatePage();
    }

    private void RightButton()
    {
        Click();
        localPage++;
        UpdatePage();
    }

    private void UpdatePage()
    {
        
        leftButton.gameObject.SetActive(!(localPage<=1));
        rightButton.gameObject.SetActive(!(localPage>=totalPages));


        leftPageText.text = (localPage*2-1).ToString();
        rightPageText.text = (localPage*2).ToString();

        for (int i = 0; i < Pictures.Length ; i++)
        {
            int PageIndex = (8*(localPage-1)+i+1);
            Pictures[i].gameObject.SetActive(PageIndex < level);
            //Pictures[i].image.sprite = Sprite.Create(PicturePrefabs[i], new Rect(0, 0, PicturePrefabs[i].width, PicturePrefabs[i].height), new Vector2(0.5f, 0.5f)); //КОД СТЕРЕТЬ ПРИ НАЛИЧИИ ПРЕФАБОВ ФОТОГРАФИЙ
            
            PictureTexts[i].text = PageIndex.ToString();
        }
    }

    
    private void BackButton()
    {
        Click();
        menu.Transition(() => GalleryScreen.SetActive(false));
    }

    private void PictureButton(int i)
    {
        Click();
        int PageIndex = (8*(localPage-1)+i+1);
        PickLevelScreen.SetActive(true);
        SelectedLevel = PageIndex;
        //
        PLSText.text = PageIndex.ToString();
        //
    }
    
    private void PLSPlay()
    {
        Register.Get<SoundManager>().PlayMusic(Music.None,false);
        SceneManager.LoadScene(SelectedLevel);
    }
    private void HidePLS()
    {
        Click();
        PickLevelScreen.SetActive(false);
    }

    private void Click()
    {
        Register.Get<SoundManager>().PlaySound(Sound.Click);
    }

    private void Subscribe()
    {
        leftButton.onClick.AddListener(LeftButton);
        rightButton.onClick.AddListener(RightButton);
        backButton.onClick.AddListener(BackButton);
        for (int i = 0; i < Pictures.Length ; i++)
        {
            int index = i;
            Pictures[i].onClick.AddListener(() => PictureButton(index));
        }
    }
    private void UnSubscribe()
    {
        leftButton.onClick.RemoveListener(LeftButton);
        rightButton.onClick.RemoveListener(RightButton);
        backButton.onClick.RemoveListener(BackButton);
        for (int i = 0; i < Pictures.Length ; i++)
        {
            int index = i;
            Pictures[i].onClick.RemoveListener(() => PictureButton(index));
        }
    }
    private void PickLevelScreenSubscribe()
    {
        PLSPlayButton.onClick.AddListener(PLSPlay);
        PLSCancelButton.onClick.AddListener(HidePLS);
        PLSCancelBG.onClick.AddListener(HidePLS);
    }
    private void PickLevelScreenUnSubscribe()
    {
        PLSPlayButton.onClick.RemoveListener(PLSPlay);
        PLSCancelButton.onClick.RemoveListener(HidePLS);
        PLSCancelBG.onClick.RemoveListener(HidePLS);
    }
}
