using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOver : PlayScript
{
   public void Click()
    {
        Debug.Log("debug start");
        int l = 0;
        for (int i = 0; 5 > i; i++)
        {
            for (int j = 0; 7 > j; j++)
            {
                l++;
                Debug.Log(l+" "+arrIF[i, j].text);
            }
        }
    }
}
