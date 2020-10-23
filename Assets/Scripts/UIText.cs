using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    public Text livesText;
    private GameObject gameManager;
    private int lives;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = this.gameObject;
        lives = gameManager.GetComponent<GameManager>().lives;
    }

    // Update is called once per frame
    void Update()
    {
        lives = gameManager.GetComponent<GameManager>().lives;
        livesText.text = "Lives = " + lives;
    }
}
