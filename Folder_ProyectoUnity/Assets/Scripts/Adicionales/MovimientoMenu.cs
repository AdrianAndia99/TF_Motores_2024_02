using UnityEngine;

public class MovimientoMenu : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    private int currentPointIndex = 0;

    private void Update()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        if (points.Length == 0) 
        {
            return;
        } 

        Vector3 target = points[currentPointIndex].position;

        Vector3 direction = (target - transform.position).normalized;

        if (direction.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % points.Length;
        }
    }
}