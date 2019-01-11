using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip destroySound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] damageSprites;

    [SerializeField] int timesHit;

    Level level;
    GameSession gamestatus;

    int maxHits;

    // Use this for initialization
    private void Start()
    {

        if(tag == "breakable")
        {
            level = FindObjectOfType<Level>();
            level.CountBlock();
        }
        gamestatus = FindObjectOfType<GameSession>();
        maxHits = damageSprites.Length + 1;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "breakable")
        {
            HandleHit();
        }
        else
        {
            TriggerSparklesVFX();
        }
    }

    private void HandleHit()
    {
        timesHit += 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();

        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = damageSprites[spriteIndex];
    }

    private void DestroyBlock()
    {
        TriggerSparklesVFX();
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
        level.DecreaseBlockCount();
        gamestatus.AddToScore();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
   
}
