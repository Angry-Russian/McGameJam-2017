using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class GlobalVars : MonoBehaviour {

    public float health = 0.5f;
    public float education = 0.5f;
    public float environment = 0.5f;

    public Image healthBar;
    public Image educationBar;
    public Image environmentBar;

    public MoneyBar moneyBar;

    public float cost = 1000;
    public float money = 10000;
    public float maxMoney = 40000;

    public float fillSpeed = 1;
    public float improvementSpeed = 1f;

    // Use this for initialization
    void Start () {
        moneyBar.max = maxMoney;
	}
	
	// Update is called once per frame
	void Update () {

        moneyBar.fill = money;

        health += fillSpeed * Time.deltaTime;
        education += fillSpeed * Time.deltaTime;
        environment += fillSpeed * Time.deltaTime;

        healthBar.transform.localScale = new Vector3(1, health * improvementSpeed, 1);
        educationBar.transform.localScale = new Vector3(1, education * improvementSpeed, 1);
        environmentBar.transform.localScale = new Vector3(1, environment * improvementSpeed, 1);


        if (Input.GetButtonDown("Fire1") && health > 0.15f) {
            money += 850 * improvementSpeed;
            health -= 0.15f;
            //education += 0.05f + Random.Range(-0.025f, 0.025f);
            //environment += 0.05f + Random.Range(-0.025f, 0.025f);
        }

        if (Input.GetButtonDown("Fire2") && education > 0.15f) {
            money += 1200 * improvementSpeed;
            education -= 0.15f;
            //health += 0.05f + Random.Range(-0.025f, 0.025f);
            //environment += 0.05f + Random.Range(-0.025f, 0.025f);
        }
        if (Input.GetButtonDown("Fire3") && environment > 0.15f) {
            money += 1200 * improvementSpeed;
            environment -= 0.15f;
            health += Random.Range(0f, 0.15f) - 0.075f;
            //education += 0.05f + Random.Range(-0.025f, 0.025f);
        }

        var penalty = Mathf.Pow(health - 0.5f, 2) + Mathf.Pow(environment - 0.5f, 2) + 2*Mathf.Pow(education - 0.5f, 2);

        money -= (cost * (penalty + 1) + Mathf.Sqrt(money)/100) * Time.deltaTime;
    }
}
