using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Control : MonoBehaviour
{
    public static UI_Control singleTone;
    public Text scoreText;
    public int Score { get { return score; } 
        set 
        {
            score = value;
            scoreText.text = "Score: " + score;
        }
    }
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        if (singleTone == null)
        {
            singleTone = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SceneSelect(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
