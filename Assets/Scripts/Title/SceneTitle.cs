using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTitle : MonoBehaviour
{
    #region �q�G�����L�[�ݒ�
    public GameObject canvas_1;  //Press Z�̕�
    public GameObject canvas_2;  //���߂���̕�

    #endregion

    #region �B���ϐ�
    public bool firstPush = false; //Press Z -> ���߂��� �A���ŉ����Ȃ��p
    private bool isStart = false;    //���߂���I��
    private bool isLoad = false;    //��������I��

    public bool isMode1 = true;    //�uPress Z�v���\������Ă����
    public bool isMode2 = false;   //�u���߂���v���\������Ă����
    private bool flgCursor = true;  // �J�[�\�����]��

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
        //�L�[�{�[�h���͎擾
        float VerticalKey = Input.GetAxis("Vertical");
        float SubmitKey = Input.GetAxis("Submit");
        float CancelKey = Input.GetAxis("Cancel");

        if (isMode2)
        {
            if (VerticalKey > 0)    //�����
            {
                if (!firstPush)
                {
                    Debug.Log("���������");
                    flgCursor = !flgCursor;
                    Canvas2_Cursor_Set();
                    firstPush = true;
                }
            }
            else if (VerticalKey < 0)   //������
            {
                if (!firstPush)
                {
                    Debug.Log("����������");
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
                //Mode1��������Mode2��
                //Mode2��������V�[���J��
                if (isMode1)
                {
                    Debug.Log("Z����->Mode2�ɑJ��");
                    isMode1 = false;
                    isMode2 = true;
                    SetCanvas();
                }
                else if (isMode2)
                {
                    Debug.Log("Z����->�V�[���J��");
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
                Debug.Log("�L�����Z������");
                isMode1 = true;
                isMode2 = false;
                SetCanvas();
            }
            firstPush = true;
        }

        //���������Ă��Ȃ�������firstPush��false�ɂ���
        if (VerticalKey == 0 && SubmitKey == 0 && CancelKey == 0)
        {
            firstPush = false;
        }

    }
    public void PressStart()
    {

        Debug.Log("�V�[���J�ڂ��܂���");

        if (flgCursor)
        {
            isStart = true;
            isLoad = false;
            //start��������load����������DataBase�ɕۑ�����


            //�����ŃZ�[�u�����[�h����
            SceneManager.sceneLoaded += GameSceneLoaded;
        }
        else
        {
            isLoad = true;
            isStart = false;
            //start��������load����������DataBase�ɕۑ�����

            //�����ŃZ�[�u�����[�h����
            SceneManager.sceneLoaded += GameSceneLoaded;
        }

        //�V�[���J�ڂ���
        SceneManager.LoadScene("Stage1 (2)");
        //2021/09/27 �ǋL �V�[�����������ׁ̈A�ύX ->Stage1 (2)
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
    /// Canvas2 �J�[�\���̈ʒu�𒲐�����
    /// </summary>
    public void Canvas2_Cursor_Set()
    {
        canvas_2.transform.Find("Sel_Start").gameObject.SetActive(flgCursor);
        canvas_2.transform.Find("Sel_Load").gameObject.SetActive(!flgCursor);
    }

    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        Debug.Log("GameSceneLoaded�J�n");
        if (isStart)
        {
            Debug.Log("���߂����I��->����");
            // �V�[���؂�ւ���̃X�N���v�g���擾
            SaveManager saveManager = GameObject.FindWithTag("GameManager").GetComponent<SaveManager>();

            //�� �Վ� �v���C���[�̃X�e�[�^�X������
            saveData.playerStatus.StatusID = 1;
            saveData.playerStatus.HP = 100;
            saveData.playerStatus.ATK = 10;
            saveData.playerStatus.DEF = 5;

            saveManager.SetSave(saveData);      //���O�̂���new���Ă邯�ǂ���Ȃ�����

            //��ł͓����Ȃ��̂ŁB
            //saveManager.save.playerStatus.StatusID = 1;
            //saveManager.save.playerStatus.HP = 100;
            //saveManager.save.playerStatus.ATK = 10;
            //saveManager.save.playerStatus.DEF = 5;

            //����ł������Ȃ��̂ŁAisStart�̏�Ԃ������čs���āA
            //���ꂪtrue�Ȃ�Stage1����start��saveManager.save.playerStatus.StatusID = 1;����I
            //GameObject.FindWithTag("GameMaager").GetComponent<SceneStage1>().isStart = true;

            //�����Ȃ�����������PressStart()��GameSceneLoaded����ĂȂ�����������ۂ��̂ŁA�m�F
        }
        else if (isLoad)
        {
            Debug.Log("���������I��->����");
            // �V�[���؂�ւ���̃X�N���v�g���擾
            SaveManager saveManager = GameObject.FindWithTag("GameManager").GetComponent<SaveManager>();

            // �f�[�^��n������
            //saveManager.save.itemFlagList[0].Bikou = "test";
            //�����炭�A�����ł̓f�[�^�����[�h���Ă��Ȃ��̂ŁA
            //1.SaveData���t�@�C�����烍�[�h����
            //2.SceneStage1��Save�ɏ����B(setsave�ŗǂ�)

            saveManager.Load();
            saveData = saveManager.GetSave();
            saveManager.SetSave(saveData);
        }
        else
        {
            Debug.Log("�V�[���J�ځF���߂���E��������ȊO�ŃV�[���J�ڂ����炵��");
        }
        // �C�x���g����폜
        SceneManager.sceneLoaded -= GameSceneLoaded;
        Debug.Log("GameSceneLoaded�I��");
    }
}