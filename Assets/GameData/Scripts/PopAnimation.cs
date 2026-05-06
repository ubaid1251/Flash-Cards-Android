using UnityEngine;
using DG.Tweening;

public class PopAnimation : MonoBehaviour
{
    public GameObject PopUp;
    public float jumpPower = 0.5f;

    CanvasGroup canvasGroup;

    void Awake()
    {
        //canvasGroup = PopUp.GetComponent<CanvasGroup>();
        //if (canvasGroup == null)
        //    canvasGroup = PopUp.AddComponent<CanvasGroup>();
    }

    public void PopOn()
    {
        PopUp.transform.parent.gameObject.SetActive(true);

        DOTween.Kill(PopUp.transform);

        PopUp.transform.localScale = Vector3.zero;
        //canvasGroup.alpha = 0;

        Sequence seq = DOTween.Sequence();

        //// Fade in
        //seq.Append(canvasGroup.DOFade(1, 0.2f));

        // Anticipation (tiny squash)
        //seq.Join(PopUp.transform.DOScale(0.8f, 0.1f));

        // Big pop with overshoot
        seq.Append(PopUp.transform.DOScale(1f, 0.7f)
            .SetEase(Ease.OutBack));

        // Settle back to normal
        //seq.Append(PopUp.transform.DOScale(1f, 0.15f));

        // Soft jump effect
        //seq.Join(PopUp.transform.DOJump(
        //    PopUp.transform.position,
        //    jumpPower,
        //    1,
        //    0.4f
        //).SetEase(Ease.OutQuad));
    }

    public void PopOff()
    {
        DOTween.Kill(PopUp.transform);

        Sequence seq = DOTween.Sequence();

        //seq.Append(PopUp.transform.DOScale(0.8f, 0.5f));
        seq.Append(PopUp.transform.DOScale(0f, 0.5f)
            .SetEase(Ease.InBack));

        //seq.Join(canvasGroup.DOFade(0, 0.2f));

        seq.OnComplete(() =>
        {
            PopUp.transform.parent.gameObject.SetActive(false);
            //PopUp.SetActive(false); 
           
        });
    }
}