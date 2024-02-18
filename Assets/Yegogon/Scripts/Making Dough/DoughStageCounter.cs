using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoughStageCounter : MonoBehaviour
{
    [SerializeField] private GameObject stage1;
    [SerializeField] private GameObject stage2;
    [SerializeField] private GameObject stage3;

    public DoughStage Stage;
    
    private void Awake()
    {
        Reset();
    }

    private void Update()
    {
        if (Stage == DoughStage.DryOut)
        {
            //Enable:
            stage1.SetActive(true);

            //Disable:
            stage2.SetActive(false);
            stage3.SetActive(false);
        }
        else if (Stage == DoughStage.Soup)
        {
            //Enable:
            stage2.SetActive(true);

            //Disable:
            stage1.SetActive(false);
            stage3.SetActive(false);
        }
        else if (Stage == DoughStage.ReadyDough)
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
        Stage = DoughStage.Empty;
        stage1.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(false);
    }

    public void NextDoughStage()
    {
        Stage++;
    }
}
