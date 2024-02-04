using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsDeleter : MonoBehaviour
{
    [SerializeField] private List<GameObject> levels;

    void Update()
    {
        
    }

    public void Delete()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            Destroy(levels[i]);

            levels.RemoveAt(i);
        }

    }
}
