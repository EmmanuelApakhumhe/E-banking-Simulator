using System.Collections;

using UnityEngine;

namespace UETools.AquaGUI.Demo
{
	public class GameScreen : UETools.AquaGUI.Demo.Screen
	{
		[SerializeField]
		private UnityEngine.UI.Text TimeText;

		private float m_Time = 180.0f;
		
		private void Update()
		{
			if(!m_Hidden)
			{
				m_Time = Mathf.Max(0.0f, m_Time - Time.deltaTime);

				if(m_Time < 0.75f)
				{
					Hide();
				}

				int time = Mathf.FloorToInt(m_Time);

				TimeText.text = "0" + (time / 60) + ":" + ((time % 60) < 10 ? ("0" + (time % 60).ToString()) : (time % 60).ToString());
			}
		}

		protected override sealed void Reset()
		{
			m_Time = 180.0f;
		}
	}
}
