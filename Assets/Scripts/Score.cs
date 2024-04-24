using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    private float startTime;
    private bool counting;
    private TextMeshProUGUI scoreText;
    private int CollectCount;
    private UserSettings uSetings;
    // Start is called before the first frame update
    void Start()
    {
        uSetings = GameObject.Find("Canvas").GetComponent<UserSettings>();
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (counting)
        {
            startTime += Time.deltaTime;
            Scoring();
        }


    }
    public void StartScore()
    {
        counting = true;
    }
    private void Scoring()
    {
        float temp = startTime*2.0f;
        temp = Mathf.Round(temp);
        scoreText.text= "Score: "+temp.ToString();
    }
    public void StopScore()
    {
        counting = false;
        startTime = 0;
    }
    public void AddCScore()
    {
        CollectCount++;
        uSetings.SetCollectCount(CollectCount);
    }
    public void initSetCollectCount(int count)
    {
        CollectCount = count;
    }
}
