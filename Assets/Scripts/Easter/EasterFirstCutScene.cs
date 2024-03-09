using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EasterFirstCutScene : MonoBehaviour
{
    [SerializeField] private List<string> _centerText;
    [SerializeField] private TMP_Text _centerTMP;
    [SerializeField] private Material newSkyboxMaterialNight;
    [SerializeField] private Material newSkyboxMaterialDay;
    [SerializeField] private GameObject _joystick;

    private int _textChanger;

    public void WriteText()
    {
        StartCoroutine(WriteTextByLetter());
    }

    public void ChangeSkyBoxToNight()
    {
        RenderSettings.skybox = newSkyboxMaterialNight;
    }


    public void ChangeSkyBoxToDay()
    {
        RenderSettings.skybox = newSkyboxMaterialDay;
    }

    public void JoystickChanger(bool change)
    {
        _joystick.SetActive(change);
    }

    private IEnumerator WriteTextByLetter()
    {
        _centerTMP.text = "";

        foreach (char letter in _centerText[_textChanger])
        {
            _centerTMP.text += letter;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(2f);

        foreach (char letter in _centerText[_textChanger])
        {
            _centerTMP.text = _centerTMP.text.Remove(_centerTMP.text.Length - 1);
            yield return new WaitForSeconds(0.025f);
        }

        _textChanger++;
    }
}
