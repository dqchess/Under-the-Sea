using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : Utilities
{
	private int scene;
    void BacktoScene()
    {
    	scene = SceneManager.GetActiveScene().buildIndex - 1;
        SceneManager.LoadScene(scene);        
    }
}
