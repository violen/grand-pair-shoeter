using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandpaController : MonoBehaviour {

    public float grandpaMoveSpeed = 4f;
    float xMinPosition;
    float xMaxPosition;
    float yMinPosition;
    float yMaxPosition;

    // Use this for initialization
    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        // TODO: grandpa should stop movement at 10% to the left and at 80% to the right of the camera.
        // the values needs to be changed dependent on the background (lawn)
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(0.7f, 0, distance));
        xMinPosition = leftmost.x;
        xMaxPosition = rightmost.x;
        Vector3 bottommost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.05f, distance));
        Vector3 topmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.95f, distance));
        yMinPosition = bottommost.y;
        yMaxPosition = topmost.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * grandpaMoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * grandpaMoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position += Vector3.up * grandpaMoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position += Vector3.down * grandpaMoveSpeed * Time.deltaTime;
        }

        float newX = Mathf.Clamp(this.transform.position.x, xMinPosition, xMaxPosition);
        float newY = Mathf.Clamp(this.transform.position.y, yMinPosition, yMaxPosition);
        this.transform.position = new Vector3(newX, newY, transform.position.z);
    }
}
