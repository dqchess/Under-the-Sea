using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PanelClose : Utilities
{
    public InputField user;
    public GameObject panel;

    public void ClosePanel()
    {
    	if(panel!=null)
        {

                panel.SetActive(false);

        }
        else
        {
            Print("Error panel","log");
        }
    }

}
