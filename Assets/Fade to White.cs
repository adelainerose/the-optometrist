using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Events;
public class FadetoWhite : MonoBehaviour

{
    [SerializeField] private GameObject LightObject;
    [SerializeField] private GameObject Player;

    private Light2D MyLight;
    private float Intensity;
    public UnityEvent loadLevel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MyLight = LightObject.GetComponent<Light2D>();
        Player.GetComponent<Move>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(MyLight.intensity<=100)
        {
            Intensity += 0.3f;
            MyLight.intensity = Intensity;
        }
        else
        {
            loadLevel.Invoke();
        }
    }
}
