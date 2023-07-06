using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExtraPerry.Shadow.WeatherApp.UI
{
    public class MenuControlManager : MonoBehaviour
    {
        [SerializeField]
        private Transform positionSource;
        [SerializeField]
        private float placementDistance = 2;
        [SerializeField]
        private float placementVerticalPosition = 2.2f;
        [SerializeField]
        private float followDistance = 2;
        [SerializeField]
        private float followHorizontalPositionOffset = 1.635002f;
        [SerializeField]
        private float followVerticalPosition = 0.25f;
        

        [SerializeField]
        private GameObject menuDisplay;

        private bool isClosed = false;

        private bool isPlaced = true;

        private void Start()
        {
            StartCoroutine(DelayedPlacement());
        }

        private void Update()
        {
            if (isClosed)
            {
                Quaternion targetRotation = Quaternion.Euler(0, positionSource.rotation.eulerAngles.y - 180, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime);

                Vector3 direction = positionSource.forward;
                direction.y = 0;
                direction.Normalize();

                Vector3 xAxis = positionSource.right;
                xAxis.y = 0;
                xAxis.Normalize();

                Vector3 targetPosition = positionSource.position + (direction * followDistance) + (xAxis * followHorizontalPositionOffset);
                targetPosition.y = followVerticalPosition;
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
            }
            else
            {
                if (!isPlaced)
                {
                    PlaceInfront();
                }
            }
        }

        private IEnumerator DelayedPlacement()
        {
            yield return new WaitForSeconds(0.5f);
            PlaceInfront();
        }

        private void PlaceInfront()
        {
            Vector3 direction = positionSource.forward;
            direction.y = 0;
            direction.Normalize();

            Vector3 targetPosition = positionSource.position + (direction * placementDistance);
            targetPosition.y = placementVerticalPosition;
            transform.position = targetPosition;

            transform.rotation = Quaternion.Euler(0, positionSource.rotation.eulerAngles.y - 180, 0);

            isPlaced = true;
        }

        public void ToggleOpenClose()
        {
            if (isClosed)
            {
                isClosed = false;
                isPlaced = false;
                menuDisplay.SetActive(true);
            }
            else
            {
                isClosed = true;
                menuDisplay.SetActive(false);
            }
        }
    }
}