using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

    public enum WeaponIndex
    {
        Melee = 0,
        Pistol = 1,
        SMG = 2,
        Machinegun = 3
    }

    private WeaponBehaviour[] inventory;
    private int inventorySize = 4;
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



    void Awake()
    {

        // populate player inventory with start weapons
        inventory = new WeaponBehaviour[inventorySize];
        WeaponBehaviour[] weaponsToPopulate = GetComponentsInChildren<WeaponBehaviour>();
        for (int i = 0; i < weaponsToPopulate.Length; i++)
        {
            AddWeapon(weaponsToPopulate[i]);
            weaponsToPopulate[i].gameObject.SetActive(false);
        }

        //set current weapon to first populated index in inventory
        for (int i = 0; i < inventorySize; i++)
        {
            Debug.Log("Inventory Iteration: " + i);
            if (inventory[i] != null)
            {
                currentWeapon = inventory[i].gameObject;
                currentWeaponBehaviour = inventory[i];
                currentWeapon.SetActive(true);
                break;
            }
        }

        if (currentWeapon == null)
        {
            Debug.Log("Weapon Manager inventory is empty.");
        }
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Alpha1))
            ChangeWeapon((int)WeaponIndex.Pistol);
        else if (Input.GetKey(KeyCode.Alpha2))
            ChangeWeapon((int)WeaponIndex.SMG);
        else if (Input.GetKey(KeyCode.Alpha3))
            ChangeWeapon((int)WeaponIndex.Machinegun);
        else if (Input.GetKey(KeyCode.Alpha4))
            ChangeWeapon((int)WeaponIndex.Melee);
    }

    void ChangeWeapon(int index)
    {
        if (!(index > inventory.Length) && inventory[index] != null)
        {
            currentWeapon.SetActive(false);
            currentWeapon = inventory[index].gameObject;
            currentWeapon.SetActive(true);
            currentWeaponBehaviour = currentWeapon.GetComponent<WeaponBehaviour>();
            //if (currentWeaponBehaviour is GunBehaviour)
                //Debug.Log("Ammo In Clip: " + ((GunBehaviour)currentWeaponBehaviour).AmmoInClip + " Clips: " + (((GunBehaviour)currentWeaponBehaviour).CurrentClips-1) + " Total Ammo: " + (((GunBehaviour)currentWeaponBehaviour).AmmoInClip + (((GunBehaviour)currentWeaponBehaviour).ClipSize * (((GunBehaviour)currentWeaponBehaviour).CurrentClips-1))));
        }
        else
        {
            Debug.Log("No weapon in that weapon slot.");
        }
        
    }

    void AddWeapon(WeaponBehaviour weapon)
    {
        if (weapon.WeaponIndex < inventorySize)
        {
            if (inventory[weapon.WeaponIndex] == null)
            {
                inventory[weapon.WeaponIndex] = weapon;
            }
            else
            {
                DropWeapon(inventory[weapon.WeaponIndex].GetComponent<WeaponBehaviour>());
                inventory[weapon.WeaponIndex] = weapon;
            }
            Debug.Log(weapon.gameObject + " added to weaponmanager at index = " + weapon.WeaponIndex);
        }
        else
        {
            Debug.Log("Weapon index exceeds inventory size. Please change weapon index to a value below " + inventorySize + ".");
        }
        
    }

    void DropWeapon(WeaponBehaviour weapon)
    {
        Debug.Log(inventory[weapon.WeaponIndex].gameObject + " being dropped by weaponmanager at index = " + inventory[weapon.WeaponIndex]);
        inventory[weapon.WeaponIndex] = null;
    }
}
