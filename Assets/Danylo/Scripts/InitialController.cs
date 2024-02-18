using System.Collections.Generic;
using UnityEngine;

namespace Base
{
    public sealed class InitialController : MonoBehaviour
    {
        private static InitialController instance { get; set; }

        [SerializeField] private UIManager uiManager;
        [SerializeField] private SoundManager soundManager;

        private List<IManager> managerPrefabs = new List<IManager>();

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
                RegisterManagers();
                InitializeManagers();
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void RegisterManagers()
        {
            managerPrefabs.Add(uiManager);
            Register.Add(uiManager);

            managerPrefabs.Add(soundManager);
            Register.Add(soundManager);
        }

        private void InitializeManagers()
        {
            managerPrefabs.ForEach(e => e.Init());
        }

        private void DisposeManagers()
        {
            managerPrefabs.ForEach(e => e.Dispose());
            managerPrefabs.Clear();

            Register.Remove(uiManager);
            Register.Remove(soundManager);
        }

        private void OnApplicationQuit()
        {
            DisposeManagers();
        }
    }
}