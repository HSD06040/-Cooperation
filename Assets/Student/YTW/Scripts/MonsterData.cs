using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Monster/Monster Data")]
public class MonsterData : ScriptableObject
{
    [Header("�⺻ ����")]
    public string _monsterName = "����"; // ���� �̸� (UI�� ������)

    [Header("�ٽ� ����")]
    public float _health = 100f;         // �ִ� ü��
    public float _atk = 10f;     // ���ݷ�
    public float _speed = 3.5f;      // �̵� �ӵ�

    [Header("���� ����")]
    public GameObject _projectilePrefab; // �߻��� ����ü ������
    public float _attackRange = 10f;     // ������ �����ϴ� �����Ÿ�
    public float _attackCooldown = 2f;   // ���� �� ���� ���ݱ����� ��� �ð�
}
