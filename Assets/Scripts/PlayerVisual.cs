using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour {
    
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private const string IS_RUNNING = "isRunning";

    private void Awake() {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        animator.SetBool(IS_RUNNING, PlayerController.Instance.IsPlayerRunning());
        SetPlayerFacingDirection();   
    }

    private void SetPlayerFacingDirection() {
        Vector3 mousePos = GameInput.Instance.GetMousePosition();
        Vector3 playerPos = PlayerController.Instance.GetPlayerScreenPosition();

        if (Input.GetKey(KeyCode.A)) {
            spriteRenderer.flipX = false;
        } else if (Input.GetKey(KeyCode.D)) {
            spriteRenderer.flipX = true;
        }
    }
}
