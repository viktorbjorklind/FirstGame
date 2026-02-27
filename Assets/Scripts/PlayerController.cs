using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  private PlayerControls controls;
  private Vector2 moveInput = Vector2.zero;
  public float speed = 5f;

  private void Awake()
  {
    controls = new PlayerControls();

    controls.Player.Move.performed += ctx =>
    {
      moveInput = ctx.ReadValue<Vector2>();
      Debug.Log("Move input: " + moveInput);
    };

    controls.Player.Move.canceled += ctx =>
    {
      moveInput = Vector2.zero;
      Debug.Log("Move input canceled");
    };
  }

  private void OnEnable()
  {
    controls.Player.Enable();
  }

  private void OnDisable()
  {
    controls.Player.Disable();
  }

  private void Update()
  {
    // Move the player in world space according to input
    Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
    transform.Translate(move * speed * Time.deltaTime, Space.World); 
  }
}