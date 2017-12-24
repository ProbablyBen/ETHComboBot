ETHCombo Bot
================================== 

This repository contains all the source code to run the ETHCombo Bot

Download: https://raw.githubusercontent.com/ProbablyBen/ETHComboBot/master/ETHComboBot.exe

## Pre-Requirements
Before running this bot, you need a few urls.

To get these urls, go to https://ethcombo.com/ and log in.

Once you are on the home page, open the developer console by pressing `ctrl + shift + j`

Execute the following code into the console:

    function getUrl(div, phpName) {
	
        var mainUrl = window.location.hostname;
        var divider = document.getElementsByClassName(div);
        var text = divider[0].innerHTML;
        var start = text.indexOf(phpName);
        var end = text.indexOf('"', start);

        return "http://" + mainUrl + "/" + text.substring(start, end);
    }

    var spinUrl = getUrl("topofthetop", "numbers.php");
    var chestUrl = getUrl("topofthetop", "chestcount.php");

    console.log
    (
        "Spin Url: " + spinUrl + "\n" +
        "Chest Url: " + chestUrl
    );

Two lines of output will show

Save the urls where it says:

Spin Url:

Chest Url:

You will need them in the next step

## Getting it to run
1) Download the executable and run it for a default configuration to be created for you.

2) Edit the config.json just created with your favorite text editor

3) Insert the urls you obtained from earlier and set the SpinDurationMs

* The spin url contains the textnumbers.php
* The chest url contains the text chestcount.php
* SpinDurationMs is the interval that a slot spin should occur in milliseconds. Example: 3000 = 3 seconds

4) Once you have edited your config, save it and start the executable again.

5) The bot should now be running and and spinning