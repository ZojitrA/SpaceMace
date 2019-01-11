using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {
    [SerializeField] int breakableBlocks;
    [SerializeField] public int numberOfBalls;
    [Range(0.1f, 3f)] [SerializeField] float gameSpeed = 1f;

    SceneLoader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }
    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

    // Use this for initialization
    public void CountBlock()
    {
        breakableBlocks++;
    }

    public void CountBall()
    {
        numberOfBalls++;
    }

    public void DecreaseBlockCount()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneloader.LoadNextScene();
        }
    }

    public void DecreaseBallCount()
    {
        numberOfBalls--;
        if (numberOfBalls <= 0)
        {
            SceneManager.LoadScene(9);
        }
    }
}
