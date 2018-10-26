using UnityEngine;
using System.Collections;

public class MenuSelect : MonoBehaviour {
    MainManager s_MainManager;
    TopManager s_TopManager;
    StageManager s_StageManager;

    public Sprite sp_Off;
    public Sprite sp_On;
    SpriteRenderer spriteRenderer;

    void OnEnable()
    {
        spriteRenderer.sprite = sp_Off;
    }

    void Awake()
    {
        s_MainManager = GameObject.Find("Managers").GetComponent<MainManager>();
        s_TopManager = GameObject.Find("Managers").GetComponent<TopManager>();
        s_StageManager = GameObject.Find("Managers").transform.FindChild("Stage").GetComponent<StageManager>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    
    void OnMouseDown()
    {
        if (this.CompareTag("Start"))
        {
            s_TopManager.curState = TopManager.ManagerActiveState.PROLOGUE;
        }

        else if (this.CompareTag("Develop"))
        {
            s_MainManager.mainState = MainManager.MainState.Develop;
        }

        else if (this.CompareTag("Tutorial"))
        {
            s_MainManager.mainState = MainManager.MainState.Tutorial;
        }

        else if (this.CompareTag("Quit"))
        {
            s_MainManager.mainState = MainManager.MainState.Quit;
        }

        else if (this.CompareTag("GotoMain"))
        {
            s_MainManager.mainState = MainManager.MainState.Title;
            s_TopManager.curState = TopManager.ManagerActiveState.MAIN;
        }

        else if (this.name == "Yes")
        {
            spriteRenderer.sprite = sp_On;
            if (StageSelect.b_Stage1)
            {
                s_StageManager.stageState = StageManager.StageState.Stage1;
                StageSelect.b_Stage1 = false;
            }
            else if (StageSelect.b_Stage2)
            {
                s_StageManager.stageState = StageManager.StageState.Stage2;
                StageSelect.b_Stage2 = false;
            }
            else if (StageSelect.b_Stage3)
            {
                s_StageManager.stageState = StageManager.StageState.Stage3;
                StageSelect.b_Stage3 = false;
            }

            else if (StageSelect.b_Stage4)
            {
                s_StageManager.stageState = StageManager.StageState.Stage4;
                StageSelect.b_Stage4 = false;
            }

            else if (StageSelect.b_Stage5)
            {
                s_StageManager.stageState = StageManager.StageState.Stage5;
                StageSelect.b_Stage5 = false;
            }

            else if (StageSelect.b_Stage6)
            {
                s_StageManager.stageState = StageManager.StageState.Stage6;
                StageSelect.b_Stage6 = false;
            }

            else if (StageSelect.b_Stage7)
            {
                s_StageManager.stageState = StageManager.StageState.Stage7;
                StageSelect.b_Stage7 = false;
            }

            else if (StageSelect.b_Stage8)
            {
                s_StageManager.stageState = StageManager.StageState.Stage8;
                StageSelect.b_Stage8 = false;
            }

            else if (StageSelect.b_Stage9)
            {
                s_StageManager.stageState = StageManager.StageState.Stage9;
                StageSelect.b_Stage9 = false;
            }
        }

        else if (this.name == "No")
        {
            s_StageManager.stageState = StageManager.StageState.Stage0;
        }
    }

    void OnMouseOver()
    {
        if (gameObject.CompareTag("Start"))
        {
            this.spriteRenderer.sprite = sp_On;
        }
           
        else if (gameObject.CompareTag("Develop"))
        {
            this.spriteRenderer.sprite = sp_On;
        }

        else if (gameObject.CompareTag("Tutorial"))
        {
            this.spriteRenderer.sprite = sp_On;
        }

        else if (gameObject.CompareTag("Quit"))
        {
            this.spriteRenderer.sprite = sp_On;
        }

        else if (gameObject.CompareTag("GotoMain"))
        {
            this.spriteRenderer.sprite = sp_On;
        }

        else if (this.name == "Yes")
        {
            this.SpriteRenderer.sprite = sp_On;
        }

        else if (this.name == "No")
        {
            this.SpriteRenderer.sprite = sp_On;
        }
    }

    void OnMouseExit()
    {
        if (gameObject.CompareTag("Start"))
        {
            this.spriteRenderer.sprite = sp_Off;
        }

        else if (gameObject.CompareTag("Develop"))
        {
            this.spriteRenderer.sprite = sp_Off;
        }

        else if (gameObject.CompareTag("Tutorial"))
        {
            this.spriteRenderer.sprite = sp_Off;
        }

        else if (gameObject.CompareTag("Quit"))
        {
            this.spriteRenderer.sprite = sp_Off;
        }

        else if (gameObject.CompareTag("GotoMain"))
        {
            this.spriteRenderer.sprite = sp_Off;
        }

        else if (this.name == "Yes")
        {
            this.spriteRenderer.sprite = sp_Off;
        }

        else if (this.name == "No")
        {
            this.spriteRenderer.sprite = sp_Off;
        }
    }

    public SpriteRenderer SpriteRenderer
    {
        get { return spriteRenderer; }
        set { spriteRenderer = value; }
    }
}
