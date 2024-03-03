using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu_ : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.B)) 
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
