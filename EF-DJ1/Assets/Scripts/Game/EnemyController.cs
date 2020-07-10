using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 2;
    public bool orientation;

    public int dir;

    // Start is called before the first frame update
    void Start()
    {
        define_orientation();
        dir = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(orientation){
           transform.Translate(2* Time.deltaTime * speed * dir,0,0);
        }else{
            transform.Translate(0,2* Time.deltaTime * speed * dir,0);
        }
    }
    public void define_orientation(){
        if (transform.name.Contains("red") || transform.name.Contains("yellow"))
        {
            orientation= true;
        }else{
            orientation= false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Wall"){
            dir *=-1;
        }
    }

}
