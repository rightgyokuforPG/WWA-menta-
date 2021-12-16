using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// キャラクターの親クラス
/// PlayerStatusに派生する
/// </summary>
[System.Serializable]
public class Status
{
    [SerializeField]
    public int StatusID;                //キャラクター図鑑と連携させる為のID

    //[SerializeField]
    //public float Name;                  //いらない可能性ある
    [SerializeField]
    public float HP;
    [SerializeField]
    public float ATK;
    [SerializeField]
    public float DEF;
    [SerializeField]
    public float MONEY;

    /// <summary>
    /// 引数ない方
    /// </summary>
    public Status()
    {
        //出来たら、このスクリプト内で、
        //CharactorListEntityからデータを取得したい
        //例
        //public Status(int statusID)
        //this.StatusID = statusID
        //forEach(CharactorListEntity.StatusID -> ID)
        //
        //if(this.StatusID == ID)
        //this.HP = CharactorListEntity.getHP(ID)   //IDを指定してHPを返す
        //this.ATK = CharactorListEntity[ID].ATK    //こっちの方がいいのかな？
        //this.DEF = 
        //This.Money = 

        //else
        //Debug.Log("status.cs:図鑑にないキャラクターを参照しています")
    }

    //★いずれ、各変数のGetter,Setter作る
}