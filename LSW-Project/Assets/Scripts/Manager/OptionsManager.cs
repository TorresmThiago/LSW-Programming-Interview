using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsManager : MonoBehaviour
{

    public Button optionButton;
    public Transform optionsBox;
    public Transform optionsMenu;

    public ItemListManager itemListManager;

    public void CreateSelection(string[] choices)
    {
        foreach (string option in choices)
        {
            Button currentOption = Instantiate(optionButton, transform.position, Quaternion.identity, optionsBox);
            currentOption.GetComponentInChildren<TextMeshProUGUI>().SetText(option);
            currentOption.onClick.AddListener(delegate { ChooseOption(option); });

        }

        StartSelection();
    }

    public void StartSelection()
    {
        optionsMenu.gameObject.SetActive(true);
    }

    public void ChooseOption(string chosenOption)
    {
        switch (chosenOption)
        {
            case "Buy":
                itemListManager.CreateList(ListType.Buy);
                break;

            case "Sell":
                itemListManager.CreateList(ListType.Sell);
                break;

            case "Cancel":
                foreach (Transform child in optionsBox)
                    Destroy(child.gameObject);
                break;
            default: break;
        }

        optionsMenu.gameObject.SetActive(false);

    }

}
