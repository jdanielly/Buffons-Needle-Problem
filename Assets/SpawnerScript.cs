using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public float timeBtwSpawn = 0.001f;
    private float currentTime = 0, needleLength = 0;

    public GameObject needle;
    private Vector3 minSpawn = Vector3.zero;  
    private Vector3 maxSpawn = Vector3.zero;

    public LogicScript logic;
    public int maxNeedleDrop = 0;
    private int dropCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        minSpawn = GetComponent<Renderer>().bounds.min;
        maxSpawn = GetComponent<Renderer>().bounds.max;

        needleLength = Get_Height(needle);

        minSpawn.x += needleLength / 2;
        maxSpawn.x -= needleLength / 2;

        minSpawn.z += needleLength / 2;
        maxSpawn.z -= needleLength / 2;
        maxNeedleDrop = logic.getMaxNeedles();
    }

    // Update is called once per frame
    void Update()
    {
        if (dropCount < maxNeedleDrop)
        {
            if (currentTime < timeBtwSpawn)
            {
                currentTime += Time.deltaTime;
            }
            else
            {
                //Debug.Log("Spawning needle");
                Vector3 randPos = new Vector3(Random.Range(minSpawn.x, maxSpawn.x), Random.Range(minSpawn.y, maxSpawn.y), Random.Range(minSpawn.z, maxSpawn.z));
                GameObject actualNeedle = Instantiate(needle, randPos, Random.rotationUniform);
                actualNeedle.GetComponent<Renderer>().material.color = Random.ColorHSV();
                actualNeedle.transform.localScale *= 0.94f;

                randPos = new Vector3(Random.Range(minSpawn.x, maxSpawn.x), Random.Range(minSpawn.y, maxSpawn.y), Random.Range(minSpawn.z, maxSpawn.z));
                actualNeedle = Instantiate(needle, randPos, Random.rotationUniform);
                actualNeedle.GetComponent<Renderer>().material.color = Random.ColorHSV();
                actualNeedle.transform.localScale *= 0.94f;
                currentTime = 0;

                dropCount += 2;
            }
        }
    }
    public static float Get_Height(GameObject gameObject)
    {
        if (gameObject != null) 
        {
            //debug.log(gameobject.getcomponent<renderer>().bounds.min.y);
            //debug.log(gameobject.getcomponent<renderer>().bounds.max.y);

            return Mathf.Abs(gameObject.GetComponent<Renderer>().bounds.max.y - gameObject.GetComponent<Renderer>().bounds.min.y);
        }
        return 0;
    }

    public int getDropCount()
    {
        return dropCount;
    }
}
