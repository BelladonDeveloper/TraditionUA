using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RecipeCollector : MonoBehaviour
{

    public GameObject player;
    public Text pickupText;
    public GameObject church;
    public string catSceneName = "CatScene";  // ����� ��� �����

    private int collectedFood = 0;
    private int totalFoodToCollect = 12;
    private bool inChurch = false;

    void Start()
    {
        pickupText.text = "Go collect 12 foods!";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            collectedFood++;

            if (collectedFood == totalFoodToCollect)
            {
                pickupText.text = "Go to the church!";
                inChurch = true;
            }
        }
        else if (other.CompareTag("Church") && inChurch)
        {
            StartCoroutine(PlayCatScene());
        }
    }

    IEnumerator PlayCatScene()
    {
        pickupText.text = "Entering church...";
        yield return new WaitForSeconds(2f);  // ��� ���  �������� �� ��� �����

        // ������ ��� �����
        SceneManager.LoadScene(catSceneName);

        // ϳ��� ���������� ��� �����, ������� ���� �������� �� ������ ���� 䳿
        player.SetActive(false);
    }
}
