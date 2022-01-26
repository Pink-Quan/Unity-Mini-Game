using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Text scoreText;
    [SerializeField] private float velocityKickTheBall;
    [SerializeField] private GameObject PlayerPosition, EnemyPosition;
    private Rigidbody2D ballRigidbody2D;
    private int playerScore = 0;
    private int enemyScore = 0;
    private Rigidbody2D velcityPlayer,velocityEnemy;
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        pauseButon.onClick.AddListener(Pause);
        continueButton.onClick.AddListener(Continue);
        newGameButton.onClick.AddListener(NewGame);
        WinLoseNewGameButton.onClick.AddListener(NewGame);
    }
    private void Start()
    {
        //pauseUI.SetActive(false);
        WinLoseCanvas.SetActive(false);
        Time.timeScale = 0;
        ballRigidbody2D = ball.transform.GetComponent<Rigidbody2D>();
        velocityEnemy=EnemyPosition.transform.GetComponent<Rigidbody2D>();
        velcityPlayer=PlayerPosition.transform.GetComponent<Rigidbody2D>();
    }
    ///<summary>
    ///true khi player có điểm, false khi enemy có điểm <br/>
    ///</summary>
    public void changeScore(bool isPlayerScore)
    {
        if (isPlayerScore)
        {
            playerScore++;
            StartCoroutine(NewTurn(true));
        }
        else
        {
            enemyScore++;
            StartCoroutine(NewTurn(false));
        }
        scoreText.text = $"{playerScore} - {enemyScore}";
    }
    /// <summary>
    /// Lượt bóng mới
    /// </summary>
    /// <param name="isPlayerWin"></param>
    /// <returns></returns>
    private IEnumerator NewTurn(bool isPlayerWin)
    {
        ballRigidbody2D.velocity = Vector2.zero;
        ball.transform.localPosition = Vector3.zero;
        ballRigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        PlayerPosition.transform.localPosition=new Vector3(-7,0,0); velcityPlayer.velocity = Vector2.zero;
        EnemyPosition.transform.localPosition = new Vector3(7, 0, 0); velocityEnemy.velocity = Vector2.zero;
        yield return new WaitForSeconds(1);
        ballRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        if (isPlayerWin)
        {
            ballRigidbody2D.velocity = velocityKickTheBall * Vector3.left;
        }
        else
        {
            ballRigidbody2D.velocity = velocityKickTheBall * Vector3.right;
        }
    }
    /// <summary>
    /// Game mới
    /// </summary>
    public void NewGame()
    {
        Debug.Log("New Game");
        playerScore = 0;
        enemyScore = 0;
        scoreText.text = "0 - 0";
        Time.timeScale = 1;
        pauseUI.SetActive(false);
        WinLoseCanvas.SetActive(false);
        //Continue();
        StartCoroutine(NewTurn(true));
    }
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button pauseButon,newGameButton;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
        if (playerScore == 5)
            isPlayerWinGame(true);
        if(enemyScore==5)
            isPlayerWinGame(false);
    }
    /// <summary>
    /// Dừng Game
    /// </summary>
    void Pause()
    {
        Debug.Log("Pause button");
        pauseUI.SetActive(true);
        Time.timeScale = 0;
    }    
    /// <summary>
    /// Tiếp tục game
    /// </summary>
    void Continue()
    {
        WinLoseCanvas.SetActive(false);
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }
    [SerializeField] private GameObject WinLoseCanvas;
    [SerializeField] private Button WinLoseNewGameButton;
    [SerializeField] private Text WinLoseText;
    private void isPlayerWinGame(bool isPlayerWin)
    {
        playerScore = 0;
        enemyScore = 0;
        Time.timeScale = 0;
        WinLoseCanvas.SetActive(true);
        if (isPlayerWin)
            WinLoseText.text = "You Win";
        else
            WinLoseText.text = "You Lose";
    }
}
