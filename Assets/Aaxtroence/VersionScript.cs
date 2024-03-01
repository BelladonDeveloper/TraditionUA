using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VersionScript : MonoBehaviour
{
    [SerializeField] private TMP_Text VerText;
    void Start()
    {
        VerText.text = "Version: " + Application.version;
    }
}
