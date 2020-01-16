using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BacktoMenu : MonoBehaviour
{
	private int scene;
    void Back()
    {
    	scene = SceneManager.GetActiveScene().buildIndex - 1;
        SceneManager.LoadScene(scene);        
    }
}
