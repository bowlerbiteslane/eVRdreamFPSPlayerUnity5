using UnityEngine;
using System.Collections;

public class GunBehaviour : WeaponBehaviour {

    public float gunFlashLength = 0.1f;

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


    public override void TriggerAttack()
    {
        pointLightOn = true;
        pointLight.light.enabled = true;
        timeCnt = 0f;
        gunshotAudio.Play();
    }
}
