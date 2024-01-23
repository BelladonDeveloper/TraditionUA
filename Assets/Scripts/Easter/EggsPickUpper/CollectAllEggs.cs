using UnityEngine;

public class CollectAllEggs : MonoBehaviour
{
    [SerializeField] private GameObject _finishTaskTimeLine;

    public void OnCollectEggs()
    {
        _finishTaskTimeLine.SetActive(true);
    }

    private void OnEnable() => CountCollectedEggs.OnCollectedAllEggs += OnCollectEggs;
    private void OnDisable() => CountCollectedEggs.OnCollectedAllEggs -= OnCollectEggs;
}
