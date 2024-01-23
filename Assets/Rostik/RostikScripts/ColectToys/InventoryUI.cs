
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI toysText;

    // Start is called before the first frame update
    void Start()
    {
        toysText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateToysText(PlayerInventory playerInventory)
    {
        toysText.text = playerInventory.NumberOfToys.ToString();
    }
}
