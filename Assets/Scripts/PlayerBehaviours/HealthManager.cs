using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

    [SerializeField]
    private float health = 100f;

    public float Health
    {
        get { return health; }
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Overkill: " + -health);
        Destroy(this.gameObject);
    }
}
