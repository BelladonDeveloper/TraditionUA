using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType { Default, Food, Weapon, Instrument }

public class ItemScritableObject : ScriptableObject
{
    public ItemType itemType;
    public string itemName;
    public int maximumAmount;
    public string itemDedcription;
    public GameObject ItemPrefab;
    public Sprite icon;
}
