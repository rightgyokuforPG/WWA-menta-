using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    #region//�v���C�x�[�g�ϐ�
    [SerializeField] Item.Type itemType;

    [SerializeField]
    int ItemID;

    private Rigidbody2D rb = null;      //����Ȃ�����

    private ObjectCollision oc = null;
    private CapsuleCollider2D col = null;

    #endregion
    void Start()
    {
        //itemType�ɉ�����Item�𐶐�����
        ItemID = 1;     //�Վ�

        rb = GetComponent<Rigidbody2D>();
        oc = GetComponent<ObjectCollision>();
        col = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (oc.playerTouchOn)
        {
            //�����蔻�������
            col.enabled = false;

            //�A�C�e����񊈐��ɂ���
            this.gameObject.SetActive(false);
        }
    }

    //�擾���������
    public void OnTouchObj()
    {
        //�A�C�e�����擾�ς݂ɂ���
        //�v���C���[�̃X�e�[�^�X��ʂ��ĕ\������

        this.gameObject.SetActive(false);
    }
}