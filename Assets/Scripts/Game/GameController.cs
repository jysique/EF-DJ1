using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Text txtLife;
    [SerializeField]
    private Text txtScore;


    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
        UpdateLife();
    }

    private void UpdateLife(){
        txtLife.text = "LIFES: "+ PlayerMovement.instance.lifes.ToString();

    }
    private void UpdateScore(){
        txtScore.text = "SCORE: "+ PlayerMovement.instance.score.ToString();
        PlayerPrefs.SetInt("score",PlayerMovement.instance.score);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        UpdateLife();
        if(PlayerMovement.instance.lifes<=0){
            GameOver();
        }
    }
    private void GameOver(){
        Time.timeScale = 0;
        SceneManager.LoadScene("GameOver");
    }
}
