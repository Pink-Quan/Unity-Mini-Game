using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame2GameManager : MonoBehaviour
{
    public static MiniGame2GameManager instance;
    private float score=0f;
    [SerializeField] private Text scoreText;
    private void Awake() 
    {
        instance=this;
    }
    void Update()
    {
        score+=Time.deltaTime;
        scoreText.text=$"{(int)score}";
    }

    public void eatGoodItem(float score)
    {
        this.score+=score;
    }
}
