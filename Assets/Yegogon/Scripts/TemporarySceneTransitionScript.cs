using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TemporarySceneTransitionScript : MonoBehaviour
{
    [SerializeField] string ThatSpecifficScene;

    private void OnTriggerEnter(Collider other)
    {
        BakeThatCake();
    }

    private void BakeThatCake()
    {
        SceneManager.LoadScene(ThatSpecifficScene);
    }
}
