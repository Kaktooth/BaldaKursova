using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class PlayScript : MonoBehaviour
{
    
    public InputField ifield1;    public InputField ifield2;
    public InputField ifield3;    public InputField ifield4;
    public InputField ifield5;    public InputField ifield6;
    public InputField ifield7;    public InputField ifield8;
    public InputField ifield9;    public InputField ifield10;
    public InputField ifield11;    public InputField ifield12;
    public InputField ifield13;    public InputField ifield14;
    public InputField ifield15;    public InputField ifield16;
    public InputField ifield17;    public InputField ifield18;
    public InputField ifield19;    public InputField ifield20;
    public InputField ifield21;    public InputField ifield22;
    public InputField ifield23;    public InputField ifield24;
    public InputField ifield25;    public InputField ifield26;
    public InputField ifield27;    public InputField ifield28;
    public InputField ifield29;    public InputField ifield30;
    public InputField ifield31;    public InputField ifield32;
    public InputField ifield33;    public InputField ifield34;
    public InputField ifield35;

   
    public InputField[,] arrIF = new InputField[5,7];
  public static string blockedword = "";


    public void Start()
    {
        Update();
       
    }

  
    public void Update()
    {
 
            arrIF[0, 0] = ifield1; 
            arrIF[0, 1] = ifield2;
            arrIF[0, 2] = ifield3;
            arrIF[0, 3] = ifield4;
            arrIF[0, 4] = ifield5;
            arrIF[0, 5] = ifield6;
            arrIF[0, 6] = ifield7;
            arrIF[1, 0] = ifield8;
            arrIF[1, 1] = ifield9;
            arrIF[1, 2] = ifield10;
            arrIF[1, 3] = ifield11;
            arrIF[1, 4] = ifield12;
            arrIF[1, 5] = ifield13;
            arrIF[1, 6] = ifield14;
            arrIF[2, 0] = ifield15;
            arrIF[2, 1] = ifield16;
            arrIF[2, 2] = ifield17;
            arrIF[2, 3] = ifield18;
            arrIF[2, 4] = ifield19;
            arrIF[2, 5] = ifield20;
            arrIF[2, 6] = ifield21;
            arrIF[3, 0] = ifield22;
            arrIF[3, 1] = ifield23;
            arrIF[3, 2] = ifield24;
            arrIF[3, 3] = ifield25;
            arrIF[3, 4] = ifield26;
            arrIF[3, 5] = ifield27;
            arrIF[3, 6] = ifield28;
            arrIF[4, 0] = ifield29;
            arrIF[4, 1] = ifield30;
            arrIF[4, 2] = ifield31;
            arrIF[4, 3] = ifield32;
            arrIF[4, 4] = ifield33;
            arrIF[4, 5] = ifield34;
            arrIF[4, 6] = ifield35;



    }
   
}
