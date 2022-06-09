using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class game_controller : MonoBehaviour
{
    //variable score
    public static int score = 0;
    public static int crashes;
    public static int lives = 1;
    public string state = "";
    private GameObject player;
    public GameObject pauseMenu;
    public GameObject resultsMenu;
    public GameObject spawners;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        crashes = 0;
        state = "Play";
        player = GameObject.Find("Player");
        pauseMenu.SetActive(false);
        resultsMenu.SetActive(false);

        timer = 0;
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
    public void PostData(int intScore, string score = "score")
    {
        StartCoroutine(PostDataCorrutina(intScore, score));
    }

    IEnumerator PostDataCorrutina(int intScore, string strScore)
    {
        string intScoreStr = intScore.ToString(); ;
        string url = "https://localhost:5000/api/post";
        WWWForm form = new WWWForm();
        form.AddField(strScore, intScoreStr);
        using (UnityWebRequest request = UnityWebRequest.Post(url, form))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
            }
        }
    }

    public void GameOver()
    {  
        if (state != "Results")
        {
            PostData(score);

            spawners.SetActive(false);
            resultsMenu.SetActive(true);
            state = "Results";
            resultsMenu.GetComponentInChildren<Text>().text = "Score: " + score;
        }
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
