using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour {

    [SerializeField]
    string m_name;
    //[SerializeField]
    //float m_damage;
    //[SerializeField]
    //float m_probabilityToHave;
    [SerializeField]
    List<Enemy.category> m_vulnerableEnemies;
    //[SerializeField]
    //float m_vulnerabilityEfficiency;
    [SerializeField]
    List<Enemy.category> m_resistantEnemies;
    //[SerializeField]
    //float m_resistanceEfficiency;

    //public float GetProbability ()
    //{
    //    return m_probabilityToHave;
    //}
    
    public List<Enemy.category> GetVulnerabilities ()
    {
        return m_vulnerableEnemies;
    }

    public void Use ()
    {
        float damage = 1;
        Enemy enemy = FightManager.singleton.actualEnemy;
        if (m_vulnerableEnemies.Contains(enemy.monsterCategory))
        {
            damage = 2;
        }
        else if (m_resistantEnemies.Contains(enemy.monsterCategory))
        {
            damage = 0;
        }
        enemy.TakeDamage(damage);
        Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
