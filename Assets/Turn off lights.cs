using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Turnofflights : MonoBehaviour
{
    [SerializeField] private GameObject LightObject;

    [SerializeField] private float Intensity;
    private Light2D MyLight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MyLight = LightObject.GetComponent<Light2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DimLights()
    {
        MyLight.intensity = Intensity;

    }
}
