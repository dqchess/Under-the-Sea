using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class MenuManager : Utilities
{
    public GameObject pausePanel; 
    public GameObject GameOver;
    public bool showFrameRate = true;
    public Text scoreText;                        // variabel bertipe text untuk score
    public Text highscoreText;                    // variable bertipe text untuk highscore
    public Text elapsedTimeText;                  // variable bertipe text untuk waktu
    public string buttonHover = "ButtonHover";
    public string buttonPress = "ButtonPress";
    public int minutes;
    public int seconds;   
     
    public Text Leaderboard2;
    public Text botScore1;
    public Text botScore2;
    public Text botScore3;
    public Text botScore4;
    public Text botScore5;

    public Text botScore6;
    public Text botScore7;
    public Text botScore8;
    public Text botScore9;
    
    public Text botScore10;
    public Text botScore11;
    public Text botScore12;
    public Text botScore13;
    public Text botScore14;
    public Text botScore15;

    public int parsedNumber1;
    public int parsedNumber2;
    public int parsedNumber3;
    public int parsedNumber4;
    public int parsedNumber5;
    public int parsedNumber6;
    public int parsedNumber7;
    public int parsedNumber8;
    public int parsedNumber9;
    
    public int parsedNumber10;
    public int parsedNumber11;
    public int parsedNumber12;
    public int parsedNumber13;
    public int parsedNumber14;
    public int parsedNumber15;

    public int rank1 ;
    public int rank2 ;
    public int rank3 ;
    public int rank4 ;
    public int rank5 ;
    public int []arr2;



    public bool currentLevel;
    private GameManager gameManager;

    // Use this for initialization
    void Start ()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Print("No AudioManager found!", "error");
        }
        botScore1.text = "0";
        botScore2.text = "0";
        botScore3.text = "0";
        botScore4.text = "0";
        botScore5.text = "0";
        botScore6.text = "0";
        botScore7.text = "0";
        botScore8.text = "0";
        botScore9.text = "0";
        botScore10.text = "0";
        botScore11.text = "0";
        botScore12.text = "0";
        botScore13.text = "0";
        botScore14.text = "0";
        botScore15.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        parsedNumber1 = int.Parse(botScore1.text);
        parsedNumber2 = int.Parse(botScore2.text);
        parsedNumber3 = int.Parse(botScore3.text);
        parsedNumber4 = int.Parse(botScore4.text);
        parsedNumber5 = int.Parse(botScore5.text);
        parsedNumber6 = int.Parse(botScore6.text);
        parsedNumber7 = int.Parse(botScore7.text);
        parsedNumber8 = int.Parse(botScore8.text);
        parsedNumber9 = int.Parse(botScore9.text);
        parsedNumber10 = int.Parse(botScore10.text);
        parsedNumber11 = int.Parse(botScore11.text);
        parsedNumber12 = int.Parse(botScore12.text);
        parsedNumber13 = int.Parse(botScore13.text);
        parsedNumber14 = int.Parse(botScore14.text);
        parsedNumber15 = int.Parse(botScore15.text);

        int []arr3 = {parsedNumber1,parsedNumber2,parsedNumber3,parsedNumber4 ,parsedNumber5,parsedNumber6,parsedNumber7,parsedNumber8,parsedNumber9,parsedNumber10,parsedNumber11,parsedNumber12,parsedNumber13,parsedNumber14 ,parsedNumber15};

        if (gameManager.currentState != GameManager.State.Menu)
        {
            if (Input.GetKeyUp(KeyCode.Escape) && !pausePanel.activeInHierarchy)
            {
                TogglePause();
            }
            else if (Input.GetKeyUp(KeyCode.Escape) && pausePanel.activeInHierarchy)
            {
                TogglePause();
            }

            minutes = (int) gameManager.currentTime/60;
            seconds = (int) gameManager.currentTime - (minutes*60);

            elapsedTimeText.text = minutes.ToString("D1") + " . " + seconds.ToString("D1");
            scoreText.text =    gameManager.user.text+"  : " + gameManager.currentScore;
            
            heapSort(arr3, 15);

             rank1 = arr3[14];
             rank2 = arr3[13];
             rank3 = arr3[12];
             rank4 = arr3[11];
             rank5 = arr3[10];

             Leaderboard2.text = "Rank 1 : "+ rank1+"\nRank 2 : "+rank2+"\nRank 3 : "+rank3+"\nRank 4 : "+rank4+"\nRank 5 : "+rank5;         
          
        }
    }
    void tampilHighscore()
    {
        scoreText.text =   "SCORE: " + gameManager.currentScore;
    }

    /// <summary>
    /// Toggle the pause menu and state.
    /// </summary>
    public void TogglePause()
    {
        if (gameManager.currentState == GameManager.State.Playing){
            TogglePanel(pausePanel);
            gameManager.Pause();
        }
        else{
            TogglePanel(pausePanel);
            gameManager.Resume();
        }
    }

    /// <summary>
    /// Toggle a panel.
    /// </summary>
    public void TogglePanel(GameObject panel)
    {
        if (panel.activeInHierarchy){
            panel.SetActive(false);
        }
        else{
            panel.SetActive(true);
        }
    }

    /// <summary>
    /// Toggle a canvas.
    /// </summary>
    public void ToggleCanvas(Canvas canvas)
    {
        if (canvas.enabled){
            canvas.enabled = false;
        }
        else{
            canvas.enabled = true;
        }
    }

    void OnGUI()
    {
        if (showFrameRate){
            int w = Screen.width, h = Screen.height;
            GUIStyle style = new GUIStyle();
            Rect rect = new Rect(0, 0, w, h * 2 / 100);
            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = h * 2 / 100;
            style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
            float msec = Time.deltaTime * 1000.0f;
            float fps = 1.0f / Time.deltaTime;
            string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
            GUI.Label(rect, text, style);
        }
    }
    public void selectLevel1()
    {
            currentLevel = true;
    }

    public void selectLevel2()
    {
            currentLevel = false;
    }
     void heapSort(int[] arr, int n) { 
         for (int i = n / 2 - 1; i >= 0; i--) 
            heapify(arr, n, i);
         for (int i = n-1; i>=0; i--) {
            int temp = arr[0]; 
            arr[0] = arr[i];
            arr[i] = temp;
            heapify(arr, i, 0); 
         }
      }
    void heapify(int[] arr, int n, int i) {
         int largest = i;
         int left = 2*i + 1;
         int right = 2*i + 2;
         if (left < n && arr[left] > arr[largest])
            largest = left;
         if (right < n && arr[right] >    arr[largest]) 
            largest = right;
         if (largest != i) {
            int swap = arr[i];
            arr[i] = arr[largest]; 
            arr[largest] = swap;
            heapify(arr, n, largest);
         }
      }
}
