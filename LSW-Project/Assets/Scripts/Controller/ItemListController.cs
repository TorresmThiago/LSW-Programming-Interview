using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemListController : MonoBehaviour
{
    public List<InventoryItem> inventory;
    public string title;
    public ListType listType;

    private void Start()
    {
        inventory = new List<InventoryItem>();

        if (listType == ListType.Buy)
        {
            inventory.Add(new InventoryItem() { Name = "Red shirt", Price = "$50" });
            inventory.Add(new InventoryItem() { Name = "Green shirt", Price = "$50" });
            inventory.Add(new InventoryItem() { Name = "Blue shirt", Price = "$50" });
        }


        if (listType == ListType.Sell)
        {
            inventory.Add(new InventoryItem() { Name = "Red shirt", Price = "$35" });
            inventory.Add(new InventoryItem() { Name = "Green shirt", Price = "$35" });
            inventory.Add(new InventoryItem() { Name = "Blue shirt", Price = "$35" });

        }
    }

    public void SetListParameters(ref string title, ref List<InventoryItem> inventory)
    {
        title = this.title;
        inventory = this.inventory;
    }

    public void ExecuteAction(Button item)
    {
        string itemName = item.GetComponentInChildren<TextMeshProUGUI>().text;

        if (listType == ListType.Buy)
        {
            Debug.Log("U just bought something!!!! It's a " + itemName);
        }


        if (listType == ListType.Sell)
        {
            Debug.Log("U just sold something!!!! It's a " + itemName);
        }
    }
}

public class InventoryItem
{
    public string Name { get; set; }
    public string Price { get; set; }
}