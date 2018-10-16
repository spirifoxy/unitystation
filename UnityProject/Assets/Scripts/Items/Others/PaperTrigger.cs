﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperTrigger : PickUpTrigger
{
	public NetTabType NetTabType;

	public override void UI_Interact(GameObject originator, string hand)
	{
		var playerScript = originator.GetComponent<PlayerScript>();

		if (!isServer)
        { 
            //Client wants this code to be run on server
            InteractMessage.Send(gameObject, hand);
        }
        else
        {
            //Server actions
            TabUpdateMessage.Send( originator, gameObject, NetTabType, TabAction.Open );
        }
	}
}