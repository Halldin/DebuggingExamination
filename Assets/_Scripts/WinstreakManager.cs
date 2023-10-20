using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinstreakManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winStreakText;
    [SerializeField] int gameSceneIndex;
    float winStreak;
    void Awake()
    {
        //Very simple singleton logic.
        DontDestroyOnLoad(gameObject);
        if(FindObjectsOfType<WinstreakManager>().Length > 1){
            Destroy(gameObject);
        }
    }

    void Update(){
        //Activate UI when in the game scene.
        winStreakText.enabled = SceneManager.GetActiveScene().buildIndex == gameSceneIndex;
    }

    public void Win(){
        //Update win streak and UI, and reload the scene.

        winStreak++;
        winStreakText.text = "Win Streak: " + winStreak.ToString();

        if(FindObjectOfType<SceneLoader>() != null){
            FindObjectOfType<SceneLoader>().LoadScene(1);
        }else{
            print("Singleton not detected! Play from Main Menu.");
        }
    }

    public void Lose(){
        //Reset win streak, update UI, and load Main Menu.

        winStreak = 0;
        winStreakText.text = "Win Streak: " + winStreak.ToString();

        if(FindObjectOfType<SceneLoader>() != null){
            FindObjectOfType<SceneLoader>().LoadScene(0);
        }else{
            print("Singleton not detected! Play from Main Menu.");
        }
    }
}
