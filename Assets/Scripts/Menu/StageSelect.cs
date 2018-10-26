using UnityEngine;
using System.Collections;

public class StageSelect : MonoBehaviour
{
    StageManager s_StageManager;

    public Sprite Off;
    public Sprite On;
    public Sprite CanPlay;
    //public Sprite YesOff;
    //public Sprite YesOn;
    //public Sprite NoOff;
    //public Sprite NoOn;

    private SpriteRenderer spriteRenderer;

    public static bool b_Stage1 = false;
    public static bool b_Stage2 = false;
    public static bool b_Stage3 = false;
    public static bool b_Stage4 = false;
    public static bool b_Stage5 = false;
    public static bool b_Stage6 = false;
    public static bool b_Stage7 = false;
    public static bool b_Stage8 = false;
    public static bool b_Stage9 = false;

    void Start()
    {
        s_StageManager = GameObject.Find("Stage").GetComponent<StageManager>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        this.spriteRenderer.sprite = Off;
    }

    void OnMouseDown()
    {
        SelectStage();
    }

    void Update()
    {
        ClearStage();
    }

    void SelectStage()
    {
        switch (gameObject.name)
        {
            case "Stage1_Select":
                b_Stage1 = true;
                b_Stage2 = false;
                b_Stage3 = false;
                b_Stage4 = false;
                b_Stage5 = false;
                b_Stage6 = false;
                b_Stage7 = false;
                b_Stage8 = false;
                b_Stage9 = false;
                break;
            case "Stage2_Select":
                if (StageClearValue.isStage1Clear)
                {
                    b_Stage1 = false;
                    b_Stage2 = true;
                    b_Stage3 = false;
                    b_Stage4 = false;
                    b_Stage5 = false;
                    b_Stage6 = false;
                    b_Stage7 = false;
                    b_Stage8 = false;
                    b_Stage9 = false;
                }
                break;
            case "Stage3_Select":
                if (StageClearValue.isStage2Clear)
                {
                    b_Stage1 = false;
                    b_Stage2 = false;
                    b_Stage3 = true;
                    b_Stage4 = false;
                    b_Stage5 = false;
                    b_Stage6 = false;
                    b_Stage7 = false;
                    b_Stage8 = false;
                    b_Stage9 = false;
                }
                break;

            case "Stage4_Select":
                if (StageClearValue.isStage3Clear)
                {
                    b_Stage1 = false;
                    b_Stage2 = false;
                    b_Stage3 = false;
                    b_Stage4 = true;
                    b_Stage5 = false;
                    b_Stage6 = false;
                    b_Stage7 = false;
                    b_Stage8 = false;
                    b_Stage9 = false;
                }
                break;

            case "Stage5_Select":
                if (StageClearValue.isStage4Clear)
                {
                    b_Stage1 = false;
                    b_Stage2 = false;
                    b_Stage3 = false;
                    b_Stage4 = false;
                    b_Stage5 = true;
                    b_Stage6 = false;
                    b_Stage7 = false;
                    b_Stage8 = false;
                    b_Stage9 = false;
                }
                break;

            case "Stage6_Select":
                if (StageClearValue.isStage5Clear)
                {
                    b_Stage1 = false;
                    b_Stage2 = false;
                    b_Stage3 = false;
                    b_Stage4 = false;
                    b_Stage5 = false;
                    b_Stage6 = true;
                    b_Stage7 = false;
                    b_Stage8 = false;
                    b_Stage9 = false;
                }
                break;

            case "Stage7_Select":
                if (StageClearValue.isStage6Clear)
                {
                    b_Stage1 = false;
                    b_Stage2 = false;
                    b_Stage3 = false;
                    b_Stage4 = false;
                    b_Stage5 = false;
                    b_Stage6 = false;
                    b_Stage7 = true;
                    b_Stage8 = false;
                    b_Stage9 = false;
                }
                break;

            case "Stage8_Select":
                if (StageClearValue.isStage7Clear)
                {
                    b_Stage1 = false;
                    b_Stage2 = false;
                    b_Stage3 = false;
                    b_Stage4 = false;
                    b_Stage5 = false;
                    b_Stage6 = false;
                    b_Stage7 = false;
                    b_Stage8 = true;
                    b_Stage9 = false;
                }
                break;

            case "Stage9_Select":
                if (StageClearValue.isStage8Clear)
                {
                    b_Stage1 = false;
                    b_Stage2 = false;
                    b_Stage3 = false;
                    b_Stage4 = false;
                    b_Stage5 = false;
                    b_Stage6 = false;
                    b_Stage7 = false;
                    b_Stage8 = false;
                    b_Stage9 = true;
                }
                break;
        }
    }

    void ClearStage()
    {
        if (!StageClearValue.isStage1Clear && this.name == "Stage1_Select")
        {
            spriteRenderer.sprite = CanPlay;
        }

        else if (StageClearValue.isStage1Clear && this.name == "Stage1_Select")
        {
            spriteRenderer.sprite = On;
        }

        if (StageClearValue.isStage1Clear && !StageClearValue.isStage2Clear && this.name == "Stage2_Select")
        {
            spriteRenderer.sprite = CanPlay;
        }

        else if (StageClearValue.isStage1Clear && StageClearValue.isStage2Clear && this.name == "Stage2_Select")
        {
            spriteRenderer.sprite = On;
        }

        if (StageClearValue.isStage2Clear && !StageClearValue.isStage3Clear && this.name == "Stage3_Select")
        {
            spriteRenderer.sprite = CanPlay;
        }

        else if (StageClearValue.isStage2Clear && StageClearValue.isStage3Clear && this.name == "Stage3_Select")
        {
            spriteRenderer.sprite = On;
        }

        if (StageClearValue.isStage3Clear && !StageClearValue.isStage4Clear && this.name == "Stage4_Select")
        {
            spriteRenderer.sprite = CanPlay;
        }

        else if (StageClearValue.isStage3Clear && StageClearValue.isStage4Clear && this.name == "Stage4_Select")
        {
            spriteRenderer.sprite = On;
        }

        if (StageClearValue.isStage4Clear && !StageClearValue.isStage5Clear && this.name == "Stage5_Select")
        {
            spriteRenderer.sprite = CanPlay;
        }

        else if (StageClearValue.isStage4Clear && StageClearValue.isStage5Clear && this.name == "Stage5_Select")
        {
            spriteRenderer.sprite = On;
        }

        if (StageClearValue.isStage5Clear && !StageClearValue.isStage6Clear && this.name == "Stage6_Select")
        {
            spriteRenderer.sprite = CanPlay;
        }

        else if (StageClearValue.isStage5Clear && StageClearValue.isStage6Clear && this.name == "Stage6_Select")
        {
            spriteRenderer.sprite = On;
        }

        if (StageClearValue.isStage6Clear && !StageClearValue.isStage7Clear && this.name == "Stage7_Select")
        {
            spriteRenderer.sprite = CanPlay;
        }

        else if (StageClearValue.isStage6Clear && StageClearValue.isStage7Clear && this.name == "Stage7_Select")
        {
            spriteRenderer.sprite = On;
        }

        if (StageClearValue.isStage7Clear && !StageClearValue.isStage8Clear && this.name == "Stage8_Select")
        {
            spriteRenderer.sprite = CanPlay;
        }

        else if (StageClearValue.isStage7Clear && StageClearValue.isStage8Clear && this.name == "Stage8_Select")
        {
            spriteRenderer.sprite = On;
        }

        if (StageClearValue.isStage8Clear && !StageClearValue.isStage9Clear && this.name == "Stage9_Select")
        {
            spriteRenderer.sprite = CanPlay;
        }

        else if (StageClearValue.isStage8Clear && StageClearValue.isStage9Clear && this.name == "Stage9_Select")
        {
            spriteRenderer.sprite = On;
        }
    }

}
