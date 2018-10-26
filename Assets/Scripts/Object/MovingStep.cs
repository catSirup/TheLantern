using UnityEngine;
using System.Collections;

public class MovingStep : MonoBehaviour {
    Animator animator;
    PlayerControl s_Player;

	public void Init () 
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("Move", false);
        s_Player = GameObject.Find("Stage5").transform.FindChild("Player").GetComponent<PlayerControl>();
	}

    public void ActiveStep(Switch s_Switch)
    {
        animator.SetBool("Move", s_Switch.switchState);
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            coll.transform.parent = gameObject.transform;
            s_Player.CanJump = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            coll.transform.parent = gameObject.transform.parent;
            s_Player.CanJump = false;
        }
    }
}
