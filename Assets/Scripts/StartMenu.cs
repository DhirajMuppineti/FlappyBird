using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenu : MonoBehaviour
{
    public TextMeshProUGUI Score, GameName, PlayBtn;
    public static bool isPaused = false;
    void Start(){
        if (Bird.score != 0)
        {
            Score.text = "You got " + Bird.score.ToString() + "!!";
        }
        if(isPaused){
            GameName.text = "Paused";
            PlayBtn.text = "Resume";
        }else{
            GameName.text = "Flappy Bird";
            PlayBtn.text = "Play";
            Bird.score = 0;
        }
        
    }
    public void Play(){
        SceneManager.LoadScene(1);
    }

    public void Quit(){
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
