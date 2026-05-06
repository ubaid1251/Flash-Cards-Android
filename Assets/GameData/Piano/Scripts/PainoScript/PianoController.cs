using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Piano;
public class PianoController : MonoBehaviour
{
    public GameObject myObj;
    public GameObject defaultObject;
    public AudioSource audioSource;
    public GameObject myAnimator, myAnimatorBG;
    public AudioClip clip;
    public AudioSource soundeffect;
    public bool checkSleepingScene,checkscene;
    public int index;
    public GameObject[] circle;
    private void Start()
    {
    
        if (!GameController.tempholder)
        {
            GameController.tempholder = defaultObject.gameObject;
        }
        
     //  GameController.tempholder.SetActive(true);

        if (checkSleepingScene)
        {
            GameController.tempsleepSceneObj = this.gameObject;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            GameController.tempsleepSceneObj.transform.GetChild(0).gameObject.SetActive(true);
        }
        //for (int i = 0; i < circle.Length; i++)
        //{
        //    circle[i].SetActive(false);
        //}
        //circle[LoadsceneCustom.Save_Scene].SetActive(true);
    }
    private void OnMouseDown()
    {
        // for (int i = 0; i < GetLevel_Active.instance.AllLevel.Length; i++)
        // {
        //     GetLevel_Active.instance.AllLevel[i].SetActive(false);
        // }
        for (int i = 0; i < circle.Length; i++)
        {
            circle[i].SetActive(false);
        }
        circle[index].SetActive(true);
        if (soundeffect)
            soundeffect.Stop();
        if (clip)
        {
            if (!myObj.activeInHierarchy)
            {
                audioSource.Stop();
                audioSource.clip = clip;
                audioSource.Play();
            }
        }

        if (GameController.tempholder != myObj && GameController.tempholder.GetComponent<Animator>())
        {
            if (GameController.tempholder.activeInHierarchy== true)
            {
                GameController.tempholder.GetComponent<Animator>().SetInteger("anim", 1);
                GameController.tempholder.GetComponent<Animator>().speed = 1;
                GameController.tempholder.GetComponent<Animator>().Play("idle");
            }
        }
        
        if (GameController.tempholder != myObj)
        {
            if(myAnimator)
            {
                myAnimator.GetComponent<Animator>().enabled = true;

                if (myAnimatorBG)
                {
                    myAnimatorBG.GetComponent<Animator>().enabled = true;
                    myAnimatorBG.GetComponent<Animator>().speed = 0;
                }
                GameController.tempholder.GetComponent<Animator>().enabled = false;
                if(GameController.tempholder.transform.GetChild(2).GetComponent<Animator>())
                    GameController.tempholder.transform.GetChild(2).GetComponent<Animator>().enabled = false;
            }
            GameController.tempholder.SetActive(false);
            GameController.tempholder = myObj;
            GameController.tempholder.SetActive(true);
            Debug.Log("Call");
            if (checkscene)
            {
                GameController.tempsleepSceneObj.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (150f/255f));
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                GameController.tempsleepSceneObj.transform.GetChild(0).gameObject.SetActive(false);
                GameController.tempsleepSceneObj = this.gameObject;
                GameController.tempsleepSceneObj.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        else
        {
            //GetLevel_Active.instance.AllLevel[LoadsceneCustom.Save_Scene].SetActive(true);
        }
        
    }

    public void GotoNextLullaby()
    {
        if (soundeffect)
            soundeffect.Stop();
        if (clip)
        {
            if (!myObj.activeInHierarchy)
            {
                audioSource.Stop();
                audioSource.clip = clip;
                audioSource.Play();
            }
        }

        if (GameController.tempholder != myObj && GameController.tempholder.GetComponent<Animator>())
        {
            GameController.tempholder.GetComponent<Animator>().SetInteger("anim", 1);
            GameController.tempholder.GetComponent<Animator>().speed = 1;
            GameController.tempholder.GetComponent<Animator>().Play("idle");
        }

        if (GameController.tempholder != myObj)
        {
            if (myAnimator)
            {
                myAnimator.GetComponent<Animator>().enabled = true;

                if (myAnimatorBG)
                {
                    myAnimatorBG.GetComponent<Animator>().enabled = true;
                    myAnimatorBG.GetComponent<Animator>().speed = 0;
                }
                GameController.tempholder.GetComponent<Animator>().enabled = false;
                if (GameController.tempholder.transform.GetChild(2).GetComponent<Animator>())
                    GameController.tempholder.transform.GetChild(2).GetComponent<Animator>().enabled = false;
            }
            GameController.tempholder.SetActive(false);
            GameController.tempholder = myObj;
            GameController.tempholder.SetActive(true);
            if (checkscene)
            {
                GameController.tempsleepSceneObj.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (150f / 255f));
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                GameController.tempsleepSceneObj.transform.GetChild(0).gameObject.SetActive(false);
                GameController.tempsleepSceneObj = this.gameObject;
                GameController.tempsleepSceneObj.transform.GetChild(0).gameObject.SetActive(true);
            }
        }

    }

}
