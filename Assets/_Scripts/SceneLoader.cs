using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float transitionTime;
    [SerializeField] Image transition;
    bool transitioning;

    void Awake()
    {
        //Very simple singleton logic.
        DontDestroyOnLoad(gameObject);
        if(FindObjectsOfType<SceneLoader>().Length > 1){
            Destroy(gameObject);
        }
    }

    public void Quit()
    {
        Application.Quit();
        print("Quitted Application");
    }

    public void LoadScene(int index)
    {
        if(!transitioning)StartCoroutine(Transition(index));
    }

    IEnumerator Transition(int index){
        //Transition to another scene.

        transitioning = true;

        float startTime = Time.time;

        //Fade in
        while(Time.time < startTime + transitionTime){
            float t = Mathf.InverseLerp(startTime, startTime + transitionTime, Time.time);

            transition.color = new Color(0, 0, 0, t);
            yield return null;
        }
        
        //Swap Scene
        SceneManager.LoadScene(index);

        //Fade Out
        startTime = Time.time;
        while(Time.time < startTime + transitionTime){
            float t = 1 - Mathf.InverseLerp(startTime, startTime + transitionTime, Time.time);

            transition.color = new Color(0, 0, 0, t);
            yield return null;
        }
        transitioning = false;
    }
}
