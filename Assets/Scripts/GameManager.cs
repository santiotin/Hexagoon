using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject scoreText;
    public GameObject player;
    public GameObject spawner;
    public GameObject highScoreText;
    public GameObject titleText;
    public GameObject endMenu;
    bool started = false;
    int score = 0;
    float highScore;
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetFloat("highscore", 0);
        highScoreText.GetComponent<Text>().text = "Highscore: " + highScore.ToString();
    }
    

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<Text>().text = score.ToString();
    }

    public void startGame() {
        started = true;
        spawner.GetComponent<Spawner>().generateHexa(true);
        player.GetComponent<PlayerMov>().startMove();
        StartCoroutine(FadeTextToFullAlpha(1f, scoreText.GetComponent<Text>()));
        StartCoroutine(FadeTextToZeroAlpha(1f, playButton.transform.GetChild(0).gameObject.GetComponent<Text>()));
        StartCoroutine(FadeTextToZeroAlpha(1f, highScoreText.GetComponent<Text>()));
        StartCoroutine(FadeTextToZeroAlpha(1f, titleText.GetComponent<Text>()));
    }

    public void endGame() {
        started = false;
        spawner.GetComponent<Spawner>().generateHexa(false);
        //StartCoroutine(changeScene(0));
        endMenu.SetActive(true);
        if(score > highScore) {
            PlayerPrefs.SetFloat("highscore", score);
            highScore = score;
        }
    }

    void endPanel() {

    }

    public bool hasStarted() {
        return started;
    }
    
    public void incrementScore() {
        if(started) score++;
    }

    IEnumerator FadeTextToZeroAlpha(float t, Text i) {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
        playButton.SetActive(false);
    }

    IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    IEnumerator changeScene(int sceneNum) {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene(sceneNum);
    }
}
