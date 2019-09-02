using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    //指のIDを初期化
    private int rightFingerId = 0;
    private int leftFingerId = 0;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {

        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }


        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.touches[i];

            // タッチした時
            if (touch.phase == TouchPhase.Began)
            {
                //画面の右半分がタッチされた時フリッパーを動かす
                if (touch.position.x > Screen.width * 0.5 && tag == "RightFripperTag")
                {
                    //押した指のIDを収納
                    this.rightFingerId = touch.fingerId;

                    SetAngle(this.flickAngle);
                }
                //画面の左半分がタッチされた時フリッパーを動かす
                if (touch.position.x < Screen.width * 0.5 && tag == "LeftFripperTag")
                {
                    //押した指のIDを収納
                    this.leftFingerId = touch.fingerId;

                    SetAngle(this.flickAngle);
                }
            }
            // 指を離した時
            if (touch.phase == TouchPhase.Ended)
            {
                //画面の右半分で押された指が離された時フリッパーを元に戻す
                if (touch.fingerId == this.rightFingerId && tag == "RightFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
                //画面の左半分で押された指が離された時フリッパーを元に戻す
                if (touch.fingerId == this.leftFingerId && tag == "LeftFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
            }
        }


    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
