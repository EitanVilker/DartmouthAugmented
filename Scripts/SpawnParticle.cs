using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpawnParticle : MonoBehaviour, IVirtualButtonEventHandler
{

    public TrackableBehaviour theTrackable;
    public GameObject vButtonObjParticle;
    public GameObject prefabParticle;
    private bool particleOn = false;

    // Use this for initialization
    void Start()
    {
        vButtonObjParticle = GameObject.Find("particle");
        vButtonObjParticle.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    // Update is called once per frame
    void Update()
    {
    }

    // when button is pressed
    public void OnButtonPressed(VirtualButtonBehaviour vButt2)
    {

        //Debug.Log("````````````````````````````````button pressed  " );
        Creature particle = new Particle();

        if (!particleOn)
        {
            particle = new Particle();
            particle.SpawnSelf(prefabParticle, theTrackable);
            CreatureManager.AddCreature(particle);
        }
        else {
            CreatureManager.RemoveCreature(particle);
        }

        CreatureManager.ChangeParticleState(particleOn);

    }

    // when button is released
    public void OnButtonReleased(VirtualButtonBehaviour vButt2)
    {
    }
}