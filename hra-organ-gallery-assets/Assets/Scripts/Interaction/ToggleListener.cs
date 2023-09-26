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
            Debug.Log($"I am {mapping} and I get {toggleMapping}");
            if (toggleMapping == mapping)
            {
                Debug.Log(toggleMapping.GetType());
                //Keep All should be a button and should toggle all the toggle buttons altogether
                if(toggleMapping.ToString().ToLower().Contains("keep") || toggleMapping.ToString().ToLower().Contains("hide"))
                {
                    Debug.Log($"Inside keep/hide, received {toggleMapping}");
                    try
                    {
                        GameObject[] go = GameObject.FindGameObjectsWithTag("Organs");
                        foreach(GameObject organ in go)
                        {
                            meshRenderers = organ.transform.GetComponentsInChildren<MeshRenderer>();
                            if (meshRenderers.Length > 0)
                            {
                                foreach (MeshRenderer item in meshRenderers)
                                {
                                    item.enabled = isOn;

                                }
                            }
                            else
                            {
                                organ.GetComponent<MeshRenderer>().enabled = isOn;
                            }
                        }
                        //gameObject.SetActive(isOn); //replace with turning off mesh renderer
                    }
                    catch (MissingComponentException)
                    {
                        Debug.Log($"No children for {toggleMapping}");
                    }

                }
                else
                {
                    try
                    {
                        meshRenderers = gameObject.transform.GetComponentsInChildren<MeshRenderer>();
                        if (meshRenderers.Length > 0)
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
}