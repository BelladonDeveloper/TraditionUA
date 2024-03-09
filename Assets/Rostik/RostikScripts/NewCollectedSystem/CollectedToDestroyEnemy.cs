using UnityEngine;
using TMPro;

public class CollectedToDestroyEnemy : MonoBehaviour
{
    public int collectedToDestroyMonster = 3;
    private int collectedCount = 0;

    public GameObject monster;
    public TMP_Text collectedText; 

    void Start()
    {
        UpdateCollectedText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Toy"))
        {
           
            Destroy(other.gameObject);
            collectedCount++;

            
            if (collectedCount == collectedToDestroyMonster)
            {
                DestroyMonster();
                collectedCount = 0;
            }

            UpdateCollectedText(); 
        }
    }

    void DestroyMonster()
    {
        
        if (monster != null)
        {
            Destroy(monster);
        }
    }

    void UpdateCollectedText()
    {
        
        if (collectedText != null)
        {
            collectedText.text = "Collected: " + collectedCount.ToString();
        }
    }
}