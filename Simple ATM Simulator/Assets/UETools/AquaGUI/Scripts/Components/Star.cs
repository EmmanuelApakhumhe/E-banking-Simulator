using UnityEngine;
using System.Collections;

namespace UETools.AquaGUI
{
	public class Star : MonoBehaviour
	{
	    private UnityEngine.UI.Toggle toggle;

	    public Animator star;

	    public void Show()
	    {
	        if(toggle != null)
	        {
	            toggle.isOn = true;
	        }
	    }

	    public void Hide()
	    {
	        if(toggle != null)
	        {
	            toggle.isOn = false;
	        }
	    }

	    public void Toggle()
	    {
	        if(toggle != null)
	        {
	            toggle.isOn = !toggle.isOn;
	        }
	    }

	    public void OnChanged()
	    {
	        if(toggle != null)
	        {
	            star.SetBool("isHidden", !toggle.isOn);
	        }
	    }

	    private void Awake()
	    {
	        toggle = gameObject.GetComponent<UnityEngine.UI.Toggle>();
	    }
	}
}
