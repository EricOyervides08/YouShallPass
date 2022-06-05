using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class game_controller : MonoBehaviour
{
    //variable score
    public static int score = 0;
    public static int crashes;
    public int lives = 1;
    public string state = "";
    private GameObject player;
    public GameObject pauseMenu;
    public GameObject resultsMenu;
    // Start is called before the first frame update
    void Start()
    {
        crashes = 0;
        state = "Play";
        player = GameObject.Find("Player");
        pauseMenu.SetActive(false);
        resultsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (crashes >= lives)
        {
            GameOver();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (state == "Play")
            {
                Pause();
                state = "Pause";
            }
            else if (state == "Pause")
            {
                Resume();
                state = "Play";
            }
        }
        if(Input.GetKeyDown(KeyCode.Q) && (state == "Pause" || state == "Results"))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Return) && state == "Results")
        {
            SceneManager.LoadScene("inicio");
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        resultsMenu.SetActive(true);
        state = "Results";
        resultsMenu.GetComponentInChildren<Text>().text = "Score: " + score;
    }
    void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        player.SetActive(false);
    }
    void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        player.SetActive(true);
    }
}
