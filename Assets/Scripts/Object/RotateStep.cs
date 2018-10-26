using UnityEngine;
using System.Collections;

public class RotateStep : MonoBehaviour
{
    Animator animator;

    public void Init()
    {
        animator.SetBool("Rotate", false);
        animator = gameObject.GetComponent<Animator>();
    }

    public void ActiveRotateStep(Switch s_Switch)
    {
        animator.SetBool("Rotate", s_Switch.switchState);
    }
}
