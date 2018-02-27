using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VRStandardAssets.Utils {

	/**
	 * For the portal only 
	 */
	public class ResetButtonScript : MonoBehaviour {
		public Material m_NormalMaterial;
		public Material m_OverMaterial;
		public VRInteractiveItem m_InteractiveItem;
		public Renderer m_Renderer;

		private void Awake() {

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
			m_Renderer.material = m_OverMaterial;
		}

		private void HandleOut() {
			m_Renderer.material = m_NormalMaterial;
		}

		private void HandleClick() {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		private void HandleDoubleClick() {
			Debug.Log("Show double click state");

		}
	}
}

