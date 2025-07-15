using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool MovingLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        bool MovingRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        bool MovingUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        bool MovingDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        bool MovingAll = MovingLeft || MovingRight || MovingUp || MovingDown;

        animator.SetBool("MovingLeft", MovingLeft);
        animator.SetBool("MovingRight", MovingRight);
        animator.SetBool("MovingUp", MovingUp);
        animator.SetBool("MovingDown", MovingDown);
        animator.SetBool("MovingAll", MovingAll);

    }
}
