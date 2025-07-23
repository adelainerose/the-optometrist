using UnityEngine;

public class ScrollCredits : MonoBehaviour
{
    [SerializeField] private float speed = 50f; // Units per second

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Scroll upwards at the given speed
        rectTransform.anchoredPosition += Vector2.up * speed * Time.deltaTime;
    }
}
