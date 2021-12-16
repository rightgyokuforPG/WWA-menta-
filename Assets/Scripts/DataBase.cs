using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataBase
{
    static Scenario tutorial01 = new Scenario()
    {
        ScenarioID = "tutorial01",
        Texts = new List<string>()
        {
                "テスト文章１",
                "テスト文章２",
                "テスト文章３",
                "テスト文章４",
                "テスト文章５"
        },
        NextScenarioID = "tutorial02"
    };
    static Scenario tutorial02 = new Scenario()
    {
        ScenarioID = "tutorial02",
        Texts = new List<string>()
        {
                "テスト文章６",
                "テスト文章７",
                "テスト文章８",
                "テスト文章９",
                "テスト文章１０"
        }
    };

    static Scenario scenario01 = new Scenario()
    {
        ScenarioID = "scenario01",
        Texts = new List<string>()
        {
                "シナリオ１",
                "シナリオ２",
                "シナリオ３",
                "シナリオ４",
                "シナリオ５"
        }
    };

    /// <summary>
    /// 全シナリオを所持
    /// </summary>
    public static List<Scenario> scenarios = new List<Scenario>()
    {
        tutorial01,
        tutorial02,
        scenario01
    };
}


//☆ 後々の参考用にメモ
//■やりたいこと
//　クラスをリスト化して値を代入した上で宣言しておきたい！
//
//
//■やりかた
//　①まず、早速クラスでやる前に、stringのリストで試す
//static List<string> text = new List<string>()
//{
//    "テスト1",
//    "テスト2",
//    "テスト3"
//};
//
//　➁次に、クラス単体で値の代入を試す
//static Scenario scenario01 = new Scenario()
//{
//    ScenarioID = "scenario01",
//    Texts = new List<string>()
//        {
//                "テスト文章１",
//                "テスト文章２",
//                "テスト文章３",
//                "テスト文章４",
//                "テスト文章５"
//        }
//};
//
//
//　③合体させる
//  上記参照
//
//　④以下、失敗例
//static List<Scenario> scenarios = new List<Scenario>()
//{
//    static Scenario scenario01 = new Scenario()
//    {
//        ScenarioID = "scenario01",
//        Texts = new List<string>()
//        {
//            "テスト文章１",
//            "テスト文章２",
//            "テスト文章３",
//            "テスト文章４",
//            "テスト文章５"
//        }
//    };
//    ,   
//    static Scenario scenario02 = new Scenario()
//    {
//        ScenarioID = "scenario01",
//        Texts = new List<string>()
//        {
//            "テスト文章１",
//            "テスト文章２",
//            "テスト文章３",
//            "テスト文章４",
//            "テスト文章５"
//        }
//    };
//};
//
//■以上