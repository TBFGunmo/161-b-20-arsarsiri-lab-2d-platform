using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image HpBar;
    public float CurrentHealth;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthBarAdjust();
    }

    public void HealthBarAdjust() 
    {
        HpBar.fillAmount = CurrentHealth;
    }

}
