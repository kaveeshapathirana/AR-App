using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SocialShare : MonoBehaviour
{

private string shareMessage;

public void ClickShareButton()
{
    shareMessage="look what i bought from Thaki's. i love it.\n #Thakis #ThakisAR #Decors ";
    StartCoroutine(TakeScreenshotAndShare());
}


private IEnumerator TakeScreenshotAndShare()
{
	yield return new WaitForEndOfFrame();

	Texture2D ss = new Texture2D( Screen.width, Screen.height, TextureFormat.RGB24, false );
	ss.ReadPixels( new Rect( 0, 0, Screen.width, Screen.height ), 0, 0 );
	ss.Apply();

	string filePath = Path.Combine( Application.temporaryCachePath, "shared img.png" );
	File.WriteAllBytes( filePath, ss.EncodeToPNG() );

	// To avoid memory leaks
	Destroy( ss );

	new NativeShare().AddFile( filePath )
		.SetSubject( "Thaki's AR" ).SetText( shareMessage ).SetUrl( "https://www.instagram.com/_.thakis._/" )
		.SetCallback( ( result, shareTarget ) => Debug.Log( "Share result: " + result + ", selected app: " + shareTarget ) )
		.Share();


        //https://github.com/yasirkula/UnityNativeShare

        //https://www.instagram.com/_.thakis._/
}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
