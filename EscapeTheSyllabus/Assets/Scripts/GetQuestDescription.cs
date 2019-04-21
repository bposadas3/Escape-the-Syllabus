﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetQuestDescription : MonoBehaviour
{
    private Text text;

    private void Start()
    {
        text = this.GetComponent<Text>();
    }

    private void Update()
    {
        text.text = UserData.instance.getActiveQuest().description;
    }
}