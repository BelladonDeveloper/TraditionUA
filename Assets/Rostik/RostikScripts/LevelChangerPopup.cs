using UnityEngine;

public class LevelChangerPopup : UIPopup
{
    [SerializeField] private LevelManager _levelManager;
    
    public override void Show()
    {
        base.Show();
        
        _levelManager.CreateLevels();
    }
}
