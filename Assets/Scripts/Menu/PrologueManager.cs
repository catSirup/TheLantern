using UnityEngine;
using System.Collections;

public class PrologueManager : MonoBehaviour {
    public Sprite One;
    public Sprite Two;
    public Sprite Three;
    public Sprite Four;
    public Sprite Five;
    public Sprite Six;
    public Sprite Seven;

    private Ray ray;
    private RaycastHit2D hit;


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
	void Update () 
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

            default:
                s_TopManager.curState = TopManager.ManagerActiveState.STAGE;
                break;

        }

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        rayCasting(ray);
	}

    IEnumerator DelayTime()
    {
        for (int i = 0; i < 8; i++)
        {
            yield return new WaitForSeconds(13);
            i_Count += 1;
        }
    }

    void rayCasting(Ray ray)
    {
        hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if (hit.collider != null && hit.transform.gameObject.name == "Skip" && Input.GetMouseButtonDown(0))
        {
            s_TopManager.curState = TopManager.ManagerActiveState.STAGE;
            StopCoroutine(DelayTime());
        }
    }
}
