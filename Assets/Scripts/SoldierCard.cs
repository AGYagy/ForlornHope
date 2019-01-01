using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SoldierCard : Card {
    private Soldier template;
    private SoldierBarManager soldierBarManager;
    private TroopBarManager troopBarManager;
    public void Initialize(Soldier soldier)
    {
        manager = GameObject.Find("CardManager");
        template = soldier;
        transform.Find("CardType").gameObject.GetComponent<Text>().text = template.type;
        soldierBarManager = GameObject.Find("SoldierManager").GetComponent<SoldierBarManager>();
        troopBarManager = GameObject.Find("TroopManager").GetComponent<TroopBarManager>();
    }

    override public void Remove()
    {
        if (troopBarManager.HasSelected() != true) return;
        soldierBarManager.Add(template);
        gameObject.GetComponent<EventTrigger>().enabled = false;
        manager.GetComponent<HorizontalBarWithEffectManager>().Delete(gameObject);
        StartCoroutine(Fade(0.2f));
    }
}
