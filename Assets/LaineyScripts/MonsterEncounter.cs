using UnityEngine;
using System.Collections;

public class RandomAudioPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private bool isOn = activate_flashlight.flashlightOn;


    [SerializeField] private AudioSource audioSource;

    [SerializeField] private float minDelay = 1f;
    [SerializeField] private float maxDelay = 5f;

    [SerializeField] private float waitAfterAudio = 2f;

    void Start()
    {
        StartCoroutine(PlayAudioRoutine());
    }

    IEnumerator PlayAudioRoutine()
    {
        while (true)
        {
            // Wait random delay before playing
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            // Play audio
            audioSource.Play();
            Debug.Log("audio played");

            // Wait until audio finishes playing
            yield return new WaitForSeconds(audioSource.clip.length);

            // Wait extra time after audio
            yield return new WaitForSeconds(waitAfterAudio);

            isOn = activate_flashlight.flashlightOn;

            // Check the boolean
            if (isOn != null)
            {
                if (isOn)
                {
                    Debug.Log("Boolean is TRUE!");
                    // do something if true
                }
                else if (!isOn)
                {
                    Debug.Log("Boolean is FALSE!");
                    // do something else if false
                }
            }
            else
            {
                Debug.LogWarning("Boolean checker reference is missing!");
            }

        }
        
    }
}