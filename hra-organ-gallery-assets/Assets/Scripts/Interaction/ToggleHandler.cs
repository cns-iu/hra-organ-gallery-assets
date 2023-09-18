using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.Interaction
{
    public enum OrganMapping { Knees, Kidneys, Eyes, Uterus, Placenta, Ovaries, F_Tubes, M_Glands,
        U_Bladder, Urethra, Ureter, Thymus, Spleen, SpinalCord, S_Intestine, Skin, Prostate,
        Pelvis, Pancreas, Liver, Heart, BloodVasculature, L_Intestine, LymphNode,
        Brain, Trachea, Tonsils, Bronchus, Lungs, Larynx, All
    }
    public class ToggleHandler : MonoBehaviour
    {
        public static event Action<OrganMapping, bool> OnToggle;
        [SerializeField] private List<Toggle> toggles = new List<Toggle>();

        private void Awake()
        {
            for (int i = 0; i < toggles.Count; i++)
            {
                Toggle toggle = toggles[i];
                toggle.onValueChanged.AddListener(
                 (isOn) =>
                 {
                     OrganMapping organId = toggle.GetComponent<ToggleIdentity>().id;
                     OnToggle?.Invoke(organId, isOn);
                 }
                    );
            }
        }

    }
}