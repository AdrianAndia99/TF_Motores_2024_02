using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 moveInput;
    [SerializeField]private float speed;

    [Header("Rotacion y velocidad")]
    [SerializeField] private float speedRotation;
    [SerializeField] private float giro; 
    [SerializeField] private SoundsSO playerEffects;
    public static event Action OnVictory;
    public static event Action<int> OnCollect;
    public static event Action<int> OnCollision;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void OnSprint(InputAction.CallbackContext context)
    {

    }
    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(moveInput.x, 0, moveInput.y).normalized;


        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref speedRotation, giro);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            rb.MovePosition(transform.position + moveDirection * speed * Time.deltaTime);

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
            //OnDefeat?.Invoke();
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