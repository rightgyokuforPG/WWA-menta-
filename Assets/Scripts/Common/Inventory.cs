using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    //やりたいのは
    //Inventory
    //{
    //  鍵 : 3本
    //  ... :0個
    //  途中帰還アイテム : 2個
    //  ... :0個
    //}
    //なのでおそらく、アイテム図鑑を継承して作成すると楽っぽい
    //
    //



    [SerializeField]
    public List<Items> itemList;

    /// <summary>
    /// 引数ない方
    /// </summary>
    public Inventory()
    {

    }
}

/// <summary>
/// アイテムクラスの子クラス
/// 個数表記が増えた
/// 目的：Inventoryに保持する際、個数を保持できないと1つしか持てない為。
/// </summary>
[System.Serializable]
public class Items : Item
{
    public float Number;

    /// <summary>
    /// 引数ない方
    /// </summary>
    public Items()
    {

    }
}