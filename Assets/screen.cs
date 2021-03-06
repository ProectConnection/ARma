﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class screen : MonoBehaviour {
    public Camera ArCam;
	// Use this for initialization
    public void CaptchaScreen()
    {
        Texture2D screenShot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        RenderTexture rt = new RenderTexture(screenShot.width, screenShot.height, 24);
        RenderTexture prev = ArCam.targetTexture;
        ArCam.targetTexture = rt;
        ArCam.Render();
        ArCam.targetTexture = prev;
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, screenShot.width, screenShot.height), 0, 0);
        screenShot.Apply();

        byte[] bytes = screenShot.EncodeToPNG();
        UnityEngine.Object.Destroy(screenShot);

        string fileName = "test_" + System.DateTime.Now.Hour.ToString()  +"時" + System.DateTime.Now.Minute.ToString() + "分" + System.DateTime.Now.Second.ToString() + "秒.png";
         Application.CaptureScreenshot("../../../../DCIM/Camera/" + fileName);
        //Application.CaptureScreenshot("phone/DCIM/Camera/" + fileName);
       // File.WriteAllBytes(Application.persistentDataPath + "/" + fileName, bytes); 
        //File.WriteAllBytes(Application.persistentDataPath + "../../../../DCIM/Camera/" + fileName, bytes);
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
