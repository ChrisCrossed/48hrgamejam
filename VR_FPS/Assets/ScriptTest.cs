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

    private Transform thisFireball;
    private float fireballTimer;
    public float fireballTimerMax = 0.1f;
    private bool fireGun;
    private bool triggerPressed;

    // Start is called before the first frame update
    void Start()
    {
        Trigger.AddOnStateDownListener(TriggerDown, thisHand);
        Trigger.AddOnStateUpListener(TriggerUp, thisHand);

        thisFireball = handModel.transform.Find("Fireball");
    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is Up");
        triggerPressed = false;
    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is Down");
        if( !triggerPressed ) fireGun = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fireGun)
        {
            fireGun = false;
            fireballTimer = fireballTimerMax;

            thisFireball.GetComponent<MeshRenderer>().enabled = true;
        }

        if(fireballTimer > 0f)
        {
            fireballTimer -= Time.deltaTime;
            if (fireballTimer <= 0f)
            {
                fireballTimer = 0f;
                thisFireball.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
