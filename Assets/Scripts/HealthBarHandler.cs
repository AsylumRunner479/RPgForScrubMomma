using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHandler : MonoBehaviour
{
    //deisginates the health section
    public GameObject healthCanvas;
    public Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //makes the healthbar go down when they lose health
        if(healthBar.fillAmount < 1 && healthBar.fillAmount > 0)
        {
            healthCanvas.SetActive(true);
            healthCanvas.transform.LookAt(Camera.main.transform);
            healthCanvas.transform.Rotate(0, 180, 0);
        }
        else
        {
            healthCanvas.SetActive(false);
        }
    }
}
