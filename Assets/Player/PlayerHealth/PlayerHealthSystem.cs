using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    [field: SerializeField] public float Health { get; private set; }
    [field: SerializeField] private CanvasGroup Black;
    [field: SerializeField] float coldDMG;
    [field: SerializeField] float healRate;

    [field: SerializeField] public bool isInCold;
    [field: SerializeField] public bool isInHeal;
    void Start()
    {
        isInCold = false;
        isInHeal = false;
    }

    public void TakeDmg(float dmg)
    {
        Health -= dmg;
        setBlack();
    }
    public void TakeHeal(float heal)
    {
        Health += heal;
        setBlack();
    }
    private void setBlack()
    {
        float a = 1-(Health/100);
        Black.alpha = a;
    }

    public void startTakeColdDMG()
    {
        isInCold = true;
        StartCoroutine("StartCDMG");
    }
    public void stopTakeColdDMG()
    {
        isInCold = false;
        StopCoroutine("StartCDMG");
    }
    IEnumerator StartCDMG()
    {
        while (true)
        {
            if (Health - coldDMG >= 0)TakeDmg(coldDMG);
            yield return new WaitForSeconds(0.02f);
        }
    }
    
    public void startHeal()
    {
        isInHeal = true;
        StartCoroutine("HealHealth");
    }
    public void stopHeal()
    {
        isInHeal = false;
        StopCoroutine("HealHealth");
    }
    IEnumerator HealHealth()
    {
        while (true)
        {
            if(Health+healRate<=100)TakeHeal(healRate);
            yield return new WaitForSeconds(0.02f);
        }
    }

}
