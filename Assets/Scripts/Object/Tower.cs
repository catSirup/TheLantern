using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
    Ove s_Ove;
    Transform t_Light;
    Transform t_BackLight;
    Transform t_Clear;
    Transform t_Tear;
    Transform t_Portal;
    public AudioClip a_Sound;
    private bool b_Attach;

    public void Init()
    {
        s_Ove = GameObject.Find("Ove").GetComponent<Ove>();
        t_Clear = GameObject.Find("Ove").transform.FindChild("Clear").transform;
        t_Light = gameObject.transform.FindChild("FrontLight").transform;
        t_BackLight = gameObject.transform.FindChild("BackLight").transform;
        t_Tear = gameObject.transform.FindChild("Tear").transform;
        t_Portal = GameObject.Find("Stage" + StageClearValue.i_CurStageLevel.ToString()).transform.FindChild("Portal").transform;
        b_Attach = false;
        
        t_Light.gameObject.light.intensity = 0.045f;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Ove" && s_Ove.OveCount == 3)
        {
            s_Ove.transform.position = new Vector2(gameObject.transform.position.x + 5.75f, gameObject.transform.position.y - 13);
            Destroy(s_Ove.rigidbody2D);
           
            b_Attach = true;
            
            t_Light.gameObject.light.intensity = 0.45f;
            t_BackLight.gameObject.light.intensity = 0.45f;
            t_Light.position = new Vector3(64, 36, -1.6f);
            t_BackLight.position = new Vector3(64, 36, 1.6f);

            if (b_Attach && !t_Clear.gameObject.activeInHierarchy)
            {
                AudioSource.PlayClipAtPoint(a_Sound, gameObject.transform.position);
                t_Tear.gameObject.SetActive(true);
            }

            StartCoroutine(StartAnimation());
        }
    }

    public void ActiveTower()
    {
        if (Attach)
        {
            t_Portal.gameObject.SetActive(true);
        }
    }

    public bool Attach
    {
        get { return b_Attach; }
        set { b_Attach = value; }
    }

    IEnumerator StartAnimation()
    {
        yield return new WaitForSeconds(0.8f);
        t_Tear.gameObject.SetActive(false);
        t_Clear.gameObject.SetActive(true);
    }
}
