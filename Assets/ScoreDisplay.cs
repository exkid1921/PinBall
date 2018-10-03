using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {

    ScoreManager scoreManager;

    //オブジェクトに触れたか判定する値
    private int touchFlg = 0;

    //得点
    private int point = 0;

    //スコアを表示するテキスト
    private GameObject scoreText;

	// Use this for initialization
	void Start () {

        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>(); 

        //シーン中のScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");

        //タグによって得点を設定
        if (tag == "SmallStarTag")
        {
            this.point = 5;
        }
        else if (tag == "LargeStarTag")
        {
            this.point = 30;
        }
        else if (tag == "SmallCloudTag")
        {
            this.point = 20;
        }
        else if (tag == "LargeCloudTag")
        {
            this.point = 50;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (this.touchFlg > 0)
        {
            scoreManager.score += this.point;

            this.touchFlg = 0;
        }

        //ScoreTextにスコアを表示
        this.scoreText.GetComponent<Text>().text = "Score:    " + scoreManager.score;
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        this.touchFlg = 1;
        Debug.Log("aaaa");
    }

}

