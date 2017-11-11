using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class UseATM : MonoBehaviour 
{
	public GameObject UseATMPanel;
	public GameObject CreateAccoutPanel;

	public Button GenerateCashButton;

	public InputField AccountNumber;
	public InputField PasswordInput;
	public InputField TransferAccountNumberInput;
	public InputField TransferAmountInput;

	public GameObject VideoPopUpPanel;
	public GameObject WrongPasswordObject;
	public GameObject MenuPanel;
	public GameObject WithdralPanel;
	public GameObject NotEnoughMoneyPanel;
	public GameObject BlankSpacesText;
	public GameObject SorryText;
	public GameObject CheckBalancePanel;
	public GameObject TransferPanel;
	public GameObject TransferSuccessPanel;

	public GameObject VideoAdsText;
	public GameObject FillItUp;
	public GameObject YouCantTransferToSelfPanel;
	public GameObject AccountDoesnotExistPanel;
	public GameObject InsufficientFundsPanel;
	public GameObject ProccessingPanel;
	public GameObject WithdrawalsuccessPanel;

	public Text TransferSuccessText;
	public Text AccountBalanceText;
	public Text MenuPanelText;
	public Text AmountLeftText;
	public Text NotEnoughMoneyText;

	public GameObject PasswordFailed;

	private string passwordHolder;
	private string AmountKeyHolder;

	private string otherAccountInfo;
	private string otherAccountAmountkeyInfo;

	private string transferAcctNo;
	private string transferAmount;


	public void ClearField()
	{
		AccountNumber.text = AtmManager.ClearString;
		PasswordInput.text = AtmManager.ClearString;
		TransferAccountNumberInput.text = AtmManager.ClearString;
		TransferAmountInput.text = AtmManager.ClearString;
	}

	public void PasswordSubmit()
	{
		if (AccountNumber.text == AtmManager.ClearString || PasswordInput.text == AtmManager.ClearString) 
		{
			StartCoroutine (ShowError (BlankSpacesText));
			return;
		}

		if (PlayerPrefs.HasKey(AccountNumber.text) == false) 
		{
			ClearField ();
			PasswordFailed.SetActive (true);
			return;
		}

		if (PasswordInput.text != PlayerPrefs.GetString(AccountNumber.text).Substring(0, 4)) 
		{
			ClearField ();
			StartCoroutine (ShowError (WrongPasswordObject));
			return;
		}

		MenuPanel.SetActive (true);
		MenuPanelText.text = "Welcome, " + PlayerPrefs.GetString(AccountNumber.text).Substring(14);
		passwordHolder = AccountNumber.text;
		AmountKeyHolder = AccountNumber.text + PasswordInput.text;

		ClearField ();
	}

	public void CreateAccount()
	{
		ClearField ();
		CreateAccoutPanel.SetActive (true);
		PasswordFailed.SetActive (false);
		UseATMPanel.SetActive (false);
	}

	public void Withdrawal()
	{
		WithdralPanel.SetActive (true);
		MenuPanel.SetActive (false);
	}

	public void OtherButton()
	{
		StartCoroutine (ShowError (SorryText));
	}

	public void CheckAccountBalance()
	{
		if (CheckBalancePanel.activeInHierarchy == false)
		{
			CheckBalancePanel.SetActive (true);
		}

		string theAccountOwner = PlayerPrefs.GetString (passwordHolder).Substring(14);
		string theBalanceLeft = PlayerPrefs.GetString (AmountKeyHolder);

		string message = "";

		if (int.Parse(theBalanceLeft) < 15000) 
		{
			message = ".  you are currently a broke ass nigga you need to connect to the internet and if available, " +
				"click on the button below to generate you some sugar baby";
		}

		else if (int.Parse(theBalanceLeft) >= 15000 && int.Parse(theBalanceLeft) <= 100000) 
		{
			message = ".  well, one could say one could say that you've got some money but could still get more " +
				"by clicking the button below if it's available. switch on your internet connection!";
		} 
		else if (int.Parse(theBalanceLeft) > 100000 && int.Parse(theBalanceLeft) <= 500000)
		{
			message = ".  wow! fella, you're really doing well that's nice but you could still do more well " +
				"by clicking the button below if it's available. switch on your internet connection!";
		}
		else if (int.Parse(theBalanceLeft) > 500000 && int.Parse(theBalanceLeft) < 1000000) 
		{
			message = ".  impressive! you're rich dude! get even richer, click the button below if it's available. " +
				"switch on your internet connection!";
		}
		else if (int.Parse(theBalanceLeft) >= 1000000 && int.Parse(theBalanceLeft) < 1000000000) 
		{
			message = ".  Quick fact, Do you know you're a millionaire!!! you could still switch on your internet connection and generate more funds";
		}
		else 
		{
			message = ".  You're a fucking wealthy person!!, nice job!!! you could still switch " +
				"on your internet connection and generate more funds to become more wealthy";
		}


		AccountBalanceText.text = "Hello, " + theAccountOwner + "! your account balance is N" + string.Format("{0:N}", int.Parse(theBalanceLeft)) + message;

		if (Advertisement.IsReady("rewardedVideo")) 
		{
			GenerateCashButton.gameObject.SetActive (true);
		} 
		else
		{
			GenerateCashButton.gameObject.SetActive (false);
		}

	}

	public void GenerateButton()
	{
		if (VideoPopUpPanel.activeInHierarchy == false) 
		{
			VideoPopUpPanel.SetActive (true);
		}

	}

	public void YesToAdvert()
	{
		if (Advertisement.IsReady("rewardedVideo") == true) 
		{
			Advertisement.Show ("rewardedVideo", new ShowOptions (){ resultCallback = ResultChecker });
		}
	}

	private void ResultChecker(ShowResult result)
	{
		int newRandomCash = Random.Range (0, 100000);
		int formerBalance = int.Parse(PlayerPrefs.GetString (AmountKeyHolder));
		int newBalance = newRandomCash + formerBalance;

		switch (result)
		{
			case ShowResult.Finished:
			
				Debug.Log ("Hey congrats on finishing the video Ads!");
				if (VideoAdsText.activeInHierarchy == false)
				{
					VideoAdsText.SetActive (true);
				}

				PlayerPrefs.SetString (AmountKeyHolder, newBalance.ToString ());
				AccountBalanceText.text = "Former Account Balance = N" + string.Format("{0:N}", formerBalance) + "\n " +
					"Generated Cash = N" + string.Format("{0:N}", newRandomCash) + " \n " +
					"New Account Balance = N" + string.Format("{0:N}", newBalance);
				break;

			case ShowResult.Skipped:
			
				Debug.Log ("Why can't you just wait and watch the video");
				AccountBalanceText.text = "You didn't stay to the end, why?";
				break;

			case ShowResult.Failed:
			
				Debug.Log ("Internet is Down");
				break;
			
			default:
				Debug.Log ("Fatal error occurred");
				break;
		}
	}

	public void Transfer()
	{
		if (TransferPanel.activeInHierarchy == false) 
		{
			TransferPanel.SetActive (true);
		}
	}

	public void TransferButtonClicked()
	{
		transferAcctNo = TransferAccountNumberInput.text;
		transferAmount = TransferAmountInput.text;

		if (transferAcctNo == "" || transferAmount == "") 
		{
			StopCoroutine (ShowError (FillItUp));
			StartCoroutine (ShowError (FillItUp));
			return;
		}

		if (PlayerPrefs.HasKey(transferAcctNo) == false) 
		{
			StopCoroutine (ShowError (AccountDoesnotExistPanel));
			StartCoroutine (ShowError (AccountDoesnotExistPanel));
			ClearField ();
			return;
		} 

		if (transferAcctNo == passwordHolder) 
		{
			StopCoroutine (ShowError (YouCantTransferToSelfPanel));
			StartCoroutine (ShowError (YouCantTransferToSelfPanel));
			ClearField ();
			return;
		}
		else 
		{

			if (int.Parse(PlayerPrefs.GetString(AmountKeyHolder)) < int.Parse(transferAmount)) 
			{
				StopCoroutine (ShowError (InsufficientFundsPanel));
				StartCoroutine (ShowError (InsufficientFundsPanel));
				return;
			}
				
			otherAccountInfo = PlayerPrefs.GetString (transferAcctNo);
			//Debug.Log ("The Other Account Info : " + otherAccountInfo);
			otherAccountAmountkeyInfo = transferAcctNo + otherAccountInfo.Substring (0, 4);

			int OtherAccountNewAmount = int.Parse(PlayerPrefs.GetString (otherAccountAmountkeyInfo)) + int.Parse(transferAmount); 
			PlayerPrefs.SetString (otherAccountAmountkeyInfo, OtherAccountNewAmount.ToString());

			int MyAccountNewAmount = int.Parse(PlayerPrefs.GetString (AmountKeyHolder)) - int.Parse(transferAmount);
			PlayerPrefs.SetString (AmountKeyHolder, MyAccountNewAmount.ToString());

			StopCoroutine (Processing ("transfer"));
			StartCoroutine (Processing ("transfer"));

			ClearField ();

		} 
			
	}

	public void N500()
	{
		ProcessAmount (500);
	}

	public void N1000()
	{
		ProcessAmount (1000);
	}

	public void N3000()
	{
		ProcessAmount (3000);
	}

	public void N5000()
	{
		ProcessAmount (5000);
	}

	public void N10000()
	{
		ProcessAmount (10000);
	}

	public void N20000()
	{
		ProcessAmount (20000);
	}

	public void CancelButton(bool choice)
	{
		if (TransferSuccessPanel.activeInHierarchy == true) 
		{
			TransferSuccessPanel.SetActive (false);
		}

		if (TransferPanel.activeInHierarchy == true) 
		{
			TransferPanel.SetActive (false);
		}

		if (CheckBalancePanel.activeInHierarchy == true) 
		{
			CheckBalancePanel.SetActive (false);
			VideoAdsText.SetActive (false);
		}

		if (WithdralPanel.activeInHierarchy == true) 
		{
			WithdralPanel.SetActive (false);
		}

		if (MenuPanel.activeInHierarchy == true) 
		{
			MenuPanel.SetActive (false);
		}

		if (choice == true) 
		{
			ClearField ();
			UseATMPanel.SetActive (false);
		}
	}

	public void MakeAnother()
	{
		WithdrawalsuccessPanel.SetActive (false);
	}

	public void End()
	{
		WithdrawalsuccessPanel.SetActive (false);
		UseATMPanel.SetActive (false);
	}

	private void ProcessAmount(int amount)
	{
		if (int.Parse(PlayerPrefs.GetString(AmountKeyHolder)) < amount) 
		{
			StartCoroutine (ShowError(NotEnoughMoneyPanel));
			return;
		}

		string userAccountBalance = PlayerPrefs.GetString (AmountKeyHolder);

		int MoneyLeft = int.Parse (userAccountBalance) - amount;

		string WhatToSave = MoneyLeft.ToString ();

		PlayerPrefs.SetString (AmountKeyHolder, WhatToSave);

		StartCoroutine (Processing (true));
	}

	IEnumerator ShowError(GameObject errorObject)
	{
		if (errorObject == NotEnoughMoneyPanel) 
		{
			NotEnoughMoneyText.text = "Sorry Dude, you're broke as fuck! Amount Left : N" + string.Format("{0:N}", int.Parse(PlayerPrefs.GetString (AmountKeyHolder)));
		}

		errorObject.SetActive (true);
		yield return new WaitForSeconds (2f);
		errorObject.SetActive (false);
	}

	IEnumerator Processing(bool IsNormalProcess)
	{
		ProccessingPanel.SetActive (true);
		yield return new WaitForSeconds (3f);
		ProccessingPanel.SetActive (false);

		if (IsNormalProcess == true) 
		{
			WithdrawalsuccessPanel.SetActive (true);
			AmountLeftText.text = "Amount left : N" + string.Format("{0:N}", int.Parse(PlayerPrefs.GetString (AmountKeyHolder)));
			WithdralPanel.SetActive (false);
		}
	}
		
	IEnumerator Processing(string process)
	{
		ProccessingPanel.SetActive (true);
		yield return new WaitForSeconds (3f);
		ProccessingPanel.SetActive (false);

		if (string.Equals(process, "transfer", System.StringComparison.Ordinal) == true) 
		{
			if (TransferSuccessPanel.activeInHierarchy == false) 
			{
				TransferSuccessPanel.SetActive (true);

				TransferSuccessText.text = "You've successfully transfered N" + string.Format("{0:N}", int.Parse(transferAmount)) + " to " +
				PlayerPrefs.GetString (transferAcctNo).Substring (14) + " \n your remaining balance is N" +
					string.Format("{0:N}",int.Parse(PlayerPrefs.GetString (AmountKeyHolder)));
			}
		}
	}
	
}
