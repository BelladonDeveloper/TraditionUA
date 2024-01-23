using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private LevelData _levelData;
    
    public int CurrentLevel => _currentLevel;
    
    private int _currentLevel;
    private TextMeshProUGUI _textMeshPro;
    private Image _image;

    private void Start()
    {
        _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        _image = GetComponent<Image>();

        _textMeshPro.text = _levelData.LevelName;
        _image.sprite = _levelData.Sprite;
        _currentLevel = _levelData.Level;
    }
}
