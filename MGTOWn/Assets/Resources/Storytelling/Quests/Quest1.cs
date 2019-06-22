﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

class Quest1 : Quests
{
	protected bool vstup = true, text1 = false, goSleep = false;
	private bool meloryDialog1 = false, meloryDialog2 = false;
    
	private Vector3 rayOrigin;
	private RaycastHit hit;
	private Ray ray;

	protected Text saying;
	protected Text sayingText;
	protected Button next;

    public override void Start()
    {
        base.Start();

		DisableDialog_UI ();
		EnableAuthor_UI ();

		Vstuplenie (); 
    }
		
	public void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Escape))
        {
			if (vstup)
            {
				vstup = false;
				text1 = true;
				Q1 ();
				return;
			}

			if (text1)
            {
				text1 = false;
				DisableAuthor_UI ();
				return;
			}
		
			try{ DisableAuthor_UI ();} catch(Exception){}

		}

		if (Input.GetKeyDown (KeyCode.E))
        {
			rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
			ray = Camera.main.ViewportPointToRay (rayOrigin);

			if (Physics.Raycast (ray, out hit, 10f)) {
				if (hit.collider.CompareTag ("Melory")) {
					EnableDialog_UI ();

					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = true;
					DisableFPS ();

					saying = GameObject.FindGameObjectWithTag ("Saying").GetComponent<Text>();
					sayingText = GameObject.FindGameObjectWithTag ("Saying text").GetComponent<Text>();
					next = GameObject.FindGameObjectWithTag ("Next").GetComponent<Button>();

					if (meloryDialog1) {
						meloryDialog1 = false;
						saying.text = "Mэлори";
						sayingText.text = "Ты заставил меня ждать!";
						return;
					} 
					if (meloryDialog2) {
						meloryDialog2 = false;
						saying.text = "Mэлори";
						sayingText.text = "Я надеялась что больше не увижу тебя!";
						return;
					}
						
					saying.text = "Mэлори";
					sayingText.text = "Выполняй мои задания, а не шляйся тут!";						
				}
				if (hit.collider.CompareTag ("Rose"))
                {
					setQuestText ("Отдать розу Мэлори.");
					meloryDialog2 = true;
				}
			}
		}
	}

	public void Vstuplenie()
	{
		SetLongAuthorText("Для начала хочется поведать читающему о том, каким образом я научился писать" +
			" и почему моя жизнь отличается от жизни остальных мужчин.\n\nБыл холодный вечер января 1443 года." +
			" В дом постучали. Неспешно подойдя к двери, я услышал голос, очень хриплый голос, и открыл дверь. " +
			"На пороге стоял старец, в его руках был клочек бумаги с каким-то текстом. Что происходит? Никогда " +
			"ранее я не видел чтоб мужчинам было разрешено прикасаться к рукописям, мы же все равно не умеем читать. " +
			"Куда бежать? Кому докладывать? Рядом не было ни одной женщины. Заметив мою панику, старец сказал:\n\n" +
			"-Наконец-то я нашел молодого мужчину. Держи этот свиток, с его помощью ты найдешь ответы на все окружающие " +
			"тебя загадки и сможешь избавить мир от несправедливости. К сожалению, мне осталось совсем мало времени, " +
			"береги этот свиток, его название - \"Права и обязанности\", научись читать с его помощью.\n\nЗакончив " +
			"говорить, старец вышел из дома и растворился в темноте ночи.\n\n*\n\nКаждый день на главной площади " +
			"Gynon'а было торжественное чтение \"Прав и обязанностей\". Этот документ был сформирован еще сотни " +
			"лет назад и с тех пор в нем ничего не изменилось. В первой строке были написаны права женщин, а после - " +
			"обязанности мужчин. Каждый в городе напамять помнит эти слова \"Женщина имеет право делать все что она хочет. " +
			"Мужчины обязаны выполнять все желания женщин. Мужчины обязаны быть добрыми по отношению к женщинам. Если женщине " +
			"плохо, мужчина обязан страдать вдвойне...\" Далее идет еще много подобных пунктов, но я не считаю нужным " +
			"перечислять их все тут.\n\nТам, на главной площади, спрятавшись за сеном, я слушал чтение \"Прав и обязанностей\"" +
			", внимательно разглядывая слова в том свитке, что дал мне старец. Я начал сопоставлять звуки с буквами, " +
			"пытаясь запомнить соответсвия. \n\nСпустя несколько месяцев я уже мог сам читат свиток.\n\nИменно так я и " +
			"научился читать. Возможно первый мужчина, который это смог. Теперь, спустя годы тренировок чтения и письма, " +
			"я начал писать свой дневник.\n");
		
	}
		
	public void Q1()
	{
		ClearLongAuthorText ();
		SetLongAuthorText("Сегодня 24 июня 1456 года.\n\nМое утро начинается как обычно: надо прийти на главную площадь " +
			"города Gynon и получить очередное задание от Мэлори.");

		setQuestText ("Прийти в город Gynon к Мелори для получения задания.");

		meloryDialog1 = true;
	}

	public void EndMeloryDialog(){
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		EnableFPS ();
		DisableDialog_UI ();
	}

}
