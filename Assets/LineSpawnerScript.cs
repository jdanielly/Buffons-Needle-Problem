using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpawnerScript : MonoBehaviour
{
    private LogicScript logic;
    public GameObject line;
    private int lineCount = 20;
    private float lineDistance = 0;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        // float needleLength = 3; // logic.getNeedleLength();
        Vector3 boundsMin = gameObject.GetComponent<Renderer>().bounds.min;
        Vector3 boundsMax = gameObject.GetComponent<Renderer>().bounds.max;

        float planeLength = Mathf.Abs(boundsMax.x - boundsMin.x);
        lineDistance = planeLength / (float)lineCount;
        Vector3 spawnPoint = new Vector3(boundsMin.x, boundsMax.y, 0);


        Debug.Log(lineDistance  + " " + planeLength);
        for(float i = 0; i <= planeLength; i += lineDistance)
        {
            Instantiate(line, spawnPoint, line.transform.rotation);
            spawnPoint += new Vector3(1, 0, 0) * lineDistance;
        }
    }

    public float getLineDistance()
    {
        return lineDistance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
