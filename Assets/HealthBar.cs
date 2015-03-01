using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public GameObject character;
    float healthTotal;
    float healthCurrent;
    float healthBarWidthTotal;
    float healthBarWidthCurrent;

	// Use this for initialization
	void Start () {
        healthBarWidthTotal = this.transform.localScale.x;
        healthBarWidthCurrent = healthBarWidthTotal;
        healthTotal = character.GetComponent<HealthManager>().Health;
        healthCurrent = healthTotal;
	}
	
	// Update is called once per frame
	void Update () {
        healthCurrent = character.GetComponent<HealthManager>().Health;
        healthBarWidthCurrent = healthBarWidthTotal * (healthCurrent / healthTotal);
        this.transform.localScale = new Vector3(healthBarWidthCurrent, this.transform.localScale.y, this.transform.localScale.z);
	    
    }
}
