using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int lifes;

    public int score;
    public static PlayerMovement instance;

    public float minPosX;
	public float maxPosX;
	private float currentPosX;

    private Rigidbody2D rbPlayer;

    public Animator animator;
    private bool isGround;
    [SerializeField]
    private float moveSpeed;
    
    [SerializeField]
    private float jumpforce;
    private int directionBullet;
    public GameObject shootPrefBrown;
    public GameObject shootPrefCream;
    public GameObject shootPrefFly;
    public GameObject shootPrefRed;
    public GameObject shootPrefYellow;
    private BulletController currentShoot;
    private void Awake() {
        MakeInstance();
    }
    void MakeInstance(){
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        lifes = PlayerPrefs.GetInt("life");
        score = 0;

        rbPlayer = GetComponent<Rigidbody2D> ();
        isGround = false;
    }
    // Update is called once per frame
    void Update()
    {
        currentPosX = Mathf.Clamp(rbPlayer.position.x, minPosX, maxPosX);
        rbPlayer.position = new Vector2 (currentPosX, rbPlayer.position.y);

        animator.SetFloat("Horizontal",Input.GetAxis("Horizontal"));
        if(Input.GetAxis("Horizontal")>0){
            directionBullet = 1;
        }else{
            directionBullet = -1;
        }

        Move();
        Jump();
    }

    private void Jump(){
        if(Input.GetKeyDown(KeyCode.UpArrow) && isGround){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,jumpforce),ForceMode2D.Impulse);
        }
        if(Input.GetKeyDown(KeyCode.A) ){
            Shoot(shootPrefBrown,false,0f,0.25f); 
        }else if(Input.GetKeyDown(KeyCode.S) ){
            Shoot(shootPrefCream,false,0f,0.25f);
        }else if(Input.GetKeyDown(KeyCode.D) ){  //FLY
            Shoot(shootPrefFly,false,0f,0.25f);  //hacia arriba
        }else if(Input.GetKeyDown(KeyCode.F) ){ // RED
            Shoot(shootPrefRed,true,0.2f,0f);  //a los costados
        }else if(Input.GetKeyDown(KeyCode.G) ){ //YELLOW
            Shoot(shootPrefYellow,true,0.2f,0f); //a los costados
        }
    }
    public void upScore(int points){
        score+=points;
    }

    private void Move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f) ;
        transform.position += movement * Time.deltaTime * moveSpeed;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        
        if (other.gameObject.tag == "Floor")
        {
            isGround = true;
        }else{
            lifes--;
            Destroy(other.gameObject);
        }
        
    }
    private void OnCollisionExit2D(Collision2D other) {
        if (other.collider.tag == "Floor")
        {
            isGround = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        
    }

    private void Shoot(GameObject _shootPref,bool _orientation, float _x, float _y){
        currentShoot = Instantiate(_shootPref, new Vector3 (transform.position.x + _x,
        transform.position.y + _y,
        transform.position.z),
        _shootPref.transform.rotation).GetComponent<BulletController>();
        currentShoot.change_orientation(_orientation,directionBullet);
    }

}
