using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Flicker : MonoBehaviour
{
    [SerializeField] private Light2D light;
    [SerializeField, Range(0f, 3f)] private float minIntensity = 0.5f;
    [SerializeField, Range(0f, 3f)] private float maxIntensity = 1.2f;
    [SerializeField] private float normalIntensity;
    [SerializeField, Min(0f)] private float minTimeBetweenFlickers;
    [SerializeField, Min(0f)] private float maxTimeBetweenFlickers;

    [SerializeField, Min(0f)] private float flickerDuration;

    private float currentTimer = 0;
    private float durationCounter = 0;
    private float timeBetweenFlickers;

    void Start()
    {
        timeBetweenFlickers = Random.Range(minTimeBetweenFlickers, maxTimeBetweenFlickers);
    }

    void Update()
    {
        if ((currentTimer > timeBetweenFlickers))
        {
            if (durationCounter <= flickerDuration)
                light.intensity = Random.Range(minIntensity, maxIntensity);
            else
            {
                light.intensity = normalIntensity;
                currentTimer = 0;
                durationCounter = 0;
                timeBetweenFlickers = Random.Range(minTimeBetweenFlickers, maxTimeBetweenFlickers);
            }

        }

        currentTimer += Time.deltaTime;
        durationCounter += Time.deltaTime;

    }

}
