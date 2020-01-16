using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController1 : MonoBehaviour
{
    private const float ThreePiOverFour = Mathf.PI * 3 / 4;
    private const float PiOverFour = Mathf.PI / 4;
    public float speed;
    public Animator animator;
    public Rigidbody2D rb2D;

    public float currentTimeBuff;
    public float startingTimeBuff = 5f;             //
    public bool buff = false;

    public GameObject splitMass;
    public GameObject food;
    public GameObject Trap;
    public GameObject newFoodShoot;
    public Joystick joystick;

    public GameObject controllerButton;
    public Canvas canvas1;
    public Canvas canvas2;

    public Button shooting;
    public Button splitting;

    public int posisi=0;
    public float movementSpeed = 50.0f;
    public float maxMovementSpeed = 3.0f;
    public float massSplitMultiplier = 0.5f;
    public float increase = 10f;
    public Vector2 movement;
    public Vector2 mouseDistance;
    public float tempSpeed = 175;

    public string eatSound = "EatSound";
    public string spawnSound = "SpawnSound";
    public string mergeSound = "MergeSound";
    public string eatFish = "EatFish";
    public string eatBuff = "EatBuff";
    public string hitBomb = "HitBomb";
    public string shootSound = "ShootSound";    

    public Text nama;
    public int NoImage;
    float currentTime= 0f;
    float staringTIme = 3f;
    private bool stun = false;
    private bool miniCam = false;

    private Rigidbody2D rigidBody2D;
    private GameManager gameManager;
    private AudioManager audioManager;
    private SpriteRenderer SR;

    // Start is called before the first frame update
    void Start()
    {
        canvas1.enabled = true;
        canvas2.enabled = true;
        shooting.onClick.AddListener(TaskOnClick);
        splitting.onClick.AddListener(TaskOnClick2);
        
        rigidBody2D = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();

        nama.text = gameManager.user.text;
    }

    // Update is called once per frame
    void Update()
    {
        
        camController();
        mouseDistance.x = (Input.mousePosition.x - Camera.main.WorldToScreenPoint(gameObject.transform.position).x) * 0.005f;
        mouseDistance.y = (Input.mousePosition.y - Camera.main.WorldToScreenPoint(gameObject.transform.position).y) * 0.005f;
        float vertical= joystick.Vertical + mouseDistance.y;
        float horizontal = joystick.Horizontal + mouseDistance.x;
        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();
        if (movement == Vector2.zero) {
            animator.SetInteger("WalkState", 0);
         } 
         else {
             float angle = Mathf.Atan2(movement.y, movement.x);
             if (angle < PiOverFour && angle > -PiOverFour) {
                 Debug.Log("Test");
                 animator.SetInteger("WalkState", 2);
                 posisi = 2;
             } else if (angle > ThreePiOverFour || angle < -ThreePiOverFour) {
                 animator.SetInteger("WalkState", 1);
                 posisi =1;
             }
         }  rb2D.velocity = movement * speed * Time.deltaTime;
        if (buff)                              
         {
             currentTimeBuff -= 1 * Time.deltaTime;	
         }
         if (currentTimeBuff <= 0)
            {
            	buff = false;
            	speed = tempSpeed;
            }
            if(gameManager.testP == true)
            {
                controllerButton.SetActive(false);
                canvas1.enabled = false;
                canvas2.enabled = false;
            }
            else if (gameManager.testP == false)
            {
                canvas1.enabled = true;
                canvas2.enabled = true;
                controllerButton.SetActive(true);
            }
    }

    void camController()
    {
        if(miniCam){
            Camera.main.orthographicSize = 3+gameManager.camSize;
        }else{
            Camera.main.orthographicSize = 5+gameManager.camSize;
        }
    }
    
    void TaskOnClick2()
    {
        if ((transform.localScale.x * massSplitMultiplier >= 0.8f)||(gameManager.currentScore >= 200)){
                audioManager.PlaySound(mergeSound);
                transform.localScale = transform.localScale * massSplitMultiplier;
                GameObject newSplitMass = Instantiate(splitMass, transform.position + new Vector3(-0.2f*transform.position.x, 0.2f*transform.position.y, 0), transform.rotation) as GameObject;
                newSplitMass.transform.localScale = transform.localScale;
            }
        
    }

    void TaskOnClick(){
         if (gameManager.currentScore >= 10){
                audioManager.PlaySound(shootSound);
                transform.localScale -= new Vector3(increase*2, increase*2, 0) ;
                GameObject newFood = Instantiate(newFoodShoot, transform.position, Quaternion.identity);
                newFood.transform.localScale = transform.localScale * massSplitMultiplier;
                gameManager.ChangeScore(-10);    
            }
    }
 void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Food"){
            audioManager.PlaySound(eatSound);
            transform.localScale += new Vector3(0.025f, 0.025f, 0) ;
            other.GetComponent<BotFood>().RemoveObject();
            Destroy(other.gameObject);
            gameManager.ChangeScore(10);
            gameManager.ChangeEatenFood(1);
        }
        if (other.gameObject.tag == "botFood1"){
            audioManager.PlaySound(eatSound);
            transform.localScale += new Vector3(0.025f, 0.025f, 0);
            other.GetComponent<BotFood>().RemoveObject();
            gameManager.respawnBotFood(gameManager.botFood1Prefab);
            gameManager.ChangeScore(10);
            gameManager.ChangeEatenFood(1);
        }
        if (other.gameObject.tag == "botFood2"){
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();
            gameManager.respawnBotFood(gameManager.botFood2Prefab);
            gameManager.ChangeScore(10);
            gameManager.ChangeEatenFood(1);
        }
        if (other.gameObject.tag == "botFood3"){            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();
            gameManager.respawnBotFood(gameManager.botFood3Prefab);
            gameManager.ChangeScore(10);
            gameManager.ChangeEatenFood(1);  
        }
        if (other.gameObject.tag == "botFood4"){            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();
            gameManager.respawnBotFood(gameManager.botFood4Prefab);
            gameManager.ChangeScore(10);
            gameManager.ChangeEatenFood(1);  
        }
        if (other.gameObject.tag == "botFood5"){            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();
            gameManager.respawnBotFood(gameManager.botFood5Prefab);
            gameManager.ChangeScore(10);
            gameManager.ChangeEatenFood(1);
        }
        if (other.gameObject.tag == "botFood6"){            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();
            gameManager.respawnBotFood(gameManager.botFood6Prefab);
            gameManager.ChangeScore(10);            
            gameManager.ChangeEatenFood(1);
        }
        if (other.gameObject.tag == "botFood7"){            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();
            gameManager.respawnBot(gameManager.botFood7Prefab);
            gameManager.ChangeScore(10);
            gameManager.ChangeEatenFood(1);  
        }
        if (other.gameObject.tag == "botFood8"){            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();
            gameManager.respawnBotFood(gameManager.botFood8Prefab);
            gameManager.ChangeScore(10);
            gameManager.ChangeEatenFood(1);
        }
        if (other.gameObject.tag == "botFood9"){
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();
            gameManager.respawnBotFood(gameManager.botFood9Prefab);
            gameManager.ChangeScore(10);
            gameManager.ChangeEatenFood(1);  
        }
        if (other.gameObject.tag == "botFood10"){            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();
            gameManager.respawnBot(gameManager.botFood10Prefab);
            gameManager.ChangeScore(10);
            gameManager.ChangeEatenFood(1);
        }
        if (other.gameObject.tag == "botFood11"){
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();
            gameManager.respawnBotFood(gameManager.botFood11Prefab);
            gameManager.ChangeScore(10);
            gameManager.ChangeEatenFood(1);  
        }
        if (other.gameObject.tag == "botFood12"){
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();
            gameManager.respawnBotFood(gameManager.botFood12Prefab);
            gameManager.ChangeScore(10);
            gameManager.ChangeEatenFood(1);
        }
        if (other.gameObject.tag == "botFood13"){            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();
            gameManager.respawnBotFood(gameManager.botFood13Prefab);
            gameManager.ChangeScore(10);
            
       gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood14")
        {
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();
            gameManager.respawnBotFood(gameManager.botFood14Prefab);
            gameManager.ChangeScore(10);
            gameManager.ChangeEatenFood(1);
        }if (other.gameObject.tag == "botFood15")
        {
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();
            gameManager.respawnBotFood(gameManager.botFood15Prefab);
            gameManager.ChangeScore(10);
            gameManager.ChangeEatenFood(1);
       
        }
        if (other.gameObject.tag == "botFood16"){
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();
            gameManager.respawnBotFood(gameManager.botFood16Prefab);
            gameManager.ChangeScore(10);
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood17")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();
            gameManager.respawnBotFood(gameManager.botFood17Prefab);
            gameManager.ChangeScore(10);
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood18")
        {       
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();
            gameManager.respawnBotFood(gameManager.botFood18Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1); 
        }if (other.gameObject.tag == "botFood19")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();
            gameManager.respawnBotFood(gameManager.botFood19Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood20")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBotFood(gameManager.botFood20Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood21")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();
            gameManager.respawnBotFood(gameManager.botFood21Prefab);
            gameManager.ChangeScore(10);
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood22")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBotFood(gameManager.botFood22Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood23")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBotFood(gameManager.botFood23Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood24")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBotFood(gameManager.botFood24Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood25")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBotFood(gameManager.botFood25Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood26")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBotFood(gameManager.botFood26Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood27")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBotFood(gameManager.botFood27Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood28")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBotFood(gameManager.botFood28Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood29")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBotFood(gameManager.botFood29Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood30")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBotFood(gameManager.botFood30Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood31")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBotFood(gameManager.botFood31Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood32")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBotFood(gameManager.botFood32Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood33")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBotFood(gameManager.botFood33Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood34")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBotFood(gameManager.botFood34Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood35")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();
            gameManager.respawnBotFood(gameManager.botFood35Prefab);
            gameManager.ChangeScore(10);
            gameManager.ChangeEatenFood(1);
        }if (other.gameObject.tag == "botFood36")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBotFood(gameManager.botFood36Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood37")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBotFood(gameManager.botFood37Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood38")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBotFood(gameManager.botFood38Prefab);
            gameManager.ChangeScore(10);
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood39")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBotFood(gameManager.botFood39Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood40")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBotFood(gameManager.botFood40Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood41")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBotFood(gameManager.botFood41Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood42")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBotFood(gameManager.botFood42Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood43")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBotFood(gameManager.botFood43Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood44")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBotFood(gameManager.botFood44Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1);
       
        }if (other.gameObject.tag == "botFood45")
        {
            
            audioManager.PlaySound(eatSound);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBotFood(gameManager.botFood45Prefab);
            gameManager.ChangeScore(10);
            
            gameManager.ChangeEatenFood(1);
       
        }

        if (other.gameObject.tag == "bubbleBuff")
        {
            audioManager.PlaySound(eatBuff);   
            other.GetComponent<BubbleController>().RemoveObject();
            Destroy(other.gameObject);
            buff = true;
            currentTimeBuff = startingTimeBuff;
            speed = speed + 25  ; 
        }
        else if (other.gameObject.tag == "SplitMass")
        {
            audioManager.PlaySound(mergeSound);
            transform.localScale = transform.localScale + (other.gameObject.transform.localScale);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Trap")
        {
           if (gameManager.currentScore == 0 ){
                audioManager.PlaySound(hitBomb);
                SceneManager.LoadScene("GameOver");
            }
            audioManager.PlaySound(hitBomb);
            transform.localScale = transform.localScale * massSplitMultiplier;
            gameManager.currentScore = gameManager.currentScore/2;
            gameManager.ChangeScore(-1*gameManager.currentScore);
            other.GetComponent<Food>().RemoveObject();
        }

        else if (other.gameObject.tag == "Bot1")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
                audioManager.PlaySound(eatFish);
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot1Prefab);
                gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(5);
            }
        }
        else if (other.gameObject.tag == "Bot2")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
                audioManager.PlaySound(eatFish);
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot2Prefab);
                gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(5);
            }
        }
        else if (other.gameObject.tag == "Bot3")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
                audioManager.PlaySound(eatFish);
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot3Prefab);
                gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(5);
            }
        }
        else if (other.gameObject.tag == "Bot4")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
                audioManager.PlaySound(eatFish);
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot4Prefab);
                gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(5);
            }
        }
        else if (other.gameObject.tag == "Bot5")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
                audioManager.PlaySound(eatFish);
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot5Prefab);

            }
        }
         else if (other.gameObject.tag == "Bot6")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
                audioManager.PlaySound(eatFish);
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot5Prefab);
                gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(5);
            }
        }
         else if (other.gameObject.tag == "Bot7")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
                audioManager.PlaySound(eatFish);
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot5Prefab);

            }
        }
         else if (other.gameObject.tag == "Bot8")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
                audioManager.PlaySound(eatFish);
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot5Prefab);
                gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(5);
            }
        }
         else if (other.gameObject.tag == "Bot9")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
                audioManager.PlaySound(eatFish);
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot5Prefab);
                gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(5);
            }
        }
         else if (other.gameObject.tag == "Bot10")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
                audioManager.PlaySound(eatFish);
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot5Prefab);
                gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(5);
            }
        }
         else if (other.gameObject.tag == "Bot11")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
                audioManager.PlaySound(eatFish);
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot5Prefab);

            }
        }
         else if (other.gameObject.tag == "Bot12")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
                audioManager.PlaySound(eatFish);
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot5Prefab);
                gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(5);
            }
        }
         else if (other.gameObject.tag == "Bot13")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
                audioManager.PlaySound(eatFish);
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot5Prefab);
                gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(5);
            }
        }
         else if (other.gameObject.tag == "Bot14")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
                audioManager.PlaySound(eatFish);
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot5Prefab);
                gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(5);
            }
        }
         else if (other.gameObject.tag == "Bot15")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
                audioManager.PlaySound(eatFish);
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot5Prefab);
                gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(5);
            }
        }
    } 
    
}
