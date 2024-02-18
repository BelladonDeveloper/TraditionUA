using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, IManager
{
    private List<UIPopup> _uiPopups = new List<UIPopup>();

    public UIPopup Show(UIPopupType type)
    {
        foreach (UIPopup popup in _uiPopups)//Dnil
        {
            if (popup.UIPopupType == type)//Dnil
            {
                popup.Show();//Dnil
                return popup;//Dnil
            }
        }


        UIPopup _popup = Resources.Load<UIPopup>(type.ToString());

        UIPopup newPopup = null;
        if (_popup != null)
        {
            newPopup = Instantiate(_popup, transform); 
            newPopup.Show();
        }
        _uiPopups.Add(newPopup);
        return newPopup;
    }

    public void Hide(UIPopupType type)
    {
        UIPopup _popup = _uiPopups.Find(x => x.UIPopupType == type);
        if (_popup != null)
        {
            _popup.Hide();
        }
    }

    public void Init()
    {
        
    }

    public void Dispose()
    {
        
    }
}

public class UIPopup : MonoBehaviour
{
    public UIPopupType UIPopupType;

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}

public enum UIPopupType
{
    None,
    POPUP1,
    LevelChanger,
    DialogueButton,
    PauseButton,
    PauseMenu,
    PauseMenuSettings
}
