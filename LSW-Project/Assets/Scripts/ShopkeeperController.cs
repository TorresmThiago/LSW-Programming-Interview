using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperController : MonoBehaviour
{

    public bool onInteractRange = false;

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
            Debug.Log("Hey! I'm the shopkeeper.");
        }
    }
}

