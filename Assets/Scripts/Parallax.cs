using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    private Transform[] parallaxLayers;
    [SerializeField]
    private float[] parallaxFactors;
    [SerializeField]
    private float smoothing = 1f;

    private Transform cameraTransform;
    private Vector3 previousCameraPosition;

    void Awake()
    {
        cameraTransform = Camera.main.transform;
    }

    void Start()
    {
        previousCameraPosition = cameraTransform.position;
        parallaxFactors = new float[parallaxLayers.Length];

        for (int i = 0; i < parallaxLayers.Length; i++)
        {
            parallaxFactors[i] = parallaxLayers[i].position.z * -1;
        }
    }

    void Update()
    {
        for (int i = 0; i < parallaxLayers.Length; i++)
        {
            float xParallax = (previousCameraPosition.x - cameraTransform.position.x) * parallaxFactors[i];
            float yParallax = (previousCameraPosition.y - cameraTransform.position.y) * parallaxFactors[i];

            float backgroundTargetPosX = parallaxLayers[i].position.x + xParallax;
            float backgroundTargetPosY = parallaxLayers[i].position.y + yParallax;
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgroundTargetPosY, parallaxLayers[i].position.z);
            parallaxLayers[i].position = Vector3.Lerp(parallaxLayers[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }
        previousCameraPosition = cameraTransform.position;
    }
}
