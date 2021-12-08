using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image EnergyFill;
    public float maxEnergy = 100;
    public float currentEnergy;

    bool isZap;

    // Start is called before the first frame update
    void Start()
    {
        isZap = false;
        currentEnergy = maxEnergy;
        EnergyFill.fillAmount = (currentEnergy / maxEnergy);
    }

    void subtractEnergyTest()
    {
        currentEnergy -= 25;

        EnergyFill.fillAmount = ( currentEnergy / maxEnergy );
    }

    // Update is called once per frame
    void Update()
    {
        isZap = Input.GetKeyDown(KeyCode.Mouse1);

        if (isZap && currentEnergy > 25)
        {
            isZap = false;
            subtractEnergyTest();
        }
    }
}
