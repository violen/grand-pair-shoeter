using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifebarController : MonoBehaviour
{

    public LifepointsController lifepointsController;
    private float lifebarYSize;
    private float r;

    // Use this for initialization
    void Start()
    {
        lifepointsController = GameObject.FindObjectOfType<LifepointsController>();
        lifebarYSize = lifepointsController.GetLifepoints();

    }

    // Update is called once per frame
    void Update()
    {
        lifebarYSize = lifepointsController.GetLifepoints() / 100;
        if(lifebarYSize > 0) { 
            this.GetComponent<Image>().fillAmount = lifebarYSize;
        }
        /* TODO: make Lose-Scene and remove comments
        else
        {
            SceneManager.LoadScene("Lose");
        }
        */
    }

}
