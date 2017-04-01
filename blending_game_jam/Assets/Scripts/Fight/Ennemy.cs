using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour {

    [SerializeField]
    float m_maxHitpoint;
    [SerializeField]
    float m_damage;

    float m_hitpoint;

	public void TakeDamage (float damage)
    {
        m_hitpoint -= damage;
        if (m_hitpoint <= 0)
        {
            Die();
        }
    }

    protected void Die ()
    {
        // dying stuff
    }
}
