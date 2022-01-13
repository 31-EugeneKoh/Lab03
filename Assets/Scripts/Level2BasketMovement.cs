using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level2BasketMovement : MonoBehaviour
{
    public float speed;
    private int healthyCount;
    public Text scoreText;
    public Text timerText;
    private float elapsedGameTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

        SetTime();

        ItemsCollected();

        scoreText.text = "Score: " + healthyCount;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Unhealthy")
        {
            SceneManager.LoadScene("LoseScene");
        }

        if (other.gameObject.tag == "Healthy")
        {
            Destroy(other.gameObject);
            healthyCount++;
        }
    }

    void ItemsCollected()
    {
        if (healthyCount >= 5)
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    private void SetTimeText(float time)
    {
        timerText.text = "Time: " + FormatTime(time);
    }

    private string FormatTime(float time)
    {
        int intTime = (int)time;
        int minutes = intTime / 60;
        int seconds = intTime % 60;
        float fraction = time * 1000;
        fraction = (fraction % 1000);
        string timeText = System.String.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
        return timeText;
    }

    void SetTime()
    {
        elapsedGameTime += Time.deltaTime;
        SetTimeText(elapsedGameTime);
    }
}
