using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public struct PlayerInput
{
    private Vector3 _MovementVector;

    public Vector3 MovementVector
    {
        internal set { _MovementVector = value; }
        get { return _MovementVector; }
    }
}

public class INPUT_MANAGER : MonoBehaviour
{
    enum InputType
    {
        KeyMouse,
        VR_Index,
        VR_Oculus
    }

    InputType inputType = InputType.KeyMouse;

    List<InputDevice> inputDevices;
    InputDevice vrDevice;
    XRNode leftHand = XRNode.LeftHand;
    XRNode rightHand = XRNode.RightHand;

    internal PlayerInput playerInput;

    private void OnEnable()
    {
        if (!vrDevice.isValid)
            GetVRDevice();
    }

    // Start is called before the first frame update
    // internal virtual void Start()
    protected void Start()
    {
        playerInput = new PlayerInput();

        
    }

    // Update is called once per frame
    protected void InputUpdateLoop()
    {
        UpdateMovementVector();
    }

    #region VR Devices
    void GetVRDevice()
    {
        inputDevices = new List<UnityEngine.XR.InputDevice>();
        InputDevices.GetDevicesAtXRNode(rightHand, inputDevices);
        vrDevice = inputDevices.FirstOrDefault();

        print("Got Here");

        foreach (var device in inputDevices)
        {
            Debug.Log(string.Format("Device found with name '{0}' and role '{1}'", device.name, device.role.ToString()));
        }
    }
    #endregion

    #region Movement Information
    internal virtual void UpdateMovementVector()
    {
        Vector3 movementVector = new Vector3();

        switch (inputType)
        {
            case InputType.KeyMouse:
                movementVector = UpdateMovementVector_KeyMouse( movementVector );
                break;
            case InputType.VR_Index:
                UpdateMovementVector_Index();
                break;
            case InputType.VR_Oculus:
                UpdateMovementVector_Oculus();
                break;
            default:
                break;
        }

        // print( movementVector );

        playerInput.MovementVector = movementVector;
    }

    Vector3 UpdateMovementVector_KeyMouse(Vector3 _movementVector)
    {
        bool _w = Input.GetKey(KeyCode.W);
        bool _s = Input.GetKey(KeyCode.S);
        bool _a = Input.GetKey(KeyCode.A);
        bool _d = Input.GetKey(KeyCode.D);

        if ( _w && !_s  )
            _movementVector.z = 1.0f;
        else if ( _s && !_w )
            _movementVector.z = -1.0f;

        if ( _a && !_d )
            _movementVector.x = -1.0f;
        else if ( _d && !_a )
            _movementVector.x = 1.0f;

        _movementVector.Normalize();

        return _movementVector;
    }

    void UpdateMovementVector_Index()
    {

    }

    void UpdateMovementVector_Oculus()
    {

    }
    #endregion
}
