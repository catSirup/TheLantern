 using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {
    PlayerControl s_Player;
    Transform t_LadderPoint;
	
	public void Init () {
        s_Player = GameObject.Find("Stage" + StageClearValue.i_CurStageLevel.ToString()).transform.FindChild("Player").GetComponent<PlayerControl>();
        t_LadderPoint = gameObject.transform.FindChild("LadderPoint").transform;
	}
	
	public void ActiveLadderCheck () 
    {
        if (s_Player.CanLadder && s_Player.InputY != 0)
        {
            s_Player.UpDownLadder = true;
            this.t_LadderPoint.gameObject.collider2D.isTrigger = true;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if ((col.name == "Head" || col.name == "Foot") && !s_Player.HaveOve)
        {
            s_Player.CanLadder = true;
        }

        if (col.name == "Foot")
        {
            s_Player.IsGround = false;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if ((col.name == "Foot" || s_Player.InputY <= 0) /*|| (col.name == "Head" || s_Player.InputY >= 0)*/)
        {
            s_Player.CanLadder = false;
            s_Player.UpDownLadder = false;
            s_Player.CanJump = true;
            t_LadderPoint.gameObject.collider2D.isTrigger = false;
            s_Player.IsGround = true;
        }
    }
}
