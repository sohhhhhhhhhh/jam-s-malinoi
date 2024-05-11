using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GOVNO : MonoBehaviour {
   [SerializeField] private VideoPlayer _videoPlayer;

   private void Start() {
       {
           _videoPlayer.loopPointReached += DoFacking;
       }
   }

   private void DoFacking(VideoPlayer vp) {
       SceneManager.LoadScene("Scenes/SampleScene");
   }
}
