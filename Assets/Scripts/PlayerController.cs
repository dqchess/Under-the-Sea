using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private const float ThreePiOverFour = Mathf.PI * 3 / 4;
    private const float PiOverFour = Mathf.PI / 4;
    public float speed;
    public Animator animator;
    public Rigidbody2D rb2D;


    public GameObject splitMass;
    public GameObject food;
    public GameObject Trap;
    public Joystick joystick;
    
    public Sprite chara1;
    public Sprite chara2;
    public Sprite chara3; 

    public Button shooting;
    public Button splitting;

    public int posisi=0;
    public float movementSpeed = 50.0f;
    public float maxMovementSpeed = 3.0f;
    public float massSplitMultiplier = 0.5f;
    public float increase = 0.01f;
    public Vector2 movement;
    public Vector2 mouseDistance;

    public string eatSound = "EatSound";
    public string spawnSound = "SpawnSound";
    public string mergeSound = "MergeSound";
    public string eatFish = "EatFish";

    public Text nama;
    public int NoImage;
    float currentTime= 0f;
    float staringTIme = 3f;
    private bool stun = false;


    private Rigidbody2D rigidBody2D;
    private GameManager gameManager;
    private AudioManager audioManager;
    private SpriteRenderer SR;

    // Start is called before the first frame update
    void Start()
    {
        //Button btn = shooting.GetComponent<Button>();
        shooting.onClick.AddListener(TaskOnClick);
        //Button btn2 = splitting.GetComponent<Button>();
        splitting.onClick.AddListener(TaskOnClick2);
        
        rigidBody2D = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
        //memilih karakter
        LoadImage();
        if (NoImage == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = chara1;                   
        }
        else if (NoImage == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = chara2;                   
        }
        //memilih karakter
        nama.text = gameManager.user.text;

        /*if (gameManager == null)
        {
            Print("No GameManager found!", "error");
        }
        if (audioManager == null)
        {
            Print("No AudioManager found!", "error");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
       /*  if (!stun)
        {
        mouseDistance.x = (Input.mousePosition.x - Camera.main.WorldToScreenPoint(gameObject.transform.position).x) * 0.005f;
        mouseDistance.y = (Input.mousePosition.y - Camera.main.WorldToScreenPoint(gameObject.transform.position).y) * 0.005f;
        //movement.x = Input.GetAxis("Horizontal") + mouseDistance.x;
        //movement.y = Input.GetAxis("Vertical") + mouseDistance.y;
        //movement.x = Mathf.Clamp(movement.x, -maxMovementSpeed, maxMovementSpeed);
        //movement.y = Mathf.Clamp(movement.y, -maxMovementSpeed, maxMovementSpeed);
        //joystick
        movement.x = joystick.Horizontal + mouseDistance.x ;
        movement.y = joystick.Vertical + mouseDistance.y;
        movement.x = Mathf.Clamp(movement.x, -maxMovementSpeed, maxMovementSpeed);
        movement.y = Mathf.Clamp(movement.y, -maxMovementSpeed, maxMovementSpeed);
        rigidBody2D.velocity = movement * movementSpeed * Time.deltaTime;
        }
        else 
        {
          // Print ("stun!","log"); 
        } */
        mouseDistance.x = (Input.mousePosition.x - Camera.main.WorldToScreenPoint(gameObject.transform.position).x) * 0.005f;
        mouseDistance.y = (Input.mousePosition.y - Camera.main.WorldToScreenPoint(gameObject.transform.position).y) * 0.005f;
        float vertical= joystick.Vertical + mouseDistance.y;
        float horizontal = joystick.Horizontal + mouseDistance.x;
        // float vertical = Input.GetAxis("Vertical");
        // float horizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();
        if(movement == Vector2.zero)
        {
            animator.SetInteger("WalkState", 0);
            posisi =0;
        } else
        {
            float angle = Mathf.Atan2(movement.y, movement.x);
            if(angle < ThreePiOverFour && angle > PiOverFour)
            {
                animator.SetInteger("WalkState", 1);
                posisi =1;
            } else if (angle < PiOverFour && angle > -PiOverFour)
            {
                animator.SetInteger("WalkState", 2);
                posisi =2;
            } else if (angle < -PiOverFour && angle > -ThreePiOverFour)
            {
                animator.SetInteger("WalkState", 3);
                posisi =3;
            } else if (angle > ThreePiOverFour || angle < -ThreePiOverFour)
            {
                animator.SetInteger("WalkState", 4);
                posisi =4;
            }
        //      if (movement == Vector2.zero) {
        //     animator.SetInteger("WalkState", 0);
        // } else {
        //     float angle = Mathf.Atan2(movement.y, movement.x);
        //     if (angle < PiOverFour && angle > -PiOverFour) {
        //         Debug.Log("Test");
        //         animator.SetInteger("WalkState", 1);
        //     } else if (angle > ThreePiOverFour || angle < -ThreePiOverFour) {
        //         animator.SetInteger("WalkState", 2);
        //     }
        // }
        }
        rb2D.velocity = movement * speed * Time.deltaTime;
    }

    void TaskOnClick2()
    {
          if (transform.localScale.x * massSplitMultiplier >= 1.0f)
            {
                audioManager.PlaySound(mergeSound);
                transform.localScale = transform.localScale * massSplitMultiplier;
                GameObject newSplitMass = Instantiate(splitMass, transform.position + new Vector3(-0.2f*transform.position.x, 0.2f*transform.position.y, 0), transform.rotation) as GameObject;
                newSplitMass.transform.localScale = transform.localScale;
            }
            // else
            // {
            //   //  Print("Can't split mass!", "log");
            // }
        
    }

    void TaskOnClick(){
         if (gameManager.currentScore >= 10)
            {
                transform.localScale -= new Vector3(increase*2, increase*2, 0) ;
                GameObject newFood = Instantiate(food, transform.position + new Vector3(( 0.2f*transform.position.x), (0.2f*transform.position.y), 0), transform.rotation) as GameObject;
                newFood.transform.localScale = transform.localScale * massSplitMultiplier;
                gameManager.ChangeScore(-10);
            }
            // else
            // {
            //    // Print("Can't split mass!", "log");
            // }
    }
    
    


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Food")
        {
            //Print("Ate food", "log");
            audioManager.PlaySound(eatSound);
            transform.localScale += new Vector3(increase, increase, 0) ;
            other.GetComponent<Food>().RemoveObject();
            gameManager.ChangeScore(10);
            gameManager.ChangeEatenFood(1);
        }
        else if (other.gameObject.tag == "SplitMass")
        {
           // Print("Collided with mass", "log");
            audioManager.PlaySound(mergeSound);
            transform.localScale = transform.localScale + (other.gameObject.transform.localScale);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Bot1")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
                  audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale/2);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot1Prefab);
                gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(70);
            }
        }
        else if (other.gameObject.tag == "Bot2")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
                  audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale/2);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot2Prefab);
                gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(70);
            }
        }
        else if (other.gameObject.tag == "Bot3")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
                  audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale/2);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot3Prefab);
                gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(5);
            }
        }
        else if (other.gameObject.tag == "Bot4")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
                  audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale/2);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot4Prefab);
                gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(70);
            }
        }
        else if (other.gameObject.tag == "Bot5")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
                  audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale/2);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot5Prefab);
gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(70);
            }
        }
         else if (other.gameObject.tag == "Bot6")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
                  audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale/2);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot6Prefab);
gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(70);
            }
        }
         else if (other.gameObject.tag == "Bot7")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
                  audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale/2);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot7Prefab);
gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(70);
            }
        }
         else if (other.gameObject.tag == "Bot8")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
                  audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale/2);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot8Prefab);
gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(70);
            }
        }
         else if (other.gameObject.tag == "Bot9")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
                  audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale/2);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot9Prefab);
gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(70);
            }
        }
         else if (other.gameObject.tag == "Bot10")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
                  audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale/2);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot10Prefab);
gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(70);
            }
        }
         else if (other.gameObject.tag == "Bot11")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
                  audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale/2);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot11Prefab);
gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(70);
            }
        }
         else if (other.gameObject.tag == "Bot12")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
                  audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale/2);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot12Prefab);
gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(70);
            }
        }
         else if (other.gameObject.tag == "Bot13")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
                  audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale/2);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot13Prefab);
gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(70);
            }
        }
         else if (other.gameObject.tag == "Bot14")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
                  audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale/2);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot14Prefab);
gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(70);
            }
        }
         else if (other.gameObject.tag == "Bot15")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
                  audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale/2);

                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot15Prefab);
gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(70);
            }
        }
        // else if (other.gameObject.tag == "Trap")
        // {
        //     stun = false;
        //    // Print("ate Trap","log");
        //     currentTime = staringTIme;
            
        //     currentTime -= 1 * Time.deltaTime;
        //     if (currentTime <=0)
        //     {
        //         stun = true;
        //     }
        // } 
    } 
    public void LoadImage()
    {
        //Print("Loading", "event");

       // NoImage= Deserialize<int>(Application.streamingAssetsPath + "/XML/image.xml");
        //userHighScore = Deserialize<string>(Application.streamingAssetsPath + "/XML/Username.xml");

    }
}
