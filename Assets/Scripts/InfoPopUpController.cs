using UnityEngine;

public class InfoPopupController : MonoBehaviour
{
    public GameObject infoPopup;   

    public void ShowInfo()
    {
        if (infoPopup == null) return;

        infoPopup.SetActive(true); 
        Time.timeScale = 0f;       
    }

    public void HideInfo()
    {
        if (infoPopup == null) return;

        infoPopup.SetActive(false); 
        Time.timeScale = 1f;       
    }
}