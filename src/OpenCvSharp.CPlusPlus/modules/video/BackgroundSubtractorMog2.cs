using System;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// The Base Class for Background/Foreground Segmentation.
    /// The class is only used to define the common interface for
    /// the whole family of background/foreground segmentation algorithms.
    /// </summary>
    public class BackgroundSubtractorMog2 : BackgroundSubtractor
    {
        /// <summary>
        /// sizeof(BackgroundSubtractorMOG2)
        /// </summary>
        public static new readonly int SizeOf = NativeMethods.video_BackgroundSubtractorMOG2_sizeof().ToInt32();

        #region Init
        /// <summary>
        /// the default constructor
        /// </summary>
        public BackgroundSubtractorMog2()
        {
            ptr = NativeMethods.video_BackgroundSubtractorMOG2_new1();
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        /// <summary>
        /// the full constructor that takes the length of the history, the number of gaussian mixtures, the background ratio parameter and the noise strength
        /// </summary>
        /// <param name="history"></param>
        /// <param name="varThreshold"></param>
        /// <param name="bShadowDetection"></param>
        public BackgroundSubtractorMog2(int history, float varThreshold, bool bShadowDetection = true)
        {
            ptr = NativeMethods.video_BackgroundSubtractorMOG2_new2(history, varThreshold, bShadowDetection ? 1 : 0);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        #endregion
        #region Dispose
#if LANG_JP
    /// <summary>
    /// リソースの解放
    /// </summary>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
#endif
        public void Release()
        {
            Dispose(true);
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
        /// Clean up any resources being used.
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
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        NativeMethods.video_BackgroundSubtractorMOG2_delete(ptr);
                    }
                    disposed = true;
                }
                finally
                {
                    // 親の解放処理
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        /// <summary>
        /// the update operator
        /// </summary>
        /// <param name="image"></param>
        /// <param name="fgmask"></param>
        /// <param name="learningRate"></param>
        public override void Run(InputArray image, OutputArray fgmask, double learningRate = 0)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (fgmask == null)
                throw new ArgumentNullException("fgmask");
            NativeMethods.video_BackgroundSubtractorMOG2_operator(ptr, image.CvPtr, fgmask.CvPtr, learningRate);
        }

        /// <summary>
        /// computes a background image
        /// </summary>
        /// <param name="backgroundImage"></param>
        public override void GetBackgroundImage(OutputArray backgroundImage)
        {
            if (backgroundImage == null)
                throw new ArgumentNullException("backgroundImage");
            NativeMethods.video_BackgroundSubtractorMOG2_getBackgroundImage(ptr, backgroundImage.CvPtr);
        }

        /// <summary>
        /// re-initiaization method
        /// </summary>
        /// <param name="frameSize"></param>
        /// <param name="frameType"></param>
        public virtual void Initialize(CvSize frameSize, int frameType)
        {
            NativeMethods.video_BackgroundSubtractorMOG2_initialize(ptr, frameSize, frameType);
        }

        #region Properties
        /*
        /// <summary>
        /// 
        /// </summary>
        public CvSize FrameSize
        {
            get
            {
                return NativeMethods.BackgroundSubtractorMOG2_frameSize_get(ptr);
            }
            set
            {
                NativeMethods.BackgroundSubtractorMOG2_frameSize_set(ptr, value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FrameType
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.BackgroundSubtractorMOG2_frameType(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.BackgroundSubtractorMOG2_frameType(ptr) = value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Mat BgModel
        {
            get
            {
                unsafe
                {
                    return new Mat(NativeMethods.BackgroundSubtractorMOG2_bgmodel(ptr));
                }
            }
        }
        /// <summary>
        /// keep track of number of modes per pixel
        /// </summary>
        public Mat BgmodelUsedModes
        {
            get
            {
                unsafe
                {
                    return new Mat(NativeMethods.BackgroundSubtractorMOG2_bgmodelUsedModes(ptr));
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Nframes
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.BackgroundSubtractorMOG2_nframes(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.BackgroundSubtractorMOG2_nframes(ptr) = value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int History
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.BackgroundSubtractorMOG2_history(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.BackgroundSubtractorMOG2_history(ptr) = value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Nmixtures
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.BackgroundSubtractorMOG2_nmixtures(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.BackgroundSubtractorMOG2_nmixtures(ptr) = value;
                }
            }
        }
        /// <summary>
        /// here it is the maximum allowed number of mixture comonents.
        /// Actual number is determined dynamically per pixel.
        /// </summary>
        public float VarThreshold
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.BackgroundSubtractorMOG2_varThreshold(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.BackgroundSubtractorMOG2_varThreshold(ptr) = value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public float BackgroundRatio
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.BackgroundSubtractorMOG2_backgroundRatio(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.BackgroundSubtractorMOG2_backgroundRatio(ptr) = value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public float VarThresholdGen
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.BackgroundSubtractorMOG2_varThresholdGen(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.BackgroundSubtractorMOG2_varThresholdGen(ptr) = value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public float FVarInit
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.BackgroundSubtractorMOG2_fVarInit(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.BackgroundSubtractorMOG2_fVarInit(ptr) = value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public float FVarMin
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.BackgroundSubtractorMOG2_fVarMin(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.BackgroundSubtractorMOG2_fVarMin(ptr) = value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public float fVarMax
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.BackgroundSubtractorMOG2_fVarMax(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.BackgroundSubtractorMOG2_fVarMax(ptr) = value;
                }
            }
        }
        /// <summary>
        /// CT - complexity reduction prior
        /// </summary>
        public float FCT
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.BackgroundSubtractorMOG2_fCT(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.BackgroundSubtractorMOG2_fCT(ptr) = value;
                }
            }
        }
        /// <summary>
        /// default 1 - do shadow detection
        /// </summary>
        public bool BShadowDetection
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.BackgroundSubtractorMOG2_bShadowDetection(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.BackgroundSubtractorMOG2_bShadowDetection(ptr) = value;
                }
            }
        }//
        /// <summary>
        /// do shadow detection - insert this value as the detection result - 127 default value
        /// </summary>
        public byte NShadowDetection
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.BackgroundSubtractorMOG2_nShadowDetection(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.BackgroundSubtractorMOG2_nShadowDetection(ptr) = value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public float FTau
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.BackgroundSubtractorMOG2_fTau(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.BackgroundSubtractorMOG2_fTau(ptr) = value;
                }
            }
        }
        //*/
        #endregion
    }
}