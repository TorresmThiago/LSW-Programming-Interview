using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperController : MonoBehaviour
{

    public bool onInteractRange;

    private string _dialogPath;

    private void Start()
    {
        onInteractRange = false;
        _dialogPath = "./Assets/Dialogs/shopkeeper.txt";
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            ShopkeeperInteraction();
        }

    }

    public void ShopkeeperInteraction()
    {
        if (onInteractRange)
        {
            DialogManager.Instance.StartDialog(_dialogPath);
        }
    }
}

