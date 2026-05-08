using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AboutPanelHandler : MonoBehaviour
{
    private void OnEnable()
    {
                IntitializeAdmob.instance.HideBanner();

    }
    public void OpenLink(string link)
    {
        //SoundManager.instance.PlayEffect_Instance(4);
        Application.OpenURL(link);
    }
    private void OnDisable()
    {
     IntitializeAdmob.instance.ShowBanner();//remove later
    }

    public void RestorePurchase()
    {
       // unityInAppPurchase_CB.instance.RestorePurchases();
    }
}
