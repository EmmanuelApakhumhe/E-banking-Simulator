using System.Collections;

using UnityEngine;

namespace UETools.AquaGUI.Demo
{
	public class FinalRibbon : UETools.AquaGUI.Demo.Screen
	{
		[SerializeField]
		private ColoredRibbon Highlights;
		
		[SerializeField]
		private ColoredRibbon Ribbon;
		
		[SerializeField]
		private ColoredRibbon Base;
		
		private UnityEngine.UI.Image m_Image;
		
		private UnityEngine.UI.Image m_Highlights;
		private UnityEngine.UI.Image m_Ribbon;
		private UnityEngine.UI.Image m_Base;

		public void SetColorScheme(string scheme)
		{
			switch(scheme)
			{
			case "aqua":
				Highlights.SetColor(new Color(0.749f, 0.749f, 0.0f));
				Ribbon.SetColor(new Color(0.3676f, 0.7353f, 0.0f));
				Base.SetColor(new Color(1.0f, 1.0f, 0.7868f));
				break;
			case "gold":
				Highlights.SetColor(new Color(1.0f, 0.6043f, 0.0f));
				Ribbon.SetColor(new Color(1.0f, 0.8142f, 0.0f));
				Base.SetColor(new Color(0.8553f, 0.0f, 0.1842f));
				break;
			case "silver":
				Highlights.SetColor(new Color(0.579f, 0.7368f, 1.0f));
				Ribbon.SetColor(new Color(1.0f, 1.0f, 1.0f));
				Base.SetColor(new Color(0.0f, 0.3974f, 0.6184f));
				break;
			case "fire":
				Highlights.SetColor(new Color(1.0f, 0.8f, 0.0f));
				Ribbon.SetColor(new Color(1.0f, 0.329f, 0.0f));
				Base.SetColor(new Color(1.0f, 1.0f, 0.7105f));
				break;
			case "magic":
				Highlights.SetColor(new Color(0.5658f, 0.4079f, 1.0f));
				Ribbon.SetColor(new Color(0.5921f, 0.0f, 1.0f));
				Base.SetColor(new Color(1.0f, 0.3684f, 0.5658f));
				break;
			case "dark":
				Highlights.SetColor(new Color(0.0f, 1.0f, 1.0f));
				Ribbon.SetColor(new Color(0.0f, 0.0f, 0.2895f));
				Base.SetColor(new Color(0.5921f, 1.0f, 1.0f));
				break;
			}
		}
		
		private void Awake()
		{
			m_Highlights	= transform.Find("Ribbon_Highlights").gameObject.GetComponent<UnityEngine.UI.Image>();
			m_Ribbon		= transform.Find("Ribbon").gameObject.GetComponent<UnityEngine.UI.Image>();
			m_Base			= transform.Find("Ribbon_Base").gameObject.GetComponent<UnityEngine.UI.Image>();

			Highlights.OnColorChanged	= RefreshHighlights;
			Ribbon.OnColorChanged		= RefreshRibbon;
			Base.OnColorChanged			= RefreshBase;
		}
		
		private void RefreshHighlights(Color color)
		{
			m_Highlights.color = color;
		}
		
		private void RefreshRibbon(Color color)
		{
			m_Ribbon.color = color;
		}
		
		private void RefreshBase(Color color)
		{
			m_Base.color = color;
		}
	}
}
