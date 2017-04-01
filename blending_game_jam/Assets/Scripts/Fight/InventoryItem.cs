using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour {

    [SerializeField]
    string m_name;
    [SerializeField]
    float m_damage;
    [SerializeField]
    float m_probabilityToHave;
    [SerializeField]
    List<Ennemy> m_vulnerableEnnemies;
    [SerializeField]
    float m_vulnerabilityEfficiency;
    [SerializeField]
    List<Ennemy> m_resistantEnnemies;
    [SerializeField]
    float m_resistanceEfficiency;

    public float GetProbability ()
    {
        return m_probabilityToHave;
    }

    public void Use ()
    {
        float damage = m_damage;
        Ennemy ennemy = InventoryManager.singleton.actualEnnemy;
        if (m_vulnerableEnnemies.Contains(ennemy))
        {
            damage *= m_vulnerabilityEfficiency;
        }
        else if (m_resistantEnnemies.Contains(ennemy))
        {
            damage -= m_damage * m_resistanceEfficiency;
        }
        ennemy.TakeDamage(damage);
    }
}
