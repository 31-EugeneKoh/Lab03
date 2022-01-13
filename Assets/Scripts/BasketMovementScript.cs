using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasketMovementScript : MonoBehaviour
{
    public float speed;
    private int healthyCount;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      float horizontalInput = Input.GetAxis("Horizontal");

      transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

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
            SceneManager.LoadScene("GamePlay_Level2");
        }
    }
}
