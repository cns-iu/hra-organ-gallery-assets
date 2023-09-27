using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.RuntimeScipts
{
    public class DestroyMaterial : MonoBehaviour
    {
        Material[] materials;
        MeshRenderer[] meshes;
        // Start is called before the first frame update
        void Start()
        {
            meshes = gameObject.transform.GetComponentsInChildren<MeshRenderer>();

        }

        // Update is called once per frame
        void Awake()
        {
            foreach (MeshRenderer mesh in meshes)
            {
                //mesh.materials = null;
                Debug.Log(mesh.name);
                mesh.enabled = false;
            }
        }
    }

}