using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : INPUT_MANAGER
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.InputUpdateLoop();

        Vector3 newPos = gameObject.transform.position;

        newPos += playerInput.MovementVector * 5.0f * Time.deltaTime;

        gameObject.transform.position = newPos;
    }
}
