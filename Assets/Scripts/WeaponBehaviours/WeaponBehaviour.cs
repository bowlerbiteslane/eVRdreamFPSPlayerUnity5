using UnityEngine;
using System.Collections;

public abstract class WeaponBehaviour : MonoBehaviour {

	[SerializeField]
    protected float fireRate = 0.5f;
    [SerializeField]
    protected float weaponReach = 2000f;
    [SerializeField]
    protected float weaponDamage = 25f;

    public float FireRate
    {
        get { return fireRate; }
    }
    public float WeaponReach
    {
        get { return weaponReach; }
    }

    public float WeaponDamage
    {
        get { return weaponDamage; }
    }


    public abstract void TriggerAttack();
}
