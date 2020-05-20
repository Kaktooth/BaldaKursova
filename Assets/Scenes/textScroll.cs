using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textScroll :MonoBehaviour
{
  public static string finish = "";
    public InputField inputscroll;
   
    public void Scrolltext()
    {
        inputscroll.text = finish;
        
    }

 
}
