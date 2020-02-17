using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBlock : MonoBehaviour
{
    // parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSpark;
    [SerializeField] Sprite[] hitSprites;
    // references
    SingleLevel singleLevel;
    // state variables
    [SerializeField] int timesHit;
    private void Start()
    {
        singleLevel = FindObjectOfType<SingleLevel>();
        if(tag == "Breakable")
        {
            singleLevel.CountBlocks();
        }    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int maxHits = 0;
        if (tag == "Breakable")
        {
            timesHit++;
            maxHits = hitSprites.Length + 1;
        }

        if(FindObjectOfType<Ball>().getIsStarted() == true && tag == "Breakable" && (timesHit >= maxHits)) 
        {
            DestroyBlock();
        }
        else
        {
            ShowHitSprites();
        }
    }

    private void ShowHitSprites()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block is missing " + gameObject.name);
        }
       
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        singleLevel.BlockDestroyed();
        FindObjectOfType<GameScore>().AddToScore();
        SparkerTrigger();
    }
    private void SparkerTrigger()
    {
        GameObject sparcles = Instantiate(blockSpark, transform.position, transform.rotation);
        Destroy(sparcles, 1f);
    }
}
