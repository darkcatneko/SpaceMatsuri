using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        movementInputer();
    }
    private void movementInputer()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput != 0 || verticalInput != 0)
        {
            var inputDir = new Vector3(horizontalInput, verticalInput, 0);
            GameManager.Instance.PlayerMovement(inputDir, GameManager.Instance.IngamePlayerData.PlayerMovementSpeed);
        }
    }
}
