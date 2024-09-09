using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Text ScoreText;

    public static UIManager Instance;

    private int score;
    public int Score
    {
        get => score; 
        set { score = value; UpdateScoreText(score); }
    }
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        ScoreText = transform.Find("ScoreText").GetComponent<Text>();
        score = 0;
    }
    void UpdateScoreText(int Score)
    {
        ScoreText.text = Score.ToString();
    }
}
