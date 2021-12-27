using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
	public GameObject menu;
	public int maxHealth = 100;
	public int valorGolpe = 1;
	public int currentHealth;

	public HealthBar healthBar;

	// Start is called before the first frame update
	void Start()
	{
		if (menu !=null) {
			menu.SetActive(false);
		}
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	// Update is called once per frame
	void Update()
	{
		if (currentHealth < 0) {
			Time.timeScale = 0;
			menu.SetActive(true);
		}
		/*if (Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(valorGolpe);
		}*/
	}
	public void RestarVida() {
		currentHealth -= valorGolpe;
		healthBar.SetHealth(currentHealth);
	}
	public void Reiniciar() {
		menu.SetActive(false);
		Time.timeScale = 1;
		currentHealth = maxHealth;
		healthBar.SetHealth(currentHealth);
		//this.transform.position = posicionInicial.position;

	}

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}
}
