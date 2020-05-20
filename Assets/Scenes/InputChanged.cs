using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class InputChanged : PlayScript
{

    public InputField inputF;
    public InputField inputscroll;

    List<string> wordlist = new List<string>();
    List<string> reversewordlist = new List<string>();
   
    int lastarri = 0;
    int lastarrj = 0;
    int nextarri = 0;
    int nextarrj = 0;
    int n = 7;
    int x = 0;
 
   
    int wasarri = 0;
    int wasarrj = 0;
   
    int count2 = 0;
    int countrange = 0;
    public static int failedcount=0;
    int wincount=0;
    string washere = "";
    string way = "";
   
    string word = "";
    string reverseword = "";
    string currentword = "";
   
    string finalword = "";
    string lastword = "";
 
   
    bool wordfound=false;

 
    public void ValueChanged()
    {

        if (inputF.text != "")
        {


            string fieldname = inputF.name;
            int index = 0;
            int c = 0;
            index = System.Convert.ToInt32(fieldname.Remove(0, 6));
            Debug.Log("Value Changed in " + inputF.name + " changed to " + inputF.text);
            inputF.interactable = false;
            for (int i = 0; 5 > i; i++)
            {
                for (int j = 0; 7 > j; j++)
                {
                    c++;
                    if (c == index)
                    {
                      

                        n++;
                        way = "";
                        lastarri = i;
                        lastarrj = j;
                        nextarri = lastarri;
                        nextarrj = lastarrj;
                        arrIF[i, j] = inputF;
                        lastword = arrIF[i, j].text;
                        FindWord();
                        WordInit();
                       
                    }


                }

            }
           
         
        }
        

    }
  
    public void LeftWay()
    {

        word = string.Concat(word, arrIF[nextarri, nextarrj - 1].text);

        nextarrj = nextarrj - 1;
        Debug.Log("go to left");
        if (washere.Contains("arrIF[" + nextarri + ", " + nextarrj + "]"))
        {

            word = "";
            Debug.Log("crossing washere");
            return;
        }

        word = word.ToLower();

        wordlist.Add(word);
        ReverseWord();


    }

    public void RightWay()
    {

        word = string.Concat(word, arrIF[nextarri, nextarrj + 1].text);

        nextarrj = nextarrj + 1;
        Debug.Log("go to right");
        if (washere.Contains("arrIF[" + nextarri + ", " + nextarrj + "]"))
        {

            word = "";
            Debug.Log("crossing washere");
            return;
        }
        word = word.ToLower();

        wordlist.Add(word);
        ReverseWord();
    }
    public void DownWay()
    {

        word = string.Concat(word, arrIF[nextarri + 1, nextarrj].text);
        nextarri = nextarri + 1;

        Debug.Log("go to down");
        if (washere.Contains("arrIF[" + nextarri + ", " + nextarrj + "]"))
        {

            word = "";
            Debug.Log("crossing washere");
            return;
        }
        word = word.ToLower();

        wordlist.Add(word);
        ReverseWord();

    }
    public void UpWay()
    {

        word = string.Concat(word, arrIF[nextarri - 1, nextarrj].text);
        nextarri = nextarri - 1;

        Debug.Log("go to up");
        if (washere.Contains("arrIF[" + nextarri + ", " + nextarrj + "]"))
        {

            word = "";
            Debug.Log("crossing washere");
            return;
        }
        word = word.ToLower();

        wordlist.Add(word);
        ReverseWord();
    }
    public void UpRightWay()
    {

        word = string.Concat(word, arrIF[nextarri - 1, nextarrj+1].text);
        nextarri = nextarri - 1;
        nextarrj = nextarrj +1;
        Debug.Log("go to up and right");
        if (washere.Contains("arrIF[" + nextarri + ", " + nextarrj + "]"))
        {

            word = "";
            Debug.Log("crossing washere");
            return;
        }
        word = word.ToLower();

        wordlist.Add(word);
        ReverseWord();
    }
    public void UpLeftWay()
    {
        Debug.Log("godds");
        word = string.Concat(word, arrIF[nextarri - 1, nextarrj-1].text);
        nextarri = nextarri - 1;
        nextarrj = nextarrj - 1;
        Debug.Log("go to up and left");
        if (washere.Contains("arrIF[" + nextarri + ", " + nextarrj + "]"))
        {

            word = "";
            Debug.Log("crossing washere");
            return;
        }
        word = word.ToLower();

        wordlist.Add(word);
        ReverseWord();
    }
    public void DownRightWay()
    {

        word = string.Concat(word, arrIF[nextarri +1, nextarrj+1].text);
        nextarri = nextarri + 1;
        nextarrj = nextarrj + 1;
        Debug.Log("go to up and right");
        if (washere.Contains("arrIF[" + nextarri + ", " + nextarrj + "]"))
        {

            word = "";
            Debug.Log("crossing washere");
            return;
        }
        word = word.ToLower();

        wordlist.Add(word);
        ReverseWord();
    }
    public void DownLeftWay()
    {

        word = string.Concat(word, arrIF[nextarri +1, nextarrj-1].text);
        nextarri = nextarri + 1;
        nextarrj = nextarrj - 1;
        Debug.Log("go to up and left");
        if (washere.Contains("arrIF[" + nextarri + ", " + nextarrj + "]"))
        {

            word = "";
            Debug.Log("crossing washere");
            return;
        }
        word = word.ToLower();

        wordlist.Add(word);
        ReverseWord();
    }
    public void WordInit()
    {

        Debug.Log("Word Init...");

       string path = Application.streamingAssetsPath + "/dictionary.txt";
        Debug.Log("path " + path);
        string[] readText = File.ReadAllLines(path);
     
        foreach (string word in wordlist)
        {
            Debug.Log("in wordlist " + word);

        }
        foreach (string word in reversewordlist)
        {
            Debug.Log("in revwordlist " + word);

        }
  
        wordfound = false;

        foreach (string word in wordlist)
        {
            count2 = 0;

            foreach (string s in readText)
            {
               

                if (word.Contains(s) && word != "")
                {

                        if (blockedword.Contains(s))
                        {
                            Debug.Log("Word in blockedlist");
                            break;
                        }
                    
                        wordfound = true;
                        finalword = s;
                    blockedword += finalword+" ";
                        Debug.Log("Word Found");
                        goto Finish;
                    
                }

                else
                {

                    count2++;
                }

            }

        }
        
        foreach (string reverseword in reversewordlist)
        {
            count2 = 0;
            foreach (string s in readText)
            {
           
                if (reverseword.Contains(s) && reverseword != "")
                {

                  
                        if (blockedword.Contains(s))
                        {
                            Debug.Log("Word in blockedlist");
                            break;
                        }

                    
                        wordfound = true;
                        finalword = s;
                    blockedword += finalword+" ";
                    Debug.Log("Word Found");
                        goto Finish;

                    

                }
                else
                {
               

                    count2++;

                }
            }

        }
    Finish:
       
        Debug.Log("in blockedwordlist " + blockedword);

     
        if (wordfound == true)
        {
            wincount++;
            if (wincount == 35)
            {
                wincount = 0;
                failedcount = 0;
                blockedword = "";
                word = "";
                washere = "";
                SceneManager.LoadScene(3);
            }
            Debug.Log("word in dictionary: " + count2 + " Word that accepted: " + finalword);
            textScroll.finish = "word in dictionary: " + count2 + "Word that accepted: " + finalword + System.Environment.NewLine;
            Text texting = inputscroll.transform.Find("Text").GetComponent<Text>();
            texting.color = Color.green;
            
            inputscroll.text += textScroll.finish;
        }
        else
        {
            wincount++;
            failedcount++;
           
            if (failedcount == 7)
            {
                wincount = 0;
                failedcount = 0;
                blockedword = "";
                word = "";
                washere = "";
                SceneManager.LoadScene(2);
            }
            Debug.Log("Word not found");
            textScroll.finish = ("Word not found") + System.Environment.NewLine;
            Text texting = inputscroll.transform.Find("Text").GetComponent<Text>();
            texting.color = Color.red;
            
            inputscroll.text += textScroll.finish;
        }
       
        word = "";
        currentword = "";
        wordlist.Clear();
        reversewordlist.Clear();
    
    }

    public void BlockingWay()
    {
        if (nextarrj - 1 < 0) //blocking
        {
            countrange++;
            if (countrange == 8)
            {
                way = "";
            }
            way += "left";
            way += "upleft";
            way += "downleft";
            Debug.Log("left way blocked");
        }
        if (nextarrj + 1 >= 7)
        {
            countrange++;
            if (countrange == 8)
            {
                way = "";
            }
            way += "right";
            way += "upright";
            way += "downright";
            Debug.Log("right way blocked");
        }
        if (nextarri - 1 < 0)
        {
            countrange++;
            if (countrange == 8)
            {
                way = "";
            }
            way += "up";
            way += "upright";
            way += "upleft";
            Debug.Log("up way blocked");
        }
        if (nextarri + 1 >= 5)
        {
            countrange++;
            if (countrange == 8)
            {
                way = "";
            }
            way += "down";
            way += "downleft";
            way += "downright";
            Debug.Log("down way blocked");
        }
     

        countrange = 0;
    }
    public void ReverseWord()
    {
        reverseword = "";
        char[] cArray = word.ToCharArray();
        for (int i = cArray.Length - 1; i > -1; i--) //reverse word
        {
            reverseword += cArray[i];
        }

        reverseword = reverseword.ToLower();
        reversewordlist.Add(reverseword);
        Array.Clear(cArray, 0, cArray.Length);


    }
    public void WordCurrent()
    {
        word = "";
        char[] cArray = currentword.ToCharArray();
        for (int i = 0; i < cArray.Length; i++)
        {
            word += cArray[i];
        }

        word = word.ToLower();
        wordlist.Add(word);
        Array.Clear(cArray, 0, cArray.Length);


    }

    public void FindWord()
    {
        
        x = 0;
        Debug.Log("Check values");
        for (int i = 0; 5 > i; i++)
        {
            for (int j = 0; 7 > j; j++)
            {
                x++;
                Debug.Log("In WordInit arrIF field " + x + " and variable " + arrIF[i, j].text);
            }
        }
     
        Debug.Log("Finding word...");
        wasarri = nextarri;
        wasarrj = nextarrj;

        word = "";
        word += lastword;
        nextarri = wasarri;
        nextarrj = wasarrj;
        washere = "";
        Debug.Log("Multiway:left");
            for (int a = 0; a < n; a++)
            {

                BlockingWay();
                if ((!way.Contains("left")) && (arrIF[nextarri, nextarrj - 1].text != ""))
                { LeftWay(); }
                else if ((!way.Contains("right")) && (arrIF[nextarri, nextarrj + 1].text != ""))
                { RightWay(); }
                else if ((!way.Contains("up")) && (arrIF[nextarri - 1, nextarrj].text != ""))
                { UpWay(); }
                else if ((!way.Contains("down")) && (arrIF[nextarri + 1, nextarrj].text != ""))
                { DownWay(); }
            else if ((!way.Contains("upleft")) && (arrIF[nextarri - 1, nextarrj - 1].text != ""))
            { UpLeftWay(); }
            else if ((!way.Contains("downleft")) && (arrIF[nextarri + 1, nextarrj - 1].text != ""))
            { DownLeftWay(); }
            else if ((!way.Contains("upright")) && (arrIF[nextarri -1, nextarrj + 1].text != ""))
            { UpRightWay(); }
        
            else if ((!way.Contains("downright")) && (arrIF[nextarri + 1, nextarrj+1].text != ""))
            { DownRightWay(); }



            if (washere.Contains("arrIF[" + nextarri + ", " + nextarrj + "]"))
                {
                    Debug.Log("washere in multifind");
                    a = n;
                    continue;
                }
                washere += "arrIF[" + nextarri + ", " + nextarrj + "] ";
                Debug.Log("way " + way);
                Debug.Log("word " + word);
                Debug.Log("washere " + washere);
                Debug.Log("next (route) " + nextarri + " " + nextarrj);




            }

        word = "";
        word += lastword;
        nextarri = wasarri;
        nextarrj = wasarrj;
        washere = "";
        Debug.Log("Multiway:right");
            for (int r = 0; r < n; r++)
            {
          
            BlockingWay();
                if ((!way.Contains("right")) && (arrIF[nextarri, nextarrj + 1].text != ""))
                {
                    RightWay();

                }
                else if ((!way.Contains("left")) && (arrIF[nextarri, nextarrj - 1].text != ""))
                {
                    LeftWay();

                }
                else if ((!way.Contains("down")) && (arrIF[nextarri + 1, nextarrj].text != ""))
                {
                    DownWay();

                }
                else if ((!way.Contains("up")) && (arrIF[nextarri - 1, nextarrj].text != ""))
                {
                    UpWay();

                }
            else if ((!way.Contains("downright")) && (arrIF[nextarri + 1, nextarrj + 1].text != ""))
            { DownRightWay(); }
            else if ((!way.Contains("upright")) && (arrIF[nextarri - 1, nextarrj + 1].text != ""))
            { UpRightWay(); }
            else if ((!way.Contains("upleft")) && (arrIF[nextarri - 1, nextarrj - 1].text != ""))
            { UpLeftWay(); }
      
            else if ((!way.Contains("downleft")) && (arrIF[nextarri + 1, nextarrj - 1].text != ""))
            { DownLeftWay(); }
           

            if (washere.Contains("arrIF[" + nextarri + ", " + nextarrj + "]"))
                {
                    Debug.Log("washere in multifind");
                    r = n;
                    Debug.Log("way " + way);
                    Debug.Log("word " + word);
                    Debug.Log("washere " + washere);
                    Debug.Log("next (route) " + nextarri + " " + nextarrj);
                    break;
                }
                washere += "arrIF[" + nextarri + ", " + nextarrj + "] ";

                Debug.Log("way " + way);
                Debug.Log("word " + word);
                Debug.Log("washere " + washere);
                Debug.Log("next (route) " + nextarri + " " + nextarrj);





            }
        word = "";
        word += lastword;
        nextarri = wasarri;
        nextarrj = wasarrj;
        washere = "";
        Debug.Log("Multiway:down");
            for (int dl = 0; dl < n; dl++)
            {
            

                BlockingWay();
                if ((!way.Contains("down")) && (arrIF[nextarri + 1, nextarrj].text != ""))
                {
                    DownWay();

                }
                else if ((!way.Contains("left")) && (arrIF[nextarri, nextarrj - 1].text != ""))
                {
                    LeftWay();

                }
                else if ((!way.Contains("right")) && (arrIF[nextarri, nextarrj + 1].text != ""))
                {
                    RightWay();

                }
            else if ((!way.Contains("downright")) && (arrIF[nextarri + 1, nextarrj + 1].text != ""))
            { DownRightWay(); }
            else if ((!way.Contains("downleft")) && (arrIF[nextarri + 1, nextarrj - 1].text != ""))
            { DownLeftWay(); }
            else if ((!way.Contains("upright")) && (arrIF[nextarri - 1, nextarrj + 1].text != ""))
            { UpRightWay(); }
            else if ((!way.Contains("upleft")) && (arrIF[nextarri - 1, nextarrj - 1].text != ""))
            { UpLeftWay(); }

           

            if (washere.Contains("arrIF[" + nextarri + ", " + nextarrj + "]"))
                {
                    Debug.Log("washere in multifind");
                    dl = n;
                    Debug.Log("way " + way);
                    Debug.Log("word " + word);
                    Debug.Log("washere " + washere);
                    Debug.Log("next (route) " + nextarri + " " + nextarrj);
                    continue;
                }
                washere += "arrIF[" + nextarri + ", " + nextarrj + "] ";
               
                Debug.Log("way " + way);
                Debug.Log("word " + word);
                Debug.Log("washere " + washere);
                Debug.Log("next (route) " + nextarri + " " + nextarrj);
            }


        word = "";
        word += lastword;
        nextarri = wasarri;
        nextarrj = wasarrj;
        washere = "";
        for (int dr = 0; dr < n; dr++)
            {
          

          
            BlockingWay();
                if ((!way.Contains("down")) && (arrIF[nextarri + 1, nextarrj].text != ""))
                {
                    DownWay();

                }
                else if ((!way.Contains("right")) && (arrIF[nextarri, nextarrj + 1].text != ""))
                {
                    RightWay();

                }
                else if ((!way.Contains("left")) && (arrIF[nextarri, nextarrj - 1].text != ""))
                {
                    LeftWay();

                }
       
            else if ((!way.Contains("upright")) && (arrIF[nextarri - 1, nextarrj + 1].text != ""))
            { UpRightWay(); }
            else if ((!way.Contains("upleft")) && (arrIF[nextarri - 1, nextarrj - 1].text != ""))
            { UpLeftWay(); }
            else if ((!way.Contains("downright")) && (arrIF[nextarri + 1, nextarrj + 1].text != ""))
            { DownRightWay(); }
            else if ((!way.Contains("downleft")) && (arrIF[nextarri + 1, nextarrj - 1].text != ""))
            { DownLeftWay(); }



            if (washere.Contains("arrIF[" + nextarri + ", " + nextarrj + "]"))
                {
                    Debug.Log("washere in multifind");
                    dr = n;
                    Debug.Log("way " + way);
                    Debug.Log("word " + word);
                    Debug.Log("washere " + washere);
                    Debug.Log("next (route) " + nextarri + " " + nextarrj);
                    continue;
                }
                washere += "arrIF[" + nextarri + ", " + nextarrj + "] ";
            
                Debug.Log("way " + way);
                Debug.Log("word " + word);
                Debug.Log("washere " + washere);
                Debug.Log("next (route) " + nextarri + " " + nextarrj);
            }
        word = "";
        word += lastword;
        nextarri = wasarri;
        nextarrj = wasarrj;
        washere = "";
        Debug.Log("Multiway:up");
            for (int ul = 0; ul < n; ul++)
            {
            BlockingWay();
                if ((!way.Contains("up")) && (arrIF[nextarri - 1, nextarrj].text != ""))
                {
                    UpWay();

                }
                else if ((!way.Contains("left")) && (arrIF[nextarri, nextarrj - 1].text != ""))
                {
                    LeftWay();

                }
                else if ((!way.Contains("right")) && (arrIF[nextarri, nextarrj + 1].text != ""))
                {
                    RightWay();

                }
                else if ((!way.Contains("down")) && (arrIF[nextarri + 1, nextarrj].text != ""))
                {
                    DownWay();

                }
       
                if (washere.Contains("arrIF[" + nextarri + ", " + nextarrj + "]"))
                {
                    Debug.Log("washere in multifind");
                    ul = n;
                    Debug.Log("way " + way);
                    Debug.Log("word " + word);
                    Debug.Log("washere " + washere);
                    Debug.Log("next (route) " + nextarri + " " + nextarrj);
                   continue;
                }
                washere += "arrIF[" + nextarri + ", " + nextarrj + "] ";

            Debug.Log("way " + way);
            Debug.Log("word " + word);
            Debug.Log("washere " + washere);
            Debug.Log("next (route) " + nextarri + " " + nextarrj);

            word = "";
            word += lastword;
            nextarri = wasarri;
            nextarrj = wasarrj;
            washere = "";
            for (int ur = 0; ur < n; ur++)
            {
             
                BlockingWay();
                    if ((!way.Contains("up")) && (arrIF[nextarri - 1, nextarrj].text != ""))
                    {
                        UpWay();

                    }
                    else if ((!way.Contains("right")) && (arrIF[nextarri, nextarrj + 1].text != ""))
                    {
                        RightWay();

                    }
                    else if ((!way.Contains("left")) && (arrIF[nextarri, nextarrj - 1].text != ""))
                    {
                        LeftWay();

                    }

                    else if ((!way.Contains("down")) && (arrIF[nextarri + 1, nextarrj].text != ""))
                    {
                        DownWay();

                    }
              
                    if (washere.Contains("arrIF[" + nextarri + ", " + nextarrj + "]"))
                    {
                        Debug.Log("washere in multifind");
                        ur = n;
                        Debug.Log("way " + way);
                        Debug.Log("word " + word);
                        Debug.Log("washere " + washere);
                        Debug.Log("next (route) " + nextarri + " " + nextarrj);
                        continue;
                    }

                    washere += "arrIF[" + nextarri + ", " + nextarrj + "] ";


                    Debug.Log("way " + way);
                    Debug.Log("word " + word);
                    Debug.Log("washere " + washere);
                    Debug.Log("next (route) " + nextarri + " " + nextarrj);
                }
               
            }






    }

}
           
        
      
    
    

