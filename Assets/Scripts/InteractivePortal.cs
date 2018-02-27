using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRStandardAssets.Utils {

	/**
	 * For the portal only 
	 */
	public class InteractivePortal : MonoBehaviour {
		public VRInteractiveItem m_InteractiveItem;
		public Renderer m_Renderer;
		public GameObject m_camera;
		public Audio_TeleportScript SFX_Teleport;

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
			Debug.Log("Show over state");

		}

		private void HandleOut() {
			Debug.Log("Show out state");

		}

		private void HandleClick() {
			Debug.Log("Show click state");

			// Teleporting
			m_camera.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
			SFX_Teleport.Play();
		}

		private void HandleDoubleClick() {
			Debug.Log("Show double click state");

		}
	}
}

