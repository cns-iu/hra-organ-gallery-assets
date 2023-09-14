using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleOrgans : MonoBehaviour
{
    public string organTag;
    GameObject toggle;
    GameObject[] go;
    Toggle m_toggle;
    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.FindGameObjectsWithTag(organTag);
        toggle = this.gameObject.transform.GetChild(0).gameObject;
        m_toggle = toggle.GetComponent<Toggle>();
        print(toggle.name);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < go.Length; i++)
        {
            go[i].SetActive(false);
        }
    }
}
