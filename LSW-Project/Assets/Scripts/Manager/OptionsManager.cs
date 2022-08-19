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
        gameObject.SetActive(true);
    }

    public void ChooseOption(string chosenOption)
    {
        switch (chosenOption)
        {
            case "Buy":
                Debug.Log("Time to spend some moneyyy");
                break;

            case "Sell":
                Debug.Log("Hard working boy, hm?");
                break;

            case "Cancel":
                gameObject.SetActive(false);
                foreach (Transform child in optionsBox)
                    Destroy(child.gameObject);
                break;
            default: break;
        }

    }

}
