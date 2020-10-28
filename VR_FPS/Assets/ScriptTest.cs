using System.Collections;
using System.Collections.Generic;
// using UnityEditor.Animations;
using UnityEngine;
using Valve.VR;

public class ScriptTest : MonoBehaviour
{
    public SteamVR_Action_Boolean Trigger;
    public SteamVR_Action_Vector2 Movement;
    public SteamVR_Input_Sources thisHand;
    public GameObject handModel;

    private Transform thisFireball;
    private float fireballTimer;
    public float fireballTimerMax = 0.1f;
    private bool fireGun;
    private bool triggerPressed;

    GameObject reticle_Back;
    GameObject reticle_Front;

    [SerializeField] GameObject targetDummyManager;

    // Start is called before the first frame update
    void Start()
    {
        // Each Trigger
        Trigger.AddOnStateDownListener(TriggerDown, thisHand);
        Trigger.AddOnStateUpListener(TriggerUp, thisHand);

        // Movement.AddOnAxisListener(MovementAxis, thisHand);
        // Movement.AddOnActiveBindingChangeListener(MovementAxis, thisHand);
        

        thisFireball = handModel.transform.Find("Fireball");

        reticle_Back = handModel.transform.Find("raycast_back").gameObject;
        reticle_Front = handModel.transform.Find("raycast_front").gameObject;
    }

    public void MovementAxis(SteamVR_Action_Vector2 inputVector, SteamVR_Input_Sources fromSource)
    {

    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        triggerPressed = false;
    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (!triggerPressed)
        {
            fireGun = true;

            FireBullet();
        }
    }

    void FireBullet()
    {
        targetDummyManager.GetComponent<TargetDummyManager>().IncrementShotsTaken();

        Vector3 fireVector = reticle_Front.transform.position - reticle_Back.transform.position;
        fireVector.Normalize();

        RaycastHit _hit;
        LayerMask enemyLayer = LayerMask.NameToLayer("Enemy");
        if (Physics.Raycast(reticle_Back.transform.position, fireVector, out _hit))
        {
            if(_hit.collider.gameObject.layer == enemyLayer)
            {
                _hit.collider.gameObject.GetComponent<TargetDummy>().TakeDamage();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Movement != null)
        {
            Vector2 output = new Vector2();

            if (Movement.changed)
            {
                output = Movement.axis;
            }

            print(output);
        }

        if( fireGun )
        {
            fireGun = false;
            fireballTimer = fireballTimerMax;

            thisFireball.GetComponent<MeshRenderer>().enabled = true;
        }

        if( fireballTimer > 0f )
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
