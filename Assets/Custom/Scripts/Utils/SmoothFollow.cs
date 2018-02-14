﻿// Smooth Follow from Standard Assets
// Converted to C# because I fucking hate UnityScript and it's inexistant C# interoperability
// If you have C# code and you want to edit SmoothFollow's vars ingame, use this instead.
using UnityEngine;
using System.Collections;

namespace com.terranovita.botretreat
{
    public class SmoothFollow : MonoBehaviour
    {

        // The target we are following
        public Transform target;
        // The distance in the x-z plane to the target
        public float distance = 5.0f;
        // the height we want the camera to be above the target
        public float height = 2.5f;
        // How much we
        public float heightDamping = 2.0f;
        public float rotationDamping = 3.0f;
        public Vector3 startPos;
        public Quaternion startRot;

        // Place the script in the Camera-Control group in the component menu
        [AddComponentMenu("Camera-Control/Smooth Follow")]

        void Start()
        {
            startPos = transform.localPosition;
            startRot = transform.localRotation;
        }

        void LateUpdate()
        {
            // Early out if we don't have a target
            if (!target)
            {
                transform.localPosition = startPos;
                transform.localRotation = startRot;
                return;
            } 

            // Calculate the current rotation angles
            float wantedRotationAngle = target.eulerAngles.y;
            float wantedHeight = target.position.y + height;

            float currentRotationAngle = transform.eulerAngles.y;
            float currentHeight = transform.position.y;

            // Damp the rotation around the y-axis
            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

            // Damp the height
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

            // Convert the angle into a rotation
            var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            // Set the position of the camera on the x-z plane to:
            // distance meters behind the target
            transform.position = target.position;
            transform.position -= currentRotation * Vector3.forward * distance;

            // Set the height of the camera
            transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

            // Always look at the target
            transform.LookAt(target);
        }
    }
}