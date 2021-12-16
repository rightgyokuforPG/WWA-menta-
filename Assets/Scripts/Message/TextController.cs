using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{

    [SerializeField]
    Text scenarioMessage;
    List<Scenario> scenarios = new List<Scenario>();

    Scenario currentScenario;
    int index = 0;
    public bool firstPush = false;

    //☆　後で別CSファイルに移動する
    //class Scenario
    //{
    //    public string ScenarioID;
    //    public List<string> Texts;
    //    public List<string> Options;
    //    public string NextScenarioID;
    //}

    void Start()
    {
       
        var scenario01 = new Scenario()
        {
            ScenarioID = "scenario01",
            Texts = new List<string>()
            {
                "テスト文章１",
                "テスト文章２",
                "テスト文章３",
                "テスト文章４",
                "テスト文章５"
            },
            NextScenarioID = "scenario02"
        };

        var scenario02 = new Scenario()
        {
            ScenarioID = "scenario02",
            Texts = new List<string>()
            {
                "テスト文章６",
                "テスト文章７",
                "テスト文章８",
                "テスト文章９",
                "テスト文章１０"
            }
        };

        SetScenario(scenario01);
    }

    void Update()
    {
        float Fire1Key = Input.GetAxis("Fire1");
        if (currentScenario != null)
        {
            if (Fire1Key > 0)
            {
                if(!firstPush)
                { 
                    SetNextMessage();
                    firstPush = true;
                }
            }
        }

        //何も押していない時だけfirstPushをfalseにする
        if (Fire1Key == 0 )
        {
            firstPush = false;
        }
    }

    void SetScenario(Scenario scenario)
    {
        currentScenario = scenario;
        scenarioMessage.text = currentScenario.Texts[0];
    }

    void SetNextMessage()
    {
        if (currentScenario.Texts.Count > index + 1)
        {
            index++;
            scenarioMessage.text = currentScenario.Texts[index];
        }
        else
        {
            ExitScenario();
        }
    }

    void ExitScenario()
    {
        scenarioMessage.text = "";
        index = 0;
        if (string.IsNullOrEmpty(currentScenario.NextScenarioID))
        {
            currentScenario = null;
        }
        else
        {
            var nextScenario = scenarios.Find
                (s => s.ScenarioID == currentScenario.NextScenarioID);
            currentScenario = nextScenario;
        }
    }

}