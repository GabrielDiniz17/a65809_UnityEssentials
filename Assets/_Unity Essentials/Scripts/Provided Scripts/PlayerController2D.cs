using UnityEngine;
using UnityEngine.InputSystem; 

/// <summary>
/// Moves forward/backward and rotates with WASD/Arrow keys.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Tooltip("Forward/back speed (units/sec).")]
    public float speed = 5.0f;

    [Tooltip("Turn speed (degrees/sec).")]
    public float rotationSpeed = 120.0f;

    private Rigidbody2D rb; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null) Debug.LogWarning("PlayerController needs a Rigidbody.");
    }

private void FixedUpdate() 
{
    Vector2 moveInput = Vector2.zero;

    // Frente/Trás
    if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)   moveInput.y = 1f;
    if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) moveInput.y = -1f;

    // Esquerda/Direita (Rotação)
    if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) moveInput.x = -1f;
    if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)moveInput.x = 1f;

    // 1. ANDAR (Usando transform.up no lugar de forward)
    Vector2 movement = (Vector2)transform.up * moveInput.y * speed * Time.fixedDeltaTime;
    rb.MovePosition(rb.position + movement);

    // 2. GIRAR (Matemática simples de 2D no lugar do Quaternion)
    float turnDirection = moveInput.x;
    if (moveInput.y < 0)
        turnDirection = -turnDirection; // Inverte o lado ao dar ré

    float turn = turnDirection * rotationSpeed * Time.fixedDeltaTime;
    rb.MoveRotation(rb.rotation - turn);
}
}
