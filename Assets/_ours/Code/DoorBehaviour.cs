using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public Vector3 closedStateEuler;
    public Vector3 openStateEuler;

    private Quaternion closedState;
    private Quaternion openState;

    public float interpolation;
    private bool opening = true;

    // Start is called before the first frame update
    void Start()
    {
        closedState = Quaternion.Euler(closedStateEuler);
        openState = Quaternion.Euler(openStateEuler);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeInterpolation();
        Quaternion newRotation = Quaternion.Lerp(openState, closedState, interpolation);
        transform.rotation = newRotation;
        Debug.Log("New rotation: " + newRotation.eulerAngles);
    }

    private void ChangeInterpolation()
    {
        if (opening && interpolation < 1.0)
        {
            interpolation += Time.deltaTime / 2;
        }
        else if (!opening && interpolation > 0)
        {
            interpolation -= Time.deltaTime / 2;
        }

        if (interpolation <= 0)
        {
            interpolation = 0.001f;
            opening = !opening;
        } else if (interpolation >= 1)
        {
            interpolation = 0.999f;
            opening = !opening;
        }
    }
}
