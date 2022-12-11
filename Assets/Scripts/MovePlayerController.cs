using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MovePlayerController : MonoBehaviour
{

    private InputDevice _targetDevice;

    public GameObject XrReference;
    public GameObject CameraReference;

    public float movementSpeed = 0.1f;

    void Start()
    {
        TryInitialize();
    }

    void TryInitialize()
    {
        var inputDevices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics =
            InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, inputDevices);

        if (inputDevices.Count == 0)
        {
            return;
        }

        _targetDevice = inputDevices[0];
    }

    void Update()
    {
        if (!_targetDevice.isValid)
        {
            TryInitialize();
        }
        else
        {

            float speed = movementSpeed;

            
            if (_targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButton)  && primaryButton == true)
            {
               
            }
             


            if (_targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool buttonPressed)  && buttonPressed == true)
            {
                speed = movementSpeed * 5;
            }


            if (_targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DaxisValue) && primary2DaxisValue != Vector2.zero)
            {
                Debug.Log("moveeee " + primary2DaxisValue);

                //Vector3.forward.


                Debug.Log(" angle " + XrReference.transform.rotation.eulerAngles.y);
                Quaternion headYaw = Quaternion.Euler(0, CameraReference.transform.eulerAngles.y, 0);
                Vector3 direction = headYaw * new Vector3(primary2DaxisValue.x, 0, primary2DaxisValue.y);
        

                
                XrReference.transform.position += direction * Time.deltaTime * speed; // new Vector3(primary2DaxisValue.x, 0, primary2DaxisValue.y) * Time.deltaTime * 10.0f;
            }
           
            if (primaryButton) {
              XrReference.transform.position += new Vector3 (0, 0.5f, 0);
              }
        }
    }
}
