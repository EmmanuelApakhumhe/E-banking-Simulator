using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateAccount : MonoBehaviour 
{
	public InputField AccountName;
	public InputField AccountPassword;
	public InputField AccountRe_passoword;
	public InputField AccountEmail;
	public InputField AccountNumber;

	public GameObject SuccessPanel;
	public GameObject FailedPanel;
	public GameObject PasswordErrorTextObject;
	public GameObject EmptySpaceTextObject;

	public GameObject PasswordLessText;
	public GameObject AccountNumberLessText;
	public GameObject AcctPassLessText;

	public float Delaytime = 2f;

	private int RewardMoney;
	public Text RewardText;

	void Start()
	{
		RewardMoney = Random.Range (10000, 1000000);
	}

	private void ClearField()
	{
		AccountName.text = AtmManager.ClearString;
		AccountPassword.text = AtmManager.ClearString;
		AccountRe_passoword.text = AtmManager.ClearString;
		AccountEmail.text = AtmManager.ClearString;
		AccountNumber.text = AtmManager.ClearString;
	}

	public void Submit()
	{

		if (AccountName.text == "" || AccountPassword.text == "" || AccountRe_passoword.text == "" || AccountEmail.text == "" || AccountNumber.text == "") 
		{
			StopCoroutine (ShowError (EmptySpaceTextObject));
			StartCoroutine (ShowError (EmptySpaceTextObject));
			return;
		}

		if (AccountPassword.text.Length != 4 && AccountNumber.text.Length != 10) 
		{
			StopCoroutine (ShowError (AcctPassLessText));
			StartCoroutine (ShowError (AcctPassLessText));
			return;
		}

		if (AccountNumber.text.Length != 10) 
		{
			StopCoroutine (ShowError (AccountNumberLessText));
			StartCoroutine (ShowError (AccountNumberLessText));
			return;
		}

		if (AccountPassword.text.Length != 4) 
		{
			StopCoroutine (ShowError (PasswordLessText));
			StartCoroutine (ShowError (PasswordLessText));
			return;
		}

		if (AccountRe_passoword.text != AccountPassword.text) 
		{
			StopCoroutine (ShowError (PasswordErrorTextObject));
			StartCoroutine (ShowError(PasswordErrorTextObject));
			return;
		}
			
		if (PlayerPrefs.HasKey(AccountNumber.text)) 
		{
			FailedPanel.SetActive (true);
			return;
		}
			

		string userInfo = AccountPassword.text + AccountNumber.text + AccountName.text;
		string userAcctBalanceKey = AccountNumber.text + AccountPassword.text;

		PlayerPrefs.SetString (AccountNumber.text, userInfo);
		PlayerPrefs.SetString (userAcctBalanceKey, RewardMoney.ToString());

		SuccessPanel.SetActive (true);
		RewardText.text = "Thanks for creating an account with us, you've been credited with this amount : N" + string.Format("{0:N}", RewardMoney);
	}
		
	public void ClearButton()
	{
		ClearField();
	}

	IEnumerator ShowError(GameObject gameobject)
	{
		gameobject.SetActive (true);
		yield return new WaitForSeconds (Delaytime);
		gameobject.SetActive (false);
	}






}
