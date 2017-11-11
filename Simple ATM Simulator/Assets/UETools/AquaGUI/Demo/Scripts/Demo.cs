using System.Collections;

using UnityEngine;

namespace UETools.AquaGUI.Demo
{
	public class Demo : MonoBehaviour
	{
		[SerializeField]
		private WelcomeScreen	About;

		[SerializeField]
		private HomeScreen		Home;
		
		[SerializeField]
		private SettingsScreen	Settings;
		
		[SerializeField]
		private ShopScreen		Shop;
		
		[SerializeField]
		private GameScreen		Game;

		[SerializeField]
		private Texture2D cursorTexture;

		private static Demo m_Instance		= null;
		private static bool	m_SoundsEnabled	= true;

		public bool useCursor = false;

		public static Demo Instance { get { return m_Instance; } }

		public void PlayTapSound()
		{
			if(m_SoundsEnabled)
			{
#if UNITY_5
				GetComponent<AudioSource>().Play();
#else
				GetComponent<AudioSource>().Play();
#endif
			}
		}
		
		public void ToggleSounds()
		{
			m_SoundsEnabled = !m_SoundsEnabled;
		}
		
		public void ShowWelcomeScreen()
		{
			Home.Hide();
			About.Show();
		}
		
		public void ShowSettingsScreen()
		{
			Home.Hide();
			Settings.Show();
		}
		
		public void ShowShopScreen()
		{
			Home.Hide();
			Shop.Show();
		}
		
		public void ShowGameScreen()
		{
			Home.Hide();
			Game.Show();
		}

		private void Awake()
		{
			m_Instance = this;

			About.OnHidden		= OnWelcomeScreenClosed;
			Settings.OnHidden	= OnSettingsScreenClosed;
			Shop.OnHidden		= OnShopScreenClosed;
			Game.OnHidden		= OnGameScreenClosed;
		}

		private void Start()
		{
			Invoke("ShowWelcomeScreen", 0.5f);

			if(useCursor)
			{
				InitializeCursor();
			}
		}

		private void OnWelcomeScreenClosed()
		{
			Home.Show();
		}
		
		private void OnSettingsScreenClosed()
		{
			Home.Show();
		}
		
		private void OnShopScreenClosed()
		{
			Home.Show();
		}
		
		private void OnGameScreenClosed()
		{
			Home.Show();
		}
		
		private void ShowHomeScreen()
		{
			Home.Show();
		}
		
		private void InitializeCursor()
		{
			Texture2D cursorSprite = new Texture2D(64 , 64);
			
			var pix = cursorTexture.GetPixels(2);
			cursorSprite.SetPixels(pix);
			cursorSprite.Apply();

#if UNITY_EDITOR
			Cursor.SetCursor(cursorSprite, new Vector2(-144.0f, 44.0f), CursorMode.ForceSoftware);
#else
			Cursor.SetCursor(cursorSprite, new Vector2(0.0f, 0.0f), CursorMode.ForceSoftware);
#endif
		}
	}
}
