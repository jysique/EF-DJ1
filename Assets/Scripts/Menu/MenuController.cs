using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Button btnPlay;
    // Start is called before the first frame update
    void Start()
    {
         btnPlay.onClick.AddListener(()=>goGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void goGame(){
        SceneManager.LoadScene("Seleccion");
    }
}
