using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    private Vector3 cameraPosition;
    private Quaternion cameraRotation;

    private Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float smoothness;

    // Start is called before the first frame update
    void Start()
    {
        initialiseCamera();
        setCameraOffset();
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }
    
    private void initialiseCamera()
    {
        cameraPosition = new Vector3(0, 7.5f, -6);
        cameraRotation = Quaternion.Euler(new Vector3(48, 0, 0));

        transform.position = cameraPosition;
        transform.rotation = cameraRotation;
    }

    private void setCameraOffset()
    {
        cameraOffset = transform.position - player.transform.position;
    }

    private void followPlayer()
    {
        Vector3 newPos = player.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothness);
    }
}
