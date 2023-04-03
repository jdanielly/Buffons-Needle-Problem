using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        DestroyNeedle needle = other.GetComponent<DestroyNeedle>();
        if (!needle.getEncountered())
        {
            logic.addScore();
            needle.setEncountered(true);
        }
    }
}
