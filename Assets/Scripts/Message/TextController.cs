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

    //���@��ŕ�CS�t�@�C���Ɉړ�����
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
                "�e�X�g���͂P",
                "�e�X�g���͂Q",
                "�e�X�g���͂R",
                "�e�X�g���͂S",
                "�e�X�g���͂T"
            },
            NextScenarioID = "scenario02"
        };

        var scenario02 = new Scenario()
        {
            ScenarioID = "scenario02",
            Texts = new List<string>()
            {
                "�e�X�g���͂U",
                "�e�X�g���͂V",
                "�e�X�g���͂W",
                "�e�X�g���͂X",
                "�e�X�g���͂P�O"
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

        //���������Ă��Ȃ�������firstPush��false�ɂ���
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