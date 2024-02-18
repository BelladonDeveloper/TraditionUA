using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Gratitude : MonoBehaviour
{
    [SerializeField] private RectTransform _transformRect;
    [SerializeField] private RectTransform _transformRectContent;
    [SerializeField] private Button _gratitudeButton;
    [SerializeField] private float _speed;

    private Vector2 _startPosition; 
    private float _yPosition;
    private bool _isTakenStartPositions;

    public void Start()
    {
        _yPosition = _transformRect.anchoredPosition.y;
        _startPosition = _transformRect.anchoredPosition; 
    }

    private void Update()
    {
        if (!_isTakenStartPositions)
        {
            _yPosition += _speed * Time.deltaTime;
            _transformRect.anchoredPosition = new Vector2(_transformRect.anchoredPosition.x, _yPosition);
        }
    }

    public void SetStartPositions()
    {
        _isTakenStartPositions = true;
        _transformRect.anchoredPosition = _startPosition;
        _transformRectContent.anchoredPosition = _startPosition;
        _yPosition = _transformRect.anchoredPosition.y;
        StartCoroutine(ChangeIsTakenStartPositions());
    }

    private IEnumerator ChangeIsTakenStartPositions()
    {
        yield return new WaitForSeconds(2f);
        _isTakenStartPositions = false;
    }

    private void OnEnable()
    {
        _gratitudeButton.onClick.AddListener(SetStartPositions);
    }
}