using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _levelPrefab; 
    
    private List<GameObject> _levels = new List<GameObject>();

    public void CreateLevels()
    {
        if (_levelPrefab.Count != 0)
        {
            for (int i = 0; i < _levelPrefab.Count; i++)
            {
                GameObject newLevel = Instantiate(_levelPrefab[i]);

                newLevel.transform.parent = gameObject.transform;

                _levels.Add(newLevel);
            }
        }
        else
        {
            Debug.Log("The Level manager haven`t levels to create");
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _levels.Count; i++)
        {
            Destroy(_levels[i]);
        }

        _levels.Clear();
    }
}