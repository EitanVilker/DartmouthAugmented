using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpawnNewCandle : MonoBehaviour, IVirtualButtonEventHandler
{

    public TrackableBehaviour theTrackable;
    public GameObject vButtonObjCandle;
    public GameObject prefabCandle;


    // Use this for initialization
    void Start()
    {
        vButtonObjCandle = GameObject.Find("candleSpawn");
        vButtonObjCandle.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    // Update is called once per frame
    void Update()
    {
    }

    // when button is pressed
    public void OnButtonPressed(VirtualButtonBehaviour vbuttonObjCandle)
    {
        Creature candle = new Candle();

        candle.SpawnSelf(prefabCandle, theTrackable);

        CreatureManager.AddCreature(candle);

    }

    // when button is released
    public void OnButtonReleased(VirtualButtonBehaviour vButt2)
    {
    }
}