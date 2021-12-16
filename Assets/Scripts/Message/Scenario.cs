using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario
{
    //Senario hava Texts
    //Senario はStaticにしたい
    //Senarioは複数のTextsをクラスリスト等で持って置きたい
    //Staticクラスはインスタンス化しなくて良いはず

    public string ScenarioID;
    public List<string> Texts;
    public List<string> Options;
    public string NextScenarioID;

    //☆ 修正案 同じScenarioIDを許容しないよう修正->Dictionary
}
