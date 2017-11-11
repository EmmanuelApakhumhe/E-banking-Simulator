using UnityEngine;
using System.Collections;

namespace UETools.AquaGUI
{
	public class Button_Toggle : MonoBehaviour
	{
		private UnityEngine.UI.Button button = null;

		private GameObject buttonEnabled	= null;
		private GameObject buttonDisabled	= null;

		private bool isEnabled = true;

		public void Toggle()
		{
			isEnabled = !isEnabled;

			Refresh();
		}

		private void Awake()
		{
			button = gameObject.GetComponent<UnityEngine.UI.Button>();

			buttonEnabled	= gameObject.transform.Find("Buttons").Find("Button_Enabled").gameObject;
			buttonDisabled	= gameObject.transform.Find("Buttons").Find("Button_Disabled").gameObject;
		}

		private void Start()
		{
			Refresh();
		}

		private void Refresh()
		{
			if(button == null || buttonEnabled == null || buttonDisabled == null)
			{
				Debug.Log("Missing reference!");
				return;
			}

			buttonEnabled.SetActive(isEnabled);
			buttonDisabled.SetActive(!isEnabled);

			button.targetGraphic = isEnabled ? buttonEnabled.GetComponent<UnityEngine.UI.Image>() : buttonDisabled.GetComponent<UnityEngine.UI.Image>();
		}
	}
}
