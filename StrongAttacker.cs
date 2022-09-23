using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrongAttacker : MonoBehaviour
{
	public GameObject _attackCollider;

	public int chargeAmount;
	public int chargeTotal;
	public Slider chargeMeter;
	public GameObject baseAttack;
	public GameObject strongAttack;

	private void Update()
	{
		if (this.tag == "Player")
		{
			if (chargeAmount > chargeTotal)
				chargeAmount = chargeTotal;


			chargeMeter.value = chargeAmount;
			if (chargeAmount == chargeTotal && Input.GetButtonDown("Power"))
			{
				StartCoroutine("PowerState");

			}
		}
	}

	public void EnableWeapon()
	{
		_attackCollider.SetActive(true);
	}

	public void DisableWeapon()
	{
		_attackCollider.SetActive(false);
	}

	public IEnumerator PowerState()
	{
		_attackCollider = strongAttack;
		GetComponent<Protagonist>().isParrying = true;
		yield return new WaitForSeconds(1.0f);
		GetComponent<Protagonist>().isParrying = false;
		while (chargeAmount >= 0)
		{
			chargeAmount -= 5;
			yield return new WaitForSeconds(0.4f);
		}
		if (chargeAmount < 0)
		{
			chargeAmount = 0;
			_attackCollider = baseAttack;
		}

	}
}
