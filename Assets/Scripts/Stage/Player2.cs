using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2: MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("ステータス画面オブジェクト")] public GameObject battleView;
    //★ データベースで管理する
    [Header("自HP")] public int pHP;
    [Header("自ATK")] public int pATK;
    [Header("自DEF")] public int pDEF;
    // ★ データベースから敵の種類を取得して表示する
    [Header("敵HP")] public int eHP;
    [Header("敵ATK")] public int eATK;
    [Header("敵DEF")] public int eDEF;
    #endregion

    #region//プライベート変数
    private Animator anim = null;           //Animator変数を宣言
    private Rigidbody2D rb = null;

    private bool isSide = false;            //アニメーション設定用フラグ
    private bool isUp = false;
    private bool isDown = false;
    private bool isWalk = false;
    private string enemyTag = "Enemy";         //接敵判定タグ
    private bool isStatus = false;             //ステータスを表示するかどうかフラグ

    //★ 別のスクリプトで管理すべき
    private bool isSubmit = false;          //決定ボタン押下中フラグ
    private bool isCancel = false;          //キャンセルボタン押下中フラグ
    private bool isPunching = false;        //バトル中フラグ
    private cData Player;                   //ステータス格納
    private cData Enemy;

    private GameObject PlayerStatus;
    private GameObject EnemyStatus;
    //2021/09/26 追記
    //★ ButtomPlayer と Playerをマージ
    private string itemTag = "Item";    //アイテムと接触した時にアイテムを回収する用
    #endregion

    public class cData
    {
        public int sHP;
        public int sATK;
        public int sDEF;
    }

    void Start()
    {
        anim = GetComponent<Animator>();    //Animatorインスタンスを生成、後でアタッチ
        rb = GetComponent<Rigidbody2D>();

        //★ 後でステータスを取得する記述
        Player = new cData() { sHP = this.pHP, sATK = this.pATK, sDEF = this.pDEF };
        Enemy = new cData() { sHP = this.eHP, sATK = this.eATK, sDEF = this.eDEF };

        PlayerStatus = GameObject.Find("PlayerStatus");
        EnemyStatus = GameObject.Find("EnemyStatus");
    }

    void FixedUpdate()
    {
        //各種座標軸の速度を求める
        float xSpeed = GetXSpeed();
        float ySpeed = GetYSpeed();

        //アニメーションを適用
        SetAnimation();

        //移動速度を設定
        rb.velocity = new Vector2(xSpeed, ySpeed);

        //ステータス表示設定
        if (isStatus == true)
        {
            //ステータスのオブジェクトをenabledにする
            battleView.SetActive(true);
            Battle();
        }
        else
        {
            battleView.SetActive(false);
        }
    }

    /// <summary>
    /// X成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>X軸の速さ</returns>
    private float GetXSpeed()
    {

        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;

        if (horizontalKey > 0)       //右方向
        {
            transform.localScale = new Vector3(1, 1, 1);
            isSide = true;
            xSpeed = speed;
        }
        else if (horizontalKey < 0)  //左方向
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isSide = true;
            xSpeed = -speed;
        }
        else
        {
            isSide = false;
            xSpeed = 0.0f;
        }

        return xSpeed;
    }

    /// <summary>
    /// Y成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>Y軸の速さ</returns>
    private float GetYSpeed()
    {

        float verticalKey = Input.GetAxis("Vertical");
        float ySpeed = 0.0f;

        if (verticalKey > 0)        //上方向
        {
            isUp = true;
            isDown = false;
            ySpeed = speed;
        }
        else if (verticalKey < 0)   //下方向
        {
            isUp = false;
            isDown = true;
            ySpeed = -speed;
        }
        else
        {
            isUp = false;
            isDown = false;
            ySpeed = 0.0f;
        }

        return ySpeed;
    }


    /// <summary>
    /// アニメーションを設定する
    /// </summary>
    private void SetAnimation()
    {
        float horizontalKey = Input.GetAxis("Horizontal");

        float verticalKey = Input.GetAxis("Vertical");

        if ((horizontalKey != 0) || (verticalKey != 0))    //移動中の処理
        {
            isWalk = true;
        }
        else                                                //停止中の処理
        {
            isWalk = false;
        }

        anim.SetBool("side", isSide);
        anim.SetBool("up", isUp);
        anim.SetBool("down", isDown);
        anim.SetBool("walk", isWalk);
    }

    #region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            //Debug.Log("敵と接触した！");
            isStatus = true;
        }
        //2021/09/26 追記
        //★ ButtomPlayer と Playerをマージ
        if (collision.collider.tag == itemTag)
        {
            Debug.Log("アイテムと接触した！");
            //ここで、SaveDataに

            //★アイテムが消えるという動作はアイテム自身にやってもらう
            ObjectCollision o = collision.gameObject.GetComponent<ObjectCollision>();

            if (o != null)
            {
                //★臨時
                //saveDataに直接記入する
                GameObject.FindWithTag("GameManager").GetComponent<SaveManager>().save.playerStatus.HP += 100;

                //アイテム削除指示
                o.playerTouchOn = true;

                //
                GameObject.FindWithTag("GameManager").GetComponent<SceneStage1>().Reload();
            }
            else
            {
                Debug.Log("アイテムに触れてるけど、ObjectCollisionが存在しない");
            }
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            //Debug.Log("敵と接触中！");
            isStatus = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            //Debug.Log("敵から離れた！");
            isStatus = false;
        }
    }
    #endregion

    ///<summary> 
    ///バトル処理
    ///</summary>
    private void Battle()
    {
        UpdateStatus();
        //Debug.Log("Zボタンでバトル開始！");

        if (isPunching == true)
        {
            //ここに入力する
            Punch(Player, Enemy);
            Punch(Enemy, Player);

            if ((Player.sHP <= 0) || (Enemy.sHP <= 0))
            {
                //バトル終了判定
                isPunching = false;
                Debug.Log("バトル終了");
                if (Enemy.sHP <= 0)
                {
                    Enemy.sHP = 0;
                    Debug.Log("敵を倒しました");
                }
            }
            else
            {
                //Debug.Log("ステータス更新");
            }
        }


        //以下は戦闘中は入力不可にする

        float submitKey = Input.GetAxis("Submit");
        float cancelKey = Input.GetAxis("Cancel");

        if (submitKey > 0 && (isSubmit == false))
        {
            //初回入力
            Debug.Log("決定キーを押下しました");
            isSubmit = true;
            isPunching = true;      //バトル開始

        }
        else if (submitKey > 0 && (isSubmit == true))
        {
            //継続入力
            //Debug.Log("決定キーを押下中です");
            isSubmit = true;
        }
        else
        {
            isSubmit = false;
        }
        if (cancelKey > 0 && (isCancel == false))
        {
            //初回入力
            Debug.Log("キャンセルキーを押下しました");
            isCancel = true;
        }
        else if (cancelKey > 0 && (isCancel == true))
        {
            //継続入力
            //Debug.Log("キャンセルキーを押下中です");
            isCancel = true;
        }
        else
        {
            isCancel = false;
        }
    }

    /// <summary>
    /// ダメージ付与処理
    /// </summary>
    /// <param name="attack"></param>
    /// <param name="defence"></param>
    private void Punch(cData attack, cData defence)
    {
        defence.sHP -= attack.sATK - defence.sDEF;
        //Debug.Log("PlayerHP=" + Player.sHP + " & EnemyHP=" + Enemy.sHP);
    }

    /// <summary>
    /// ステータス画面を更新する
    /// </summary>
    private void UpdateStatus()
    {
        //Debug.Log(PlayerStatus.transform.GetChild(0).GetComponent<Text>().text);

        //Playerステータス更新
        PlayerStatus.transform.GetChild(0).GetComponent<Text>().text = "HP  :" + Player.sHP;
        PlayerStatus.transform.GetChild(1).GetComponent<Text>().text = "ATK:" + Player.sATK;
        PlayerStatus.transform.GetChild(2).GetComponent<Text>().text = "DEF:" + Player.sDEF;

        //Playerステータス更新
        EnemyStatus.transform.GetChild(0).GetComponent<Text>().text = "HP  :" + Enemy.sHP;
        EnemyStatus.transform.GetChild(1).GetComponent<Text>().text = "ATK:" + Enemy.sATK;
        EnemyStatus.transform.GetChild(2).GetComponent<Text>().text = "DEF:" + Enemy.sDEF;
    }
}
