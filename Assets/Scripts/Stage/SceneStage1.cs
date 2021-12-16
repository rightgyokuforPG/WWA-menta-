using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneStage1 : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("HP"), SerializeField] public Text statusHP;
    [Header("ATK")] public Text statusATK;
    [Header("DEF")] public Text statusDEF;
    [Header("MONEY")] public Text statusMONEY;

    //[Header("初めからかどうか")] public bool isStart = false;
    #endregion



    void Awake()
    {
    }

    void Start()
    {
        //SceneTitleからシーン遷移する際、SaveManager内のsaveに上書きしているので
        //本当に取得出来ているか確認するコード
        //GameObject obj = GameObject.FindWithTag("GameManager");
        //SaveData save = obj.GetComponent<SaveManager>().GetSave();

        //if (save.itemFlagList[0].ItemID == 1)
        //{
        //    Debug.Log("データ遷移_確認OK");
        //    GameObject.Find("Item").SetActive(false);
        //}
        //Q:シーン間でデータ移せてるの？
        //A:Stage1側のAwakeでsaveを生成し、Title側のGameSceneLoadedでsaveに上書きしているから出来てる

        //★臨時 titleで初めからを選択していた場合、ステータスを直入力する
        //if(isStart)
        //{
        //    Debug.Log("SceneStage1でisStartがtrueでした");
        //    GameObject.FindWithTag("GameManager").GetComponent<SaveManager>().save.playerStatus.HP = 100;
        //    GameObject.FindWithTag("GameManager").GetComponent<SaveManager>().save.playerStatus.ATK = 10;
        //    GameObject.FindWithTag("GameManager").GetComponent<SaveManager>().save.playerStatus.HP = 5;
        //    GameObject.FindWithTag("GameManager").GetComponent<SaveManager>().save.playerStatus.HP = 0;
        //    isStart = false;
        //}

        //★左のステータスに値を設定する
        Reload();
    }

    void Update()
    {

    }

    /// <summary>
    /// ステータスを再表示する
    /// </summary>
    public void Reload()
    {
        Debug.Log("Reloadに入った");
        statusHP.text = GameObject.FindWithTag("GameManager")
            .GetComponent<SaveManager>().save.playerStatus.HP.ToString();

        statusATK.text = GameObject.FindWithTag("GameManager")
            .GetComponent<SaveManager>().save.playerStatus.ATK.ToString();

        statusDEF.text = GameObject.FindWithTag("GameManager")
            .GetComponent<SaveManager>().save.playerStatus.DEF.ToString();

        statusMONEY.text = GameObject.FindWithTag("GameManager")
            .GetComponent<SaveManager>().save.playerStatus.MONEY.ToString();
    }
}
