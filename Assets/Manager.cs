using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public Text score_txt;
    public Text lives_txt;
    public float score = 0;
    public int lives = 3;

    bool game_ended = false;
    public GameObject GameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        score_txt.text = score.ToString();
        GameOverCanvas.SetActive(false);

        Time.timeScale = 1f;
        game_ended = false;
    }

    // Update is called once per frame
    void Update()
    {
        score_txt.text = Mathf.FloorToInt(score).ToString();
        lives_txt.text = lives.ToString() + "\nLIVES";

        if (lives <= 0)
            Endgame();

    }

    void Endgame()
    {
        if (!game_ended)
        {
            game_ended = true;
            Time.timeScale = 0f;
            GameOverCanvas.SetActive(true);

        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();  
    }
}
