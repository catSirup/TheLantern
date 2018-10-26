using UnityEngine;
using System.Collections;

public class LadderPoint : MonoBehaviour {
    PlayerControl s_Player;
	
	void Awake() {
        s_Player = GameObject.Find("Player").GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void OnTriggerStay2D (Collider2D col) 
    {
        if (col.gameObject.name == "LadderCollision" && s_Player.InputY < 0 && !s_Player.HaveOve)
        {
            gameObject.collider2D.isTrigger = true;
        }

        else if (col.gameObject.name == "LadderCollision")
        {
            gameObject.collider2D.isTrigger = false;
        }
	}
}
