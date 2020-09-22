using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;//引入UI，记录分数

public class GameControl : MonoBehaviour
{
    public static GameControl instance; //强制对象为单例模式,允许它从我们的任何其它脚本中访问
    public GameObject GameOverText;
    public bool GameOver = false;
    public float scrollSpeed = -1.5f;
    public Text scoreText;

    private int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this; //当初始化时，确保没有其它gamecontrol
        }
        else if (instance != this)
        {
            Destroy (gameObject);//意味着破坏此脚本所附加的游戏对象
        }
    }

    void Update()
    {
        if (GameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);//加载一个场景文件
        }
    }

    public void BirdScored ()
    {
        if (GameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Score: " + score.ToString ();
    }

    public void BirdDied()
    {
        GameOverText.SetActive (true);
        GameOver = true;
    }
}
