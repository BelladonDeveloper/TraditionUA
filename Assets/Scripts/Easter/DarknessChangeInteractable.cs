using UnityEngine;

public class DarknessChangeInteractable : MonoBehaviour
{
    [SerializeField] private GameObject _darkness;

    [SerializeField] private CanvasGroup _canvasGroup;

    private bool _isDone;

    private void Update()
    {
        if (_canvasGroup.alpha == 0 && !_isDone)
        {
            _darkness.SetActive(false);

            ChangeIsDone(true);
        }

        if (_canvasGroup.alpha > 0 && _isDone)
        {
            _darkness.SetActive(true);

            ChangeIsDone(false);
        }
    }

    private bool ChangeIsDone(bool change)
    {
        _isDone = change;

        return _isDone;
    }
}