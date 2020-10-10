using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class EndDayUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject winPanel;
    [SerializeField]
    GameObject resultsPanel;

    [SerializeField]
    TextMeshProUGUI moneyEarned;
    bool resultsDisplayed = false;
    bool loadingMenu = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!resultsDisplayed)
        {
            resultsPanel.SetActive(true);
            resultsDisplayed = true;
        }
        else
        {
            if(!loadingMenu)
            {
                UserData.instance.currentMoney += Mathf.Max(0, (int)GameState.instance.GetPlayer().transform.position.x);

                SceneManager.LoadScene(1);
                Time.timeScale = 1;
            }
            loadingMenu = true;
        }
    }

    public void DisplayResults(bool win)
    {
        if(win)
        {
            winPanel.SetActive(true);
        }
        else
        {
            resultsPanel.SetActive(true);
            resultsDisplayed = true;
        }
        moneyEarned.text = "$" + ((int)(GameState.instance.GetPlayer().transform.position.x)).ToString();
    }
}
