using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    public void ChangeScenetomenu(string level)
    {

        SceneManager.LoadScene(level);
        
      
    }
}
