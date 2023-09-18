using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Interaction
{

    public class ToggleListener : MonoBehaviour
    {
        [SerializeField] private OrganMapping mapping;
        MeshRenderer[] meshRenderers;
        private void Start()
        {
            ToggleHandler.OnToggle += ShowHide;
        }

        private void ShowHide(OrganMapping toggleMapping, bool isOn)
        {
            //Debug.Log($"I am {mapping} and I get {toggleMapping}");
            if (toggleMapping == mapping)
            {
                try
                {
                    meshRenderers = gameObject.transform.GetComponentsInChildren<MeshRenderer>();
                    if(meshRenderers.Length > 0)
                    {
                        foreach (MeshRenderer item in meshRenderers)
                        {
                            item.enabled = isOn;

                        }
                    }
                    else
                    {
                        gameObject.GetComponent<MeshRenderer>().enabled = isOn;
                    }
                        //gameObject.SetActive(isOn); //replace with turning off mesh renderer
                }
                catch (MissingComponentException)
                {
                    Debug.Log($"No children for {toggleMapping}");
                }
            }
        }
    }
}