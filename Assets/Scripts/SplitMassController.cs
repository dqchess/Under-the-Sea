using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SplitMassController : Utilities
{
        private const float ThreePiOverFour = Mathf.PI * 3 / 4;
    private const float PiOverFour = Mathf.PI / 4;
    public GameObject splitMass;
    public float speed;
    public float movementSpeed = 50.0f;
    public float massSplitMultiplier = 0.5f;
    public Transform target;
    public float increase = 0.05f;
    public Vector2 movement;
    public Vector2 mouseDistance;
    public Animator animator;
      public Joystick joystick;
    //public Rigidbody2D rb2D;
    private PlayerController1 playerController1;
    private Rigidbody2D rigidBody2D;
    private GameManager gameManager;
    public Rigidbody2D rb2D;
    private SpriteRenderer SR;

    // Use this for initialization
    void Start()
    {
        // splitMass = GameObject.FindGameObjectWithTag("SplitMass").GetComponent<GameObject>();
        // target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        playerController1 = FindObjectOfType<PlayerController1>();
        if (gameManager == null)
        {
            Print("No GameManager found!", "error");
        }
    }

    // FixedUpdate is used for physics
    private void FixedUpdate()
    {
         transform.position = Vector2.MoveTowards(transform.position,target.position,speed * Time.deltaTime);
         mouseDistance.x = (Input.mousePosition.x - Camera.main.WorldToScreenPoint(gameObject.transform.position).x) * 0.005f;
         mouseDistance.y = (Input.mousePosition.y - Camera.main.WorldToScreenPoint(gameObject.transform.position).y) * 0.005f;
         movement.x = Input.GetAxis("Horizontal") + mouseDistance.x;
         movement.y = Input.GetAxis("Vertical") + mouseDistance.y;
        rigidBody2D.velocity = movement * movementSpeed * Time.deltaTime;
       if(playerController1.posisi == 0)
        {
            animator.SetInteger("WalkState", 0);
        } else
        {
            
            if(playerController1.posisi == 1)
            {
                animator.SetInteger("WalkState", 1);
            } else if (playerController1.posisi == 2)
            { 
                animator.SetInteger("WalkState", 2);
            } else if (playerController1.posisi == 3)
            {
                animator.SetInteger("WalkState", 3);
            } else if (playerController1.posisi == 4)
            {
                animator.SetInteger("WalkState", 4);
            }
        }
       // rb2D.velocity = movement * speed * Time.deltaTime;
       
    }

    // Update is called once per frame
    // private void Update()
    // {
    //     // Button btn = shooting.GetComponent<Button>();
    //     // btn.onClick.AddListener(playerController1.TaskOnClick);
    //     //Button btn2 = splitting.GetComponent<Button>();
    //     playerController1.splitting.onClick.AddListener(TaskOnClick2);
    //     // if (Input.GetKeyUp(KeyCode.Space))
    //     // {
    //     //     if (transform.localScale.x * massSplitMultiplier >= 1.0f)
    //     //     {
    //     //         transform.localScale = transform.localScale * massSplitMultiplier;
    //     //         GameObject newSplitMass = Instantiate(splitMass, transform.position + new Vector3(-0.6f, 0.8f, 0), transform.rotation) as GameObject;
    //     //         newSplitMass.transform.localScale = transform.localScale;
    //     //     }
    //     //     else
    //     //     {
    //     //         Print("Can't split mass!", "log");
    //     //     }
    //     // }
    // }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Food")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<Food>().RemoveObject();
            gameManager.ChangeScore(10);
        }
         else if (other.gameObject.tag == "Trap")
        {
             //Print("Ate food", "log");
           if (gameManager.currentScore >= 10)
           {
            // audioManager.PlaySound(eatSound);
            // transform.localScale += new Vector3(increase, increase, 0) ;
            transform.localScale = transform.localScale * massSplitMultiplier;
            gameManager.currentScore = gameManager.currentScore/2;
            gameManager.ChangeScore(-1*gameManager.currentScore);
            // gameManager.ChangeEatenFood(1);
            //trap.Exploed();
            //TaskOnClick2();
            other.GetComponent<Food>().RemoveObject();
           }
         /*   else if (gameManager.currentScore < 0 )
            {
                SceneManager.LoadScene("GameOver");
            }
*/
        }
      else if (other.gameObject.tag == "Bot1")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
          //       audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot1Prefab);
                gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(5);
            }
        }
        else if (other.gameObject.tag == "Bot2")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
           //       audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot2Prefab);
                gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(5);
            }
        }
        else if (other.gameObject.tag == "Bot3")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
           //       audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale);
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
            //      audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot4Prefab);
                gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(5);
            }
        }
        else if (other.gameObject.tag == "Bot5")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
           //       audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot5Prefab);

            }
        }
         else if (other.gameObject.tag == "Bot6")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
              //    audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot5Prefab);

            }
        }
         else if (other.gameObject.tag == "Bot7")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
               //   audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot5Prefab);

            }
        }
         else if (other.gameObject.tag == "Bot8")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
              //    audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot5Prefab);

            }
        }
         else if (other.gameObject.tag == "Bot9")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
            //      audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot5Prefab);

            }
        }
         else if (other.gameObject.tag == "Bot10")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
             //     audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot5Prefab);

            }
        }
         else if (other.gameObject.tag == "Bot11")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
              //    audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot5Prefab);

            }
        }
         else if (other.gameObject.tag == "Bot12")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
              //    audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot5Prefab);

            }
        }
         else if (other.gameObject.tag == "Bot13")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
               //   audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot5Prefab);

            }
        }
         else if (other.gameObject.tag == "Bot14")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
               //   audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot5Prefab);

            }
        }
         else if (other.gameObject.tag == "Bot15")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
                 // audioManager.PlaySound(eatFish);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale);
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot5Prefab);

            }
        }
    }
    // void TaskOnClick2()
    // {
    //       if (transform.localScale.x * massSplitMultiplier >= 1.0f)
    //         {
    //             // audioManager.PlaySound(mergeSound);
    //             transform.localScale = transform.localScale * massSplitMultiplier;
    //             GameObject newSplitMass = Instantiate(splitMass, transform.position + new Vector3(-0.2f*transform.position.x, 0.2f*transform.position.y, 0), transform.rotation) as GameObject;
    //             newSplitMass.transform.localScale = transform.localScale;
    //         }
    //         // else
    //         // {
    //         //   //  Print("Can't split mass!", "log");
    //         // }
        
    // }
}
