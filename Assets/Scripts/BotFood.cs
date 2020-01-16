using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class BotFood : Utilities
{
    public float speed;
    public float increase = 0.01f;
    public Transform target;
    public Transform[] moveSpots;
    public int radius;
    private int randomSpot;
    private GameManager gameManager;
    public float a=0,b=0;
    public float c;
    public Rigidbody2D rb2D;

    public Animator animator;
    public int score;
    public Text scoreBot;
    private AudioManager audioManager;
   // private GameManager gameManager;
    private Level level;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        randomSpot = Random.Range(0,moveSpots.Length);
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
        gameManager = FindObjectOfType<GameManager>();
        level = FindObjectOfType<Level>();

    
        if (gameManager == null)
        {
            Print("No GameManager found!", "error");
        }

         int foodScore = gameManager.currentScore;
        if (foodScore < 500)
        {
            int increase = 0;
            increase = foodScore / 25;
            transform.localScale += Vector3.one * increase * Time.deltaTime;
        }
        if (foodScore > 499)
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0f);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
         b=transform.position.x;
          transform.localScale = new Vector3(0.1f, 0.1f, 0f);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if(Vector2.Distance(transform.position,target.position) < radius){
        	if(target.localScale.x < transform.localScale.x)
            {
                
            	transform.position = Vector2.MoveTowards(transform.position,target.position,speed * Time.deltaTime);
            }
            else 
            {
                transform.position = Vector2.MoveTowards(transform.position,target.position,-speed * Time.deltaTime);
                    
                    randomSpot = Random.Range(0,moveSpots.Length);
            }
        }
        
        else {
            transform.position = Vector2.MoveTowards(transform.position,moveSpots[randomSpot].position,speed * Time.deltaTime);
            }
        if(Vector2.Distance(transform.position,moveSpots[randomSpot].position) < 1.0f)
        {
           
            randomSpot = Random.Range(0,moveSpots.Length);
        }
         
            
        gerakAnimasi(a,b);
          // float angle = Mathf.Atan2(movement.y, movement.x);
          
            /* else if (a >= b)
            {
                animator.SetInteger("WalkState", 3);
                     } else if ( a>= b)
            {
                animator.SetInteger("WalkState", 4);
         
            }*/  
            a = b;
        
    }
    public void RemoveObject()
    {
        level.food.Remove(gameObject);
        Destroy(gameObject);
    } 
   
    void gerakAnimasi(float a,float b)
    {
         if(a > b)
            {
                animator.SetInteger("WalkState", 1);
                c=2;
            }

            else 
            {
              animator.SetInteger("WalkState", 2);
                c=4;
            }
    }

}
