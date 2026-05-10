using UnityEngine;

public class CheckLock : MonoBehaviour
{
    public GameObject ParentPos;
    void Start()
    {
      if(PlayerPrefs.GetInt("RemoveAds")==1)
      {
         ParentPos.transform.localPosition = new Vector3(82f, 14f, 0f);
      }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
