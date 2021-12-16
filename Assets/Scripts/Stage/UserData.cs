using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{
}

[System.Serializable]
public class PlayerStatus : Status
{
    public string Name = "なまえ";
}

[System.Serializable]
public class ItemFlag : Flag
{
    public string ItemFlagName = "アイテム回収フラグ";

    [SerializeField]
    public int ItemID;

    [SerializeField]
    public bool isExist;

    [SerializeField]
    public string Bikou;
    public ItemFlag()
    {
        //this.isExist = true;
    }

}


//出来たらフラグは、
//★進行フラグ
//★敵倒したかフラグ
//★アイテム回収したかフラグに分けたい