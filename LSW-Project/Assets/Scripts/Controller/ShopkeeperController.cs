using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperController : MonoBehaviour
{
    public static ShopkeeperController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public bool onInteractRange;

    public string _dialogPath;

    private void Start()
    {
        onInteractRange = false;
        _dialogPath = "./Assets/Dialogs/shopkeeper.txt";
    }

    public void ShopkeeperInteraction()
    {
        if (onInteractRange)
        {
            DialogManager.Instance.lines = System.IO.File.ReadAllLines(_dialogPath);
            DialogManager.Instance.StartDialog();
        }
    }
}

