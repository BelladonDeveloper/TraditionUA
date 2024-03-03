using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoughStageCounter : MonoBehaviour
{
    [Header("Important Stage References")]
    [SerializeField] private GameObject stage1;
    [SerializeField] private GameObject stage2;
    [SerializeField] private GameObject stage3;

    [Header("Dry Bread Components To Consume")]
    [SerializeField] private GameObject Flour;
    [SerializeField] private GameObject Salt;
    [SerializeField] private GameObject Sugar;
    [SerializeField] private GameObject Yeast;
    [Header("Dry Bread Components To Consume")]
    [SerializeField] private GameObject Water;
    [SerializeField] private GameObject Oil;

    [Header("Button references")]
    [SerializeField] private GameObject MixButton;
    [SerializeField] private GameObject BakeButton;

    [Header("Current dough stage")]
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

            MixButton.SetActive(false);
            BakeButton.SetActive(false);

            Flour.SetActive(false);
            Salt.SetActive(false);
            Sugar.SetActive(false);
            Yeast.SetActive(false);
        }
        else if (Stage == DoughStage.Soup)
        {
            //Enable:
            stage2.SetActive(true);

            MixButton.SetActive(true);

            //Disable:
            stage1.SetActive(false);
            stage3.SetActive(false);

            BakeButton.SetActive(false);

            Water.SetActive(false);
            Oil.SetActive(false);
        }
        else if (Stage == DoughStage.ReadyDough)
        {
            //Enable:
            stage3.SetActive(true);

            BakeButton.SetActive(true);

            //Disable:
            stage1.SetActive(false);
            stage2.SetActive(false);

            MixButton.SetActive(false);
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
        MixButton.SetActive(false);
        BakeButton.SetActive(false);
    }

    public void NextDoughStage()
    {
        Stage++;
    }
}
