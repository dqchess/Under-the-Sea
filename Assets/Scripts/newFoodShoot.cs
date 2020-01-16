using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newFoodShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Transform source;
    private Vector2 target;
    public float timeShoot = 0f;
    private float startingShoot = 7f;
    private BotController botController;


    void Start()
    {
    	timeShoot = startingShoot;
        source = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        target = new Vector2(source.position.x + 1,source.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        timeShoot -= 1*Time.deltaTime;
        if(timeShoot<0){
            Destroy(gameObject);
        }
    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    // 	if (other.gameObject.tag == "Bot1")
    //     {
    //             botController.speed = 0f;
    //     }
    //     else if (other.gameObject.tag == "Bot2")
    //     {
    //             botController.speed = 0f;
    //     }
    //     else if (other.gameObject.tag == "Bot3")
    //     {
    //             botController.speed = 0f;
    //     }
    //     else if (other.gameObject.tag == "Bot4")
    //     {
    //             botController.speed = 0f;
    //     }
    //     else if (other.gameObject.tag == "Bot5")
    //     {
    //             botController.speed = 0f;
    //     }
    //     else if (other.gameObject.tag == "Bot6")
    //     {
    //             botController.speed = 0f;
    //     }
    //     else if (other.gameObject.tag == "Bot7")
    //     {
    //             botController.speed = 0f;
    //     }
    //     else if (other.gameObject.tag == "Bot8")
    //     {
    //             botController.speed = 0f;
    //     }
    //     else if (other.gameObject.tag == "Bot9")
    //     {
    //             botController.speed = 0f;
    //     }
    //     else if (other.gameObject.tag == "Bot10")
    //     {
    //             botController.speed = 0f;
    //     }
    //     else if (other.gameObject.tag == "Bot11")
    //     {
    //             botController.speed = 0f;
    //     }
    //     else if (other.gameObject.tag == "Bot12")
    //     {
    //             botController.speed = 0f;
    //     }
    //     else if (other.gameObject.tag == "Bot13")
    //     {
    //             botController.speed = 0f;
    //     }
    //     else if (other.gameObject.tag == "Bot14")
    //     {
    //             botController.speed = 0f;
    //     }
    //     else if (other.gameObject.tag == "Bot15")
    //     {
    //             botController.speed = 0f;
    //     }
    // }
}
