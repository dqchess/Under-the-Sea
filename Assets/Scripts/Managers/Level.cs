using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Level : Utilities
{
    public Vector2 spawnField;
    public float borderThickness = 1.0f;
    public int currentLevel;

    public GameObject foodPrefab;
    public GameObject tilePrefab;
    public GameObject tilePrefab2;
    public GameObject botPrefab;
    public GameObject trapPrefab;                               //trap
    public GameObject bubblePrefab;
    public GameObject bubbleBuffPrefab;
    public GameObject testFood; //test 

    public List<GameObject> tiles = new List<GameObject>();
    public List<GameObject> food = new List<GameObject>();
    public List<GameObject> bot = new List<GameObject>();
    public List<GameObject> trap = new List <GameObject>();
    public List<GameObject> bubble = new List <GameObject>();
    public List<GameObject> bubbleBuff = new List <GameObject>();
    
    public float spawnInterval = 5.0f;
    public int initialFoodAmount = 100;
    public int initialBotAmount = 15;
    public int initialTrapAmount = 10;

    private GameManager gameManager;
    private MenuManager menuManager;
    private Character character;



    private SpriteRenderer spriteRenderer;
    private BoxCollider2D upCollider;
    private BoxCollider2D downCollider;
    private BoxCollider2D rightCollider;
    private BoxCollider2D leftCollider;
    private float accumulator;

    private int maxFood = 30;
    private int maxBot = 15;
    private int maxTrap = 5;
    private int maxBubble = 50;
    private int maxBubbleBuff = 50;

    private float spriteWidth;
    private float spriteHeight;
    private int tileCount;

    public string [] nameBot; //namebot

    // Awake is always called before any Start functions
    void Awake()
    {

    }
    // Use this for initialization
    void Start ()
    {
        character = FindObjectOfType<Character>();
        menuManager = FindObjectOfType<MenuManager>();
        gameManager = FindObjectOfType<GameManager>();
        upCollider = gameObject.AddComponent<BoxCollider2D>();
        upCollider.offset = new Vector2(0.0f, spawnField.y);
        upCollider.size = new Vector2(spawnField.x * 2.0f, borderThickness);
        rightCollider = gameObject.AddComponent<BoxCollider2D>();
        rightCollider.offset = new Vector2(spawnField.x, 0.0f);
        rightCollider.size = new Vector2(borderThickness, spawnField.y * 2.0f);
        downCollider = gameObject.AddComponent<BoxCollider2D>();
        downCollider.offset = new Vector2(0.0f, -spawnField.y);
        downCollider.size = new Vector2(spawnField.x * 2.0f, borderThickness);
        leftCollider = gameObject.AddComponent<BoxCollider2D>();
        leftCollider.offset = new Vector2(-spawnField.x, 0.0f);
        leftCollider.size = new Vector2(borderThickness, spawnField.y * 2.0f);
        if (menuManager.currentLevel == true){
                spriteRenderer = tilePrefab.GetComponent<SpriteRenderer>();  
        }
        else if (menuManager.currentLevel == false){
                spriteRenderer = tilePrefab2.GetComponent<SpriteRenderer>();      
        }
        spriteWidth = spriteRenderer.sprite.bounds.size.x;
        spriteHeight = spriteRenderer.sprite.bounds.size.y;
       // currentLevel = character.SelectLevel;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (gameManager.currentState == GameManager.State.Playing){
            if (accumulator > spawnInterval){
                if (bubble.Count < maxBubble){
                    SpawnBubble(1);
                }
                if (bubble.Count < maxBubble){
                    SpawnBubbleBuff(1);
                }
                if (currentLevel== 1){
                        SpawnTrap(0);
                }
                else if (currentLevel == 2) {
                    if (trap.Count < maxTrap){
                    SpawnTrap(1);
                    }    

                }

                accumulator = 0;
            }
            accumulator += Time.deltaTime;
        }
    }

    public void SpawnBubble(int amount)
    {
    	print("Spawning bubble: " + amount);
        for (int i = 0; i < amount; i++)
        {
            Vector3 position = new Vector3(Random.Range(-spawnField.x, spawnField.x), -48, 0.0f);
            GameObject newBubble = Instantiate(bubblePrefab, position, Quaternion.identity);
            newBubble.transform.parent = gameObject.transform;
            bubble.Add(newBubble);
        }
    }

    public void SpawnBubbleBuff(int amount)
    {
        print("Spawning bubbleBuff: " + amount);
        for (int i = 0; i < amount; i++)
        {
            Vector3 position = new Vector3(Random.Range(-spawnField.x, spawnField.x), -48, 0.0f);
            GameObject newBubbleBuff = Instantiate(bubbleBuffPrefab, position, Quaternion.identity);
            newBubbleBuff.transform.parent = gameObject.transform;
            bubble.Add(newBubbleBuff);
        }
    }

    /// <summary>
    /// Spawn a certain amount of food instances.
    /// </summary>
    public void SpawnFood(int amount)
    {
        print("Spawning food: " + amount);
        for (int i = 0; i < amount; i++)
        {
            Vector3 position = new Vector3(Random.Range(-spawnField.x, spawnField.x), Random.Range(-spawnField.y, spawnField.y), 0.0f);
            GameObject newFood = Instantiate(foodPrefab, position, Quaternion.identity);
            newFood.transform.parent = gameObject.transform;
            food.Add(newFood);
        }
    }
    public void SpawnTrap(int amount)
    {
        print("Spawning Trap: " + amount);
        for (int i = 0; i < amount; i++){
            Vector3 position = new Vector3(Random.Range(-spawnField.x, spawnField.x), Random.Range(-spawnField.y, spawnField.y), 0.0f);
            GameObject newTrap = Instantiate(trapPrefab, position, Quaternion.identity);
            newTrap.transform.parent = gameObject.transform;
            bot.Add(newTrap);
        }
    }

    /// <summary>
    /// Change the current variables in FoodManager.
    /// </summary>
    public void ChangeLimits(int a_Maxfood, Vector2 a_Maxfield)
    {
        maxFood = a_Maxfood;
        spawnField = a_Maxfield;
    }

    public void PrepareLevel()
    {
       if (spriteWidth > 0.0f && spriteHeight > 0.0f){
            float tilesOnX = (spawnField.x * 2) / spriteWidth;
            float tilesOnY = (spawnField.y * 2) / spriteHeight;
            tileCount = Mathf.CeilToInt(tilesOnX) * Mathf.CeilToInt(tilesOnY);

            Print("Spawning " + tileCount + " tiles");
                    Vector3 position = new Vector3(-0 + 0, -0 + 0, 0.0f);
                    if (gameManager.latar == true){
                        GameObject newTile = Instantiate(tilePrefab, position, Quaternion.identity);
                        newTile.transform.parent = gameObject.transform;
                        tiles.Add(newTile);
                    }
                    else{
                        GameObject newTile = Instantiate(tilePrefab2, position, Quaternion.identity);
                        newTile.transform.parent = gameObject.transform;
                        tiles.Add(newTile);
                    }                 
        }
        else{
            Print("Tile prefab contains no data!", "error");
        }
        SpawnFood(initialFoodAmount);
       // SpawnTrap(1);
    }
    public void chageTile()
    {
        tilePrefab = tilePrefab2;
    }
}
