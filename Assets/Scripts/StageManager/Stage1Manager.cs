using UnityEngine;
using System.Collections;

public class Stage1Manager : MonoBehaviour {
    PlayerControl s_Player;
    Switch s_Switch;
    Flower s_BigFlower;
    Flower s_SmallFlower1;
    Flower s_SmallFlower2;
    Ove s_Ove;
    Tower s_Tower;
    StageManager s_StageManager;

    void OnEnable() { Init(); }

    void Awake()
    {
        StageClearValue.i_CurStageLevel = 1;
    }

	void Update () 
    {
        s_BigFlower.ActiveFlower(s_Switch);
        s_SmallFlower1.ActiveFlower(s_Switch);
        s_SmallFlower2.ActiveFlower(s_Switch);
        s_Switch.ActiveSwitch();
        s_Ove.ActiveOve();
        s_Tower.ActiveTower();

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
        s_Player = GameObject.Find("Stage1").transform.FindChild("Player").GetComponent<PlayerControl>();
        s_Switch = GameObject.Find("Stage1").transform.FindChild("Switch").GetComponent<Switch>();
        s_BigFlower = GameObject.Find("Stage1").transform.FindChild("BigFlower").GetComponent<Flower>();
        s_SmallFlower1 = GameObject.Find("Stage1").transform.FindChild("SmallFlower1").GetComponent<Flower>();
        s_SmallFlower2 = GameObject.Find("Stage1").transform.FindChild("SmallFlower2").GetComponent<Flower>();
        s_Ove = GameObject.Find("Stage1").transform.FindChild("Ove").GetComponent<Ove>();
        s_Tower = GameObject.Find("Stage1").transform.FindChild("Tower").GetComponent<Tower>();
        s_StageManager = GameObject.Find("Stage").GetComponent<StageManager>();

        s_Player.Init();
        s_Player.transform.position = new Vector3(4.3f, -49.6f, -1);
        s_Switch.Init();
        s_BigFlower.Init();
        s_SmallFlower1.Init();
        s_SmallFlower2.Init();
        s_Ove.Init();
        s_Ove.transform.position = new Vector3(51.7f, -51.9f, -2);
        s_Tower.Init();
    }
}
