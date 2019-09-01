using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CreatureManager : MonoBehaviour
{

    private static int _numCreatures;
    private static ArrayList _allCreatures;
    private static ArrayList _allCreaturesToDelete; // can't change the list all creatures while inside foreach
    private float _time;     
    public static float Zbot;
    public static float Ztop;
    public static bool particleState;

    // Use this for initialization
    void Start()
    {
        _time = 0;
        _numCreatures = 0;
        _allCreatures = new ArrayList();
        _allCreaturesToDelete = new ArrayList();
        particleState = false;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        // Update all current creatures
        foreach (Creature creature in _allCreatures)
        {
            creature.Update(_time);
        }

        if (_allCreaturesToDelete != null)
        {

            // There are creatures to delete
            foreach (Creature creature in _allCreaturesToDelete)
            {
                _allCreatures.RemoveAt(_allCreatures.IndexOf(creature));
                Destroy(creature.myMesh);
                _numCreatures--;
            }
            _allCreaturesToDelete.Clear();
        }

    }

    public static void AddCreature(Creature newCreature)
    {
        _allCreatures.Add(newCreature);
        _numCreatures++;
    }

    public static void RemoveCreature(Creature oldCreature)
    {
        //Debug.Log("adding creature to delete " + oldCreature.myMesh.name);
        _allCreaturesToDelete.Add(oldCreature);
    }

    public static void ChangeParticleState(bool isParticleOn)
    {
        particleState = isParticleOn;
        // broadcast to Particles that particle state has changed
        foreach (Creature creature in _allCreatures)
        {
            if (creature.GetType() == typeof(Particle)){
                creature.ChangeState(particleState);

            }
        }
    }

}

abstract public class Creature // Includes ToadA, ToadB, Candle, and Particle subclasses
{
    public GameObject myMesh;  // mesh game object to visually represent this insect

    abstract public void SpawnSelf(GameObject creaturePrefab, TrackableBehaviour parentObj);
    abstract public void Update(float time);
    abstract public void ChangeState(bool particleState);

}

public class Candle : Creature
{

    private float xPosition;
    private float yPosition;
    private float zPosition;


    public override void SpawnSelf(GameObject CandlePrefab, TrackableBehaviour parentObj)
    {
        //Debug.Log("++++++++++++ spawning insect mesh");
        xPosition = 0f;
        yPosition = 25f;
        zPosition = 0f;
        Vector3 startPos = parentObj.transform.position;

        startPos.x += xPosition;
        startPos.y += yPosition;
        myMesh = GameObject.Instantiate(CandlePrefab, startPos, Quaternion.identity) as GameObject;
        myMesh.transform.parent = parentObj.transform;

    }
    public override void Update(float time)
    {
    
    }

    public override void ChangeState(bool particleState)
    {
    }
}

public class Particle : Creature // Appears around the magician, Jace, upon button press
{

    private float xPosition;
    private float yPosition;
    private float zPosition;
    private bool particleOn = false;


    public override void SpawnSelf(GameObject CandlePrefab, TrackableBehaviour parentObj)
    {
        //Debug.Log("++++++++++++ spawning insect mesh");
        Vector3 startPos = parentObj.transform.position;
        startPos.x += 0f;
        startPos.y += 0f;
        myMesh = GameObject.Instantiate(CandlePrefab, startPos, Quaternion.identity, parentObj.transform) as GameObject;
        particleOn = true;

    }
    public override void Update(float time)
    {
    }

    public override void ChangeState(bool particleState)
    {
    //    if (particleState)
    //    {
    //        // initialize values to create an orbit
    //        //_curRadiusIncrement = Random.Range(-0.02f, -0.04f);
    //        //Debug.Log("LOOK! a light! " + _curRadiusIncrement);
    //        CreatureManager.RemoveCreature(this);
    //    }
    //    else
    //    {
    //        // initialize values to fly away
    //        //_curRadiusIncrement = Random.Range(0.02f, 0.04f);
    //        //Debug.Log("fly away fly away fly away my little doves " + _curRadiusIncrement);
    //    }
    }
}

public class ToadA : Creature // Has idle animation
{

    public override void SpawnSelf(GameObject bugPrefab, TrackableBehaviour parentObj)
    {
        //Debug.Log("++++++++++++ spawing gnat mesh");
        Vector3 startPos = parentObj.transform.position;
        startPos.x += 15f;
        startPos.y += 5f;
        myMesh = GameObject.Instantiate(bugPrefab, startPos, Quaternion.identity, parentObj.transform) as GameObject;

    }
    public override void Update(float time)
    {

    }
    public override void ChangeState(bool anyState)
    {

    }
}

public class ToadB : Creature // This toad catches bugs with its tongue
{

    public override void SpawnSelf(GameObject ToadBPrefab, TrackableBehaviour parentObj)
    {
        //Debug.Log("++++++++++++ spawning insect mesh");
        Vector3 startPos = parentObj.transform.position;
        startPos.x += -20f;
        startPos.y += -10f;
        myMesh = GameObject.Instantiate(ToadBPrefab, startPos, Quaternion.identity, parentObj.transform) as GameObject;
    }

    public override void Update(float time)
    {

    }

    public override void ChangeState(bool anyState)
    {

    }
}

