using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Utilities
{
    public enum State { Menu, Preparing, Playing, Paused };  //variable asing 
    
    public State currentState;                  //variabel keadaan saat ini          
    public float currentTime;
    public float startingTime = 150f;             //
    public int currentScore = 0;                // variabel score
    public int currentHighScore = 0;            //variable highscore
    public int eatenFood=1;
    
    public bool testP = false;

    private Transform camScale;
    public float camSize;
    public int foodEat;
    public int botScore = 0;                // variabel score
    public string userHighScore;
    public GameObject playerPrefab;
    public Sprite chara1;
    public Sprite chara2;
    public Sprite chara3;
    public int test = 0;
    
    public string backgroundMusic = "BackgroundMusic"; //background music
    public string mainMenu = "MainMenu";
    public string gameOverBGM = "GameOver";

    public GameObject bot1Prefab;
    public GameObject bot2Prefab;
    public GameObject bot3Prefab;
    public GameObject bot4Prefab;
    public GameObject bot5Prefab;
    public GameObject bot6Prefab;
    public GameObject bot7Prefab;
    public GameObject bot8Prefab;
    public GameObject bot9Prefab;
    public GameObject bot10Prefab;
    public GameObject bot11Prefab;
    public GameObject bot12Prefab;
    public GameObject bot13Prefab;
    public GameObject bot14Prefab;
    public GameObject bot15Prefab;

    public GameObject botFood1Prefab;
    public GameObject botFood2Prefab;
    public GameObject botFood3Prefab;
    public GameObject botFood4Prefab;
    public GameObject botFood5Prefab;
    public GameObject botFood6Prefab;
    public GameObject botFood7Prefab;
    public GameObject botFood8Prefab;
    public GameObject botFood9Prefab;
    public GameObject botFood10Prefab;
    public GameObject botFood11Prefab;
    public GameObject botFood12Prefab;
    public GameObject botFood13Prefab;
    public GameObject botFood14Prefab;
    public GameObject botFood15Prefab;

    public GameObject botFood16Prefab;
    public GameObject botFood17Prefab;
    public GameObject botFood18Prefab;
    public GameObject botFood19Prefab;
    public GameObject botFood20Prefab;
    public GameObject botFood21Prefab;
    public GameObject botFood22Prefab;
    public GameObject botFood23Prefab;
    public GameObject botFood24Prefab;
    public GameObject botFood25Prefab;
    public GameObject botFood26Prefab;
    public GameObject botFood27Prefab;
    public GameObject botFood28Prefab;
    public GameObject botFood29Prefab;
    public GameObject botFood30Prefab;

    public GameObject botFood31Prefab;
    public GameObject botFood32Prefab;
    public GameObject botFood33Prefab;
    public GameObject botFood34Prefab;
    public GameObject botFood35Prefab;
    public GameObject botFood36Prefab;
    public GameObject botFood37Prefab;
    public GameObject botFood38Prefab;
    public GameObject botFood39Prefab;
    public GameObject botFood40Prefab;
    public GameObject botFood41Prefab;
    public GameObject botFood42Prefab;
    public GameObject botFood43Prefab;
    public GameObject botFood44Prefab;
    public GameObject botFood45Prefab;

    public GameObject menuPrefab;
    public GameObject panelTombolControler;
    public Text highscoreBar;           //Highscore pada menu
    
    public GameObject panelLevel1;
    public GameObject panelLevel2;
    public GameObject panelWinner;
    
    public int targetScoreLevel1 = 1000;       
    public int targetScoreLevel2 = 1000;
    public int currentLevel ;

    public bool latar = true;
    public int pilihanLatar;

    private PlayerController1 playerController;
    public InputField user;
    private AudioManager audioManager;                  //audio
    private Camera mainCamera;                            //camera
    private Level level;                                //level
    
    private MenuManager menuManager;
    bool gameHasEnded = false;
    // Awake is always called before any Start functions
    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        //currentLevel =1;
        if (currentLevel == 1){
            panelLevel2.SetActive(false);    
        }
        else if (currentLevel == 2){
            panelLevel2.SetActive(true);
        }
        testP = false;
        panelTombolControler = GameObject.FindGameObjectWithTag("a");
        Vector3 menuPosition = new Vector3(0.0f, 2.5f, 0.0f);
        GameObject newMenu = Instantiate(menuPrefab, menuPosition, Quaternion.identity);

        audioManager = FindObjectOfType<AudioManager>();
        if (audioManager == null){
            Print("No AudioManager found!", "error");
        }
        mainCamera = Camera.main;
        if (mainCamera == null){
            Print("No Camera found!", "error");
        }
        level = FindObjectOfType<Level>();
        if (level == null){
            Print("No Level found!", "error");
        }
        audioManager.PlaySound(mainMenu);
        Load();
        highscoreBar.text = userHighScore +":"+currentHighScore;
    }

    // Update is called once per frame
    void Update()
    {
        // elapsedTime = Time.time;
        if (currentScore >= targetScoreLevel1 && currentLevel ==1){
          SceneManager.LoadScene("NextLevel");    
        }

        if (currentState == State.Playing){
            camController();
            currentTime -= 1 * Time.deltaTime;
            if (currentScore > currentHighScore){
                currentHighScore = currentScore;
                Save();
                Save2();
            }
        }
        GameOver();
        if (pilihanLatar ==1){
            latar = true;
        }
        else if (pilihanLatar ==2 ){    
            latar = false;
        }
    }

    /// <summary>
    /// Change the current game state.
    /// </summary>
    public void ChangeState(State state)
    {
        Print("Changing state", "event");

        currentState = state;
    }

    /// <summary>
    /// Start the game.
    /// </summary>
    public void PrepareLevel(int level)
    {
        Print("Preparing level", "event");

        currentState = State.Preparing;
    }

    /// <summary>
    /// Play the game.
    /// </summary>
    public void Play()
    { 
        Print("Preparing game", "event");

        Destroy(GameObject.Find("Background Menu(Clone)"));

        currentState = State.Preparing;
        GameObject newPlayer = Instantiate(playerPrefab, gameObject.transform.position, Quaternion.identity);

        respawnBot(bot1Prefab);  
        respawnBot(bot2Prefab);     
        respawnBot(bot3Prefab);     
        respawnBot(bot4Prefab);     
        respawnBot(bot5Prefab);     
        respawnBot(bot6Prefab); 
        respawnBot(bot8Prefab);  
        respawnBot(bot7Prefab);     
        respawnBot(bot8Prefab);     
        respawnBot(bot9Prefab);     
        respawnBot(bot10Prefab); 
        respawnBot(bot11Prefab);  
        respawnBot(bot12Prefab);     
        respawnBot(bot13Prefab);     
        respawnBot(bot14Prefab);     
        respawnBot(bot15Prefab);     

        respawnBotFood(botFood1Prefab);  
        respawnBotFood(botFood2Prefab);     
        respawnBotFood(botFood3Prefab);     
        respawnBotFood(botFood4Prefab);     
        respawnBotFood(botFood5Prefab);     
        respawnBotFood(botFood6Prefab); 
        respawnBotFood(botFood8Prefab);  
        respawnBotFood(botFood7Prefab);     
        respawnBotFood(botFood8Prefab);     
        respawnBotFood(botFood9Prefab);     
        respawnBotFood(botFood10Prefab); 
        respawnBotFood(botFood11Prefab);  
        respawnBotFood(botFood12Prefab);     
        respawnBotFood(botFood13Prefab);     
        respawnBotFood(botFood14Prefab);     
        respawnBotFood(botFood15Prefab);

        respawnBotFood(botFood16Prefab);  
        respawnBotFood(botFood17Prefab);     
        respawnBotFood(botFood18Prefab);     
        respawnBotFood(botFood19Prefab);     
        respawnBotFood(botFood20Prefab);     
        respawnBotFood(botFood21Prefab); 
        respawnBotFood(botFood22Prefab);  
        respawnBotFood(botFood23Prefab);     
        respawnBotFood(botFood24Prefab);     
        respawnBotFood(botFood25Prefab);     
        respawnBotFood(botFood26Prefab); 
        respawnBotFood(botFood27Prefab);  
        respawnBotFood(botFood28Prefab);     
        respawnBotFood(botFood29Prefab);     
        respawnBotFood(botFood30Prefab);     
        
        respawnBotFood(botFood31Prefab);  
        respawnBotFood(botFood32Prefab);     
        respawnBotFood(botFood33Prefab);     
        respawnBotFood(botFood34Prefab);     
        respawnBotFood(botFood35Prefab);     
        respawnBotFood(botFood36Prefab); 
        respawnBotFood(botFood38Prefab);  
        respawnBotFood(botFood37Prefab);     
        respawnBotFood(botFood38Prefab);     
        respawnBotFood(botFood39Prefab);     
        respawnBotFood(botFood40Prefab); 
        respawnBotFood(botFood41Prefab);  
        respawnBotFood(botFood42Prefab);     
        respawnBotFood(botFood43Prefab);     
        respawnBotFood(botFood44Prefab);     
        respawnBotFood(botFood45Prefab);

        mainCamera.GetComponent<SmoothFollow2DCamera>().target = newPlayer.transform;
        mainCamera.GetComponent<SmoothFollow2DCamera>().enabled = true;
        audioManager.StopSound(mainMenu);
        audioManager.PlaySound(backgroundMusic);
        Reset();
        level.PrepareLevel();  
        currentState = State.Playing;
        currentTime = startingTime;
        
    }

    /// <summary>
    /// Pause the game.
    /// </summary>
    public void Pause()
    {
        Print("Pausing game", "event");
        currentState = State.Paused;
        audioManager.PauseSound(backgroundMusic);
        Time.timeScale = 0;
        testP = true;

    }

    /// <summary>
    /// Proceed gameplay.
    /// </summary>
    public void Resume()
    {
        currentState = State.Playing;
        audioManager.ResumeSound(backgroundMusic);
        Time.timeScale = 1.0f;
        testP = false;
    }
    /// <summary>
    /// GameOver the game.
    /// </summary>
   
    public void GameOver()
    {
        if (currentTime<0){
            SceneManager.LoadScene("GameOver");    
            currentTime = startingTime; 
        }
    }

/// <summary>
    /// Quit the game and save settings.
    /// </summary>
    public void Quit()
    {
        Print("Quitting game", "event");
        Application.Quit();//bug
    }
    /// <summary>
    /// Reset the game.
    /// </summary>
    public void Reset()
    {
        currentScore = 0;
        currentTime = 0.0f;
    }

    /// <summary>
    /// Change the current score.
    /// </summary>
    public void ChangeScore(int score)
    {
        Print("Changing score", "event");
        currentScore += score;
    }
    public void ChangeEatenFood(int totalFood){
        Print("Changing eaten food", "event");
        eatenFood += totalFood;
    }

    /// <summary>
    /// Load game preferences and other save files.
    /// </summary>
    public void Load()
    {
        Print("Loading", "event");
        currentHighScore = Deserialize<int>(Application.streamingAssetsPath + "/XML/Highscores.xml");
        userHighScore = Deserialize<string>(Application.streamingAssetsPath + "/XML/Username.xml");

    }

    /// <summary>
    /// Save preferences and progress.
    /// </summary>
    public void Save()
    {
        Print("Saving", "event");
        Serialize(currentHighScore, Application.streamingAssetsPath + "/XML/Highscores.xml");
    }
    public void Save2()
    {
        Print("Saving","event");
        Serialize(user.text, Application.streamingAssetsPath + "/XML/Username.xml");

    }

    public void Save3(int angka)
    {
        Print("Saving","event");
        Serialize(angka, Application.streamingAssetsPath + "/XML/image.xml");
    }

   public void camController()
   {
        camScale = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        camSize=camScale.localScale.x/0.3f;
        Camera.main.orthographicSize = camSize;
    }

    public void chara()//memilih karakter
    {
            Save3(1);
    }
    public void charake2()//memilih karakter
    {
        Save3(2);
    }
    public void EndGame()
    {
        Print("Game Over","log");
        Print("Game Over","log");
        Print("Game Over","log");
    }
    public void respawnBot(GameObject botPrefab)
    {
        Vector3 position = new Vector3(Random.Range(-48, 48), Random.Range(-48, 48), 0.0f);
        GameObject newBot = Instantiate(botPrefab, position, Quaternion.identity);
    }
    public void respawnBotFood(GameObject botPrefab)//test
    {
        Vector3 position = new Vector3(Random.Range(-48, 48), Random.Range(-48, 48), 0.0f);
        GameObject newBotFood = Instantiate(botPrefab, position, Quaternion.identity);
    }
    public void changelatar()
    {
       latar = true;
    }  
    public void changelatar2()
    {
        latar = false;
    }
    public void offPanelWinner()
    {
        panelWinner.SetActive(false);
    }
    public void restart()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.FindGameObjectWithTag("Bot1"));  
        Destroy(GameObject.FindGameObjectWithTag("Bot2"));     
        Destroy(GameObject.FindGameObjectWithTag("Bot3"));     
        Destroy(GameObject.FindGameObjectWithTag("Bot4"));     
        Destroy(GameObject.FindGameObjectWithTag("Bot5"));     
        Destroy(GameObject.FindGameObjectWithTag("Bot6")); 
        Destroy(GameObject.FindGameObjectWithTag("Bot7"));  
        Destroy(GameObject.FindGameObjectWithTag("Bot8"));     
        Destroy(GameObject.FindGameObjectWithTag("Bot9"));     
        Destroy(GameObject.FindGameObjectWithTag("Bot10"));     
        Destroy(GameObject.FindGameObjectWithTag("Bot11")); 
        Destroy(GameObject.FindGameObjectWithTag("Bot12"));  
        Destroy(GameObject.FindGameObjectWithTag("Bot13"));     
        Destroy(GameObject.FindGameObjectWithTag("Bot14"));     
        Destroy(GameObject.FindGameObjectWithTag("Bot15"));     
        Destroy(GameObject.FindGameObjectWithTag("background"));

        Destroy(botFood1Prefab);  
        Destroy(botFood2Prefab);     
        Destroy(botFood3Prefab);     
        Destroy(botFood4Prefab);     
        Destroy(botFood5Prefab);     
        Destroy(botFood6Prefab); 
        Destroy(botFood8Prefab);  
        Destroy(botFood7Prefab);     
        Destroy(botFood8Prefab);     
        Destroy(botFood9Prefab);     
        Destroy(botFood10Prefab); 
        Destroy(botFood11Prefab);  
        Destroy(botFood12Prefab);     
        Destroy(botFood13Prefab);     
        Destroy(botFood14Prefab);     
        Destroy(botFood15Prefab);

        Destroy(botFood16Prefab);  
        Destroy(botFood17Prefab);     
        Destroy(botFood18Prefab);     
        Destroy(botFood19Prefab);     
        Destroy(botFood20Prefab);     
        Destroy(botFood21Prefab); 
        Destroy(botFood22Prefab);  
        Destroy(botFood23Prefab);     
        Destroy(botFood24Prefab);     
        Destroy(botFood25Prefab);     
        Destroy(botFood26Prefab); 
        Destroy(botFood27Prefab);  
        Destroy(botFood28Prefab);     
        Destroy(botFood29Prefab);     
        Destroy(botFood30Prefab);     
        
        Destroy(botFood31Prefab);  
        Destroy(botFood32Prefab);     
        Destroy(botFood33Prefab);     
        Destroy(botFood34Prefab);     
        Destroy(botFood35Prefab);     
        Destroy(botFood36Prefab); 
        Destroy(botFood38Prefab);  
        Destroy(botFood37Prefab);     
        Destroy(botFood38Prefab);     
        Destroy(botFood39Prefab);     
        Destroy(botFood40Prefab); 
        Destroy(botFood41Prefab);  
        Destroy(botFood42Prefab);     
        Destroy(botFood43Prefab);     
        Destroy(botFood44Prefab);     
        Destroy(botFood45Prefab);
    }

    public void goToMainMenu() {
        Print("Go to Main Menu", "event");
        SceneManager.LoadScene("Main");
        currentState = State.Menu;
        Time.timeScale = 1.0f;
    }
}
