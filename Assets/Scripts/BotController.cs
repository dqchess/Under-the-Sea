using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class BotController : Utilities
{
    public float speed;
    public float increase = 0.01f;
    public Transform target;
    public Transform[] moveSpots;
    public Transform targetFood1;
    public Transform targetFood2;
    public Transform targetFood3;
    public Transform targetFood4;
    public Transform targetFood5;
    public Transform targetFood6;
    public Transform targetFood7;
    public Transform targetFood8;
    public Transform targetFood9;
    public Transform targetFood10;
    public Transform targetFood11;
    public Transform targetFood12;
    public Transform targetFood13;
    public Transform targetFood14;
    public Transform targetFood15;
    public Transform targetFood16;
    public Transform targetFood17;
    public Transform targetFood18;
    public Transform targetFood19;
    public Transform targetFood20;
    public Transform targetFood21;
    public Transform targetFood22;
    public Transform targetFood23;
    public Transform targetFood24;
    public Transform targetFood25;
    public Transform targetFood26;
    public Transform targetFood27;
    public Transform targetFood28;
    public Transform targetFood29;
    public Transform targetFood30;

    public Transform targetFood31;  
    public Transform targetFood32;
    public Transform targetFood33;
    public Transform targetFood34;
    public Transform targetFood35;
    public Transform targetFood36;
    public Transform targetFood37;
    public Transform targetFood38;
    public Transform targetFood39;
    public Transform targetFood40;
    public Transform targetFood41;
    public Transform targetFood42;
    public Transform targetFood43;
    public Transform targetFood44;
    public Transform targetFood45;


    public Transform    targetBot1;
    public Transform    targetBot2;
    public Transform    targetBot3;
    public Transform    targetBot4;
    public Transform    targetBot5;
    public Transform    targetBot6;
    public Transform    targetBot7;
    public Transform    targetBot8;
    public Transform    targetBot9;
    public Transform    targetBot10;
    public Transform    targetBot11;
    public Transform    targetBot12;
    public Transform    targetBot13;
    public Transform    targetBot14;
    public Transform    targetBot15;

     public static float[] arr;
     public float lier1;
     public float lier2;
     public static float lier3;
     public float distanceObjek1;
     public float distanceObjek2;
     public float distanceObjek3;
     public float distanceObjek4;
     public float distanceObjek5;
     public float distanceObjek6;
     public float distanceObjek7;
     public float distanceObjek8;
     public float distanceObjek9;
     public float distanceObjek10;

     public float distanceObjek11;
     public float distanceObjek12;
     public float distanceObjek13;
     public float distanceObjek14;
     public float distanceObjek15;
     public float distanceObjek16;
     public float distanceObjek17;
     public float distanceObjek18;
     public float distanceObjek19;
     public float distanceObjek20;

     public float distanceObjek21;
     public float distanceObjek22;
     public float distanceObjek23;
     public float distanceObjek24;
     public float distanceObjek25;
     public float distanceObjek26;
     public float distanceObjek27;
     public float distanceObjek28;
     public float distanceObjek29;
     public float distanceObjek30;

     public float distanceObjek31;
     public float distanceObjek32;
     public float distanceObjek33;
     public float distanceObjek34;
     public float distanceObjek35;
     public float distanceObjek36;
     public float distanceObjek37;
     public float distanceObjek38;
     public float distanceObjek39;
     public float distanceObjek40;

     public float distanceObjek41;
     public float distanceObjek42;
     public float distanceObjek43;
     public float distanceObjek44;
     public float distanceObjek45;
     public float distanceObjek46;
     public float distanceObjek47;
     public float distanceObjek48;
     public float distanceObjek49;
     public float distanceObjek50;

     public float distanceObjek51;
     public float distanceObjek52;
     public float distanceObjek53;
     public float distanceObjek54;
     public float distanceObjek55;
     public float distanceObjek56;
     public float distanceObjek57;
     public float distanceObjek58;
     public float distanceObjek59;
     public float distanceObjek60;

    public float posisiFoodx;
    public float posisiFoody;
    public float radius=10.0f;
   
    private int randomSpot;
    private GameManager gameManager;
    public float a=0,b=0;
    public float c;
    public Rigidbody2D rb2D;
    private newFoodShoot timeFoodShoot;

    private float currentTimeFoodShoot;
    private float startingTimeFoodShoot = 7f;
    private bool FoodShoot2 = false;

    public Animator animator;
    public int score;
    public Text scoreBot;
    private AudioManager audioManager;
    public string deadSound = "DeadSound";

    
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        randomSpot = Random.Range(0,moveSpots.Length);
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();

        if (gameManager == null)
        {
            Print("No GameManager found!", "error");
        }
    }

    // Update is called once per frame
    void Update()
    {
      
        b=transform.position.x;
    
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        targetFood1 = GameObject.FindGameObjectWithTag("botFood1").GetComponent<Transform>();
        targetFood2 = GameObject.FindGameObjectWithTag("botFood2").GetComponent<Transform>();
        targetFood3 = GameObject.FindGameObjectWithTag("botFood3").GetComponent<Transform>();
        targetFood4 = GameObject.FindGameObjectWithTag("botFood4").GetComponent<Transform>();
        targetFood5 = GameObject.FindGameObjectWithTag("botFood5").GetComponent<Transform>();
        targetFood6 = GameObject.FindGameObjectWithTag("botFood6").GetComponent<Transform>();
        targetFood7 = GameObject.FindGameObjectWithTag("botFood7").GetComponent<Transform>();
        targetFood8 = GameObject.FindGameObjectWithTag("botFood8").GetComponent<Transform>();
        targetFood9 = GameObject.FindGameObjectWithTag("botFood9").GetComponent<Transform>();
        targetFood10 = GameObject.FindGameObjectWithTag("botFood10").GetComponent<Transform>();
        targetFood11 = GameObject.FindGameObjectWithTag("botFood11").GetComponent<Transform>();
        targetFood12 = GameObject.FindGameObjectWithTag("botFood12").GetComponent<Transform>();
        targetFood13 = GameObject.FindGameObjectWithTag("botFood13").GetComponent<Transform>();
        targetFood14 = GameObject.FindGameObjectWithTag("botFood14").GetComponent<Transform>();
        targetFood15 = GameObject.FindGameObjectWithTag("botFood15").GetComponent<Transform>();
 
        targetFood16 = GameObject.FindGameObjectWithTag("botFood16").GetComponent<Transform>();
        targetFood17 = GameObject.FindGameObjectWithTag("botFood17").GetComponent<Transform>();
        targetFood18 = GameObject.FindGameObjectWithTag("botFood18").GetComponent<Transform>();
        targetFood19 = GameObject.FindGameObjectWithTag("botFood19").GetComponent<Transform>();
        targetFood20 = GameObject.FindGameObjectWithTag("botFood20").GetComponent<Transform>();
        targetFood21 = GameObject.FindGameObjectWithTag("botFood21").GetComponent<Transform>();
        targetFood22 = GameObject.FindGameObjectWithTag("botFood22").GetComponent<Transform>();
        targetFood23 = GameObject.FindGameObjectWithTag("botFood23").GetComponent<Transform>();
        targetFood24 = GameObject.FindGameObjectWithTag("botFood24").GetComponent<Transform>();
        targetFood25 = GameObject.FindGameObjectWithTag("botFood25").GetComponent<Transform>();
        targetFood26 = GameObject.FindGameObjectWithTag("botFood26").GetComponent<Transform>();
        targetFood27 = GameObject.FindGameObjectWithTag("botFood27").GetComponent<Transform>();
        targetFood28 = GameObject.FindGameObjectWithTag("botFood28").GetComponent<Transform>();
        targetFood29 = GameObject.FindGameObjectWithTag("botFood29").GetComponent<Transform>();
        targetFood30 = GameObject.FindGameObjectWithTag("botFood30").GetComponent<Transform>();

        targetFood31 = GameObject.FindGameObjectWithTag("botFood31").GetComponent<Transform>();
        targetFood32 = GameObject.FindGameObjectWithTag("botFood32").GetComponent<Transform>();
        targetFood33 = GameObject.FindGameObjectWithTag("botFood33").GetComponent<Transform>();
        targetFood34 = GameObject.FindGameObjectWithTag("botFood34").GetComponent<Transform>();
        targetFood35 = GameObject.FindGameObjectWithTag("botFood35").GetComponent<Transform>();
        targetFood36 = GameObject.FindGameObjectWithTag("botFood36").GetComponent<Transform>();
        targetFood37 = GameObject.FindGameObjectWithTag("botFood37").GetComponent<Transform>();
        targetFood38 = GameObject.FindGameObjectWithTag("botFood38").GetComponent<Transform>();
        targetFood39 = GameObject.FindGameObjectWithTag("botFood39").GetComponent<Transform>();
        targetFood40 = GameObject.FindGameObjectWithTag("botFood40").GetComponent<Transform>();
        targetFood41 = GameObject.FindGameObjectWithTag("botFood41").GetComponent<Transform>();
        targetFood42 = GameObject.FindGameObjectWithTag("botFood42").GetComponent<Transform>();
        targetFood43 = GameObject.FindGameObjectWithTag("botFood43").GetComponent<Transform>();
        targetFood44 = GameObject.FindGameObjectWithTag("botFood44").GetComponent<Transform>();
        targetFood45 = GameObject.FindGameObjectWithTag("botFood45").GetComponent<Transform>();

/*
        targetBot1 = GameObject.FindGameObjectWithTag("Bot1").GetComponent<Transform>();
        targetBot2 = GameObject.FindGameObjectWithTag("Bot2").GetComponent<Transform>();
        targetBot3 = GameObject.FindGameObjectWithTag("Bot3").GetComponent<Transform>();
        targetBot4 = GameObject.FindGameObjectWithTag("Bot4").GetComponent<Transform>();
        targetBot5 = GameObject.FindGameObjectWithTag("Bot5").GetComponent<Transform>();
        targetBot6 = GameObject.FindGameObjectWithTag("Bot6").GetComponent<Transform>();
        targetBot7 = GameObject.FindGameObjectWithTag("Bot7").GetComponent<Transform>();
        targetBot8 = GameObject.FindGameObjectWithTag("Bot8").GetComponent<Transform>();
        targetBot9 = GameObject.FindGameObjectWithTag("Bot9").GetComponent<Transform>();
        targetBot10 = GameObject.FindGameObjectWithTag("Bot10").GetComponent<Transform>();
        targetBot11 = GameObject.FindGameObjectWithTag("Bot11").GetComponent<Transform>();
        targetBot12 = GameObject.FindGameObjectWithTag("Bot12").GetComponent<Transform>();
        targetBot13 = GameObject.FindGameObjectWithTag("Bot13").GetComponent<Transform>();
        targetBot14 = GameObject.FindGameObjectWithTag("Bot14").GetComponent<Transform>();
        targetBot15 = GameObject.FindGameObjectWithTag("Bot15").GetComponent<Transform>();*/
 
        distanceObjek1  = Vector2.Distance(transform.position,targetFood1.position);
        distanceObjek2  = Vector2.Distance(transform.position,targetFood2.position);
        distanceObjek3  = Vector2.Distance(transform.position,targetFood3.position);
        distanceObjek4  = Vector2.Distance(transform.position,targetFood4.position);
        distanceObjek5  = Vector2.Distance(transform.position,targetFood5.position);
        distanceObjek6  = Vector2.Distance(transform.position,targetFood6.position);
        distanceObjek7  = Vector2.Distance(transform.position,targetFood7.position);
        distanceObjek8  = Vector2.Distance(transform.position,targetFood8.position);
        distanceObjek9  = Vector2.Distance(transform.position,targetFood9.position);
        distanceObjek10  = Vector2.Distance(transform.position,targetFood10.position);
                

        distanceObjek11  = Vector2.Distance(transform.position,targetFood11.position);
        distanceObjek12  = Vector2.Distance(transform.position,targetFood12.position);
        distanceObjek13  = Vector2.Distance(transform.position,targetFood13.position);
        distanceObjek14  = Vector2.Distance(transform.position,targetFood14.position);
        distanceObjek15  = Vector2.Distance(transform.position,targetFood15.position);
        distanceObjek16  = Vector2.Distance(transform.position,targetFood16.position);
        distanceObjek17  = Vector2.Distance(transform.position,targetFood17.position);
        distanceObjek18  = Vector2.Distance(transform.position,targetFood18.position);
        distanceObjek19  = Vector2.Distance(transform.position,targetFood19.position);
        distanceObjek20  = Vector2.Distance(transform.position,targetFood20.position);


        distanceObjek21  = Vector2.Distance(transform.position,targetFood21.position);
        distanceObjek22  = Vector2.Distance(transform.position,targetFood22.position);
        distanceObjek23  = Vector2.Distance(transform.position,targetFood23.position);
        distanceObjek24  = Vector2.Distance(transform.position,targetFood24.position);
        distanceObjek25  = Vector2.Distance(transform.position,targetFood25.position);
        distanceObjek26  = Vector2.Distance(transform.position,targetFood26.position);
        distanceObjek27  = Vector2.Distance(transform.position,targetFood27.position);
        distanceObjek28  = Vector2.Distance(transform.position,targetFood28.position);
        distanceObjek29  = Vector2.Distance(transform.position,targetFood29.position);
        distanceObjek30  = Vector2.Distance(transform.position,targetFood30.position);


        distanceObjek31  = Vector2.Distance(transform.position,targetFood31.position);
        distanceObjek32  = Vector2.Distance(transform.position,targetFood32.position);
        distanceObjek33  = Vector2.Distance(transform.position,targetFood33.position);
        distanceObjek34  = Vector2.Distance(transform.position,targetFood34.position);
        distanceObjek35  = Vector2.Distance(transform.position,targetFood35.position);
        distanceObjek36  = Vector2.Distance(transform.position,targetFood36.position);
        distanceObjek37  = Vector2.Distance(transform.position,targetFood37.position);
        distanceObjek38  = Vector2.Distance(transform.position,targetFood38.position);
        distanceObjek39  = Vector2.Distance(transform.position,targetFood39.position);
        distanceObjek40  = Vector2.Distance(transform.position,targetFood40.position);


        distanceObjek41  = Vector2.Distance(transform.position,targetFood41.position);
        distanceObjek42  = Vector2.Distance(transform.position,targetFood42.position);
        distanceObjek43  = Vector2.Distance(transform.position,targetFood43.position);
        distanceObjek44  = Vector2.Distance(transform.position,targetFood44.position);
        distanceObjek45  = Vector2.Distance(transform.position,targetFood45.position);
        distanceObjek46  = Vector2.Distance(transform.position,targetBot1.position);
        distanceObjek47  = Vector2.Distance(transform.position,targetBot2.position);
        distanceObjek48  = Vector2.Distance(transform.position,targetBot3.position);
        distanceObjek49  = Vector2.Distance(transform.position,targetBot4.position);
        distanceObjek50  = Vector2.Distance(transform.position,targetBot5.position);


        distanceObjek51  = Vector2.Distance(transform.position,targetBot6.position);
        distanceObjek52  = Vector2.Distance(transform.position,targetBot7.position);
        distanceObjek53  = Vector2.Distance(transform.position,targetBot8.position);
        distanceObjek54  = Vector2.Distance(transform.position,targetBot9.position);
        distanceObjek55  = Vector2.Distance(transform.position,targetBot10.position);
        distanceObjek56  = Vector2.Distance(transform.position,targetBot11.position);
        distanceObjek57  = Vector2.Distance(transform.position,targetBot12.position);
        distanceObjek58  = Vector2.Distance(transform.position,targetBot13.position);
        distanceObjek59  = Vector2.Distance(transform.position,targetBot14.position);
        distanceObjek60  = Vector2.Distance(transform.position,targetBot15.position);


        Tree BST = new Tree();
        BST.Insert (distanceObjek1);
        BST.Insert (distanceObjek2);
        BST.Insert (distanceObjek3);
        BST.Insert (distanceObjek4);
        BST.Insert (distanceObjek5);
        BST.Insert (distanceObjek6);
        BST.Insert (distanceObjek7);
        BST.Insert (distanceObjek8);
        BST.Insert (distanceObjek9);
        BST.Insert (distanceObjek10);

        BST.Insert (distanceObjek11);
        BST.Insert (distanceObjek12);
        BST.Insert (distanceObjek13);
        BST.Insert (distanceObjek14);
        BST.Insert (distanceObjek15);
        BST.Insert (distanceObjek16);
        BST.Insert (distanceObjek17);
        BST.Insert (distanceObjek18);
        BST.Insert (distanceObjek19);
        BST.Insert (distanceObjek20);

        BST.Insert (distanceObjek21);
        BST.Insert (distanceObjek22);
        BST.Insert (distanceObjek23);
        BST.Insert (distanceObjek24);
        BST.Insert (distanceObjek25);
        BST.Insert (distanceObjek26);
        BST.Insert (distanceObjek27);
        BST.Insert (distanceObjek28);
        BST.Insert (distanceObjek29);
        BST.Insert (distanceObjek30);

        BST.Insert (distanceObjek31);
        BST.Insert (distanceObjek32);
        BST.Insert (distanceObjek33);
        BST.Insert (distanceObjek34);
        BST.Insert (distanceObjek35);
        BST.Insert (distanceObjek36);
        BST.Insert (distanceObjek37);
        BST.Insert (distanceObjek38);
        BST.Insert (distanceObjek39);
        BST.Insert (distanceObjek40);

        BST.Insert (distanceObjek41);
        BST.Insert (distanceObjek42);
        BST.Insert (distanceObjek43);
        BST.Insert (distanceObjek44);
        BST.Insert (distanceObjek45);
     /*   BST.Insert (distanceObjek46);
        BST.Insert (distanceObjek47);
        BST.Insert (distanceObjek48);
        BST.Insert (distanceObjek49);
        BST.Insert (distanceObjek50);

        BST.Insert (distanceObjek51);
        BST.Insert (distanceObjek52);
        BST.Insert (distanceObjek53);
        BST.Insert (distanceObjek54);
        BST.Insert (distanceObjek55);
        BST.Insert (distanceObjek56);
        BST.Insert (distanceObjek57);
        BST.Insert (distanceObjek58);
        BST.Insert (distanceObjek59);
        BST.Insert (distanceObjek60);
*/
        BST.Inorder(BST.ReturnRoot());
       /* lier1 = arr[0];
        lier2 = arr[1];
        lier3 = arr[2];
*/
        lier2 = lier3;

        if(Vector2.Distance(transform.position,target.position) < radius){

        	if(target.localScale.x < transform.localScale.x)                  //jika bot lebih besar dari player
            {
            	transform.position = Vector2.MoveTowards(transform.position,target.position,speed * Time.deltaTime);
            }

        
         else                                                              //jika bot lebih kecil dari player
            {
                transform.position = Vector2.MoveTowards(transform.position,target.position,-speed * Time.deltaTime);
                  
                    randomSpot = Random.Range(0,moveSpots.Length);
            }
        }
        
        

        else {
            if(lier2 == distanceObjek1){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood1.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek2){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood2.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek3){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood3.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek4){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood4.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek5){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood5.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek6){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood6.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek7){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood7.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek8){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood8.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek9){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood9.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek10){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood10.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek11){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood11.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek12){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood12.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek13){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood13.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek14){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood14.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek15){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood15.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek16){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood16.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek17){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood17.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek18){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood18.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek19){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood19.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek20){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood20.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek21){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood21.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek22){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood22.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek23){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood23.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek24){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood24.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek25){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood25.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek26){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood26.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek27){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood27.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek28){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood28.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek29){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood29.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek30){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood30.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek31){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood31.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek32){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood32.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek33){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood33.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek34){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood34.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek35){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood35.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek36){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood36.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek37){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood37.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek38){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood38.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek39){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood39.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek40){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood40.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek41){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood41.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek42){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood42.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek43){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood43.position,speed * Time.deltaTime);
                }
            if(lier2 == distanceObjek44){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood44.position,speed * Time.deltaTime);
                }

            if(lier2 == distanceObjek45){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetFood45.position,speed * Time.deltaTime);
                }

            /*//bot
             if(lier2 == distanceObjek46){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetBot1.position,speed * Time.deltaTime);
                }

             if(lier2 == distanceObjek47){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetBot2.position,speed * Time.deltaTime);
                }

             if(lier2 == distanceObjek48){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetBot3.position,speed * Time.deltaTime);
                }

             if(lier2 == distanceObjek49){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetBot4.position,speed * Time.deltaTime);
                }

             if(lier2 == distanceObjek50){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetBot5.position,speed * Time.deltaTime);
                }

             if(lier2 == distanceObjek51){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetBot6.position,speed * Time.deltaTime);
                }

             if(lier2 == distanceObjek52){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetBot7.position,speed * Time.deltaTime);
                }

             if(lier2 == distanceObjek53){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetBot8.position,speed * Time.deltaTime);
                }

             if(lier2 == distanceObjek54){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetBot9.position,speed * Time.deltaTime);
                }

             if(lier2 == distanceObjek55){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetBot10.position,speed * Time.deltaTime);
                }

             if(lier2 == distanceObjek56){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetBot11.position,speed * Time.deltaTime);
                }

             if(lier2 == distanceObjek57){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetBot12.position,speed * Time.deltaTime);
                }

             if(lier2 == distanceObjek58){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetBot13.position,speed * Time.deltaTime);
                }

             if(lier2 == distanceObjek59){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetBot14.position,speed * Time.deltaTime);
                }

             if(lier2 == distanceObjek60){
            
                    transform.position = Vector2.MoveTowards(transform.position,targetBot15.position,speed * Time.deltaTime);
                }
*/
        }

        if(Vector2.Distance(transform.position,moveSpots[randomSpot].position) < 1.0f)  //pindah spot
        {
          
            randomSpot = Random.Range(0,moveSpots.Length);
        }
         
            
        gerakAnimasi(a,b);
            
            a = b;
        if (FoodShoot2 = true){
            currentTimeFoodShoot -= 1*Time.deltaTime;
        }
        if(currentTimeFoodShoot < 0f){
            FoodShoot2 = false;
            speed = 3f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       /* if (other.gameObject.tag == "Food")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }*/

        if (other.gameObject.tag == "botFood1")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();
            gameManager.respawnBot(gameManager.botFood1Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }
        if (other.gameObject.tag == "botFood2")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();
            
            gameManager.respawnBot(gameManager.botFood2Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood3")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood3Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood4")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood4Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood5")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood5Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood6")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood6Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood7")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood7Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood8")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood8Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood9")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood9Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood10")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood10Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood11")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood11Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood12")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood12Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood13")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood13Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood14")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood14Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood15")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood15Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood16")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood16Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood17")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood17Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood18")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood18Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood19")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood19Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood20")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood20Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood21")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood21Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood22")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood22Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood23")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood23Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood24")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood24Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood25")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood25Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood26")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood26Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood27")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood27Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood28")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood28Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood29")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood29Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood30")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood30Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood31")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood31Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood32")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood32Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood33")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood33Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood34")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood34Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood35")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood35Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood36")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood36Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood37")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood37Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood38")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood38Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood39")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood39Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood40")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood40Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood41")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood41Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood42")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood42Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood43")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood43Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood44")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood44Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }if (other.gameObject.tag == "botFood45")
        {
            Print("Ate food", "log");
            transform.localScale += new Vector3(increase, increase, 0);
            other.GetComponent<BotFood>().RemoveObject();

            gameManager.respawnBot(gameManager.botFood45Prefab);
            score += 10;
            this.gameObject.GetComponent<Text>().text = score.ToString();
            scoreBot.text = this.gameObject.GetComponent<Text>().text;
       
        }
        if (other.gameObject.tag == "foodShoot")
        {
            Print("Ate food", "log");
            currentTimeFoodShoot = startingTimeFoodShoot;
            score -= 10;
            speed = 0;
            FoodShoot2 = true;
            
        }
        else if (other.gameObject.tag == "Player")
        {
        	if (transform.localScale.x > other.gameObject.transform.localScale.x){
            	Print("Ate player", "log");
                audioManager.PlaySound(deadSound);
            	transform.localScale = transform.localScale + (other.gameObject.transform.localScale/2);
            	SceneManager.LoadScene("GameOver");
            }
        }
        else if (other.gameObject.tag == "SplitMass")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
                Print("Ate SplitMass", "log");
                audioManager.PlaySound(deadSound);
                transform.localScale = transform.localScale + (other.gameObject.transform.localScale/2);
                 Destroy(other.gameObject);
              }
        }
         else if (other.gameObject.tag == "Bot1")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
                 transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot1Prefab);
                audioManager.PlaySound(deadSound);
                score += 20;
                // gameManager.ChangeScore(20);
                // gameManager.ChangeEatenFood(5);
            }
        }
        else if (other.gameObject.tag == "Bot2")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot2Prefab);
                audioManager.PlaySound(deadSound);
                score += 20;
                // gameManager.ChangeScore(20);
                // gameManager.ChangeEatenFood(5);
            }
        }
        else if (other.gameObject.tag == "Bot3")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot3Prefab);
                audioManager.PlaySound(deadSound);
                score += 20;
                // gameManager.ChangeScore(20);
                // gameManager.ChangeEatenFood(5);
            }
        }
        else if (other.gameObject.tag == "Bot4")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot4Prefab);               
                audioManager.PlaySound(deadSound);
                // gameManager.ChangeScore(20);
                // gameManager.ChangeEatenFood(5);
                score += 20;
            }
        }
        else if (other.gameObject.tag == "Bot5")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot5Prefab);
                audioManager.PlaySound(deadSound);
                score += 20;
                // gameManager.ChangeScore(20);
                // gameManager.ChangeEatenFood(5);

            }
        }
         else if (other.gameObject.tag == "Bot6")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                gameManager.respawnBot(gameManager.bot6Prefab);
                audioManager.PlaySound(deadSound);
                score += 20;
                // gameManager.ChangeScore(20);
                // gameManager.ChangeEatenFood(5);
            }
        }
         else if (other.gameObject.tag == "Bot7")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                audioManager.PlaySound(deadSound);
                gameManager.respawnBot(gameManager.bot7Prefab);
                // gameManager.ChangeScore(20);
                // gameManager.ChangeEatenFood(5);
                score += 20;
            }
        }
         else if (other.gameObject.tag == "Bot8")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                audioManager.PlaySound(deadSound);
                gameManager.respawnBot(gameManager.bot8Prefab);
                // gameManager.ChangeScore(20);
                // gameManager.ChangeEatenFood(5);
                score += 20;
            }
        }
         else if (other.gameObject.tag == "Bot9")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
             
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                audioManager.PlaySound(deadSound);
                gameManager.respawnBot(gameManager.bot9Prefab);
                // gameManager.ChangeScore(20);
                // gameManager.ChangeEatenFood(5);
                score += 20;
            }
        }
         else if (other.gameObject.tag == "Bot10")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
              
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                audioManager.PlaySound(deadSound);
                gameManager.respawnBot(gameManager.bot10Prefab);
                // gameManager.ChangeScore(20);
                // gameManager.ChangeEatenFood(5);
                score += 20;
            }
        }
         else if (other.gameObject.tag == "Bot11")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
             
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                audioManager.PlaySound(deadSound);
                gameManager.respawnBot(gameManager.bot11Prefab);
                score += 20;

            }
        }
         else if (other.gameObject.tag == "Bot12")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
               // Print("Ate bot", "log");
             //     audioManager.PlaySound(eatFish);
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                audioManager.PlaySound(deadSound);
                gameManager.respawnBot(gameManager.bot12Prefab);
                gameManager.ChangeScore(20);
                gameManager.ChangeEatenFood(5);
            }
        }
         else if (other.gameObject.tag == "Bot13")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
          
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                audioManager.PlaySound(deadSound);
                gameManager.respawnBot(gameManager.bot13Prefab);
                // gameManager.ChangeScore(20);
                // gameManager.ChangeEatenFood(5);
                score += 20;
            }
        }
         else if (other.gameObject.tag == "Bot14")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
              
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                audioManager.PlaySound(deadSound);
                gameManager.respawnBot(gameManager.bot14Prefab);
                // gameManager.ChangeScore(20);
                score += 20;
                // gameManager.ChangeEatenFood(5);
            }
        }
         else if (other.gameObject.tag == "Bot15")
        {
            if (transform.localScale.x > other.gameObject.transform.localScale.x){
            
                transform.localScale += new Vector3(increase*5, increase*5, 0) ;
                Destroy(other.gameObject);
                audioManager.PlaySound(deadSound);
                gameManager.respawnBot(gameManager.bot15Prefab);
                // gameManager.ChangeScore(20);
                score += 20;
                // gameManager.ChangeEatenFood(5);
            }
        }
    }
    void gerakAnimasi(float a,float b)
    {
         if(a > b)
            {
                animator.SetInteger("WalkState", 1);
                c=2;
            }
            else {
                animator.SetInteger("WalkState", 2);
                c=4;
            }
    }

class Node
    {
        public float item;
        public Node left;
        public Node right;
    }
   class Tree
    {
        public Node root;
        public Tree()
        {
            root = null;
        }
        public Node ReturnRoot()
        {
            return root;
        }

        public void Insert(float id)
        {
            Node newNode = new Node();
            newNode.item = id;
            if (root == null)
                root = newNode;
            else
            {
                Node current = root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if (id < current.item)
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = newNode;
                            return;
                        }
                    }
                }
            }
        }
        
      
        public void Inorder(Node Root)
        {
            
            if (Root != null)
            {
                Inorder(Root.right);
                lier3 = Root.item;
                Inorder(Root.left);

            }
        }
    }

}
