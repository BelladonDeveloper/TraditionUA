using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSceneViaButton : MonoBehaviour
{
    [SerializeField] string ThatSpecifficScene;
    public void GoToASpecifficScene() => SceneManager.LoadScene(ThatSpecifficScene);
}
