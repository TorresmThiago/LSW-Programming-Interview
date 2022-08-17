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

    private float _verticalInput;
    private float _horizontalInput;


    void Update()
    {
        PlayerMovement();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.GetComponent<ShopkeeperController>().onInteractRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.transform.GetComponent<ShopkeeperController>().onInteractRange = false;
    }

    private void PlayerMovement()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        if ((_horizontalInput == 1 && transform.position.x >= horizontalRightOffset)
          || _horizontalInput == -1 && transform.position.x <= horizontalLeftOffset)
        {
            _horizontalInput = 0;
        }

        if ((_verticalInput == 1 && transform.position.y >= verticalUpOffset)
        || _verticalInput == -1 && transform.position.y <= verticalDownOffset)
        {
            _verticalInput = 0;
        }

        Vector3 direction = new Vector3(_horizontalInput, _verticalInput, 0);
        transform.Translate(direction * Time.deltaTime * speed, Space.World);
    }
}
