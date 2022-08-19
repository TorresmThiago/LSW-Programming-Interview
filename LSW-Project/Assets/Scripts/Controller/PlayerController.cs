using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalLeftOffset;
    public float horizontalRightOffset;
    public float verticalUpOffset;
    public float verticalDownOffset;

    public float speed = 1;

    private void OnTriggerEnter2D(Collider2D other) { PlayerInteractRange(other.transform, true); }

    private void OnTriggerExit2D(Collider2D other) { PlayerInteractRange(other.transform, false); }

    public void PlayerInteractRange(Transform other, bool collision)
    {
        switch (other.name)
        {
            case "Shopkeeper":
                other.GetComponent<ShopkeeperController>().onInteractRange = collision;

                break;
            case "ShopOptions":
                other.GetComponent<ShopOptionsController>().onInteractRange = collision;
                other.GetComponent<ShopOptionsController>().CloseOptions();
                break;
            default: break;
        }
    }

    public void PlayerMovement(float horizontalInput, float verticalInput)
    {
        if (transform.position.x >= horizontalRightOffset || transform.position.x <= horizontalLeftOffset)
        {
            horizontalInput = 0;
        }

        if (transform.position.y >= verticalUpOffset || transform.position.y <= verticalDownOffset)
        {
            verticalInput = 0;
        }

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * Time.deltaTime * speed, Space.World);
    }
}
