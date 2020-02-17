using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPoolHead : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float minX = 1.28f;
    [SerializeField] float maxX = 14.75f;
    [SerializeField] float minY = 0.8f;
    [SerializeField] float maxY = 10.5f;
    // [SerializeField] float screenWidthInUnits = 16f;
    GameScore gameScore;
    Ball theBall;
    Vector2 headPos;
    void Start()
    {
        gameScore = FindObjectOfType<GameScore>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        headPos = transform.position;
        headPos.x = Mathf.Clamp(GetXPosition(), minX, maxX);
        headPos.y = Mathf.Clamp(headPos.y, minY, maxY);
        transform.position = headPos;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            headPos.x = headPos.x - 0.25f;
            this.transform.position = headPos;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            headPos.x = headPos.x + 0.25f;
            this.transform.position = headPos;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            headPos.y = headPos.y + 0.25f;
            this.transform.position = headPos;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            headPos.y = headPos.y - 0.25f;
            this.transform.position = headPos;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
    }

    private float GetXPosition()
    {
        if (gameScore.IsAutoPlay())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return headPos.x;
        }
    }
}
