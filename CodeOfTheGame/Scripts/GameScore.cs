using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScore : MonoBehaviour
{
    // parameters
    [SerializeField] int scorePerBlock = 78;
    // variables
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlay;
    private void Awake()
    {
        int gameStatus = FindObjectsOfType<GameScore>().Length;
        if(gameStatus > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    public void AddToScore()
    {
        currentScore = currentScore + scorePerBlock;
        scoreText.text = currentScore.ToString();
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlay()
    {
        return isAutoPlay;
    }
}
