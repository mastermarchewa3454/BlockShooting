using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleLevel : MonoBehaviour
{
    [SerializeField] int breakableBlocks;
    SceneCharger sceneCharger;

    private void Start()
    {
        sceneCharger = FindObjectOfType<SceneCharger>();
    }
    public void CountBlocks()
    {
        breakableBlocks++;
    }
    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            sceneCharger.ChangeToNextScene();
        }
    }
}
