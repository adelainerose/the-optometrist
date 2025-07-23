using UnityEngine;

public class DestroyOnKeypress : MonoBehaviour
{
    private bool playerInRange = false;
    [SerializeField] private AudioSource audio;
    [SerializeField] private bool playAudio = false;

    private void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown("e"))
            {
                if (playAudio)
                    audio.Play();
                playerInRange = false;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInRange = true;
    }

}
