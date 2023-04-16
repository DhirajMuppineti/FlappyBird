using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Bird : MonoBehaviour
{
    Rigidbody2D rb;

    private float jumpSpeed = 8f;
    public GameObject pipePrefab;
    private float respawnTime = 3f;
    private Vector2 screenBounds;
    public static int score = 0;
    public TextMeshProUGUI Score;
    public static bool gameOver = false;
    void Start()
    {
        if(!StartMenu.isPaused){
            gameOver = false;
            rb = GetComponent<Rigidbody2D>();
            screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            StartCoroutine(pipeWave());
        }else{
            StartMenu.isPaused = false;
        }
       
    }

    void Update()
    {
        score += (int)Mathf.Pow(2, 10 * Time.deltaTime);
        if (!gameOver)
            Score.text = score.ToString();
        else{
            SceneManager.LoadScene(0);
        }

        if (Input.GetMouseButtonDown(0))
            rb.velocity = Vector2.up * (jumpSpeed);

        if (score != 0 && score % 5000 == 0){
            Pipe.speed *= 1.25f;
            BackgroundScrolling.xVel *= 1.25f;
        }
            

        if (score != 0 && score % 7500 == 0 && respawnTime != 1)
            respawnTime -= 1;
    }

    public void Paused(){
        StartMenu.isPaused = true;
        SceneManager.LoadScene(0);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        gameOver = true;
    }


    private void spawnEnemy()
    {
        GameObject a = Instantiate(pipePrefab);
        a.transform.position = new Vector2(screenBounds.x, Random.Range(-screenBounds.y, 0));
    }
    IEnumerator pipeWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }

}
