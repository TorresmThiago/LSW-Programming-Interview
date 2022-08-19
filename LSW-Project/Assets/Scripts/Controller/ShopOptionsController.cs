using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOptionsController : MonoBehaviour
{
    public bool onInteractRange;

    public OptionsManager optionsManager;

    public string[] choices;

    private void Start()
    {
        onInteractRange = false;
    }

    public void OptionsInteraction()
    {
        if (onInteractRange)
        {
            optionsManager.CreateSelection(choices);
            onInteractRange = false;
        }
    }

    public void CloseOptions()
    {
        optionsManager.ChooseOption("Cancel");
    }
}
