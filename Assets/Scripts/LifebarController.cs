using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        lifebarYSize = lifepointsController.GetLifepoints();
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, lifebarYSize);
    }

}
