using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour {

    [SerializeField]
    float m_maxHitpoint = 2;
    [SerializeField]
    float m_damage = 1;
    public Ennemy.category monsterCategory;

    public enum category
    {
        Zombie, Vampire, Demon, Werewolf, Fairy, SpiderWoman, Ent, Minotaur, Lamia
    }

    [SerializeField]
    float m_hitpoint;

    private void Start()
    {
        m_hitpoint = m_maxHitpoint;
    }

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
