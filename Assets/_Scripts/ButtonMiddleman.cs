using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMiddleman : MonoBehaviour
{
    //A middleman for the buttons so they can interact with the SceneLoader singelton.
    public void Play(int index){
        FindObjectOfType<SceneLoader>().LoadScene(index);

    } 

    public void Quit(){
        FindObjectOfType<SceneLoader>().Quit();
    } 
}
