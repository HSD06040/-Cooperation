using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SheetMusicMonsterSO", menuName = "SO/Monsters/SheetMusicMonster")]
public class SheetMusicMonsterSO : ScriptableObject
{
    [Header("Stats")]
    public float health = 50f;
    public float attackPower = 10f;
    public float moveSpeed = 5f;

    [Header("Behavior Stats")]
    public float chaseRange = 5f; // �� �Ÿ� ������ ������ ����
    public float rangedAttackRange = 15f; // ���Ÿ� ���� ��Ÿ�

    [Header("Attack Timers")]
    public float rangedAttackCooldown = 3f; // ���Ÿ� ���� ��Ÿ��

    [Header("Ranged Attack")]
    public GameObject notePrefab; // ��ǥ ������
    public float noteSpeed = 10f; // ��ǥ �ӵ�
}
