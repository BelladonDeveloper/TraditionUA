using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingBowl : MonoBehaviour
{
    private DoughStageCounter stage;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Bread Component")
        {
            if (stage.Counter == 1 && other.name != "water" && other.name != "oil")
            {
                if (other.name == "wheat" && other.name == "salt" && other.name == "sugar" && other.name == "yeast")
                    stage.NextDoughStage();
            }
            else if (stage.Counter == 2 && other.name == "water" && other.name == "oil")
                stage.NextDoughStage();
            else if (other == null)
                Debug.LogError("\"other\" is null");
            else
                Debug.LogError("unknown error :(");
        }
        else
            Debug.LogError("unknown error :(");
    }
}
