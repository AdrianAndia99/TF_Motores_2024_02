using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonController : MonoBehaviour
{
    public Button[] buttons;
    public float rotationSpeed = 1f; 
    [SerializeField] private float rotationAngle = 15f;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = buttons[0].transform.localScale;
        for (int i = 0; i < buttons.Length; i++)
        {
            StartButtonRotation(buttons[i], true);
        }
    }

    private void StartButtonRotation(Button button, bool rotatePositive)
    {
        float targetAngle = 0f;
        if (rotatePositive)
        {
            targetAngle = rotationAngle;
        }
        else
        {
            targetAngle = -rotationAngle;
        }

        button.transform.DOLocalRotate(new Vector3(0f, 0f, targetAngle), rotationSpeed).SetEase(Ease.InOutSine)
            .OnComplete(() =>
            {
                StartButtonRotation(button, !rotatePositive);
            });
    }
}