using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonController : MonoBehaviour
{
    public Button[] buttons;
    public float rotationSpeed = 1f; 
    [SerializeField] private float rotationAngle = 15f;
    [SerializeField] private float scaleFactor = 1.2f;
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
    private void OnMouseEnter()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].transform.DOScale(originalScale * scaleFactor, 0.2f).SetEase(Ease.OutBack);
        }
    }

    private void OnMouseExit()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].transform.DOScale(originalScale, 0.2f).SetEase(Ease.InBack);
        }
    }
}