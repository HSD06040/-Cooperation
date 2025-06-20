using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{  //�����̽��� �뽬 �����ؾ���

    [Header("�÷��̾�")]
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rigid;
    private Vector2 movemoent;
    Camera cam;

    [Header("����")]
    [SerializeField] private GameObject defaultWeapon;
    private List<GameObject> ownedWeapons = new List<GameObject>(); //ȹ���� �Ǳ� ����Ʈ
    private GameObject currentWeapon;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentWeapon != null)
            {
                // �������� �Ǳ��� ����;
            }

            else
            {
                // �⺻������ ����;
            }
        }

        WeaponSwap();
    }

    public void AddWeapon(GameObject weapon)
    {
        ownedWeapons.Add(weapon);
        Debug.Log("�����߰�" +  weapon.name);
    }

    private void WeaponSwap()
    {
        for (int i = 0; i < ownedWeapons.Count; i++) //������ �Ǳ��� ������ŭ Ű �Ҵ�
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i)) //�ڵ� Ű �Ҵ�
            {
                SelectWeapon(i); //SelectWeapon�� �ŰԺ��� �Ѱ���
                Debug.Log(i + "�� �Ǳ� ����");
            }
        }
    }

    private void SelectWeapon(int index)
    {
        if (index >= ownedWeapons.Count)  //���������� ū ������ Ű�� ������ ����
        {
            return;
        }

        currentWeapon = ownedWeapons[index];  //������ ���� = currentWeapon
        Debug.Log(index + "�� ���� �����");

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()  //�÷��̾� �̵� �Լ�
    {
        movemoent.x = Input.GetAxisRaw("Horizontal");
        movemoent.y = Input.GetAxisRaw("Vertical");
        rigid.velocity = movemoent.normalized * moveSpeed;
    }

}
