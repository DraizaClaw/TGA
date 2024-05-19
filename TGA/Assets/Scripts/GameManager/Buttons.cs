using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    //Button scripts

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
    
    public void Quit()
    {//-------------------------------------------BE SURE TO MAYBE FIX THIS BEFORE PUBLISHING--------------------------------------------------------------
        if (UnityEditor.EditorApplication.isPlaying == true)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }







}
