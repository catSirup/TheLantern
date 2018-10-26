using UnityEngine;
using System.Collections;

public class Stage5Manager : MonoBehaviour {
    PlayerControl s_Player;
    Ove s_Ove;
    Flower s_Flower1;
    Flower s_Flower2;
    Flower s_Flower3;
    Tower s_Tower;
    Switch s_Switch;
    MovingStep s_MovingStep1;
    MovingStep s_MovingStep2;
    StageManager s_StageManager;

    void Awake()
    {
        StageClearValue.i_CurStageLevel = 5;
    }

    void OnEnable() 
    {
        Init();
	}
	
	void Update () 
    {
        s_Ove.ActiveOve();
        s_Flower1.ActiveFlower(s_Switch);
        s_Flower2.ActiveFlower(s_Switch);
        s_Flower3.ActiveFlower(s_Switch);
        s_Switch.ActiveSwitch();
        s_MovingStep1.ActiveStep(s_Switch);
        s_MovingStep2.ActiveStep(s_Switch);
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
        s_Player = GameObject.Find("Stage5").transform.FindChild("Player").GetComponent<PlayerControl>();
        s_Ove = GameObject.Find("Stage5").transform.FindChild("Ove").GetComponent<Ove>();
        s_Flower1 = GameObject.Find("Stage5").transform.FindChild("SmallFlower1").GetComponent<Flower>();
        s_Flower2 = GameObject.Find("Stage5").transform.FindChild("SmallFlower2").GetComponent<Flower>();
        s_Flower3 = GameObject.Find("Stage5").transform.FindChild("SmallFlower3").GetComponent<Flower>();
        s_Tower = GameObject.Find("Stage5").transform.FindChild("Tower").GetComponent<Tower>();
        s_Switch = GameObject.Find("Stage5").transform.FindChild("Switch").GetComponent<Switch>();
        s_MovingStep1 = GameObject.Find("Stage5").transform.FindChild("MovingStep1").GetComponent<MovingStep>();
        s_MovingStep2 = GameObject.Find("Stage5").transform.FindChild("MovingStep2").GetComponent<MovingStep>();
        s_StageManager = GameObject.Find("Stage").GetComponent<StageManager>();

        s_Player.transform.position = new Vector3(4.2f, -29.2f, 0);
        s_Player.Init();
        s_Ove.Init();
        s_Ove.transform.position = new Vector3(14.8f, -31.7f, -1);
        s_Flower1.Init();
        s_Flower2.Init();
        s_Flower3.Init();
        s_Switch.Init();
        s_MovingStep1.Init();
        s_MovingStep2.Init();
    }
}
