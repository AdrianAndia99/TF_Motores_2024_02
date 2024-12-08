using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 moveInput;
    [SerializeField]private float speed;
    [SerializeField] private Animator playerAnimator;

    [Header("Rotacion y velocidad")]
    [SerializeField] private float speedRotation;
    [SerializeField] private float giro;   
    public static event Action OnVictory;
    public static event Action OnDefeat;
    public static event Action<int> OnCollect;
    public static event Action<int> OnCollision;

    private bool isRunning;
    private bool isWalk;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if (context.started)
        {
            isWalk = true;
            playerAnimator.SetBool("isWalk",isWalk);
        }
        else if (context.canceled)
        {
            isWalk = false;
            playerAnimator.SetBool("isWalk", isWalk);
        }
    }
    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isRunning = true;
            playerAnimator.SetBool("isRun", isRunning);
            speed = speed * 1.5f;
        }
        else if (context.canceled)
        {
            isRunning = false;
            playerAnimator.SetBool("isRun", isRunning);
            speed = 15f;
        }
    }
    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(moveInput.x, 0f, moveInput.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            float smoothAngle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, giro * Time.fixedDeltaTime);
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.MovePosition(rb.position + moveDirection * speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EscapeDoor"))
        {
            OnVictory?.Invoke();
        }
        if (collision.gameObject.CompareTag("Dino"))
        {
            OnCollision?.Invoke(1);
            
        }else if(collision.gameObject.CompareTag("REX"))
        {
            OnDefeat?.Invoke();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            OnCollect?.Invoke(1);           
            Destroy(other.gameObject);
        }
    }
}