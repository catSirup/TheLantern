using UnityEngine;
using System.Collections;

public class Flower : MonoBehaviour {
    PlayerControl s_Player;
    Ove s_Ove;
    Transform t_Light;

    public Sprite FlowerOff;
    public Sprite FlowerOn;

    SpriteRenderer spriteRenderer;

    private bool b_IsOn;
    private bool b_NotOff;

    public void Init()
    {
        s_Player = GameObject.Find("Player").GetComponent<PlayerControl>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        s_Ove = GameObject.Find("Ove").GetComponent<Ove>();
        t_Light = gameObject.transform.FindChild("Point light").transform;
        this.b_IsOn = false;
        b_NotOff = true;
    }

    public void ActiveFlower(Switch s_Switch)
    {
        if (s_Switch.switchState && b_NotOff)
        {
            this.b_IsOn = true;
        }
        else if(!s_Switch.switchState || !b_NotOff)
        {
            this.b_IsOn = false;
        }

        switch (b_IsOn)
        {
            case true:
                this.spriteRenderer.sprite = FlowerOn;
                t_Light.gameObject.light.intensity = 3.0f;
                break;

            case false:
                this.spriteRenderer.sprite = FlowerOff;
                t_Light.gameObject.light.intensity = 0.0f;
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player" && s_Player.HaveOve && b_IsOn)
        {
            b_NotOff = false;
            s_Ove.OveCount += 1;
        }

        else if (col.name == "Player" && !s_Player.HaveOve && b_IsOn)
        {
            b_NotOff = false;
            s_Player.LanternCount += 1;
        }
    }
}
