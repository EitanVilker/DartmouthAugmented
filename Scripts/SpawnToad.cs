using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpawnToad : MonoBehaviour, IVirtualButtonEventHandler
{

    public TrackableBehaviour theTrackable;
    public GameObject vButtonObjToad;
    public GameObject prefabToadA;
    public GameObject prefabToadB;
    private int toadButtonPresses = 0;
    private Animator frogTongueController;

    // Use this for initialization
    void Start()
    {
        vButtonObjToad = GameObject.Find("toadSpawn");
        vButtonObjToad.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        frogTongueController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    // when button is pressed
    public void OnButtonPressed(VirtualButtonBehaviour vButt2)
    {

        //Debug.Log("````````````````````````````````button pressed  " );
        Creature toad;

        if (toadButtonPresses == 0)
        {
            toad = new ToadA();
            toad.SpawnSelf(prefabToadA, theTrackable);
            CreatureManager.AddCreature(toad);

        }

        if (toadButtonPresses == 1)
        {
            toad = new ToadB();
            toad.SpawnSelf(prefabToadB, theTrackable);
            CreatureManager.AddCreature(toad);
        }

        if (toadButtonPresses > 1)
        {
            // Play ToadB tongue animation
            frogTongueController.SetTrigger("trigger");

        }

        toadButtonPresses += 1;

    }

    // when button is released
    public void OnButtonReleased(VirtualButtonBehaviour vButt2)
    {
    }
}