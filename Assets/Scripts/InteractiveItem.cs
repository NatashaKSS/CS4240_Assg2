using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRStandardAssets.Utils {
    public class InteractiveItem : MonoBehaviour {
        [SerializeField] private Material m_NormalMaterial;
        [SerializeField] private Material m_OverMaterial;
        [SerializeField] private Material m_ClickedMaterial;
        [SerializeField] private Material m_DoubleClickedMaterial;
        [SerializeField] private VRInteractiveItem m_InteractiveItem;
        [SerializeField] private Renderer m_Renderer;
    
        private void Awake() {
            m_Renderer.material = m_NormalMaterial;
        }

        private void OnEnable() {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut+= HandleOut;
            m_InteractiveItem.OnClick += HandleClick;
            m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
        }

        private void OnDisable() {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
            m_InteractiveItem.OnClick -= HandleClick;
            m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
        }

        private void HandleOver() {
            Debug.Log("Show over state");
            m_Renderer.material = m_OverMaterial;
        }

        private void HandleOut() {
            Debug.Log("Show out state");
            m_Renderer.material = m_NormalMaterial;
        }

        private void HandleClick() {
            Debug.Log("Show click state");
            m_Renderer.material = m_ClickedMaterial;
        }

        private void HandleDoubleClick() {
            Debug.Log("Show double click state");
            m_Renderer.material = m_DoubleClickedMaterial;
        }
    }
}

