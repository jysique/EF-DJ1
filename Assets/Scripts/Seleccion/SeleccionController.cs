using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SeleccionController : MonoBehaviour
{
    [SerializeField]
    private Button btnNormal;
    [SerializeField]
    private Button btnHard;
    // Start is called before the first frame update
    void Start()
    {
         btnNormal.onClick.AddListener(()=>goNormalGame());
         btnHard.onClick.AddListener(()=>goHardGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void goNormalGame(){
        PlayerPrefs.SetInt("life",4);
        goGame();
    }
    private void goHardGame(){
        PlayerPrefs.SetInt("life",1);
        goGame();
    }


    private void goGame(){
        SceneManager.LoadScene("Game");
    }
}
