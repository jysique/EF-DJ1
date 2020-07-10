using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speedXMovement = 5;
    public bool hor = false;
    private Rigidbody2D rbShoot;
     private SpriteRenderer rendShoot;

    public int direction = 1;
    public void change_orientation(bool _orientation,int _dir){
        hor = _orientation;
        direction = _dir;
    }
    void Start()
    {
        rbShoot = GetComponent<Rigidbody2D> ();
    }
    void FixedUpdate () {
        if(hor){
            rbShoot.velocity = new Vector2 (speedXMovement * direction,rbShoot.velocity.y);
        }else{
            rbShoot.velocity = new Vector2 (rbShoot.velocity.x,speedXMovement);
        }
	}
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag != "Player"){      
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == gameObject.tag)
        {
            Destroy(other.gameObject);
            if(other.gameObject.tag == "Brown"){
                PlayerMovement.instance.upScore(5);
            }else if(other.gameObject.tag == "Red"){
                PlayerMovement.instance.upScore(10);
            }else if(other.gameObject.tag == "Yellow"){
                PlayerMovement.instance.upScore(15);
            }else if(other.gameObject.tag == "Cream"){
                PlayerMovement.instance.upScore(20);
            }else if(other.gameObject.tag == "Red"){
                PlayerMovement.instance.upScore(50);
            }
        }

    }
}
