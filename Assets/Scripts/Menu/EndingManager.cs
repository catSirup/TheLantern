using UnityEngine;
using System.Collections;

public class EndingManager : MonoBehaviour {
    StageManager s_StageManager;

    public Sprite Stage1;
    public Sprite Stage2;
    public Sprite Stage3;
    public Sprite Stage4;
    public Sprite Stage5;
    public Sprite Stage6;
    public Sprite Stage7;
    public Sprite Stage8;
    public Sprite Stage9;

    SpriteRenderer spriteRenderer;

	void Start () {
        s_StageManager = GameObject.Find("Managers").transform.FindChild("Stage").GetComponent<StageManager>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	void Update () {
        if (s_StageManager.stageState == StageManager.StageState.Stage1)
        {
            spriteRenderer.sprite = Stage1;
        }

        else if (s_StageManager.stageState == StageManager.StageState.Stage2)
        {
            spriteRenderer.sprite = Stage2;
        }

        else if (s_StageManager.stageState == StageManager.StageState.Stage3)
        {
            spriteRenderer.sprite = Stage3;
        }

        else if (s_StageManager.stageState == StageManager.StageState.Stage4)
        {
            spriteRenderer.sprite = Stage4;
        }

        else if (s_StageManager.stageState == StageManager.StageState.Stage5)
        {
            spriteRenderer.sprite = Stage5;
        }

        else if (s_StageManager.stageState == StageManager.StageState.Stage6)
        {
            spriteRenderer.sprite = Stage6;
        }

        else if (s_StageManager.stageState == StageManager.StageState.Stage7)
        {
            spriteRenderer.sprite = Stage7;
        }

        else if (s_StageManager.stageState == StageManager.StageState.Stage8)
        {
            spriteRenderer.sprite = Stage8;
        }
        
        else if (s_StageManager.stageState == StageManager.StageState.Stage9)
        {
            spriteRenderer.sprite = Stage9;
        }

	}
}
