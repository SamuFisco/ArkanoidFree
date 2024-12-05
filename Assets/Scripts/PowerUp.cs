using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject powerUp;
    public float velocidad = 2f;
    // Start is called before the first frame update
    

    // Update is called once per frame
    public void PowerUpActivo()
    {
        if(powerUp)
        {
            powerUp.SetActive(false);
        }
        else
        {
            Input.GetKey("y");
            powerUp.SetActive(true);
        }
        
       
    }

    private void Start()
    {
       
       

        

    }
   
}
