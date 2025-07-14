using UnityEngine;

public class DestroyOnKeypress : MonoBehaviour
{
    private bool playerInRange = false;

    private void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown("e"))
            {
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
