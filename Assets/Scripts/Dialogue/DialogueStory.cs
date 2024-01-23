using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueStory : MonoBehaviour
{
    [SerializeField] private Story[] _stories;
    private Dictionary<string, Story> _storyDictionary;
    public event Action<Story> ChangedStory;

    [Serializable]
    public struct Story
    {
        [SerializeField] public string Tag;
        [SerializeField] public string Text;
        [SerializeField] public Answer[] Answers;
    }

    [Serializable]
    public struct Answer
    {
        [SerializeField] public string Text;
        [SerializeField] public string ReposeText;
    }

    private void Start()
    {
        _storyDictionary = _stories.ToDictionary(key => key.Tag, element => element);
        ChangeStory(_stories[0].Tag);
    }

    public void ChangeStory(string tag) => ChangedStory?.Invoke(_storyDictionary[tag]);
}
