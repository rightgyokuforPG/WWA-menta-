using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    [SerializeField]
    string text = "おはよう";

    //プレイヤーステータス
    [SerializeField]
    public PlayerStatus playerStatus;

    //(プレイヤーの) 所持アイテムリスト
    [SerializeField]
    public Inventory inventory;


    //★　以下はマスクデータ

    //アイテム回収フラグ
    [SerializeField]
    public List<ItemFlag> itemFlagList;

    //シンボル存続フラグ
    //★ stage1の右上のアイテム回収したかー　とか。シンボルエンカウントから。

    //[SerializeField]
    //public List<SymbolExistFlag> symbolExistFlagList;

    //★ 図鑑はそう簡単に変わらないからObjectScriptingでいいだろ

    public SaveData()
    {
        playerStatus = new PlayerStatus();
        inventory = new Inventory();
        itemFlagList = new List<ItemFlag>();
    }

}