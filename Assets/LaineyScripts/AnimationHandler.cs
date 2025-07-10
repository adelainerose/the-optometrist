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
        bool MovingLeft = Input.GetKey(KeyCode.LeftArrow);
        bool MovingRight = Input.GetKey(KeyCode.RightArrow);
        bool MovingUp = Input.GetKey(KeyCode.UpArrow);
        bool MovingDown = Input.GetKey(KeyCode.DownArrow);
        bool MovingAll;

        if (MovingLeft == false && MovingRight == false && MovingUp == false && MovingDown == false)
            MovingAll = false;
        else
            MovingAll = true;

        animator.SetBool("MovingLeft", MovingLeft);
        animator.SetBool("MovingRight", MovingRight);
        animator.SetBool("MovingUp", MovingUp);
        animator.SetBool("MovingDown", MovingDown);
        animator.SetBool("MovingAll", MovingAll);

    }
}
