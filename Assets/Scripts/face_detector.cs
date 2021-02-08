using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp;


public class face_detector : MonoBehaviour
{
    WebCamTexture wct;
    CascadeClassifier cascade;

    public float face_x, face_y;

    // Start is called before the first frame update
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        wct = new WebCamTexture(devices[0].name);
        wct.Play();
        cascade = new CascadeClassifier(Application.dataPath + @"/haarcascade_frontalface_default.xml");
        //Debug.Log(Application.dataPath);

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.mainTexture = wct;
        Mat frame = OpenCvSharp.Unity.TextureToMat(wct);
        findFace(frame);

    }

    private void findFace(Mat m)
    {
        var faces = cascade.DetectMultiScale(m, 1.1, 2, HaarDetectionType.ScaleImage);
        if (faces.Length > 0)
        {
            face_x = faces[0].Location.X;
            face_y = faces[0].Location.Y;
            //Debug.Log(faces[0].Location);
        }

    }
}
