using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemListManager : MonoBehaviour
{

    public BuyListController buyList;
    public SellListController sellList;
    public Transform listContainer;

    private Button item;
    private string title;
    private string[] inventory;

    public void CreateList(ListType listType)
    {

        listContainer.parent.parent.gameObject.SetActive(true);

        switch (listType)
        {
            case ListType.Buy:
                item = buyList.buyButton;
                inventory = buyList.buyInventory;
                title = buyList.title;
                break;
            case ListType.Sell:
                item = sellList.sellButton;
                inventory = sellList.sellInventory;
                title = buyList.title;
                break;
            default:
                item = null;
                inventory = null;
                title = null;
                break;
        }

        if (item != null || inventory != null || title != null)
        {
            for (int index = 0; index < inventory.Length; index++)
            {
                Button currentOption = Instantiate(item, transform.position, Quaternion.identity, listContainer);
                currentOption.GetComponentInChildren<TextMeshProUGUI>().SetText(inventory[index]);
                currentOption.onClick.AddListener(delegate { ChooseListItem(); });
            }
        }

    }

    public void ChooseListItem()
    {
        listContainer.parent.parent.gameObject.SetActive(false);
        foreach (Transform child in listContainer)
            Destroy(child.gameObject);
    }
}


public enum ListType
{
    Buy,
    Sell
}
