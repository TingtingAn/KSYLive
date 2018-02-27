using System;
using System.Runtime.InteropServices;
using CoreGraphics;
using CoreMedia;
using CoreVideo;
using Foundation;
using ObjCRuntime;

namespace KSYLive
{
    [Native]
    public enum KSYLiveScene : ulong
    {
        Default = 0,
        Showself,
        Game
    }

    [Native]
    public enum KSYGPUStreamerKitType : ulong
    {
        Default = 0,
        Interrupt
    }

    [Native]
    public enum KSYRecScene : ulong
    {
        BitRate = 0,
        Quality
    }

    [Native]
    public enum KSYVideoEncodePerformance : ulong
    {
        LowPower = 0,
        Balance,
        HighPerformance
    }

    [Native]
    public enum KSYDevAuthStatus : ulong
    {
        NotDetermined = 0,
        Restricted,
        Denied,
        Authorized
    }

    [Native]
    public enum KSYVideoDimension : ulong
    {
        KSYVideoDimension_16_9__1280x720 = 0,
        KSYVideoDimension_16_9__960x540,
        KSYVideoDimension_4_3__640x480,
        KSYVideoDimension_16_9__640x360,
        KSYVideoDimension_5_4__352x288,
        UserDefine_Scale,
        UserDefine_Crop,
        Default = KSYVideoDimension_4_3__640x480
    }

    [Native]
    public enum KSYVideoCodec : ulong
    {
        X264 = 0,
        Qy265,
        Vt264,
        Vt265,
        Auto = 100,
        Gif
    }

    [Native]
    public enum KSYAudioCodec : ulong
    {
        AcHe = 0,
        Ac,
        TAac,
        AcHeV2
    }

    [Native]
    public enum KSYCaptureState : ulong
    {
        Idle,
        Capturing,
        DevAuthDenied,
        ClosingCapture,
        ParameterError,
        DevBusy
    }

    [Native]
    public enum KSYStreamState : ulong
    {
        Idle = 0,
        Connecting,
        Connected,
        Disconnecting,
        Error
    }

    [Native]
    public enum KSYStreamErrorCode : ulong
    {
        None = 0,
        Ksyauthfailed,
        EncodeFramesFailed,
        CodecOpenFailed,
        ConnectFailed,
        ConnectBreak,
        RTMP_NonExistDomain,
        RTMP_NonExistApplication,
        RTMP_AlreadyExistStreamName,
        RTMP_ForbiddenByBlacklist,
        RTMP_InternalError,
        RTMP_URLExpired,
        RTMP_SignatureDoesNotMatch,
        RTMP_InvalidAccessKeyId,
        RTMP_BadParams,
        RTMP_ForbiddenByRegion,
        FramesThreshold,
        NoInputSample,
        DNS_Parse_failed,
        Connect_Server_failed,
        RTMP_Publish_failed,
        AvSyncError,
        InvalidAddress,
        NetworkUnreachable,
        RTMP_GetUserIdFailed,
        RTMP_AkAndUserIsNotMatch,
        RTMP_GetServerInfoFailed,
        RTMP_IllegalOutsideUrl,
        RTMP_OutsideAuthFailed,
        RTMP_SimpleAuthFailed,
        RTMP_InvalidAuthType,
        RTMP_IllegalUserId
    }

    [Native]
    public enum KSYNetStateCode : ulong
    {
        None = 0,
        SendPacketSlow,
        EstBwRaise,
        EstBwDrop,
        VideoFpsRaise,
        VideoFpsDrop,
        Ksyauthfailed,
        InAudioDiscontinuous,
        Unreachable,
        Reachable
    }

    [Native]
    public enum KSYBgmPlayerState : ulong
    {
        Init,
        Starting,
        Stopped,
        Playing,
        Paused,
        Error,
        Interrupted
    }

    [Native]
    public enum KSYMicType : ulong
    {
        builtinMic = 0,
        headsetMic,
        bluetoothMic,
        unknow = 1000
    }

    [Native]
    public enum KSYBWEstimateMode : ulong
    {
        Default = 0,
        Negtive,
        Disable = 1000
    }

    [Native]
    public enum KSYRecordState : long
    {
        Idle,
        Recording,
        Stopped,
        Error
    }

    [Native]
    public enum KSYRecordError : long
    {
        None,
        PathInvalid,
        FormatNotSupport,
        Internal
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct KSYStreamerQosInfo
    {
        public int audioBufferDataSize;

        public int audioBufferTimeLength;

        public int audioBufferPackets;

        public long audioTotalDataSize;

        public int videoBufferDataSize;

        public int videoBufferTimeLength;

        public int videoBufferPackets;

        public long videoTotalDataSize;
    }

    [Native]
    public enum KSYNetReachState : long
    {
        Unknown,
        Ok,
        Bad
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct GPUTextureOptions
    {
        public uint minFilter;

        public uint magFilter;

        public uint wrapS;

        public uint wrapT;

        public uint internalFormat;

        public uint format;

        public uint type;
    }

    public enum GPUImageRotationMode : uint
    {
        NoRotation,
        RotateLeft,
        RotateRight,
        FlipVertical,
        FlipHorizonal,
        RotateRightFlipVertical,
        RotateRightFlipHorizontal,
        Rotate180
    }

    static class CFunctions
    {
        // extern void runOnMainQueueWithoutDeadlocking (void (^block)());
        [DllImport ("__Internal")]

        static extern void runOnMainQueueWithoutDeadlocking (Action block);

        // extern void runSynchronouslyOnVideoProcessingQueue (void (^block)());
        [DllImport ("__Internal")]

        static extern void runSynchronouslyOnVideoProcessingQueue (Action block);

        // extern void runAsynchronouslyOnVideoProcessingQueue (void (^block)());
        [DllImport ("__Internal")]

        static extern void runAsynchronouslyOnVideoProcessingQueue (Action block);

        // extern void runSynchronouslyOnContextQueue (GPUImageContext *context, void (^block)());
        [DllImport ("__Internal")]

        static extern void runSynchronouslyOnContextQueue (GPUImageContext context, Action block);

        // extern void runAsynchronouslyOnContextQueue (GPUImageContext *context, void (^block)());
        [DllImport ("__Internal")]

        static extern void runAsynchronouslyOnContextQueue (GPUImageContext context, Action block);

        // extern void reportAvailableMemoryForGPUImage (NSString *tag);
        [DllImport ("__Internal")]

        static extern void reportAvailableMemoryForGPUImage (NSString tag);

        // extern void stillImageDataReleaseCallback (void *releaseRefCon, const void *baseAddress);
        [DllImport ("__Internal")]

        static extern unsafe void stillImageDataReleaseCallback (void* releaseRefCon, void* baseAddress);

        // extern void GPUImageCreateResizedSampleBuffer (CVPixelBufferRef cameraFrame, CGSize finalSize, CMSampleBufferRef *sampleBuffer);
        [DllImport ("__Internal")]

        static extern unsafe void GPUImageCreateResizedSampleBuffer (CVPixelBuffer cameraFrame, CGSize finalSize, CMSampleBuffer sampleBuffer);
    }

    public enum GPUImageFillModeType : uint
    {
        Stretch,
        PreserveAspectRatio,
        PreserveAspectRatioAndFill
    }

    public enum GPUPixelFormat : uint
    {
        Bgra = 32993,
        Rgba = 6408,
        Rgb = 6407,
        Luminance = 6409
    }

    public enum GPUPixelType : uint
    {
        UByte = 5121,
        Float = 5126
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct GPUByteColorVector
    {
        public byte red;

        public byte green;

        public byte blue;

        public byte alpha;
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct GPUVector4
    {
        public float one;

        public float two;

        public float three;

        public float four;
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct GPUVector3
    {
        public float one;

        public float two;

        public float three;
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct GPUMatrix4x4
    {
        public GPUVector4 one;

        public GPUVector4 two;

        public GPUVector4 three;

        public GPUVector4 four;
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct GPUMatrix3x3
    {
        public GPUVector3 one;

        public GPUVector3 two;

        public GPUVector3 three;
    }

    public enum GPUImageHistogramType : uint
    {
        Red,
        Green,
        Blue,
        Rgb,
        Luminance
    }

    public enum GPUImageFASTDetectorType : uint
    {
        kGPUImageFAST12Contiguous,
        NonMaximumSuppressed
    }

    [Native]
    public enum KSYAudioEffectType : ulong
    {
        None = 0,
        Male,
        Female,
        Heroic,
        Robot,
        Coustom
    }

    [Native]
    public enum KSYAudioNoiseSuppress : long
    {
        Off = -1,
        Low = 0,
        Medium = 1,
        High = 2,
        Veryhigh = 3
    }

    [Native]
    public enum KSYAVMuxerStatus : long
    {
        Idle,
        Muxing,
        Completed,
        Failed,
        Cancelled
    }

    [Native]
    public enum KSYGPUEffectType : long
    {
        None = 0,
        Freshy,
        Beauty,
        Sweety,
        Sepia,
        Blue,
        Nostalgia,
        Sakura,
        Sakura_night,
        Ruddy_night,
        Sunshine_night,
        Ruddy,
        Sushine,
        Nature,
        Amatorka,
        Elegance,
        KSYGPUEffectType_1977,
        Amaro,
        Brannan,
        Early_bird,
        Hefe,
        Hudson,
        Ink,
        Lomo,
        Lord_kelvin,
        Nashville,
        Rise,
        Sierra,
        Sutro,
        Toaster,
        Valencia,
        Walden,
        Xproll
    }

    [Native]
    public enum KSYTranscodeState : long
    {
        Idle,
        Transcoding,
        Completed,
        Error
    }

    [Native]
    public enum KSYTranscodeErrorCode : long
    {
        None = 0,
        InvalidAddress = -1,
        InputFile_OpenFailed = -2,
        InvalidData = -3,
        OutputFile_UnsupportedFormat = -4,
        OutputFile_OpenFailed = -5,
        OutputFile_AddStreamFailed = -6,
        OutputFile_StartWriteFailed = -7,
        Transcoding_Failed = -8
    }

    [Native]
    public enum KSYMPErrorCode : long
    {
        Ok = 0,
        ErrorCodeUnknownError = 1,
        ErrorCodeFileIOError = -1004,
        ErrorCodeUnsupportProtocol = -10001,
        ErrorCodeDNSParseFailed = -10002,
        ErrorCodeCreateSocketFailed = -10003,
        ErrorCodeConnectServerFailed = -10004,
        ErrorCodeBadRequest = -10005,
        ErrorCodeUnauthorizedClient = -10006,
        ErrorCodeAccessForbidden = -10007,
        ErrorCodeTargetNotFound = -10008,
        ErrorCodeOtherErrorCode = -10009,
        ErrorCodeServerException = -10010,
        ErrorCodeInvalidData = -10011,
        ErrorCodeUnsupportVideoCodec = -10012,
        ErrorCodeUnsupportAudioCodec = -10013,
        ErrorCodeVideoDecodeFailed = -10014,
        ErrorCodeAudioDecodeFailed = -10015,
        ErrorCode3xxOverFlow = -10016,
        ErrorInvalidURL = -10050,
        ErrorNetworkUnReachable = -10051
    }

    [Native]
    public enum MPMovieStatus : long
    {
        VideoDecodeWrong,
        AudioDecodeWrong,
        HWCodecUsed,
        SWCodecUsed,
        DLCodecUsed
    }

    [Native]
    public enum MPMovieVideoDecoderMode : ulong
    {
        Software = 0,
        Hardware,
        Auto,
        DisplayLayer
    }

    [Native]
    public enum MPMovieReloadMode : ulong
    {
        Fast,
        Accurate
    }

    [Native]
    public enum MPMovieVideoDeinterlaceMode : ulong
    {
        None = 0,
        Auto
    }

    [Native]
    public enum MPMovieAudioPan : long
    {
        Left = -1,
        Stereo,
        Right
    }

    [Native]
    public enum MPMovieMetaType : long
    {
        Media = 0,
        Video,
        Audio,
        Subtitle
    }

    [Native]
    public enum KSYNetworkStatus : long
    {
        NotReachable = 0,
        ReachableViaWiFi = 2,
        ReachableViaWWAN = 1
    }

    [Native]
    public enum MediainfoMuxType : long
    {
        Unknown,
        Mp2t,
        Mov,
        Avi,
        Flv,
        Mkv,
        Asf,
        Rm,
        Wav,
        Ogg,
        Ape,
        Rawvideo,
        Hls
    }

    [Native]
    public enum MediainfoCodecId : long
    {
        IdUnknown,
        Mpeg2video,
        Mpeg4,
        Mjpeg,
        Jpeg2000,
        H264,
        Hevc,
        Vc1,
        IdFirstAudio = 65536,
        Aac,
        Ac3,
        Mp3,
        Pcm,
        Dts,
        Nellymoser
    }

    [Native]
    public enum MediainfoSampleFmt : long
    {
        Unknown,
        U8,
        S16,
        S32,
        Flt,
        Dbl,
        U8p,
        S16p,
        S32p,
        Fltp,
        Dblp,
        Nb
    }

    [Native]
    public enum KsyNettrackerAction : long
    {
        Mtr,
        Ping
    }

    [Native]
    public enum KSYShakeType : long
    {
        Zoom = 0,
        Color = 1,
        ShockWave = 2,
        BlackMagic = 3,
        Lightning = 4,
        Ktv = 5
    }

    [Native]
    public enum KSYTransitionType : ulong
    {
        None = 0,
        FadesIn,
        BlurIn,
        FadesOut = 101,
        BlurOut,
        FadesInOut = 201,
        FlashBlack,
        FlashWhite,
        BlurInOut,
        PushUp,
        PushDown,
        PushLeft,
        PushRight
    }

    [Native]
    public enum KSYOverlapType : ulong
    {
        BothVideo = 0,
        LastFrameVideo = 1,
        VideoFirstFrame = 2,
        VideoOnly = 3
    }

    [Native]
    public enum KSYTPushDirection : ulong
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3
    }

    [Native]
    public enum KSYAudioCapType : long
    {
        udioUnit,
        VCaptureDevice
    }

    [Native]
    public enum KSYAudioDataType : long
    {
        CMSampleBuffer,
        RawPCM
    }

    [Native]
    public enum KSYStreamerProfile : long
    {
        KSYStreamerProfile_360p_auto = 0,
        KSYStreamerProfile_360p_1 = 1,
        KSYStreamerProfile_360p_2 = 2,
        KSYStreamerProfile_360p_3 = 3,
        KSYStreamerProfile_540p_auto = 100,
        KSYStreamerProfile_540p_1 = 101,
        KSYStreamerProfile_540p_2 = 102,
        KSYStreamerProfile_540p_3 = 103,
        KSYStreamerProfile_720p_auto = 200,
        KSYStreamerProfile_720p_1 = 201,
        KSYStreamerProfile_720p_2 = 202,
        KSYStreamerProfile_720p_3 = 203
    }

    [Native]
    public enum KSYPlayRecordScheme : ulong
    {
        PicMix_Scheme = 0,
        ScreenShot_Scheme
    }
}
