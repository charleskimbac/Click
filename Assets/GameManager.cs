using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public float spawnRate = 1f;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool gameActive;
    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        addScore(0);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        gameActive = true;
        StartCoroutine(spawnTarget());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnTarget() {
        while (gameActive) {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void addScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void gameOver() {
        gameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
