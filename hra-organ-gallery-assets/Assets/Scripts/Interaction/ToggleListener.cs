using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Interaction
{

    public class ToggleListener : MonoBehaviour
    {
        [SerializeField] private OrganMapping mapping;

        private void Start()
        {
            ToggleHandler.OnToggle += ShowHide;
        }

        private void ShowHide(OrganMapping toggleMapping, bool isOn)
        {
            Debug.Log($"I am {mapping} and I get {toggleMapping}");
            if (toggleMapping == mapping) gameObject.SetActive(isOn); //replace with turning off mesh renderer

        }
    }
}