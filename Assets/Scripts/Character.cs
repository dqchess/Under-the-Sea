using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public GameObject player;
    public GameObject clonePlayer;
    public GameObject background;
    public GameObject latar2;
    public int SelectLevel;

    private Level level;

    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<Level>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle(GameObject gameObject) {
    	if(gameObject.activeInHierarchy) {
    		gameObject.SetActive(false);
    	} else {
    		gameObject.SetActive(true);
    	}
    } 

    public void ChangeCharacterSprite(Sprite character, RuntimeAnimatorController animatorController) {
        player.GetComponent<SpriteRenderer>().sprite = character;        
    }

    public void ChangeCharacterAnimation(RuntimeAnimatorController animatorController) {
        player.GetComponent<Animator>().runtimeAnimatorController = animatorController as RuntimeAnimatorController;
        clonePlayer.GetComponent<Animator>().runtimeAnimatorController = animatorController as RuntimeAnimatorController;
    }
     public void ChangeCharacterAnimation(Sprite latar) {
        background.GetComponent<SpriteRenderer>().sprite = latar ;
        //clonePlayer.GetComponent<SpriteRenderer>() = latar as GameObject;
    }
    public void SelectLevel1()
    {
            level.currentLevel =1;
            SelectLevel = 1;
    }
    public void SelectLevel2()
    {
            level.currentLevel =2;
            SelectLevel = 2;
    }
}
