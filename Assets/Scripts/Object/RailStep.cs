using UnityEngine;
using System.Collections;

public class RailStep : MonoBehaviour {
    Animator animator;
    PlayerControl s_Player;

    public void Init () 
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("SwitchState", false);
        s_Player = GameObject.Find("Stage" + StageClearValue.i_CurStageLevel.ToString()).transform.FindChild("Player").GetComponent<PlayerControl>();
	}

    public void ActiveStep(Switch s_Switch)
    {
        animator.SetBool("SwitchState", s_Switch.switchState);
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
