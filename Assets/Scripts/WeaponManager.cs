using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

    public GameObject[] weapons = new GameObject[4];
    private GameObject currentWeapon;
    private WeaponBehaviour currentWeaponBehaviour;

    public GameObject CurrentWeapon
    {
        get
        {
            return currentWeapon;
        }
    }

    public WeaponBehaviour CurrentWeaponBehaviour
    {
        get
        {
            return currentWeaponBehaviour;
        }
    }


    void Start()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i] != null)
            {
                weapons[i].SetActive(false);
            }
        }
        currentWeapon = weapons[0];
        currentWeapon.SetActive(true);
        currentWeaponBehaviour = currentWeapon.GetComponent<WeaponBehaviour>(); 
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
            ChangeWeapon(0);
        else if (Input.GetKey(KeyCode.Alpha2))
            ChangeWeapon(1);
        else if (Input.GetKey(KeyCode.Alpha3))
            ChangeWeapon(2);
        else if (Input.GetKey(KeyCode.Alpha4))
            ChangeWeapon(3);
    }

    void ChangeWeapon(int weaponIndex)
    {
        if (!(weaponIndex > weapons.Length) && weapons[weaponIndex]!=null)
        {
            currentWeapon.SetActive(false);
            currentWeapon = weapons[weaponIndex];
            currentWeapon.SetActive(true);
            currentWeaponBehaviour = currentWeapon.GetComponent<WeaponBehaviour>();
            
        }
    }
}
