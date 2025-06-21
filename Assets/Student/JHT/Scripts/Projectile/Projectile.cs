using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage;
    StatusController target = null;

    [SerializeField] private float maxTime;
    [SerializeField] private GameObject bulletModel;
    [SerializeField] private float Speed = 1;
    private Rigidbody rigid;
    private Transform startPos;
    public bool IsPass;

    private Vector3 targetPos;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
    public void Init(Transform _projectilePos, Vector3 _targetPos)
    {
        GameObject obj = Instantiate(bulletModel, _projectilePos);
        targetPos = _targetPos;
        startPos = _projectilePos.transform;
    }
    
    private void Update()
    {
        //������ �������� �̵�

        //������ ��
        //transform.position += targetPos.normalized * Time.deltaTime * Speed;

        //�ش� ��ġ���� ������
        transform.position = Vector3.MoveTowards(startPos.position, targetPos, 0.1f);

        if (transform.position == targetPos)
        {
            Destroy(this.gameObject, 0.3f); // PooledObject.ReturnPool()�ڸ�
        }
    }

    //��ƼŬ ���� ��ġ
    private Transform SetParticlePos()
    {
        return null;
    }

    //�ٽ�
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject == null) return; // Ʈ���� �ż� ��������� ���ÿ� Destroy�� ȣ��ɰ��
        if (IsPass == true) return;
        if (other.GetComponent<StatusController>() != target && other.gameObject.layer != 7) //layer == 7 �÷��̾�� ����
            return;
        if (target == null) return; //�׾������ return;

        target.TakeDamage(damage);
        Destroy(gameObject, 0.3f);
        
        //particle
    }
}
