using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : Utilities
{
	private GameManager gameManager;
    private Level level;
    private float accumulator;
    
    // Start is called before the first frame update
    void Start()
    {
    	gameManager = FindObjectOfType<GameManager>();
        level = FindObjectOfType<Level>();

        if (gameManager == null)
        {
            Print("No GameManager found!", "error");
        }
        if (level == null)
        {
            Print("No Level found!", "error");
        }
    }

    // Update is called once per frame
    void Update()
    {
    	if (accumulator > 31.5f)
            {
            	level.bubble.Remove(gameObject);
        		Destroy(gameObject);
            	accumulator = 0;
            }
        accumulator += Time.deltaTime;
    }
     public void RemoveObject()
    {
        level.food.Remove(gameObject);
        Destroy(gameObject);
    } 
}
