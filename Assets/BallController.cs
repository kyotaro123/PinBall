using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //得点を表示するテキスト
    private GameObject scoreText;
    //得点を初期化
    private int score = 0;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーン中のScoreTExtオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }

        //ScoreTextに得点を表示
        this.scoreText.GetComponent<Text>().text = "Score:" + score.ToString();
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "SmallStarTag")
        {
            score += 10;
        }else if (col.gameObject.tag == "LargeStarTag")
        {
            score += 50;
        }else if (col.gameObject.tag == "SmallCloudTag")
        {
            score += 100;
        }else if (col.gameObject.tag == "LargeCloudTag")
        {
            score += 1000;
        }
    }
}