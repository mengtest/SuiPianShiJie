﻿using UnityEngine;
using System.Collections;

public class TalkFightEvent : TalkEvent {
	
	void Start(){
        if (isDefined) {
            this.buttonText = "战斗";
            this.conText = "小伙子\n来吧战斗吧！";
        }
	}

    override public void runEvent() {
        this.startFight();
	}
}
