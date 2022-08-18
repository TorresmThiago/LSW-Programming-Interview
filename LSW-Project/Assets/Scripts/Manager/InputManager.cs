using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        // DialogBox related actions
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            ShopkeeperController.Instance.ShopkeeperInteraction();
            DialogManager.Instance.SkipText();
        }

        // Player related Actions
        float horizontalInput = Input.GetButton("Horizontal") ? Input.GetAxisRaw("Horizontal") : 0;
        float verticalInput = Input.GetButton("Vertical") ? Input.GetAxisRaw("Vertical") : 0;

        PlayerController.Instance.PlayerMovement(horizontalInput, verticalInput);
    }
}
