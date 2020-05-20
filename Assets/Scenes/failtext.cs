using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[SerializeField]
public class failtext : InputChanged
{
    public Text texter;
   
  public void Update()
    {
        
        texter.text = failedcount.ToString();
        
    }
}
