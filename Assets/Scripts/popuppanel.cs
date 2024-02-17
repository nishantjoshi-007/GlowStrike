using UnityEngine;
using UnityEngine.UI;

public class HowToPopup : MonoBehaviour
{
    public GameObject howToPanel;

    void Start()
    {
        howToPanel.SetActive(false);
    }

    public void ShowHowToPanel()
    {
        howToPanel.SetActive(true);
    }

    public void CloseHowToPanel()
    {
        howToPanel.SetActive(false);
    }
}