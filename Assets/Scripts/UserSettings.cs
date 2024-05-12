using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserSettings : MonoBehaviour
{
    //user settings
    // voulme for in game
    // voulme for music
    // pause, for when you enter the menu
    // restart and title buttons
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider gameSlider;
    [SerializeField] private TextMeshProUGUI CollectableScore;
    [SerializeField] private TextMeshProUGUI HighScoreText;
    [SerializeField] private TextMeshProUGUI LossScoreText;
    [SerializeField] private bool isTitle;
    private float curTimeScale;
    private int collectCount;
    [SerializeField] private Score score;
    [SerializeField] private GameObject gamePlay,gPaused,gameOver;
    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            loadMusicvol();
        }
        else
        {
            SetMusicVol();
        }
        if (PlayerPrefs.HasKey("gameVolume"))
        {
            loadGamevol();
        }
        else
        {
            SetGameVol();
        }
        if (PlayerPrefs.HasKey("collectCount"))
        {
            loadCollectCount();
        }
        else
        {
            SetCollectCount(0);
        }
        if (PlayerPrefs.HasKey("High Score"))
        {
            loadHighScore();
        }
        else
        {
            SetHighScore(0);
        }
    }

    public void Pause1()//toggle Ui Elements
    {
        gPaused.SetActive(true);
        gamePlay.SetActive(false);
        curTimeScale = Time.timeScale;//get cur Timescale
        Time.timeScale = 0f;//pause game

    }
    public void Unpause()//toggle Ui Elements
    {
        gPaused.SetActive(false);
        gamePlay.SetActive(true);
        Time.timeScale = curTimeScale;//resume
    }

    public void winDeathScreen()//toggles the game over screen after Gordon dies
    {
        gameOver.SetActive(true);
        gamePlay.SetActive(false);
        //gamePlay.transform.GetChild(3).gameObject.SetActive(false);
        gameOver.transform.GetChild(4).gameObject.SetActive(false);
        gameOver.transform.GetChild(0).gameObject.SetActive(false);
        /*
        HighScoreText.text = ""+PlayerPrefs.GetFloat("High Score");
        gameObject.transform.GetChild(7).gameObject.SetActive(true); //high Score
        gameObject.transform.GetChild(9).gameObject.SetActive(true); //New high Score
        gameObject.transform.GetChild(1).gameObject.SetActive(true); // Restart
        gameObject.transform.GetChild(6).gameObject.SetActive(false);//Score
        gameObject.transform.GetChild(2).gameObject.SetActive(false); //Settings Button
        gameObject.transform.GetChild(5).gameObject.SetActive(false); //Settings Paused
        */
        /*new high score
        
        
         get rid of settings button,
         
         */
    }

    public void loseDeathScreen()
    {
        SetLossScore();
        gameOver.SetActive(true);
        gamePlay.SetActive(false);
        gameOver.transform.GetChild(5).gameObject.SetActive(false);
        gameOver.transform.GetChild(1).gameObject.SetActive(false);
        /*
        //if not beat high score display score and high score
        SetLossScore();
        gameObject.transform.GetChild(7).gameObject.SetActive(true); //high Score
        gameObject.transform.GetChild(8).gameObject.SetActive(true); //Loss Score
        gameObject.transform.GetChild(1).gameObject.SetActive(true); // Restart
        gameObject.transform.GetChild(6).gameObject.SetActive(false);//Score
        gameObject.transform.GetChild(2).gameObject.SetActive(false); //Settings Button
        gameObject.transform.GetChild(5).gameObject.SetActive(false); //Settings Paused
        */
    }
    public void SetMusicVol()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("musicVol", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    private void loadMusicvol()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SetMusicVol();
    }
    public void SetGameVol()
    {
        float volume = gameSlider.value;
        myMixer.SetFloat("gameVol", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("gameVolume", volume);
    }
    private void loadGamevol()
    {
        gameSlider.value = PlayerPrefs.GetFloat("gameVolume");
        SetGameVol();
    }
    public void SetCollectCount(int count)
    {
        CollectableScore.text = "Flies: " + count;
        PlayerPrefs.SetInt("collectCount", count);
    }
    private void loadCollectCount()
    {
        CollectableScore.text = "Flies: " + PlayerPrefs.GetInt("collectCount");
        SetCollectCount(PlayerPrefs.GetInt("collectCount"));
        score.initSetCollectCount(PlayerPrefs.GetInt("collectCount"));
    }
    public void SetHighScore(float count)
    {
        HighScoreText.text = "High Score: " + count;
        PlayerPrefs.SetFloat("High Score", count);
    }
    private void loadHighScore()
    {
        HighScoreText.text = "High Score: " + PlayerPrefs.GetFloat("High Score");
        SetHighScore(PlayerPrefs.GetFloat("High Score"));
        
    }

    public float GetHighScore()
    {
        return PlayerPrefs.GetFloat("High Score");   
    }

    public void SetLossScore()
    {
        LossScoreText.text = "Your Score: " + score.getScore();
    }


    public void died()
    {
        Invoke("re", 2.0f);
    }
    public void restart()
    {
        Time.timeScale = 1.0f;
        re();
    }
    private void re()//RestartScene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        if(Input.GetKey("p"))
        {
            PlayerPrefs.SetFloat("High Score", 0);
        }
    }

}
