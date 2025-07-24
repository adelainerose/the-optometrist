using UnityEngine;

public class activate_flashlight : MonoBehaviour
{
    [SerializeField] private GameObject flashlight;
    public static bool flashlightOn = false;
    [SerializeField] private AudioSource FlashlightAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            FlashlightAudio.time = 0.05f;
            FlashlightAudio.Play();
            if (flashlightOn)
            {
                flashlight.SetActive(false);
                flashlightOn = false;
            }
            else if (!flashlightOn)
            {
                flashlight.SetActive(true);
                flashlightOn = true;
            }
        }
    }
}
