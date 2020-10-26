using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using Valve.VR;

public class ScriptTest : MonoBehaviour
{
    public SteamVR_Action_Boolean Trigger;
    public SteamVR_Input_Sources thisHand;
    public GameObject handModel;

    // Start is called before the first frame update
    void Start()
    {
        Trigger.AddOnStateDownListener(TriggerDown, thisHand);
        Trigger.AddOnStateUpListener(TriggerUp, thisHand);
    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is Up");
        handModel.GetComponent<MeshRenderer>().enabled = true;

        foreach(MeshRenderer childMesh in handModel.transform.GetComponentsInChildren<MeshRenderer>())
            childMesh.enabled = true;
    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is Down");
        handModel.GetComponent<MeshRenderer>().enabled = false;

        foreach (MeshRenderer childMesh in handModel.transform.GetComponentsInChildren<MeshRenderer>())
            childMesh.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
