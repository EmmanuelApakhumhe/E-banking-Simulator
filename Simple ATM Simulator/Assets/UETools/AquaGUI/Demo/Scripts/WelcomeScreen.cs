using System.Collections;

using UnityEngine;

namespace UETools.AquaGUI.Demo
{
	public class WelcomeScreen : UETools.AquaGUI.Demo.Screen
	{
		[SerializeField]
		private GameObject[] Texts;

		[SerializeField]
		private UnityEngine.UI.Text ButtonText;

		private int		m_ActiveText	= 0;

		public void ShowNext()
		{
			++m_ActiveText;

			Refresh();

			Demo.Instance.PlayTapSound();
		}
		
		protected override sealed void Reset()
		{
			m_ActiveText = 0;
			ButtonText.text = "Next";
			
			foreach(GameObject go in Texts)
			{
				go.SetActive(false);
			}
			Texts[0].SetActive(true);
		}

		private void Refresh()
		{
			if(m_ActiveText < Texts.Length)
			{
				Texts[m_ActiveText - 1].SetActive(false);
				Texts[m_ActiveText].SetActive(true);
			}
			else
			{
				Hide();
			}
			
			if(m_ActiveText == Texts.Length - 1)
			{
				ButtonText.text = "Finish";
			}
		}
	}
}
