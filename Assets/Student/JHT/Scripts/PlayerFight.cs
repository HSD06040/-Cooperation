using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    MusicWeapon musicWeapon;
    public Transform[] WeaponSpawnPos;
    public List<string> WeaponList;
    private int setWeaponNum;


    private void Start()
    {
        WeaponList = new List<string>(4);
    }

    //musicWeapon�� �Ҵ��ϴ°� �ٽ� �ѹ� �� �����غ�����
    public void AddMusicWeapon(MusicWeapon _musicWeapon)
    {
        if (_musicWeapon == null) return;
        int notSet = 0;

        if (!WeaponList.Contains(_musicWeapon.WeaponData.itemName))
        {
            WeaponList.Add(_musicWeapon.WeaponData.itemName);
            notSet = WeaponList.Count - 1;

            MusicWeapon weapon = _musicWeapon.Spawn(WeaponSpawnPos[notSet]).GetOrAddComponent<MusicWeapon>();
            weapon.Init(_musicWeapon.WeaponData);
            musicWeapon = weapon; // �� ���� �Ҵ�
            setWeaponNum = notSet; // ���߿� �÷��̾�� ���� ��ư���� �ٲܰ�
        }
        else
        {
            for (int i = 0; i < WeaponList.Count; i++)
            {
                if (WeaponList[i] == _musicWeapon.WeaponData.itemName)
                {
                    notSet = i;
                    break;
                }
            }

            // ���� ���⸦ ã�� (��: WeaponSpawnPos�� �ڽ����� �����ϴ� ����)
            Transform slot = WeaponSpawnPos[notSet];
            musicWeapon = slot.GetComponentInChildren<MusicWeapon>(); // ���� ���� �Ҵ�

            Debug.Log($"{WeaponList[notSet]}�� Count++");
            setWeaponNum = notSet; // ���߿� �÷��̾�� ���� ��ư���� �ٲܰ�

            if (musicWeapon != null)
                CheckOldWeapon(notSet);
            else
                Debug.LogWarning("���� ���⸦ ã�� �� ����.");
        }
    }


    public void CheckOldWeapon(int num) // �Ķ���� Player
    {
        musicWeapon.Count++;
        if (musicWeapon.Count > musicWeapon.WeaponData.WeaponMaxCount)
        {
            musicWeapon.OnUpgrade?.Invoke(num); //�̰� count�ƴ� notSet�����;���
        }
    }

    public void GoProjectile(MusicWeapon weapon,Vector3 targetPos)
    {
        if (weapon == null)
        {
            Debug.Log("Go Weapon null");
            return;
        }
        Debug.Log($"Go : {weapon.transform.name}");
        Projectile projectile = weapon.GetComponent<MusicWeapon>().WeaponData.Projectile;
        Projectile inst = Instantiate(projectile);
        inst.Init(inst.transform, targetPos);
    }

    public void GoAreaProjectile(MusicWeapon weapon,Vector3 targetPos)
    {
        if (weapon == null)
        {
            Debug.Log("Area Weapon null");
            return;
        }

        Debug.Log($"Area : {weapon.transform.name}");
        AreaProjectile areaProjectile = weapon.GetComponent<MusicWeapon>().WeaponData.AreaProjectile;
        AreaProjectile inst = Instantiate(areaProjectile);
        inst.Init(inst.transform, targetPos);
    }
}
