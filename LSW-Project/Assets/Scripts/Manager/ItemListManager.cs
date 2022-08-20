using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;


public class ItemListManager : MonoBehaviour
{

    public ItemListController itemList;
    public Transform listContainer;
    public Transform parent;
    public Button buttonPrefab;

    private string title;
    private List<InventoryItem> inventory;

    public void CreateList(ListType listType)
    {

        parent.gameObject.SetActive(true);
        itemList.listType = listType;
        itemList.SetListParameters(ref title, ref inventory);

        for (int index = 0; index < inventory.Count; index++)
        {
            Button currentOption = Instantiate(buttonPrefab, transform.position, Quaternion.identity, listContainer);
            currentOption.GetComponentInChildren<TextMeshProUGUI>().SetText(inventory[index].Name);
            currentOption.onClick.AddListener(delegate { SelectListItem(currentOption); });
        }
    }

    public void SelectListItem(Button listItem)
    {
        itemList.ExecuteAction(listItem);

        parent.gameObject.SetActive(false);
        foreach (Transform child in listContainer)
        {
            Destroy(child.gameObject);
        }
    }
}

public enum ListType
{
    Buy,
    Sell
}
