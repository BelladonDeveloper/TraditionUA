using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRanomizer : MonoBehaviour
{
    public Sprite openSprite;

    private void Start()
    {
        StartCoroutine("Opening");
    }

    public IEnumerator Opening()
    {
        for(int i = 0;i < 10; i++) 
        {
            int r = Random.Range(1, 5);
            if (r == 1)
            {
                transform.gameObject.GetComponent<SpriteRenderer>().sprite = openSprite;
            }
            yield return new WaitForSeconds(2);
        }
    }
}
