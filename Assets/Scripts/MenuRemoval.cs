using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRemoval : Utilities
{
	private GameManager gameManager;
	public enum State { Menu, Preparing, Playing, Paused };
	public State currentState;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Print("No GameManager found!", "error");
        }
    }

    // Update is called once per frame
    void Update()
    {
    	
    }
}
