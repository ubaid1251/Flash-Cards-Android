using UnityEngine;
using UnityEngine.SceneManagement;
public class Parental : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     void Start()
    {
        
    }
    public GameObject Obj;
    // Update is called once per frame
    public void ShowParental()
    {
        Obj.SetActive(true);
        SoundHandler.instance.PlayClick();
        AdditionParentalPanel.ins.isParent = true;
    }
    public void ShowSetting()
    {
        SettingHandler.instance.ShowPanel();
        SoundHandler.instance.PlayClick();
    }
    public void pp()
    {
        Obj.SetActive(true);
        SoundHandler.instance.PlayClick();
        AdditionParentalPanel.ins.isPrivacy = true;
    }
    public void term()
    {
        Obj.SetActive(true);
        SoundHandler.instance.PlayClick();
        AdditionParentalPanel.ins.terms = true;
    }
    public void LoadHome()
    {
        PlayerPrefs.SetInt("RateCounter", PlayerPrefs.GetInt("RateCounter") + 1);
        PlayerPrefs.SetInt("Completed", 1);

        SceneManager.LoadScene("Selection");
    }
}
