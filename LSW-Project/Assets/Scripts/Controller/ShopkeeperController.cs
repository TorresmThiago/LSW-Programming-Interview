using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperController : MonoBehaviour
{
    public bool onInteractRange;

    public DialogManager dialogManager;

    private string _dialogPath;
    private string[] _lines;

    private void Start()
    {
        onInteractRange = false;
        _dialogPath = "./Assets/Dialogs/shopkeeper.txt";
        _lines = System.IO.File.ReadAllLines(_dialogPath);
    }

    public void ShopkeeperInteraction()
    {
        if (onInteractRange && dialogManager.lines.Length == 0)
        {
            dialogManager.lines = _lines;
            dialogManager.StartDialog();
        }
    }
}

