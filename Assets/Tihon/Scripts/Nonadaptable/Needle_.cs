using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Needle_ : MonoBehaviour
{
    public GameObject sino;
    public Text counterText;
    private bool canShow = true;
    private void Update()
    {
        if (canShow)
        {
            StartCoroutine("ShowingUp");
        }
    }
    public IEnumerator ShowingUp()
    {
        canShow = false;
        int x = Random.Range(8, -8);
        int y = Random.Range(8, -1);
        transform.position = new Vector3(x, y, 0);
        transform.DOMoveZ(0, 2, false);
        yield return new WaitForSeconds(1.5f);
        transform.DOMoveZ(3, 2, false);
        float waitingTime = Random.Range(1, 3);
        yield return new WaitForSeconds(waitingTime);
        canShow = true;
    }
    private void OnMouseDown()
    {
        if (gameObject.CompareTag("needle"))
        {
            Destroy(gameObject);
            sino.GetComponent<NeedleFinding>().needles--;
            sino.GetComponent<NeedleFinding>().counter++;
            counterText.text = sino.GetComponent<NeedleFinding>().counter.ToString();
        }
        if (gameObject.CompareTag("stick"))
        {
            Destroy(gameObject);
            sino.GetComponent<NeedleFinding>().counter -= 3;
            counterText.text = sino.GetComponent<NeedleFinding>().counter.ToString();
        }
    }
}