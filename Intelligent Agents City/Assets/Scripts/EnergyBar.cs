using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;
   
    //Τιμές που δίνουμε για τον Slider του npc μας
    public void SetMaxEnergy(float energy)
    {
        slider.maxValue = energy;
        slider.value = energy;
    }

    public void SetEnergy(float energy)
    {
        slider.value = energy;
    }
}
