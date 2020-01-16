using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenGameOver : MonoBehaviour
{
    public Button menu;
    void Start()
    {
        Button btn = menu.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        SceneManager.LoadScene("Main");
    }
    public void TaskOnClick2()
    {
        SceneManager.LoadScene("Main2");   
    }
}