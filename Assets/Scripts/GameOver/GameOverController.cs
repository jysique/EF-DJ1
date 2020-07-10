using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private Text txtScore;
    // Start is called before the first frame update
    void Start()
    {
        txtScore.text = "SCORE: "+ PlayerPrefs.GetInt("score").ToString();
        StartCoroutine(GoMenu());
    }
    IEnumerator GoMenu(){
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
