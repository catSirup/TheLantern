using UnityEngine;
using System.Collections;

public class EpilogueManager : MonoBehaviour {
    public Sprite One;
    public Sprite Two;
    public Sprite Three;
    public Sprite Four;
    public Sprite Five;
    public Sprite Six;
    public Sprite Seven;
    public Sprite Eight;
    public Sprite Nine;
    public Sprite Ten;

    int i_Count = 1;
    SpriteRenderer spriteRenderer;
    TopManager s_TopManager;

    void OnEnable()
    {
        i_Count = 1;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        s_TopManager = GameObject.Find("Managers").GetComponent<TopManager>();
        StartCoroutine(DelayTime());
    }
    void Update()
    {
        switch (i_Count)
        {
            case 1:
                spriteRenderer.sprite = One;
                break;
            case 2:
                spriteRenderer.sprite = Two;
                break;
            case 3:
                spriteRenderer.sprite = Three;
                break;
            case 4:
                spriteRenderer.sprite = Four;
                break;
            case 5:
                spriteRenderer.sprite = Five;
                break;
            case 6:
                spriteRenderer.sprite = Six;
                break;
            case 7:
                spriteRenderer.sprite = Seven;
                break;

            case 8:
                spriteRenderer.sprite = Eight;
                break;

            case 9:
                spriteRenderer.sprite = Nine;
                break;

            case 10:
                spriteRenderer.sprite = Ten;
                break;

            default:
                s_TopManager.curState = TopManager.ManagerActiveState.MAIN;
                break;

        }
    }

    IEnumerator DelayTime()
    {
        for (int i = 0; i < 11; i++)
        {
            yield return new WaitForSeconds(5.1f);
            i_Count += 1;
        }
    }
}
