using System;
using System.Collections;

using UnityEngine;

namespace UETools.AquaGUI.Demo
{
	public class ColoredRibbon : UETools.AquaGUI.Demo.Screen
	{
		[SerializeField]
		private UnityEngine.UI.Slider RedSlider;

		[SerializeField]
		private UnityEngine.UI.Slider GreenSlider;

		[SerializeField]
		private UnityEngine.UI.Slider BlueSlider;

		private UnityEngine.UI.Image m_Image = null;

		public Action<Color> OnColorChanged = null;

		public void SetColor(Color color)
		{
			RedSlider.value		= Mathf.Clamp01(color.r);
			GreenSlider.value	= Mathf.Clamp01(color.g);
			BlueSlider.value	= Mathf.Clamp01(color.b);
		}
		
		public void RefreshColor()
		{
			m_Image.color = new Color(RedSlider.value, GreenSlider.value, BlueSlider.value);

			if(OnColorChanged != null)
			{
				OnColorChanged(m_Image.color);
			}
		}

		private void Awake()
		{
			m_Image = GetComponent<UnityEngine.UI.Image>();
		}

		private void Start()
		{
			SetColor(m_Image.color);
		}
	}
}
