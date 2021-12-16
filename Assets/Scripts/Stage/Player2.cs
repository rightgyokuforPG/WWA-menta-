using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2: MonoBehaviour
{
    #region//�C���X�y�N�^�[�Őݒ肷��
    [Header("�ړ����x")] public float speed;
    [Header("�X�e�[�^�X��ʃI�u�W�F�N�g")] public GameObject battleView;
    //�� �f�[�^�x�[�X�ŊǗ�����
    [Header("��HP")] public int pHP;
    [Header("��ATK")] public int pATK;
    [Header("��DEF")] public int pDEF;
    // �� �f�[�^�x�[�X����G�̎�ނ��擾���ĕ\������
    [Header("�GHP")] public int eHP;
    [Header("�GATK")] public int eATK;
    [Header("�GDEF")] public int eDEF;
    #endregion

    #region//�v���C�x�[�g�ϐ�
    private Animator anim = null;           //Animator�ϐ���錾
    private Rigidbody2D rb = null;

    private bool isSide = false;            //�A�j���[�V�����ݒ�p�t���O
    private bool isUp = false;
    private bool isDown = false;
    private bool isWalk = false;
    private string enemyTag = "Enemy";         //�ړG����^�O
    private bool isStatus = false;             //�X�e�[�^�X��\�����邩�ǂ����t���O

    //�� �ʂ̃X�N���v�g�ŊǗ����ׂ�
    private bool isSubmit = false;          //����{�^���������t���O
    private bool isCancel = false;          //�L�����Z���{�^���������t���O
    private bool isPunching = false;        //�o�g�����t���O
    private cData Player;                   //�X�e�[�^�X�i�[
    private cData Enemy;

    private GameObject PlayerStatus;
    private GameObject EnemyStatus;
    //2021/09/26 �ǋL
    //�� ButtomPlayer �� Player���}�[�W
    private string itemTag = "Item";    //�A�C�e���ƐڐG�������ɃA�C�e�����������p
    #endregion

    public class cData
    {
        public int sHP;
        public int sATK;
        public int sDEF;
    }

    void Start()
    {
        anim = GetComponent<Animator>();    //Animator�C���X�^���X�𐶐��A��ŃA�^�b�`
        rb = GetComponent<Rigidbody2D>();

        //�� ��ŃX�e�[�^�X���擾����L�q
        Player = new cData() { sHP = this.pHP, sATK = this.pATK, sDEF = this.pDEF };
        Enemy = new cData() { sHP = this.eHP, sATK = this.eATK, sDEF = this.eDEF };

        PlayerStatus = GameObject.Find("PlayerStatus");
        EnemyStatus = GameObject.Find("EnemyStatus");
    }

    void FixedUpdate()
    {
        //�e����W���̑��x�����߂�
        float xSpeed = GetXSpeed();
        float ySpeed = GetYSpeed();

        //�A�j���[�V������K�p
        SetAnimation();

        //�ړ����x��ݒ�
        rb.velocity = new Vector2(xSpeed, ySpeed);

        //�X�e�[�^�X�\���ݒ�
        if (isStatus == true)
        {
            //�X�e�[�^�X�̃I�u�W�F�N�g��enabled�ɂ���
            battleView.SetActive(true);
            Battle();
        }
        else
        {
            battleView.SetActive(false);
        }
    }

    /// <summary>
    /// X�����ŕK�v�Ȍv�Z�����A���x��Ԃ��B
    /// </summary>
    /// <returns>X���̑���</returns>
    private float GetXSpeed()
    {

        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;

        if (horizontalKey > 0)       //�E����
        {
            transform.localScale = new Vector3(1, 1, 1);
            isSide = true;
            xSpeed = speed;
        }
        else if (horizontalKey < 0)  //������
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isSide = true;
            xSpeed = -speed;
        }
        else
        {
            isSide = false;
            xSpeed = 0.0f;
        }

        return xSpeed;
    }

    /// <summary>
    /// Y�����ŕK�v�Ȍv�Z�����A���x��Ԃ��B
    /// </summary>
    /// <returns>Y���̑���</returns>
    private float GetYSpeed()
    {

        float verticalKey = Input.GetAxis("Vertical");
        float ySpeed = 0.0f;

        if (verticalKey > 0)        //�����
        {
            isUp = true;
            isDown = false;
            ySpeed = speed;
        }
        else if (verticalKey < 0)   //������
        {
            isUp = false;
            isDown = true;
            ySpeed = -speed;
        }
        else
        {
            isUp = false;
            isDown = false;
            ySpeed = 0.0f;
        }

        return ySpeed;
    }


    /// <summary>
    /// �A�j���[�V������ݒ肷��
    /// </summary>
    private void SetAnimation()
    {
        float horizontalKey = Input.GetAxis("Horizontal");

        float verticalKey = Input.GetAxis("Vertical");

        if ((horizontalKey != 0) || (verticalKey != 0))    //�ړ����̏���
        {
            isWalk = true;
        }
        else                                                //��~���̏���
        {
            isWalk = false;
        }

        anim.SetBool("side", isSide);
        anim.SetBool("up", isUp);
        anim.SetBool("down", isDown);
        anim.SetBool("walk", isWalk);
    }

    #region//�ڐG����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            //Debug.Log("�G�ƐڐG�����I");
            isStatus = true;
        }
        //2021/09/26 �ǋL
        //�� ButtomPlayer �� Player���}�[�W
        if (collision.collider.tag == itemTag)
        {
            Debug.Log("�A�C�e���ƐڐG�����I");
            //�����ŁASaveData��

            //���A�C�e����������Ƃ�������̓A�C�e�����g�ɂ���Ă��炤
            ObjectCollision o = collision.gameObject.GetComponent<ObjectCollision>();

            if (o != null)
            {
                //���Վ�
                //saveData�ɒ��ڋL������
                GameObject.FindWithTag("GameManager").GetComponent<SaveManager>().save.playerStatus.HP += 100;

                //�A�C�e���폜�w��
                o.playerTouchOn = true;

                //
                GameObject.FindWithTag("GameManager").GetComponent<SceneStage1>().Reload();
            }
            else
            {
                Debug.Log("�A�C�e���ɐG��Ă邯�ǁAObjectCollision�����݂��Ȃ�");
            }
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            //Debug.Log("�G�ƐڐG���I");
            isStatus = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            //Debug.Log("�G���痣�ꂽ�I");
            isStatus = false;
        }
    }
    #endregion

    ///<summary> 
    ///�o�g������
    ///</summary>
    private void Battle()
    {
        UpdateStatus();
        //Debug.Log("Z�{�^���Ńo�g���J�n�I");

        if (isPunching == true)
        {
            //�����ɓ��͂���
            Punch(Player, Enemy);
            Punch(Enemy, Player);

            if ((Player.sHP <= 0) || (Enemy.sHP <= 0))
            {
                //�o�g���I������
                isPunching = false;
                Debug.Log("�o�g���I��");
                if (Enemy.sHP <= 0)
                {
                    Enemy.sHP = 0;
                    Debug.Log("�G��|���܂���");
                }
            }
            else
            {
                //Debug.Log("�X�e�[�^�X�X�V");
            }
        }


        //�ȉ��͐퓬���͓��͕s�ɂ���

        float submitKey = Input.GetAxis("Submit");
        float cancelKey = Input.GetAxis("Cancel");

        if (submitKey > 0 && (isSubmit == false))
        {
            //�������
            Debug.Log("����L�[���������܂���");
            isSubmit = true;
            isPunching = true;      //�o�g���J�n

        }
        else if (submitKey > 0 && (isSubmit == true))
        {
            //�p������
            //Debug.Log("����L�[���������ł�");
            isSubmit = true;
        }
        else
        {
            isSubmit = false;
        }
        if (cancelKey > 0 && (isCancel == false))
        {
            //�������
            Debug.Log("�L�����Z���L�[���������܂���");
            isCancel = true;
        }
        else if (cancelKey > 0 && (isCancel == true))
        {
            //�p������
            //Debug.Log("�L�����Z���L�[���������ł�");
            isCancel = true;
        }
        else
        {
            isCancel = false;
        }
    }

    /// <summary>
    /// �_���[�W�t�^����
    /// </summary>
    /// <param name="attack"></param>
    /// <param name="defence"></param>
    private void Punch(cData attack, cData defence)
    {
        defence.sHP -= attack.sATK - defence.sDEF;
        //Debug.Log("PlayerHP=" + Player.sHP + " & EnemyHP=" + Enemy.sHP);
    }

    /// <summary>
    /// �X�e�[�^�X��ʂ��X�V����
    /// </summary>
    private void UpdateStatus()
    {
        //Debug.Log(PlayerStatus.transform.GetChild(0).GetComponent<Text>().text);

        //Player�X�e�[�^�X�X�V
        PlayerStatus.transform.GetChild(0).GetComponent<Text>().text = "HP  :" + Player.sHP;
        PlayerStatus.transform.GetChild(1).GetComponent<Text>().text = "ATK:" + Player.sATK;
        PlayerStatus.transform.GetChild(2).GetComponent<Text>().text = "DEF:" + Player.sDEF;

        //Player�X�e�[�^�X�X�V
        EnemyStatus.transform.GetChild(0).GetComponent<Text>().text = "HP  :" + Enemy.sHP;
        EnemyStatus.transform.GetChild(1).GetComponent<Text>().text = "ATK:" + Enemy.sATK;
        EnemyStatus.transform.GetChild(2).GetComponent<Text>().text = "DEF:" + Enemy.sDEF;
    }
}
