using UnityEngine;
using System.Collections;

public class DirectToHealthManager : HealthManager {
    public GameObject healthManagerHolder = null;
    private HealthManager healthManager;

    public float damageModifier = 1;
    

    void Start()
    {
        if (healthManagerHolder == null)
        {
            Debug.Log("Must assign a GameObject with a health manager to this script. Disabling Script.");
            this.enabled = false;
            return;
        }
        healthManager = healthManagerHolder.GetComponent<HealthManager>();
        if (healthManager == null)
        {
            Debug.Log("The referenced GameObject does not appear to have a HealthManger script attached. DisablingScript.");
            this.enabled = false;
            return;
        }
    }

    public override void TakeDamage(float damage)
    {
        if(this.enabled)
            healthManager.TakeDamage(damage*damageModifier);
    }
}
