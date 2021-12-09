using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image EnergyFill;
    public Image HealthFill;
    public float maxEnergy = 100;
    public float maxHealth = 100;
    public float currentHealth;
    public float currentEnergy;

    public bool isStunRange = false;
    bool isZap = false;

    public shark shark;

    // Start is called before the first frame update
    void Start()
    {
        shark = FindObjectOfType<shark>();
        currentEnergy = maxEnergy;
        EnergyFill.fillAmount = (currentEnergy / maxEnergy);
        currentHealth = maxHealth;
        HealthFill.fillAmount = (currentEnergy / maxEnergy);
    }

    public void subtractHealth(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        HealthFill.fillAmount = (currentHealth / maxHealth);
    }

    public void subtractEnergy(int amount)
    {
        currentEnergy -= amount;
        if (currentEnergy < 0)
        {
            currentEnergy = 0;
        }

        EnergyFill.fillAmount = (currentEnergy / maxEnergy);
    }

    public void addEnergy(int amount)
    {
        currentEnergy += amount;
        if (currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }

        EnergyFill.fillAmount = (currentEnergy / maxEnergy);

    }

    public void Stun()
    {
        isStunRange = true;
        shark.getStunned();
    }

    public void endStun()
    {
        isStunRange = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
