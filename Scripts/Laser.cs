using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    float yMax;
    float yMin;
    Camera gameCamera;
    // Start is called before the first frame update
    void Start()
    {
        gameCamera = Camera.main;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > yMax)
        {
            Destroy(gameObject);
        }
        
        if (this.transform.position.y < yMin)
        {
            Destroy(gameObject);
        }
    }

}
