using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }
    private PlayerInput _playerInput;
    
    
    private void Awake()
    {
        Instance = this;
        _playerInput = new PlayerInput();
        _playerInput.Enable();
    }
    
    public Vector2 GetMovementVector() {
        Vector2 inputVector = _playerInput.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }
}
