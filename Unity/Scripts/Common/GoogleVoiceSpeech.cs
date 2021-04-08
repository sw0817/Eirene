﻿//	Copyright (c) 2016 steele of lowkeysoft.com
//        http://lowkeysoft.com
//
//	This software is provided 'as-is', without any express or implied warranty. In
//	no event will the authors be held liable for any damages arising from the use
//	of this software.
//
//	Permission is granted to anyone to use this software for any purpose,
//	including commercial applications, and to alter it and redistribute it freely,
//	subject to the following restrictions:
//
//	1. The origin of this software must not be misrepresented; you must not claim
//	that you wrote the original software. If you use this software in a product,
//	an acknowledgment in the product documentation would be appreciated but is not
//	required.
//
//	2. Altered source versions must be plainly marked as such, and must not be
//	misrepresented as being the original software.
//
//	3. This notice may not be removed or altered from any source distribution.
//
//  =============================================================================
//
// Acquired from https://github.com/steelejay/LowkeySpeech
//
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Web;
using UnityEngine.UI;

[RequireComponent (typeof (AudioSource))]

public class GoogleVoiceSpeech : MonoBehaviour {

	public static string initial = "          \"transcript\": \"";
	// public Text TextBox;

	struct ClipData
		{
				public int samples;
		}

		const int HEADER_SIZE = 44;

		private static int minFreq;
		private static int maxFreq;

		private static bool micConnected = false;

		//A handle to the attached AudioSource
		private static AudioSource goAudioSource;

		public string apiKey;


	// Use this for initialization
	void Start () {
				// //Check if there is at least one microphone connected
				if(Microphone.devices.Length <= 0)
				{
					//Throw a warning message at the console if there isn't
					Debug.LogWarning("Microphone not connected!");
				}
				else //At least one microphone is present
				{
					Debug.Log("스타트");
						//Set 'micConnected' to true
						micConnected = true;

						//Get the default microphone recording capabilities
						Microphone.GetDeviceCaps(null, out minFreq, out maxFreq);

						//According to the documentation, if minFreq and maxFreq are zero, the microphone supports any frequency...
						if(minFreq == 0 && maxFreq == 0)
						{
								//...meaning 44100 Hz can be used as the recording sampling rate
								maxFreq = 44100;
						}

						//Get the attached AudioSource component
						goAudioSource = this.GetComponent<AudioSource>();
				}
	}

// void OnGUI() 
	public static void GoStt(string targetWord)
	{
			//If there is a microphone
			if(micConnected)
			{
					//If the audio from any microphone isn't being recorded
					if(!Microphone.IsRecording(null))
					{
						Debug.Log( "녹음시작");
							goAudioSource.clip = Microphone.Start( null, true, 7, maxFreq); //Currently set for a 7 second clip
					}
					else //Recording is in progress
					{
							
							float filenameRand = UnityEngine.Random.Range (0.0f, 10.0f);

							string filename = "testing" + filenameRand;

							Microphone.End(null); //Stop the audio recording

							Debug.Log( "Recording Stopped");

							if (!filename.ToLower().EndsWith(".wav")) {
									filename += ".wav";
							}

							var filePath = Path.Combine("testing/", filename);
							filePath = Path.Combine(Application.persistentDataPath, filePath);
							Debug.Log("Created filepath string: " + filePath);

							// Make sure directory exists if user is saving to sub dir.
							Directory.CreateDirectory(Path.GetDirectoryName(filePath));
							SavWav.Save (filePath, goAudioSource.clip); //Save a temporary Wav File
							Debug.Log( "Saving @ " + filePath);
							//Insert your API KEY here.
							string apiURL = "https://speech.googleapis.com/v1/speech:recognize?&key=AIzaSyCDAd1LVa8TOkpby_J9ezKK_bh9FO7vFcE";
							string Response;

							Debug.Log( "Uploading " + filePath);
							Response = HttpUploadFile (apiURL, filePath, "file", "audio/wav; rate=44100", targetWord);
							Debug.Log ("Response String: " +Response);

							var jsonresponse = SimpleJSON.JSON.Parse(Response);

							if (jsonresponse != null) {		
									string resultString = jsonresponse ["result"] [0].ToString ();
									var jsonResults = SimpleJSON.JSON.Parse (resultString);

									string transcripts = jsonResults ["alternative"] [0] ["transcript"].ToString ();

									Debug.Log ("transcript string: " + transcripts );
									// TextBox.text = transcripts;

							}
							//goAudioSource.Play(); //Playback the recorded audio

							File.Delete(filePath); //Delete the Temporary Wav file

					}
			}
			else // No microphone
			{
					Debug.Log("마이크연결좀");
			}
	}

	public static string HttpUploadFile(string url, string file, string paramName, string contentType, string targetWord) {

        System.Net.ServicePointManager.ServerCertificateValidationCallback += (o, certificate, chain, errors) => true;
        Debug.Log(string.Format("Uploading {0} to {1}", file, url));

        Byte[] bytes = File.ReadAllBytes(file);
        String file64 = Convert.ToBase64String(bytes,
                                         Base64FormattingOptions.None);

        Debug.Log("44"+file64);

        try
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
				string json = "{ \"config\": { \"languageCode\" : \"ko-KR\" }, \"audio\" : { \"content\" : \"" + file64 + "\"}}";
              
                Debug.Log("11"+json);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Debug.Log("22"+httpResponse);
            
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
				streamReader.ReadLine();
				streamReader.ReadLine();
				streamReader.ReadLine();
				streamReader.ReadLine();
				streamReader.ReadLine();


                var result = streamReader.ReadLine();
				// var result = streamReader.ReadToEnd();

				if (targetWord == "로그인입력")
                {
					Debug.Log("로그인 입력 확인");
					Debug.Log(result);
					int lenResult = result.Length;
					Debug.Log(lenResult);
					result = result.Substring(25, lenResult-27);
					Debug.Log(result);
					LoginInput.ConfirmNickname(result);
					//           "transcript": "나올 꺼져",
				}

				else
                {
					string targetWord2 = initial + targetWord + "\",";
					Debug.Log("확인");
					Debug.Log(result);
					Debug.Log(targetWord);
					if (result == targetWord2)
					{
						Debug.Log("111111111111");
						Debug.Log("Response:" + result);
						Debug.Log("2222222222222");

						TryStt.Interact(targetWord);
					}

				}
			}
        
        } catch (WebException ex) {
 			var resp = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
			Debug.Log("3333333333");
            Debug.Log(resp);
			Debug.Log("4444444444");
 
}


        return "empty";
		
	}

	

}
		
