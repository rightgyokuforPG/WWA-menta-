using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTitle : MonoBehaviour
{
    #region ヒエラルキー設定
    public GameObject canvas_1;  //Press Zの方
    public GameObject canvas_2;  //初めからの方

    #endregion

    #region 隠し変数
    public bool firstPush = false; //Press Z -> 初めから 連続で押さない用
    private bool isStart = false;    //初めから選択
    private bool isLoad = false;    //続きから選択

    public bool isMode1 = true;    //「Press Z」が表示されている方
    public bool isMode2 = false;   //「初めから」が表示されている方
    private bool flgCursor = true;  // カーソル反転式

    [SerializeField]
    SaveData saveData;
    #endregion


    void Awake()
    {
    }


    void Start()
    {
        SetCanvas();
        saveData = new SaveData();
    }


    void Update()
    {
        //キーボード入力取得
        float VerticalKey = Input.GetAxis("Vertical");
        float SubmitKey = Input.GetAxis("Submit");
        float CancelKey = Input.GetAxis("Cancel");

        if (isMode2)
        {
            if (VerticalKey > 0)    //上方向
            {
                if (!firstPush)
                {
                    Debug.Log("上方向押下");
                    flgCursor = !flgCursor;
                    Canvas2_Cursor_Set();
                    firstPush = true;
                }
            }
            else if (VerticalKey < 0)   //下方向
            {
                if (!firstPush)
                {
                    Debug.Log("下方向押下");
                    flgCursor = !flgCursor;
                    Canvas2_Cursor_Set();
                    firstPush = true;
                }
            }

        }

        if (SubmitKey > 0)
        {
            if (!firstPush)
            {
                //Mode1だったらMode2に
                //Mode2だったらシーン遷移
                if (isMode1)
                {
                    Debug.Log("Z押下->Mode2に遷移");
                    isMode1 = false;
                    isMode2 = true;
                    SetCanvas();
                }
                else if (isMode2)
                {
                    Debug.Log("Z押下->シーン遷移");
                    isMode1 = true;
                    isMode2 = false;
                    PressStart();
                }
                firstPush = true;
            }
        }
        else
        {
            //firstPush = false;
        }
        if (CancelKey > 0)
        {
            if (!firstPush)
            {
                Debug.Log("キャンセル押下");
                isMode1 = true;
                isMode2 = false;
                SetCanvas();
            }
            firstPush = true;
        }

        //何も押していない時だけfirstPushをfalseにする
        if (VerticalKey == 0 && SubmitKey == 0 && CancelKey == 0)
        {
            firstPush = false;
        }

    }
    public void PressStart()
    {

        Debug.Log("シーン遷移しました");

        if (flgCursor)
        {
            isStart = true;
            isLoad = false;
            //startだったかloadだったかをDataBaseに保存する


            //ここでセーブをロードする
            SceneManager.sceneLoaded += GameSceneLoaded;
        }
        else
        {
            isLoad = true;
            isStart = false;
            //startだったかloadだったかをDataBaseに保存する

            //ここでセーブをロードする
            SceneManager.sceneLoaded += GameSceneLoaded;
        }

        //シーン遷移する
        SceneManager.LoadScene("Stage1 (2)");
        //2021/09/27 追記 シーン書き換えの為、変更 ->Stage1 (2)
    }
    public void SetCanvas()
    {
        if (isMode1)
        {
            canvas_1.SetActive(true);

            canvas_2.SetActive(false);
        }
        else if (isMode2)
        {
            canvas_1.SetActive(false);
            canvas_2.SetActive(true);
            flgCursor = true;
            Canvas2_Cursor_Set();
        }
        else
        {
            Debug.Log("SceneTitle_SetCanvas_Error");
        }
    }

    /// <summary>
    /// Canvas2 カーソルの位置を調整する
    /// </summary>
    public void Canvas2_Cursor_Set()
    {
        canvas_2.transform.Find("Sel_Start").gameObject.SetActive(flgCursor);
        canvas_2.transform.Find("Sel_Load").gameObject.SetActive(!flgCursor);
    }

    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        Debug.Log("GameSceneLoaded開始");
        if (isStart)
        {
            Debug.Log("初めからを選択->処理");
            // シーン切り替え後のスクリプトを取得
            SaveManager saveManager = GameObject.FindWithTag("GameManager").GetComponent<SaveManager>();

            //★ 臨時 プレイヤーのステータスを入れる
            saveData.playerStatus.StatusID = 1;
            saveData.playerStatus.HP = 100;
            saveData.playerStatus.ATK = 10;
            saveData.playerStatus.DEF = 5;

            saveManager.SetSave(saveData);      //★念のためnewしてるけどいらないかも

            //上では動かないので。
            //saveManager.save.playerStatus.StatusID = 1;
            //saveManager.save.playerStatus.HP = 100;
            //saveManager.save.playerStatus.ATK = 10;
            //saveManager.save.playerStatus.DEF = 5;

            //これでも動かないので、isStartの状態を持って行って、
            //それがtrueならStage1側のstartでsaveManager.save.playerStatus.StatusID = 1;する！
            //GameObject.FindWithTag("GameMaager").GetComponent<SceneStage1>().isStart = true;

            //動かなかった原因がPressStart()でGameSceneLoaded入れてなかったからっぽいので、確認
        }
        else if (isLoad)
        {
            Debug.Log("続きからを選択->処理");
            // シーン切り替え後のスクリプトを取得
            SaveManager saveManager = GameObject.FindWithTag("GameManager").GetComponent<SaveManager>();

            // データを渡す処理
            //saveManager.save.itemFlagList[0].Bikou = "test";
            //おそらく、ここではデータをロードしていないので、
            //1.SaveDataをファイルからロードする
            //2.SceneStage1のSaveに書く。(setsaveで良い)

            saveManager.Load();
            saveData = saveManager.GetSave();
            saveManager.SetSave(saveData);
        }
        else
        {
            Debug.Log("シーン遷移：初めから・続きから以外でシーン遷移したらしい");
        }
        // イベントから削除
        SceneManager.sceneLoaded -= GameSceneLoaded;
        Debug.Log("GameSceneLoaded終了");
    }
}