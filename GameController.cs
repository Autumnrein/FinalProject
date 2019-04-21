using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
  


    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text WinText;
    public Text hardModeText;
    public Text normalText;
    public Text hardlevelText;

    public int score;
    public AudioClip musicClipOne;

    public AudioClip musicClipTwo;

    public AudioSource musicSource;

    private bool gameOver;
    private bool restart;
    private bool hardMode;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        hardModeText.text = "";
        WinText.text = "";
        normalText.text = "";
        hardlevelText.text = "";
        score = 0;
        UpdateScore();
        

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            hardMode = false;
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            hardMode = true;
        }

        StartCoroutine(SpawnWaves());

        //Debug.Log("Hard Mode is " + hardMode);

    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                SceneManager.LoadScene(1);
            }
        }
        if (Input.GetKey("escape"))
            Application.Quit();
    }
    


IEnumerator SpawnWaves()
{
    // Debug.Log("Hard Mode is " + hardMode);
    if (hardMode == false)
    {
            normalText.text = "NORMAL MODE";
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'N' for Normal Mode";
                hardModeText.text = "Press 'H' for Hard Mode";
                restart = true;
                break;
            }
            
        }
    }
    if (hardMode == true)
    {
            hardlevelText.text = "HARD MODE";
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);

                if (gameOver)
                {
                    restartText.text = "Press 'N' for Normal Mode";
                    hardModeText.text = "Press 'H' for Hard Mode";
                    restart = true;
                    break;
                }
               
            }
        }
    }
}
public void AddScore(int newScoreValue)
{
    score += newScoreValue;
    UpdateScore();
}


void UpdateScore()
{
    scoreText.text = "Points: " + score;
    {
        scoreText.text = "Points: " + score;
        if (score >= 100)
        {
            WinText.text = "You Win! Created By Autumn Knox";
            gameOver = true;
            restart = true;
                musicSource.clip = musicClipOne;
                musicSource.Play();
        }
    }
}

public void GameOver()
{
    gameOverText.text = "Game Over!";
    gameOver = true;
        musicSource.clip = musicClipTwo;
        musicSource.Play();
    }
}


