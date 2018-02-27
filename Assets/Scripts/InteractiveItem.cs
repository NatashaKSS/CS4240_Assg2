using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VRStandardAssets.Utils {

	/**
	 * For the bullet only 
	 */
    public class InteractiveItem : MonoBehaviour {
		public GameManager GameManagerScript;

		public Audio_TargetHitScript SFX_TargetHit;
		public Audio_BulletPickupScript SFX_BulletPickup;
		public Audio_ShootScript SFX_Shoot;

		public Material m_NormalMaterial;
		public Material m_OverMaterial;

		public VRInteractiveItem m_InteractiveItem;
		public Renderer m_Renderer;
		public GameObject m_camera;
		public GameObject ShooterWeapon;
		public GameObject ScoreText;

		public int forceMagnitude;
    	
		private bool isHeld = false;

		void OnTriggerEnter(Collider other) {
			if (other.gameObject.CompareTag("target")) {
				Debug.Log("Bullet hit!");
				SFX_TargetHit.Play();
				GameManagerScript.SetScore(GameManagerScript.GetScore() + 1);
				ScoreText.transform.GetComponent<Text>().text = "Score: " + GameManagerScript.GetScore().ToString();
				GameManagerScript.SetWinningText();
				Destroy(other.gameObject);
			}
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
			Debug.Log("Show click state " + isHeld.ToString());

			if (!isHeld) {
				// Holding the bullet
				transform.SetParent(ShooterWeapon.transform);
				transform.GetComponent<Rigidbody> ().useGravity = false;
				isHeld = true;
				SFX_BulletPickup.Play();
			} else {
				// Throwing the bullet
				transform.SetParent(null);
				transform.GetComponent<Rigidbody>().AddForce(m_camera.transform.forward * forceMagnitude);
				transform.GetComponent<Rigidbody> ().useGravity = true;
				isHeld = false;
				GameManagerScript.SetShotsFired(GameManagerScript.GetShotsFired() + 1);
				SFX_Shoot.Play();
			}
        }

        private void HandleDoubleClick() {
            Debug.Log("Show double click state");
            
        }
    }
}

