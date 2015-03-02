using UnityEngine;
using System.Collections;

public class GunBehaviour : WeaponBehaviour {

    [SerializeField]
    private int clipSize = 10;
    [SerializeField]
    private int maxClips = 1;
    [SerializeField]
    private int currentClips = 1;
    [SerializeField]
    private int ammoInClip = 10;
    [SerializeField]
    private float gunFlashLength = 0.1f;

    private AudioSource gunshotAudio = null;
    private bool pointLightOn;
    private float timeCnt;

    private GameObject pointLight;


	// Use this for initialization
	void Start () {

        pointLightOn = false;
        timeCnt = 0f;
        pointLight = GameObject.Find("BarrelEnd/Point light");
        gunshotAudio = gameObject.GetComponent<AudioSource>();
        if (pointLight == null)
        {
            Debug.Log("Cannot find reference to Point Light. Script Disabled");
            this.enabled = false;
        }
        if (gunshotAudio == null)
        {
            Debug.Log("Cannot find reference to AudioSource. Script Disabled");
            this.enabled = false;
        }
        Debug.Log("Ammo In Clip: " + ammoInClip + " Total Ammo: " + (ammoInClip + clipSize * currentClips));

	}
	
	// Update is called once per frame
	void Update () {
        timeCnt += Time.deltaTime;
        if (pointLightOn && timeCnt > gunFlashLength)
        {
            //disable point light
            pointLightOn = false;
            pointLight.light.enabled = false;
            timeCnt = 0f;
        }

	}

    public void PickUpAmmoClip()
    {
        if (currentClips < maxClips)
        {
            currentClips++;
        }
    }

    public bool Reload()
    {
        if (currentClips > 0)
        {
            Debug.Log("Reloading...");
            currentClips--;
            ammoInClip = clipSize;
            return true;
        }
        Debug.Log("No clips left.");
        return false;
    }


    public override bool TriggerAttack()
    {
        // update Ammo
        if (ammoInClip > 0)
        {
            ammoInClip--;
            Debug.Log("Ammo In Clip: " + ammoInClip + " Total Ammo: " + (ammoInClip + clipSize * currentClips));
            // other gun effects
            pointLightOn = true;
            pointLight.light.enabled = true;
            timeCnt = 0f;
            gunshotAudio.Play();
            return true;
        }
        else
        {
            Reload();
            return false;
            /*
            if (Reload())
            {
                
                return true;
            }
            else
            {
                return false;
            }
             */
        }        
    }
}
