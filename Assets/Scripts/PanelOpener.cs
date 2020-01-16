using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOpener : Utilities
{
    public InputField user;
    public GameObject panel;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject menupanel;
    
    public InputField playername;
    string nametest;
    
    
    
    public void OpenPanel()
    {
        nametest = playername.text;
    	if(panel!=null)
        {
            if(nametest.Length < 9 && nametest.Length>0)
            {
                
                Print("Hello","log");
                
                panel.SetActive(false);
                menupanel.SetActive(true);   
                GameObject.Find("under the sea").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            } 
            else if(nametest.Length>8)
            {
                panel2.SetActive(true);
            }
            else
            {
                panel3.SetActive(true);
            }
        }
        else
        {
            Print("Error panel","log");
        }
    }

}
