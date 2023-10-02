using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Interaction
{
    public class DistanceMapper : MonoBehaviour
    {
        private TMP_Text _textDistance;
        private float distance;
        [SerializeField]
        private Transform hmdCamera;
        [SerializeField]
        private Transform organGO;
        private Transform parentImage;
        void Start()
        {
            _textDistance = GetComponent<TMP_Text>();
            parentImage = gameObject.transform.parent.GetComponent<Transform>();
            // Debug.Log($"Parent image: {parentImage.name}");
            StartCoroutine(DisplayDistanceToObject());
        }

        // Update is called once per frame
        void Update()
        {
            // parentImage.transform.LookAt(2*(organGO.position- hmdCamera.position));
            parentImage.transform.rotation = Quaternion.LookRotation(organGO.position - hmdCamera.position);
            CalculateDistance(hmdCamera);
        }

        private void CalculateDistance(Transform hmdCamera)
        {
            
            distance = (hmdCamera.position - organGO.position).magnitude;
            // var ray = new Ray(origin: hmdCamera.transform.position, direction: hmdCamera.transform.forward);
            // if (Physics.Raycast(ray: ray, out RaycastHit hit))
            // {
            //     lastHit = hit.transform.gameObject;
            //     collision = hit.point;
            //     distanceToObject = Vector3.Distance(collision, hmdCamera.gameObject.transform.position);
            // }
        }
        private IEnumerator DisplayDistanceToObject()
        {
            while (true)
            {
                _textDistance.text = $"Distance to: {organGO.name}: {distance:0.00}m";
                yield return new WaitForSeconds(0.1f);
            }
        }

    }
}