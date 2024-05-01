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
    [SerializeField] private bool isTitle;
    private float curTimeScale;
    private int collectCount;
    [SerializeField] private Score score;
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
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(3).gameObject.SetActive(true);
        gameObject.transform.GetChild(4).gameObject.SetActive(true);
        gameObject.transform.GetChild(5).gameObject.SetActive(true);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        gameObject.transform.GetChild(7).gameObject.SetActive(true);
        if (!isTitle)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        curTimeScale = Time.timeScale;//get cur Timescale
        Time.timeScale = 0f;//pause game

    }
    public void Unpause()//toggle Ui Elements
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(3).gameObject.SetActive(false);
        gameObject.transform.GetChild(4).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
        gameObject.transform.GetChild(5).gameObject.SetActive(false);
        gameObject.transform.GetChild(7).gameObject.SetActive(false);
        if (!isTitle)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        Time.timeScale = curTimeScale;//resume
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
    
}
