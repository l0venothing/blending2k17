using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour {

    public static FightManager singleton;

    public Ennemy actualEnnemy;

    //[SerializeField]
    //GameObject m_modelContainer;
    [SerializeField]
    GameObject m_inventoryContainer;
    [SerializeField]
    Transform m_ennemyContainer;
    //[SerializeField]
    //int m_itemNbr;

    List<Ennemy> m_ennemyPool = new List<Ennemy>();

    private void Start()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        GenerateEnnemyPool();
        SelectEnnemy();
    }

    public void GenerateEnnemyPool ()
    {
        InventoryItem[] items = m_inventoryContainer.GetComponentsInChildren<InventoryItem>();
        Ennemy model = m_ennemyContainer.gameObject.GetComponentInChildren<Ennemy>();
        foreach (InventoryItem item in items)
        {
            Ennemy newEnnemy = Instantiate(model.gameObject).GetComponent<Ennemy>();
            newEnnemy.transform.SetParent(m_ennemyContainer, false);
            int vulnerabilityNbr = Random.Range(0, item.GetVulnerabilities().Count);
            newEnnemy.monsterCategory = item.GetVulnerabilities()[vulnerabilityNbr];
            m_ennemyPool.Add(newEnnemy);
            newEnnemy.gameObject.SetActive(false);
        }
        model.gameObject.SetActive(false);
    }

    public void SelectEnnemy ()
    {
        actualEnnemy = m_ennemyPool[Random.Range(0, m_ennemyPool.Count)];
        actualEnnemy.gameObject.SetActive(true);
    }

    //public void GenerateInventory ()
    //{
        //m_modelContainer.SetActive(true);
        //InventoryItem[] models = m_modelContainer.GetComponentsInChildren<InventoryItem>();
        //float maxProba = 0;
        //foreach (InventoryItem model in models)
        //{
        //    maxProba += model.GetProbability();
        //}
        //for (int i = 0; i < m_itemNbr; i++)
        //{
        //    SelectNewItem();
        //}
        //m_modelContainer.SetActive(false);
    //}

    //void SelectNewItem ()
    //{
    //        float result = Random.Range(0, maxProba);
    //        float actualStep = 0;
    //        GameObject newIntem;
    //        foreach (InventoryItem model in models)
    //        {
    //            actualStep += model.GetProbability();
    //            if (result <= actualStep)
    //            {
    //                newIntem = Instantiate(model.gameObject);
    //                newIntem.transform.SetParent(m_inventoryContainer, false);
    //                return;
    //            }
    //        }
    //}
}
