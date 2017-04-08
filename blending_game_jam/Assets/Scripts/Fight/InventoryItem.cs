using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public GameObject fightUI;
    private Animator animItem;
    private Animator monsterAnim;
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
    [SerializeField]
    AudioClip sound;
    //[SerializeField]
    //float m_resistanceEfficiency;

    //public float GetProbability ()
    //{
    //    return m_probabilityToHave;
    //}

    public List<Enemy.category> GetVulnerabilities()
    {
        return m_vulnerableEnemies;
    }

    public void Use()
    {
        if (!FightManager.singleton.stoping)
        {
            transform.SetParent(fightUI.transform, false);
            float damage = 1;
            Enemy enemy = FightManager.singleton.actualEnemy;
            monsterAnim = enemy.GetComponent<Animator>();
            animItem = gameObject.GetComponent<Animator>();
            animItem.enabled = true;
            if (m_vulnerableEnemies.Contains(enemy.monsterCategory))
            {
                damage = 2;
                monsterAnim.SetBool("monsterTouched", true);
            }
            else if (m_resistantEnemies.Contains(enemy.monsterCategory))
            {
                damage = 0;
            }
          
            enemy.TakeDamage(damage);
            FightManager.singleton.PlayFightSound(sound);
            StartCoroutine(DestroyObj(2));
        }
    }


    public IEnumerator DestroyObj(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
