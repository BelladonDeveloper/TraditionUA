using TMPro;
using UnityEngine;

public class PickUpUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerPointsTMP;
    [SerializeField] private TextMeshProUGUI _bunnyPointsTMP;

    private int _playerPoints;
    private int _bunnyPoints;

    public void OnPickedUpByPlayer()
    {
        _playerPoints++;
        _playerPointsTMP.text = _playerPoints.ToString();

        Debug.Log(_playerPoints);
    }

    public void OnPickedUpByBunny()
    {
        _bunnyPoints++;
        _bunnyPointsTMP.text = _bunnyPoints.ToString();
    }

    private void OnEnable()
    {
        
        PickingThingsUp.OnPickedUpByPlayer += OnPickedUpByPlayer;
        PickingThingsUp.OnPickedUpByBunny += OnPickedUpByBunny;
    }

    private void OnDisable()
    {
        PickingThingsUp.OnPickedUpByPlayer -= OnPickedUpByPlayer;
        PickingThingsUp.OnPickedUpByBunny -= OnPickedUpByBunny;
    }
}
