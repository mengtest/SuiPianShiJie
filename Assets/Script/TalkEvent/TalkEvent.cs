﻿using UnityEngine;
using System.Collections;

public class TalkEvent : GameEvent {

    protected TextEvent notice;
    protected MainGame mainGame;

    /******************************
     *对继承类接口
     *调用其他类的功能请在这里调用
     *继承类不得自己调用
     ******************************/
    
    /*******************
     *其他相关
     *
     *
     *******************/
    protected void backMove() {
        if(selectMainGame()){
            mainGame.backMove();
        }
    }


    /*******************
     *奖励相关
     *
     *
     *******************/
    protected GameNpc getNpc() {
        if (selectMainGame()) {
            return mainGame.getMyNpc();
        }
        return null;
    }
    /*******************
     *战斗相关
     *
     *
     *******************/
    //开始战斗
    protected void startFight() {
        if (selectMainGame()) {
            if (mainGame.getMyNpc().GetComponent<FightEvent>() != null) {
                mainGame.startFight(this.GetComponentInParent<GameNpc>());
            } else {
                setNotice("你还没有学会任何技能，怎么战斗啊\n去新手接待员那里学习普通攻击吧！", 1.5f, true);
                backMove();
            }
        }
    }

    
    /*******************
     *文本提示相关
     *
     *
     *******************/
    //发送文本，在物体顶部显示()
    protected void setText(string str, GameObject gameObj) {
        if (selectMainGame()) {
            mainGame.setText(str, gameObj);
        }
    }

    //发送公告，显示在屏幕中间偏下方
    protected void setNotice(string str, float time, bool isChangeColor) {
        if (selectNotice()) {
            notice.setNotice(str, time, isChangeColor);
        }
    }
    //发送公告，显示在屏幕中间偏下方
    protected void setNotice(string str, float time, Color col) {
        if (selectNotice()) {
            notice.setNotice(str, time, col);
        }
    }
    //发送公告，显示在屏幕中间偏下方
    protected void setNotice(string str, float time, float r, float g, float b) {
        if (selectNotice()) {
            notice.setNotice(str, time, r, g, b);
        }
    }


    /******************************
     *不对外开放的函数
     *
     *
     ******************************/

    private bool selectMainGame() {
        if (mainGame == null) {
            mainGame = GameObject.Find("Game").GetComponent<MainGame>();
        }
        return true;
    }

    private bool selectNotice() {
        if (notice == null) {
            notice = GameObject.Find("Game").transform.Find("GameGraphics").transform.Find("NoticeCanvas").transform.Find("Notice").transform.GetComponent<TextEvent>();
        }
        return true;
    }
}
