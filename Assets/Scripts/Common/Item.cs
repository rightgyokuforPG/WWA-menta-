using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �A�C�e���N���X�̐e�N���X
/// Items�N���X�ɔh������
/// </summary>
[System.Serializable]
public class Item
{
    // �񋓌^�F��ނ�񋓂���
    public enum Type
    {
        MaxHPUP,    //�ő�HP�̏�����㏸������A�C�e��
        HealHP,    //HP���񕜂�����A�C�e��
        ATKUP,  //ATK�𑝉�������A�C�e��
        DEFUP,   //DEF�𑝉�������A�C�e��
        MONEYUP,    //MONEY�𑝉�������A�C�e��
        Other,      //���̑� ����A�҃A�C�e���A�d�v�A�C�e���Ȃ�
    }

    public Type type;       //�A�C�e���̎��
    public Sprite sprite;   //Slot�ɕ\������摜

    [SerializeField]
    int ItemID;             //�A�C�e���}�ӂƘA�g������ׂ�ID
    [SerializeField]
    float Value;            //���ʒl HP��������50�񕜂���Ƃ��B

    /// <summary>
    /// �A�C�e���������Ȃ���
    /// </summary>
    public Item()
    {

    }

    /// <summary>
    /// �A�C�e���������K��Type��sprite���擾����
    /// </summary>
    public Item(Type type, Sprite sprite)
    {
        this.type = type;
        this.sprite = sprite;
    }

    //��������A�e�ϐ���Getter,Setter���

}



//��WeaponListEntity ����̎�ނ��Ǘ�����z
//��PlayerListEntity �v���C���[���������Ă��镨���Ǘ�����z
//��EnemyListEntity  �G�̏����Ǘ�����z�i�Ȃ񂩎�ނ��Ǘ����邾���ł���/���Ȃ��Ǘ��o���Ȃ������j
//��FlagListEntity   �V�i���I�i�s�t���O�₨�ז�NPC�̏o���t���O���Ǘ�����z

//��EnemyExistFlagListEntity �G�̓|�������ǂ������Ǘ�����z
//  {�ǂ̃X�e�[�W�� �ǂ̎�ނ� �ǂ�ID��}

//2021/09/25 �ǋL ���������Ă�̂��s��