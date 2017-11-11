using System;
using System.Collections;

using UnityEngine;

namespace UETools.AquaGUI.Demo
{
	public class Screen : MonoBehaviour
	{
		protected bool m_Hidden = true;
		
		public	Action OnHidden = null;

		protected virtual void Reset() {}
		
		public void Show()
		{
			Reset();
			
			if(m_Hidden)
			{
				GetComponent<Animator>().SetTrigger("Show");
				m_Hidden = false;
			}
		}
		
		public void Hide()
		{
			if(!m_Hidden)
			{
				GetComponent<Animator>().SetTrigger("Hide");
				m_Hidden = true;

				if(OnHidden != null)
				{
					OnHidden();
				}
			}
		}
	}
}
