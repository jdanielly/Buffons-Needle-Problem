using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNeedle : MonoBehaviour
{
    private float elapsedTime = 0;
    public float maxTime = 10;
    private bool encountered = false;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime < maxTime)
        {
            elapsedTime += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setEncountered(bool encountered)
    {
        this.encountered = encountered;
    }

    public bool getEncountered()
    {
        return encountered;
    }
}
