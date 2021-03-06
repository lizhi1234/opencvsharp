﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace CppStyleSamplesCS
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ISample sample =
                //new VideoWriterSample();
                //new VideoCaptureSample();
                //new MatToBitmap();
                //new MatToIplImage();
                //new SiftSurfSample();
                //new HistSample();
                //new Subdiv2DSample();
                //new FASTSample();
                //new FlannSample(); // Todo: crash
                //new HOGSample();
                //new HoughLinesSample();
                //new MSERSample();
                //new MDS();
                //new PixelAccess();
                //new StarDetectorSample();
                //new StereoCorrespondence();
                //new MorphologySample();
                //new MergeSplitSample();
                //new NormalArrayOperations();
                //new SolveEquation();
                //new MatOperations();
                new FaceDetection();
            sample.Run();
        }
    }
}
