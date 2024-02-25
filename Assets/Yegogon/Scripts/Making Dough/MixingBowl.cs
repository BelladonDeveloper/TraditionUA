using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class MixingBowl : MonoBehaviour
{
    [Header("Referencces")]
    [SerializeField] private DoughStageCounter stage;
    [SerializeField] private List<ComponentInfo> AddedComponents;

    private ComponentType[] DryComponents =
    {
        ComponentType.Flour, ComponentType.Salt, ComponentType.Sugar, ComponentType.Yeast
    };
    private ComponentType[] WetComponents =
    {
        ComponentType.Water, ComponentType.Oil
    };

    private void AddingComponents()
    {
        if (stage.Stage == DoughStage.Empty && !CheckForWetSubstances())
        {
            if (IsFirstStageComlpeted())
                stage.NextDoughStage();
        }
        else if (stage.Stage == DoughStage.DryOut && IsSecondStageComlpeted())
            stage.NextDoughStage();
    }

    #region ComponentRegister
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bread Component")
        {
            ComponentInfo otherInfo = other.GetComponent<ComponentInfo>();
            ComponentInfo info = AddedComponents.Find(c => c.Type == otherInfo.Type);
            if (info == null)
            {
                AddedComponents.Add(otherInfo);
                AddingComponents();
            }
            else
                Debug.LogError($"Oops! {otherInfo.Type} somehow got in the bowl!");
        }
        else
            Debug.LogError("unknown error :(");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bread Component")
        {
            ComponentInfo otherInfo = other.GetComponent<ComponentInfo>();
            ComponentInfo info = AddedComponents.Find(c => c.Type == otherInfo.Type);
            if (info != null)
            {
                AddedComponents.Remove(info);
            }
            else
                Debug.LogError($"Oops! There's no {otherInfo.Type} in the bowl (Unity thinks so, but uhm... you know it's not true, hehe)");
        }
        else
            Debug.LogError("unknown error :(");
    }
    #endregion

    private bool CheckForWetSubstances()
    {
        //if there's any of the dry components in the bowl:
        foreach (ComponentInfo info in AddedComponents)
        {
            for (int i = 0; i < WetComponents.Length; i++)
            {
                if (info.Type == WetComponents[i])
                    return true;
            }
        }

        //if there are no "wet" components in the bowl:
        return false;
    }

    public void MixingStuff()
    {
        if (stage.Stage == DoughStage.Soup)
            stage.NextDoughStage();
    }

    #region StageProgressCheck 
    private bool IsFirstStageComlpeted()
    {
        //AND gate for dry components
        return DryComponents.All(component => AddedComponents.Any(info => info.Type == component));
    }

    private bool IsSecondStageComlpeted()
    {
        //AND gate for "wet" components
        return WetComponents.All(component => AddedComponents.Any(info => info.Type == component));
    }
    #endregion
}
