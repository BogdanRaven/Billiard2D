using System;
using UnityEngine;

namespace GameMechanics
{
    public class RotateService : MonoBehaviour
    {
        private GameObject objectToRotate;

        private Camera mainCamera;
        private Vector3 screenPos;
        private float angleOffset;

        private bool canRotate;

        public void EnableRotation(bool canRotate, GameObject objectToRotate = null)
        {
            this.canRotate = canRotate;
            this.objectToRotate = objectToRotate;
            if (objectToRotate == null)
            {
                this.canRotate = false;
            }
        }

        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            if (!canRotate)
                return;

            Rotate(objectToRotate);
        }

        private void Rotate(GameObject gameObject)
        {
            if (Input.GetMouseButtonDown(0))
            {
                screenPos = mainCamera.WorldToScreenPoint(gameObject.transform.position);
                Vector3 vector3 = Input.mousePosition - screenPos;
                angleOffset =
                    (float) ((Mathf.Atan2(gameObject.transform.right.y, gameObject.transform.right.x) -
                              Math.Atan2(vector3.y, vector3.x)) *
                             Mathf.Rad2Deg);
            }
            else if (Input.GetMouseButton(0))
            {
                Vector3 vector3 = Input.mousePosition - screenPos;
                float angel = Mathf.Atan2(vector3.y, vector3.x) * Mathf.Rad2Deg;
                gameObject.transform.eulerAngles = new Vector3(0, 0, angel + angleOffset);
            }
        }
    }
}