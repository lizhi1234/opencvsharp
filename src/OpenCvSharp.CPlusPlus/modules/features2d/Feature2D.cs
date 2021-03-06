﻿using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    public class Feature2D : FeatureDetector
    {
        private bool disposed;
        /// <summary>
        /// cv::Ptr&lt;Feature2D&gt;
        /// </summary>
        private PtrOfFeature2D detectorPtr;

        /// <summary>
        /// 
        /// </summary>
        internal Feature2D()
            : base()
        {
        }
        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal static new Feature2D FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid FeatureDetector pointer");
            Feature2D detector = new Feature2D();
            PtrOfFeature2D ptrObj = new PtrOfFeature2D(ptr);
            detector.detectorPtr = ptrObj;
            detector.ptr = ptrObj.ObjPointer;
            return detector;
        }
        /// <summary>
        /// Creates instance from raw pointer T*
        /// </summary>
        /// <param name="ptr"></param>
        internal static new Feature2D FromRawPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid FeatureDetector pointer");
            Feature2D detector = new Feature2D
                {
                    detectorPtr = null, 
                    ptr = ptr
                };
            return detector;
        }


#if LANG_JP
    /// <summary>
    /// リソースの解放
    /// </summary>
    /// <param name="disposing">
    /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
    /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
    ///</param>
#else
        /// <summary>
        /// Releases the resources
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    // releases managed resources
                    if (disposing)
                    {
                    }
                    // releases unmanaged resources
                    if (IsEnabledDispose)
                    {
                        if (detectorPtr != null)
                            detectorPtr.Dispose();
                        detectorPtr = null;
                        ptr = IntPtr.Zero;
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="keypoints"></param>
        /// <param name="descriptors"></param>
        public void Compute(Mat image, out KeyPoint[] keypoints, Mat descriptors)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            using (VectorOfKeyPoint keypointsVec = new VectorOfKeyPoint())
            {
                NativeMethods.features2d_Feature2D_compute(ptr, image.CvPtr, keypointsVec.CvPtr, descriptors.CvPtr);
                keypoints = keypointsVec.ToArray();
            }
        }

        /// <summary>
        /// Create feature detector by detector name.
        /// </summary>
        /// <param name="detectorType"></param>
        /// <returns></returns>
        public static new Feature2D Create(string detectorType)
        {
            if(String.IsNullOrEmpty(detectorType))
                throw new ArgumentNullException("detectorType");
            // gets cv::Ptr<Feature2D>
            IntPtr ptr = NativeMethods.features2d_Feature2D_create(detectorType);
            try
            {
                Feature2D detector = FromPtr(ptr);
                return detector;
            }
            catch (OpenCvSharpException)
            {
                throw new OpenCvSharpException("Detector name '{0}' is not valid.", detectorType);
            }
        }

    }
}
