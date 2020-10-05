using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI weight;
    [SerializeField]
    TextMeshProUGUI altitude;
    [SerializeField]
    TextMeshProUGUI drag;
    [SerializeField]
    TextMeshProUGUI speed;
    [SerializeField]
    TextMeshProUGUI distance;

    [SerializeField]
    GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Player player = GameState.instance.GetPlayer();

        weight.text = player.GetRigidbody().mass.ToString() + "kg";
        altitude.text = player.transform.position.y.ToString("F0") + "m";
        drag.text = player.GetRigidbody().drag.ToString("F3");
        speed.text = player.GetRigidbody().velocity.magnitude.ToString("F0");
        distance.text = player.transform.position.x.ToString("F0") + "m";

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void QuitGame()
    {
        pauseMenu.SetActive(false);
        GameState.instance.EndGame();
    }
}
