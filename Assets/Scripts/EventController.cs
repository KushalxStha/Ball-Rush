using TMPro;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public AudioSource collectibleSound;
    public AudioSource deadSound;
    public AudioSource completeSound;

    private int totalCollectibles;
    private int coin = 0;

    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;

    private void Start()
    {
        totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
        gameOverPanel.SetActive(false);
        levelCompletePanel.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            Debug.Log("+1 coin " + coin);
            collectibleSound.Play();

            coin++;
            if (coin == totalCollectibles) Debug.Log("Perfect! All coins collected!");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            deadSound.Play();
            ShowGameOverPanel();
            Destroy(gameObject);
            Debug.Log("Player is Destroyed! Game Over! \nTotal Coins Collected: " + coin);
            Time.timeScale = 0f;
        }

        if (collision.gameObject.CompareTag("CompleteWall"))
        {
            completeSound.Play();
            ShowLevelCompletePanel();
            Debug.Log("Game Completed! \nTotal Coins Collected: " + coin);
            Time.timeScale = 0f;
        }
    }

    void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; 
    }

    void ShowLevelCompletePanel()
    {
        levelCompletePanel.SetActive(true);
        Time.timeScale = 0f; 
    }
}
