using System.Collections.Generic;
using UnityEngine;

namespace Dialogues
{
    [CreateAssetMenu (fileName = "DialogContainer", menuName = "ScriptableObject/DialogContainer")]
    public class DialogSO : ScriptableObject
    {
        [SerializeField] private List<Dialogue> _dialogues;
        
        public Dialogue GetDialogue(DialogueName dialogue)
        {
            return _dialogues.Find(d => d.Name == dialogue);
        }
    }
}
