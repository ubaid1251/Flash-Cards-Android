using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ToyScript : MonoBehaviour
{
    public GameObject cardEntered,demoCard,Circle,Butons;
    public Transform cardFinalPos;
    public static ToyScript ins;
    void Start()
    {
        ins = this;        
    }
    private void Awake()
    {

        if (ResCheck.ResolutionType== ResType.tab)
        {
            transform.position = new Vector3(0.75f, 0.31f, 0f);
            transform.localScale = new Vector3(0.96f, 0.96f, 0.96f);

            Butons.transform.localPosition = new Vector3(82f, 14f, 0f);
            Butons.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(-143f, -225f); 
            Butons.transform.GetChild(0).transform.localScale = new Vector3(1.06f, 1.06f, 1.06f);

            Butons.transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition = new Vector2(-143f, -342f);
            Butons.transform.GetChild(1).transform.localScale = new Vector3(0.94f, 0.94f, 0.94f);

        }
    }
    public void JumpDemoOnPlace(Sprite pickedCard,Vector2 cardPickedPos)
    {
        Circle.SetActive(false);
        demoCard.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
        demoCard.GetComponent<SpriteRenderer>().sprite = pickedCard;
        cardEntered.SetActive(false);
        demoCard.SetActive(true);
        demoCard.transform.position=cardPickedPos;
        demoCard.transform.localScale = new Vector3(.65f, .65f, .65f);
        var t=new Vector3(0,4.5f,0);
        Invoke(nameof(SetMaskOn),.28f);
        Invoke(nameof(PlaySound), .6f);
        Invoke(nameof(PlayEffectSound),1f);

        demoCard.transform.DOLocalJump(t, 2, 1, 0.375f).SetEase(Ease.Linear).OnComplete(() =>
        {
           demoCard.transform.DOLocalMoveY(1.145f, 0.375f).SetEase(Ease.Linear);
        });
        
        demoCard.transform.DOScale(.75f, .75f);
    }
    public void PlaySound()
    {
        if (SettingHandler.instance)
        {
            if (SettingHandler.instance.isUiActive) return;
        }
        if (cardEntered)
        {
            AudioClip t = cardEntered.GetComponent<DragDropUbaid>().MySound;
            SoundHandler.instance.PlayFirstClip(t);
            Circle.SetActive(true);
        }
        else
        {
            SoundHandler.instance.PlayClick();
        }
    }
    public void PlayEffectSound()
    {
        if (SettingHandler.instance)
        {
            if (SettingHandler.instance.isUiActive) return;
        }
        if (cardEntered)
        {
            if (cardEntered.GetComponent<EffectSound>() && cardEntered.GetComponent<EffectSound>().Is_Effct == true)
            {
                AudioClip tAnim = cardEntered.GetComponent<EffectSound>().EfctSound;
                SoundHandler.instance.PlaySourceClip2(tAnim);
            }
        }
        else
        {
            SoundHandler.instance.PlayClick();
        }
    }
    public void PlayEffectButtonSound()
    {
        if (SettingHandler.instance)
        {
            if (SettingHandler.instance.isUiActive) return;
        }
        if (cardEntered)
        {
            if (cardEntered.GetComponent<EffectSound>())
            {
                AudioClip tAnim = cardEntered.GetComponent<EffectSound>().EfctSound;
                SoundHandler.instance.PlaySourceClip(tAnim);
            }
        }
        else
        {
            SoundHandler.instance.PlayClick();
        }
    }
    void SetMaskOn()
    {
        demoCard.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
    }
}
