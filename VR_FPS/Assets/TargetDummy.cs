using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    float Timer;

    // Start is called before the first frame update
    void Awake()
    {
        SetState = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer > 0f)
        {
            Timer -= Time.deltaTime;
            if(Timer <= 0f)
            {
                SetState = false;
            }
        }
    }

    public void NewPosition( Vector3 _newPos, float _timerMax )
    {
        gameObject.transform.position = _newPos;
        Timer = _timerMax;
        SetState = true;
    }

    public void TakeDamage()
    {
        Timer = 0f;
        SetState = false;

        // Connect with TargetDummyManager to report death
    }

    bool SetState
    {
        set
        {
            gameObject.GetComponent<MeshRenderer>().enabled = value;
            gameObject.GetComponent<Collider>().enabled = value;
        }
    }
}
