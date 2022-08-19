using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public PlayerController player;
    public ShopkeeperController shopkeeper;
    public ShopOptionsController shopOptions;

    public DialogManager dialogManager;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            shopkeeper.ShopkeeperInteraction();
            shopOptions.OptionsInteraction();

            if (dialogManager.hasActiveDialog)
            {
                dialogManager.UpdateDialog();
            }
        }

        float horizontalInput = Input.GetButton("Horizontal") ? Input.GetAxisRaw("Horizontal") : 0;
        float verticalInput = Input.GetButton("Vertical") ? Input.GetAxisRaw("Vertical") : 0;

        player.PlayerMovement(horizontalInput, verticalInput);
    }
}
