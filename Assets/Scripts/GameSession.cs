using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour {



    [SerializeField] int pointsPerBlock = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] public int sceneIndex;
    [SerializeField] bool autoPlay;


    [SerializeField] int currentScore = 0;


    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;

        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        scoreText.text = currentScore.ToString();
        if (SceneManager.GetActiveScene().buildIndex != 9)
        {
            sceneIndex = SceneManager.GetActiveScene().buildIndex;
        }
    }
    
    // Update is called once per frame
    void Update () {

        scoreText.text = currentScore.ToString();
        if (sceneIndex != SceneManager.GetActiveScene().buildIndex && SceneManager.GetActiveScene().buildIndex != 9)
        {
            sceneIndex = SceneManager.GetActiveScene().buildIndex;
        }
    }


    public void AddToScore()
    {
        currentScore += pointsPerBlock;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public bool AutoPlayEnabled()
    {
        return autoPlay;
    }
}
