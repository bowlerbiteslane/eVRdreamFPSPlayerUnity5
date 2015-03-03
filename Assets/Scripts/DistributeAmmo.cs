using UnityEngine;
using System.Collections;

public class DistributeAmmo : MonoBehaviour {


    public WeaponManager wm;

    public float distributeSpeed = 3f;

    private float distTime = 0f;

    void OnTriggerEnter(Collider col)
    {
        Distribute(col.gameObject);
    }

    void OnTriggerStay(Collider col){
        distTime += Time.deltaTime;
        if(distTime > distributeSpeed)
        {
            Distribute(col.gameObject);
            distTime = 0f;
        }
    }


    // distributes ammo to the currently equipped Gun Behaviour - automatically checks if Weapon Behaviour is a gun behaviour
    private void Distribute(GameObject obj){
        if (obj.tag == "Player")
        {
            if (wm != null)
            {
                if (wm.CurrentWeaponBehaviour is GunBehaviour)
                {
                    ((GunBehaviour)wm.CurrentWeaponBehaviour).PickUpAmmoClip();
                }
                else
                {
                    Debug.Log("Weapon Behaviour is not a gun behaviour.");
                }
            }
            else
            {
                Debug.Log("Player does not have a valid WeaponManager object attached.");
            }
            
        }
    }
}
