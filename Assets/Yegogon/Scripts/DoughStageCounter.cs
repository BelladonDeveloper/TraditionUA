using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoughStageCounter : MonoBehaviour
{
    [SerializeField] private GameObject stage1;
    [SerializeField] private GameObject stage2;
    [SerializeField] private GameObject stage3;

    public int Counter = 0;
    
    private void Awake()
    {
        Reset();
    }

    private void Update()
    {
        if (Counter == 1)
        {
            //Enable:
            stage1.SetActive(true);

            //Disable:
            stage2.SetActive(false);
            stage3.SetActive(false);
        }
        else if (Counter == 2)
        {
            //Enable:
            stage2.SetActive(true);

            //Disable:
            stage1.SetActive(false);
            stage3.SetActive(false);
        }
        else if (Counter == 3)
        {
            //Enable:
            stage3.SetActive(true);

            //Disable:
            stage1.SetActive(false);
            stage2.SetActive(false);
        }
        else
            Reset();
    }

    private void Reset()
    {
        Counter = 0;
        stage1.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(false);
    }

    public void NextDoughStage()
    {
        Counter++;
    }
}
