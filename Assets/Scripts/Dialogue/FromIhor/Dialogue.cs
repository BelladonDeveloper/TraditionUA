using System;
using System.Collections.Generic;

namespace Dialogues
{
    [Serializable]
    public class Dialogue
    {
        public DialogueName Name;
        public List<DialogueLine> Lines;
    }
}
