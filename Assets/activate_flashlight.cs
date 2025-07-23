using UnityEngine;

public class activate_flashlight : MonoBehaviour
{
    [SerializeField] private GameObject flashlight;
    public static bool flashlightOn = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flashlight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
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
