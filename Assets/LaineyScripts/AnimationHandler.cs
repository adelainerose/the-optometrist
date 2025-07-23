using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    Animator animator;
    [SerializeField] private AudioSource walkingAudio;
    [SerializeField] private bool startFacingDown;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (startFacingDown)
            animator.Play("Idle_down");
    }

    void Update()
    {
        // Check inputs
        bool movingLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        bool movingRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        bool movingUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        bool movingDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);

        // Determine if any movement key is pressed
        bool movingAll = movingLeft || movingRight || movingUp || movingDown;

        // Only one direction can be true at once, so prioritize them in order:
        bool finalLeft = false;
        bool finalRight = false;
        bool finalUp = false;
        bool finalDown = false;

        // Priority order (you can adjust this order as needed)
        if (movingLeft)
            finalLeft = true;
        else if (movingRight)
            finalRight = true;
        else if (movingUp)
            finalUp = true;
        else if (movingDown)
            finalDown = true;

        // Set animator bools
        animator.SetBool("MovingLeft", finalLeft);
        animator.SetBool("MovingRight", finalRight);
        animator.SetBool("MovingUp", finalUp);
        animator.SetBool("MovingDown", finalDown);
        animator.SetBool("MovingAll", movingAll);

        if (movingAll)
            playWalkingAudio();
        else if (!movingAll)
            stopWalkingAudio();
    }

    private void playWalkingAudio()
    {
        if (!walkingAudio.isPlaying)
            walkingAudio.Play();
    }

    private void stopWalkingAudio()
    {
        walkingAudio.Stop();
    }
}
