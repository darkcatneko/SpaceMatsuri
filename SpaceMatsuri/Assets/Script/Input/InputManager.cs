using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.M_MainGameEvent.FeverTimeOnUpdateEvent.AddListener(FireworkInputer);
        GameManager.Instance.M_MainGameEvent.FreeGamePlayUpdateEvent.AddListener(movementInputer);
        GameManager.Instance.M_MainGameEvent.FeverTimeOnUpdateEvent.AddListener(movementInputer);
    }
    void Update()
    {
        //movementInputer();
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameManager.Instance.ChangePlayerTension(99);
        }
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
    private void FireworkInputer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Fire!!!");
            GameManager.Instance.CallSpawnFirework();
        }
    }
}
