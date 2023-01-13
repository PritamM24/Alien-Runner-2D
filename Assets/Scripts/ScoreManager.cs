using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text hiScoreText;

    public float ScoreCount;
    public float hiScoreCount;

    public float pointsPerSecond;

    public bool scoreAdd;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Hi-Score")) 
        {
            hiScoreCount = PlayerPrefs.GetFloat("Hi-Score");
        }
    }

    // Update is called once per frame
    
    
    void Update()
    {
        if(scoreAdd)
        {
            ScoreCount += pointsPerSecond * Time.deltaTime;
        }
 
        if (ScoreCount > hiScoreCount)
        {
            hiScoreCount = ScoreCount;
            PlayerPrefs.SetFloat("Hi-Score", hiScoreCount);
        }

        scoreText.text = "Score - " + Mathf.Round(ScoreCount);
        hiScoreText.text = "Hi-Score - " + Mathf.Round(hiScoreCount);
    }

    public void AddScore(int pointsToAdd)
    {
        ScoreCount += pointsToAdd;
    }
}
