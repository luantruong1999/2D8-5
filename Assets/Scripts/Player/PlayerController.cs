using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [Header("Compoments")] 
    [SerializeField]private Rigidbody2D _rigidbody2D;
    [SerializeField]private SpriteRenderer _spriteRenderer;
    [SerializeField] private MouseUtilities _mouseUtilities;
    private Vector2 moveInput;

    private void Update()
    {
        Vector2 mouseDirection = _mouseUtilities.GetMouseDirection(transform.position);
        _spriteRenderer.flipX = mouseDirection.x < 0;

    }

    private void FixedUpdate()
    {
        Vector2 velocity = moveInput * moveSpeed;
        _rigidbody2D.velocity = velocity;
        
    }
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        
    }
    
}
