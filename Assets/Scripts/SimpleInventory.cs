using UnityEngine;
using System.Collections.Generic;
using TMPro;



public class SimpleInventory : MonoBehaviour
{
    //Generic List Declaration
    private List<string> playerItems = new List<string>();
    public TextMeshProUGUI inventoryText;

    void Start()
    {
        //Create(add items)
        playerItems.Add("Fire Sword");
        playerItems.Add("Health Potion");
        UpdateUI();
    }

    public void AddItem(string itemName)
    {
        playerItems.Add(itemName);
        UpdateUI();
    }

    public void RemoveItem(string itemName)
    {
        //Remove
        if (playerItems.Remove(itemName))
        {
            Debug.Log($"Removed {itemName} from inventory");
        }
        else
        {
            Debug.LogWarning($"Could not Find {itemName}");
        }
        UpdateUI();
    }

    //player drop items when dead
    public void RemoveItemDrop()
    {
        //Loop backwards from end to 0
        for(int i = playerItems.Count; i>= 0; i--)
        {
            if (playerItems[i].Contains("Potion"))
            {
                playerItems.RemoveAt(i);
            }
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        //Update
        inventoryText.text = "Inventory Contents: \n";
        for (int i = 0; i < playerItems.Count; i++) 
        { 
            inventoryText.text += $"- {playerItems[i]}\n";
        }
    }
}
