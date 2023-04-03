using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    private int maxColl;
    private int needleFCollisions;
    public SpawnerScript spawner;
    
    public GameObject needle;
    public GameObject lineSpawner;

    public int needlesCollisions = 0;
    public float needleLength;
    public int maxNeedles;
    public int dropedNeedles;
    public double piAprox;
    public float lineDistance;



    void Start()
    {
        needleLength = Get_Height(needle);
        lineDistance = lineSpawner.GetComponent<LineSpawnerScript>().getLineDistance();
    }
    public void addScore()
    {
        if (dropedNeedles < maxNeedles)
        {
            if (needlesCollisions > maxColl)
            {
                needlesCollisions++;
            }
            else
            {
                needlesCollisions++;
                needleFCollisions = needlesCollisions;
            }
        }
    }

    void Update()
    {
        maxColl = (int)((needleLength * 2 * maxNeedles) / (lineDistance * nestedValue));
        dropedNeedles = spawner.getDropCount();
        lineDistance = lineSpawner.GetComponent<LineSpawnerScript>().getLineDistance();

        piAprox = (2 * (float)dropedNeedles * needleLength) / (lineDistance * (float)needleFCollisions); 
    }
    public int getMaxNeedles()
    {
        return maxNeedles;
    }

    public float getNeedleLength()
    {
        return needleLength;
    }

    public static float Get_Height(GameObject gameObject)
    {
        if (gameObject != null)
        {
            //debug.log(gameobject.getcomponent<renderer>().bounds.min.y);
            //debug.log(gameobject.getcomponent<renderer>().bounds.max.y);

            return Mathf.Abs(gameObject.GetComponent<Renderer>().bounds.max.y - gameObject.GetComponent<Renderer>().bounds.min.y) * 0.94f;
        }
        return 0;
    }
    private float nestedValue = 3.14159265f;
}
