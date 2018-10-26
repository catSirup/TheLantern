using UnityEngine;
using System.Collections;

public class Stage2Manager : MonoBehaviour {
    PlayerControl s_Player;
    Ove s_Ove;
    Flower s_Flower1;
    Flower s_Flower2;
    Flower s_Flower3;
    Tower s_Tower;
    Switch s_Switch;
    StageManager s_StageManager;

	void OnEnable () 
    {
        Init();
	}

    void Awake()
    {
        StageClearValue.i_CurStageLevel = 2;
    }
	
	void Update () 
    {
        s_Flower1.ActiveFlower(s_Switch);
        s_Flower2.ActiveFlower(s_Switch);
        s_Flower3.ActiveFlower(s_Switch);
        s_Tower.ActiveTower();
        s_Ove.ActiveOve();
        s_Switch.ActiveSwitch();


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            s_Ove.transform.parent = s_Tower.transform.parent;
            s_StageManager.stageState = StageManager.StageState.Stage0;
        }
	}

    void FixedUpdate()
    {
        s_Player.ActivePlayer();
    }

    void Init()
    {
        s_Player = GameObject.Find("Stage2").transform.FindChild("Player").GetComponent<PlayerControl>();
        s_Ove = GameObject.Find("Stage2").transform.FindChild("Ove").GetComponent<Ove>();
        s_Flower1 = GameObject.Find("Stage2").transform.FindChild("SmallFlower1").GetComponent<Flower>();
        s_Flower2 = GameObject.Find("Stage2").transform.FindChild("SmallFlower2").GetComponent<Flower>();
        s_Flower3 = GameObject.Find("Stage2").transform.FindChild("SmallFlower3").GetComponent<Flower>();
        s_Tower = GameObject.Find("Stage2").transform.FindChild("Tower").GetComponent<Tower>();
        s_Switch = GameObject.Find("Stage2").transform.FindChild("Switch").GetComponent<Switch>();
        s_StageManager = GameObject.Find("Stage").GetComponent<StageManager>();

        s_Player.Init();
        s_Player.transform.position = new Vector3(4.6f, -56.21f, -1);
        s_Ove.Init();
        s_Ove.transform.position = new Vector3(25.6f, -59.5f, -2);
        s_Flower1.Init();
        s_Flower2.Init();
        s_Flower3.Init();
        s_Tower.Init();
        s_Switch.Init();
    }
}
