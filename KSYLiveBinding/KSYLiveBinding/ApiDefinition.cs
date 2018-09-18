using System;
using AVFoundation;
using AudioToolbox;
using CoreAnimation;
using CoreFoundation;
using CoreGraphics;
using CoreMedia;
using CoreVideo;
using Foundation;
using MediaPlayer;
using ObjCRuntime;
using OpenGLES;
using UIKit;
using GPUImage;

namespace KSYLive
{
    // @interface KSY (AVAudioSession)
    [Category]
    [BaseType(typeof(AVAudioSession))]
    interface AVAudioSession_KSY
    {
        // -(void)setDefaultCfg;
        [Export("setDefaultCfg")]
        void SetDefaultCfg();

        // @property (assign, nonatomic) BOOL bInterruptOtherAudio;
        [Export("bInterruptOtherAudio")]
        bool BInterruptOtherAudio();

        // @property (assign, nonatomic) BOOL bDefaultToSpeaker;
        [Export("bDefaultToSpeaker")]
        bool BDefaultToSpeaker();

        // @property (assign, nonatomic) BOOL bAllowBluetooth;
        [Export("bAllowBluetooth")]
        bool BAllowBluetooth();

        // @property (assign, nonatomic) NSString * AVAudioSessionCategory;
        [Export("AVAudioSessionCategory")]
        string AVAudioSessionCategory();

        // +(BOOL)isBluetoothInputAvaible;
        [Static]
        [Export("isBluetoothInputAvaible")]

        bool IsBluetoothInputAvaible { get; }

        // +(BOOL)switchBluetoothInput:(BOOL)onOrOff;
        [Static]
        [Export("switchBluetoothInput:")]
        bool SwitchBluetoothInput(bool onOrOff);

        // +(BOOL)isHeadsetInputAvaible;
        [Static]
        [Export("isHeadsetInputAvaible")]

        bool IsHeadsetInputAvaible { get; }

        // +(BOOL)isHeadsetPluggedIn;
        [Static]
        [Export("isHeadsetPluggedIn")]

        bool IsHeadsetPluggedIn { get; }

        // @property KSYMicType currentMicType;
        [Export("currentMicType", ArgumentSemantic.Assign)]
        KSYMicType CurrentMicType();
    }

    // @interface GLProgram : NSObject
    [BaseType(typeof(NSObject))]
    interface GLProgram
    {
        // @property (readwrite, nonatomic) BOOL initialized;
        [Export("initialized")]
        bool Initialized { get; set; }

        // @property (readwrite, copy, nonatomic) NSString * vertexShaderLog;
        [Export("vertexShaderLog")]
        string VertexShaderLog { get; set; }

        // @property (readwrite, copy, nonatomic) NSString * fragmentShaderLog;
        [Export("fragmentShaderLog")]
        string FragmentShaderLog { get; set; }

        // @property (readwrite, copy, nonatomic) NSString * programLog;
        [Export("programLog")]
        string ProgramLog { get; set; }

        // -(id)initWithVertexShaderString:(NSString *)vShaderString fragmentShaderString:(NSString *)fShaderString;
        [Export("initWithVertexShaderString:fragmentShaderString:")]
        IntPtr Constructor(string vShaderString, string fShaderString);

        // -(id)initWithVertexShaderString:(NSString *)vShaderString fragmentShaderFilename:(NSString *)fShaderFilename;
        [Export("initWithVertexShaderString:fragmentShaderFilename:")]
        IntPtr ConstructorWithVertexShaderString(string vShaderString, string fShaderFilename);

        // -(id)initWithVertexShaderFilename:(NSString *)vShaderFilename fragmentShaderFilename:(NSString *)fShaderFilename;
        [Export("initWithVertexShaderFilename:fragmentShaderFilename:")]
        IntPtr ConstructorWithVertexShaderFilename(string vShaderFilename, string fShaderFilename);

        // -(void)addAttribute:(NSString *)attributeName;
        [Export("addAttribute:")]
        void AddAttribute(string attributeName);

        // -(GLuint)attributeIndex:(NSString *)attributeName;
        [Export("attributeIndex:")]
        uint AttributeIndex(string attributeName);

        // -(GLuint)uniformIndex:(NSString *)uniformName;
        [Export("uniformIndex:")]
        uint UniformIndex(string uniformName);

        // -(BOOL)link;
        [Export("link")]

        bool Link { get; }

        // -(void)use;
        [Export("use")]
        void Use();

        // -(void)validate;
        [Export("validate")]
        void Validate();
    }

    // @interface KSYAQPlayer : NSObject
    [BaseType(typeof(NSObject))]
    interface KSYAQPlayer
    {
        // -(BOOL)play:(AudioStreamBasicDescription *)fmt;
        [Export("play:")]
        unsafe bool Play(AudioStreamBasicDescription fmt);

        // -(void)stop;
        [Export("stop")]
        void Stop();

        // -(void)pause;
        [Export("pause")]
        void Pause();

        // -(void)resume;
        [Export("resume")]
        void Resume();

        // @property (assign, nonatomic) double volume;
        [Export("volume")]
        double Volume { get; set; }

        // @property (assign, nonatomic) double pitch;
        [Export("pitch")]
        double Pitch { get; set; }

        // @property (assign, nonatomic) double playRate;
        [Export("playRate")]
        double PlayRate { get; set; }

        // @property (readonly, nonatomic) AudioStreamBasicDescription inFmt;
        [Export("inFmt")]
        AudioStreamBasicDescription InFmt { get; }

        // @property (readonly, nonatomic) AudioStreamBasicDescription outFmt;
        [Export("outFmt")]
        AudioStreamBasicDescription OutFmt { get; }

        // @property (assign, nonatomic) BOOL mute;
        [Export("mute")]
        bool Mute { get; set; }

        // @property (copy, nonatomic) BOOL (^pullDataCB)(AudioQueueBufferRef);
        [Export("pullDataCB", ArgumentSemantic.Copy)]
        unsafe Func<AudioToolbox.AudioQueueBuffer, bool> PullDataCB { get; set; }

        // @property (copy, nonatomic) BOOL (^putDataCB)(uint8_t **, int, const AudioStreamBasicDescription *, CMTime);
        [Export("putDataCB", ArgumentSemantic.Copy)]
        unsafe Func<byte, int, AudioStreamBasicDescription, CMTime, bool> PutDataCB { get; set; }

        // @property (readonly, nonatomic) BOOL isRunning;
        [Export("isRunning")]
        bool IsRunning { get; }

        // @property (readonly, nonatomic) BOOL isPaused;
        [Export("isPaused")]
        bool IsPaused { get; }

        // @property (readonly, nonatomic) OSStatus audioErrorCode;
        [Export("audioErrorCode")]
        int AudioErrorCode { get; }
    }

    // @interface KSYAUAudioCapture : NSObject
    [BaseType(typeof(NSObject))]
    interface KSYAUAudioCapture
    {
        // -(id)initWithSampleRate:(double)sampleRate;
        [Export("initWithSampleRate:")]
        IntPtr Constructor(double sampleRate);

        // -(BOOL)startCapture;
        [Export("startCapture")]

        bool StartCapture { get; }

        // -(void)stopCapture;
        [Export("stopCapture")]
        void StopCapture();

        // -(BOOL)pauseCapture;
        [Export("pauseCapture")]

        bool PauseCapture { get; }

        // -(BOOL)pauseWithMuteData;
        [Export("pauseWithMuteData")]

        bool PauseWithMuteData { get; }

        // -(BOOL)resumeCapture;
        [Export("resumeCapture")]

        bool ResumeCapture { get; }

        // @property (assign, nonatomic) BOOL bPlayCapturedAudio;
        [Export("bPlayCapturedAudio")]
        bool BPlayCapturedAudio { get; set; }

        // @property (assign, nonatomic) BOOL enableVoiceProcess;
        [Export("enableVoiceProcess")]
        bool EnableVoiceProcess { get; set; }

        // @property (assign, nonatomic) KSYAudioNoiseSuppress noiseSuppressionLevel;
        [Export("noiseSuppressionLevel", ArgumentSemantic.Assign)]
        KSYAudioNoiseSuppress NoiseSuppressionLevel { get; set; }

        // @property (assign, nonatomic) BOOL bForceAudioSessionCatogary;
        [Export("bForceAudioSessionCatogary")]
        bool BForceAudioSessionCatogary { get; set; }

        // @property (assign, nonatomic) Float32 micVolume;
        [Export("micVolume")]
        float MicVolume { get; set; }

        // @property (readonly, nonatomic) CMTime outputPts;
        [Export("outputPts")]
        CMTime OutputPts { get; }

        // @property (assign, nonatomic) int reverbType;
        [Export("reverbType")]
        int ReverbType { get; set; }

        // @property (assign, nonatomic) KSYAudioEffectType effectType;
        [Export("effectType", ArgumentSemantic.Assign)]
        KSYAudioEffectType EffectType { get; set; }

        // @property (copy, nonatomic) void (^audioProcessingCallback)(CMSampleBufferRef);
        [Export("audioProcessingCallback", ArgumentSemantic.Copy)]
        Action AudioProcessingCallback { get; set; }

        // @property (copy, nonatomic) void (^pcmProcessingCallback)(uint8_t **, int, const AudioStreamBasicDescription *, CMTime);
        [Export("pcmProcessingCallback", ArgumentSemantic.Copy)]
        Action<byte, int, AudioStreamBasicDescription, CMTime> PcmProcessingCallback { get; set; }

        // @property (copy, nonatomic) void (^customPlayCallback)(AudioBufferList *, UInt32);
        [Export("customPlayCallback", ArgumentSemantic.Copy)]
        Action<AudioBuffers, uint> CustomPlayCallback { get; set; }

        // +(BOOL)isHeadsetPluggedIn;
        [Static]
        [Export("isHeadsetPluggedIn")]

        bool IsHeadsetPluggedIn { get; }

        // @property (readonly, nonatomic) BOOL isRunning;
        [Export("isRunning")]
        bool IsRunning { get; }

        // @property (assign, nonatomic) int effectTypeFlag;
        [Export("effectTypeFlag")]
        int EffectTypeFlag { get; set; }

        // -(void)setReverbParamID:(AudioUnitParameterID)inID withInValue:(AudioUnitParameterValue)inValue;
        [Export("setReverbParamID:withInValue:")]
        void SetReverbParamID(uint inID, float inValue);

        // -(void)setPitchParamID:(AudioUnitParameterID)inID withInValue:(AudioUnitParameterValue)inValue;
        [Export("setPitchParamID:withInValue:")]
        void SetPitchParamID(uint inID, float inValue);

        // -(void)setDelayParamID:(AudioUnitParameterID)inID withInValue:(AudioUnitParameterValue)inValue;
        [Export("setDelayParamID:withInValue:")]
        void SetDelayParamID(uint inID, float inValue);
    }

    // @interface KSYAVAudioSession : NSObject
    [BaseType(typeof(NSObject))]
    interface KSYAVAudioSession
    {
        // @property (assign, nonatomic) BOOL bInterruptOtherAudio;
        [Export("bInterruptOtherAudio")]
        bool BInterruptOtherAudio();

        // @property (assign, nonatomic) BOOL bDefaultToSpeaker;
        [Export("bDefaultToSpeaker")]
        bool BDefaultToSpeaker();

        // @property (assign, nonatomic) BOOL bAllowBluetooth;
        [Export("bAllowBluetooth")]
        bool BAllowBluetooth();

        // -(void)setAVAudioSessionOption;
        [Export("setAVAudioSessionOption")]
        void SetAVAudioSessionOption();

        // @property (assign, nonatomic) NSString * AVAudioSessionCategory;
        [Export("AVAudioSessionCategory")]
        string AVAudioSessionCategory { get; set; }

        // -(BOOL)checkCategory;
        [Export("checkCategory")]

        bool CheckCategory { get; }

        // +(BOOL)isBluetoothInputAvaible;
        [Static]
        [Export("isBluetoothInputAvaible")]

        bool IsBluetoothInputAvaible { get; }

        // +(BOOL)switchBluetoothInput:(BOOL)onOrOff;
        [Static]
        [Export("switchBluetoothInput:")]
        bool SwitchBluetoothInput(bool onOrOff);

        // +(BOOL)isHeadsetInputAvaible;
        [Static]
        [Export("isHeadsetInputAvaible")]

        bool IsHeadsetInputAvaible { get; }

        // +(BOOL)isHeadsetPluggedIn;
        [Static]
        [Export("isHeadsetPluggedIn")]

        bool IsHeadsetPluggedIn { get; }

        // @property KSYMicType currentMicType;
        [Export("currentMicType", ArgumentSemantic.Assign)]
        KSYMicType CurrentMicType();
    }

    // @interface KSYAVFCapture : NSObject <AVCaptureVideoDataOutputSampleBufferDelegate, AVCaptureAudioDataOutputSampleBufferDelegate>
    [BaseType(typeof(NSObject))]
    interface KSYAVFCapture : IAVCaptureVideoDataOutputSampleBufferDelegate, IAVCaptureAudioDataOutputSampleBufferDelegate
    {
        // @property (readonly, nonatomic) BOOL isRunning;
        [Export("isRunning")]
        bool IsRunning { get; }

        // @property (readonly, retain, nonatomic) AVCaptureSession * captureSession;
        [Export("captureSession", ArgumentSemantic.Retain)]
        AVCaptureSession CaptureSession { get; }

        // @property (readwrite, copy, nonatomic) NSString * captureSessionPreset;
        [Export("captureSessionPreset")]
        string CaptureSessionPreset { get; set; }

        // @property (readwrite) int32_t frameRate;
        [Export("frameRate")]
        int FrameRate { get; set; }

        // @property (readwrite) OSType outputPixelFmt;
        [Export("outputPixelFmt")]
        uint OutputPixelFmt { get; set; }

        // @property (readonly, getter = isFrontFacingCameraPresent) BOOL frontFacingCameraPresent;
        [Export("frontFacingCameraPresent")]
        bool FrontFacingCameraPresent { [Bind("isFrontFacingCameraPresent")] get; }

        // @property (readonly, getter = isBackFacingCameraPresent) BOOL backFacingCameraPresent;
        [Export("backFacingCameraPresent")]
        bool BackFacingCameraPresent { [Bind("isBackFacingCameraPresent")] get; }

        // @property (readonly) AVCaptureDevice * inputCamera;
        [Export("inputCamera")]
        AVCaptureDevice InputCamera { get; }

        // @property (readwrite, nonatomic) UIInterfaceOrientation outputImageOrientation;
        [Export("outputImageOrientation", ArgumentSemantic.Assign)]
        UIInterfaceOrientation OutputImageOrientation { get; set; }

        // @property (readwrite, nonatomic) BOOL bMirrorFrontCamera;
        [Export("bMirrorFrontCamera")]
        bool BMirrorFrontCamera { get; set; }

        // @property (readwrite, nonatomic) BOOL bMirrorRearCamera;
        [Export("bMirrorRearCamera")]
        bool BMirrorRearCamera { get; set; }

        // +(BOOL)isBackFacingCameraPresent;
        [Static]
        [Export("isBackFacingCameraPresent")]

        bool IsBackFacingCameraPresent { get; }

        // +(BOOL)isFrontFacingCameraPresent;
        [Static]
        [Export("isFrontFacingCameraPresent")]

        bool IsFrontFacingCameraPresent { get; }

        // +(AVCaptureVideoOrientation)uiOrientationToAVOrientation:(UIInterfaceOrientation)orien;
        [Static]
        [Export("uiOrientationToAVOrientation:")]
        AVCaptureVideoOrientation UiOrientationToAVOrientation(UIInterfaceOrientation orien);

        // -(id)initWithSessionPreset:(NSString *)sessionPreset cameraPosition:(AVCaptureDevicePosition)cameraPosition;
        [Export("initWithSessionPreset:cameraPosition:")]
        IntPtr Constructor(string sessionPreset, AVCaptureDevicePosition cameraPosition);

        // -(BOOL)addAudioInputsAndOutputs;
        [Export("addAudioInputsAndOutputs")]

        bool AddAudioInputsAndOutputs { get; }

        // -(BOOL)removeAudioInputsAndOutputs;
        [Export("removeAudioInputsAndOutputs")]

        bool RemoveAudioInputsAndOutputs { get; }

        // -(void)removeInputsAndOutputs;
        [Export("removeInputsAndOutputs")]
        void RemoveInputsAndOutputs();

        // -(void)startCameraCapture;
        [Export("startCameraCapture")]
        void StartCameraCapture();

        // -(void)stopCameraCapture;
        [Export("stopCameraCapture")]
        void StopCameraCapture();

        // -(void)pauseCameraCapture;
        [Export("pauseCameraCapture")]
        void PauseCameraCapture();

        // -(void)resumeCameraCapture;
        [Export("resumeCameraCapture")]
        void ResumeCameraCapture();

        // -(AVCaptureDevicePosition)cameraPosition;
        [Export("cameraPosition")]

        AVCaptureDevicePosition CameraPosition { get; }

        // -(AVCaptureConnection *)videoCaptureConnection;
        [Export("videoCaptureConnection")]

        AVCaptureConnection VideoCaptureConnection { get; }

        // -(void)rotateCamera;
        [Export("rotateCamera")]
        void RotateCamera();

        // -(CGSize)captureDimension;
        [Export("captureDimension")]

        CGSize CaptureDimension { get; }

        // -(BOOL)isTorchSupported;
        [Export("isTorchSupported")]

        bool IsTorchSupported { get; }

        // -(void)toggleTorch;
        [Export("toggleTorch")]
        void ToggleTorch();

        // -(void)setTorchMode:(AVCaptureTorchMode)mode;
        [Export("setTorchMode:")]
        void SetTorchMode(AVCaptureTorchMode mode);

        // @property (copy, nonatomic) void (^audioProcessingCallback)(CMSampleBufferRef);
        [Export("audioProcessingCallback", ArgumentSemantic.Copy)]
        Action AudioProcessingCallback { get; set; }

        // @property (copy, nonatomic) void (^videoProcessingCallback)(CMSampleBufferRef);
        [Export("videoProcessingCallback", ArgumentSemantic.Copy)]
        Action VideoProcessingCallback { get; set; }

        // @property (copy, nonatomic) void (^interruptCallback)(BOOL);
        [Export("interruptCallback", ArgumentSemantic.Copy)]
        Action<bool> InterruptCallback { get; set; }
    }

    // @interface KSYAVMuxer : NSObject
    [BaseType(typeof(NSObject))]
    interface KSYAVMuxer
    {
        // @property (assign, atomic) BOOL bLoopVideo;
        [Export("bLoopVideo")]
        bool BLoopVideo { get; set; }

        // @property (assign, atomic) BOOL bLoopAudio;
        [Export("bLoopAudio")]
        bool BLoopAudio { get; set; }

        // @property (copy, atomic) NSDictionary * metadata;
        [Export("metadata", ArgumentSemantic.Copy)]
        NSDictionary Metadata { get; set; }

        // -(void)startMuxVideo:(NSURL *)vFile andAudio:(NSURL *)aFile To:(NSURL *)oFile;
        [Export("startMuxVideo:andAudio:To:")]
        void StartMuxVideo(NSUrl vFile, NSUrl aFile, NSUrl oFile);

        // -(void)asyncMuxVideo:(NSURL *)vFile andAudio:(NSURL *)aFile To:(NSURL *)oFile;
        [Export("asyncMuxVideo:andAudio:To:")]
        void AsyncMuxVideo(NSUrl vFile, NSUrl aFile, NSUrl oFile);

        // -(void)cancelMux;
        [Export("cancelMux")]
        void CancelMux();

        // @property (copy, nonatomic) void (^muxCompleteBlock)(KSYAVMuxerStatus);
        [Export("muxCompleteBlock", ArgumentSemantic.Copy)]
        Action<KSYAVMuxerStatus> MuxCompleteBlock { get; set; }
    }

    // @interface KSYAudioFilter : NSObject
    [BaseType(typeof(NSObject))]
    interface KSYAudioFilter
    {
        // @property (assign, nonatomic) float speed;
        [Export("speed")]
        float Speed { get; set; }

        // -(void)processAudioSampleBuffer:(CMSampleBufferRef)inSampleBuffer;
        [Export("processAudioSampleBuffer:")]
        void ProcessAudioSampleBuffer(CMSampleBuffer inSampleBuffer);

        // -(void)processAudioData:(uint8_t **)pData nbSample:(int)nbSample withFormat:(const AudioStreamBasicDescription *)fmt timeinfo:(CMTime)pts;
        [Export("processAudioData:nbSample:withFormat:timeinfo:")]
        void ProcessAudioData(byte pData, int nbSample, AudioStreamBasicDescription fmt, CMTime pts);

        // @property (copy, nonatomic) void (^audioProcessingCallback)(CMSampleBufferRef);
        [Export("audioProcessingCallback", ArgumentSemantic.Copy)]
        Action AudioProcessingCallback { get; set; }

        // @property (copy, nonatomic) void (^pcmProcessingCallback)(uint8_t **, int, CMTime);
        [Export("pcmProcessingCallback", ArgumentSemantic.Copy)]
        Action<byte, int, CMTime> PcmProcessingCallback { get; set; }
    }

    // @interface KSYAudioMixer : NSObject
    [BaseType(typeof(NSObject))]
    interface KSYAudioMixer
    {
        // -(int)getMaxMixTrack;
        [Export("getMaxMixTrack")]

        int MaxMixTrack { get; }

        // -(BOOL)setMixVolume:(float)vol of:(int)trackId;
        [Export("setMixVolume:of:")]
        bool SetMixVolume(float vol, int trackId);

        // -(BOOL)setMixVolume:(float)leftVolume rightVolume:(float)rightVolume of:(int)trackId;
        [Export("setMixVolume:rightVolume:of:")]
        bool SetMixVolume(float leftVolume, float rightVolume, int trackId);

        // -(float)getMixVolume:(int)trackId;
        [Export("getMixVolume:")]
        float GetMixVolume(int trackId);

        // -(void)getMixVolume:(float *)leftVolume rightVolume:(float *)rightVolume of:(int)trackId;
        [Export("getMixVolume:rightVolume:of:")]
        unsafe void GetMixVolume(float leftVolume, float rightVolume, int trackId);

        // -(BOOL)setTrack:(int)trackId enable:(BOOL)onOff;
        [Export("setTrack:enable:")]
        bool SetTrack(int trackId, bool onOff);

        // -(BOOL)getTrackEnable:(int)trackId;
        [Export("getTrackEnable:")]
        bool GetTrackEnable(int trackId);

        // -(int)getBufLength:(int)trackId;
        [Export("getBufLength:")]
        int GetBufLength(int trackId);

        // -(int)getNumSamplesInBuffer:(int)trackId;
        [Export("getNumSamplesInBuffer:")]
        int GetNumSamplesInBuffer(int trackId);

        // -(BOOL)processAudioSampleBuffer:(CMSampleBufferRef)sampleBuffer of:(int)trackId;
        [Export("processAudioSampleBuffer:of:")]
        bool ProcessAudioSampleBuffer(CMSampleBuffer sampleBuffer, int trackId);

        // -(BOOL)processAudioData:(uint8_t **)pData nbSample:(int)len withFormat:(const AudioStreamBasicDescription *)fmt timeinfo:(CMTime)pts of:(int)trackId;
        [Export("processAudioData:nbSample:withFormat:timeinfo:of:")]
        bool ProcessAudioData(byte pData, int len, AudioStreamBasicDescription fmt, CMTime pts, int trackId);

        // @property (copy, nonatomic) void (^audioProcessingCallback)(CMSampleBufferRef);
        [Export("audioProcessingCallback", ArgumentSemantic.Copy)]
        Action AudioProcessingCallback { get; set; }

        // @property (copy, nonatomic) void (^pcmProcessingCallback)(uint8_t **, int, CMTime);
        [Export("pcmProcessingCallback", ArgumentSemantic.Copy)]
        Action<byte, int, CMTime> PcmProcessingCallback { get; set; }

        // @property (assign, nonatomic) int mainTrack;
        [Export("mainTrack")]
        int MainTrack { get; set; }

        // @property (assign, nonatomic) BOOL bStereo;
        [Export("bStereo")]
        bool BStereo { get; set; }

        // @property (assign, nonatomic) int frameSize;
        [Export("frameSize")]
        int FrameSize { get; set; }

        // @property (assign, nonatomic) int sampleRate;
        [Export("sampleRate")]
        int SampleRate { get; set; }

        // @property (readonly, nonatomic) AudioStreamBasicDescription * outFmtDes;
        [Export("outFmtDes")]
        unsafe AudioStreamBasicDescription OutFmtDes { get; }
    }

    // @interface KSYBeautifyFaceFilter : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface KSYBeautifyFaceFilter
    {
        // +(void)showVersion;
        [Static]
        [Export("showVersion")]
        void ShowVersion();

        // @property (readwrite, nonatomic) CGFloat grindRatio;
        [Export("grindRatio")]
        nfloat GrindRatio { get; set; }

        // @property (readwrite, nonatomic) CGFloat whitenRatio;
        [Export("whitenRatio")]
        nfloat WhitenRatio { get; set; }

        // -(id)initWithRubbyMaterial:(UIImage *)img;
        [Export("initWithRubbyMaterial:")]
        IntPtr Constructor(UIImage img);

        // @property (readwrite, nonatomic) CGFloat ruddyRatio;
        [Export("ruddyRatio")]
        nfloat RuddyRatio { get; set; }
    }

    // @interface KSYBeautifyProFilter : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface KSYBeautifyProFilter
    {
        // -(id)initWithIdx:(NSInteger)idx;
        [Export("initWithIdx:")]
        IntPtr Constructor(nint idx);

        // +(void)showVersion;
        [Static]
        [Export("showVersion")]
        void ShowVersion();

        // @property (readwrite, nonatomic) CGFloat grindRatio;
        [Export("grindRatio")]
        nfloat GrindRatio { get; set; }

        // @property (readwrite, nonatomic) CGFloat whitenRatio;
        [Export("whitenRatio")]
        nfloat WhitenRatio { get; set; }

        // @property (readwrite, nonatomic) CGFloat ruddyRatio;
        [Export("ruddyRatio")]
        nfloat RuddyRatio { get; set; }
    }

    // @interface KSYBgmPlayer : NSObject
    [BaseType(typeof(NSObject))]
    interface KSYBgmPlayer
    {
        // -(BOOL)startPlayBgm:(NSString *)path isLoop:(BOOL)loop;
        [Export("startPlayBgm:isLoop:")]
        bool StartPlayBgm(string path, bool loop);

        // -(void)stopPlayBgm;
        [Export("stopPlayBgm")]
        void StopPlayBgm();

        // -(void)stopPlayBgm:(void (^)())completion;
        [Export("stopPlayBgm:")]
        void StopPlayBgm(Action completion);

        // -(void)pauseBgm;
        [Export("pauseBgm")]
        void PauseBgm();

        // -(void)resumeBgm;
        [Export("resumeBgm")]
        void ResumeBgm();

        // -(BOOL)seekToTime:(float)time;
        [Export("seekToTime:")]
        bool SeekToTime(float time);

        // -(BOOL)seekToProgress:(float)prog;
        [Export("seekToProgress:")]
        bool SeekToProgress(float prog);

        // @property (assign, nonatomic) double bgmVolume;
        [Export("bgmVolume")]
        double BgmVolume { get; set; }

        // @property (assign, nonatomic) double bgmPitch;
        [Export("bgmPitch")]
        double BgmPitch { get; set; }

        // @property (assign, nonatomic) double playRate;
        [Export("playRate")]
        double PlayRate { get; set; }

        // @property (assign, nonatomic) BOOL bMuteBgmPlay;
        [Export("bMuteBgmPlay")]
        bool BMuteBgmPlay { get; set; }

        // @property (assign, nonatomic) BOOL callBackRawData;
        [Export("callBackRawData")]
        bool CallBackRawData { get; set; }

        // @property (copy, nonatomic) BOOL (^audioDataBlock)(uint8_t **, int, const AudioStreamBasicDescription *, CMTime);
        [Export("audioDataBlock", ArgumentSemantic.Copy)]
        unsafe Func<byte, int, AudioStreamBasicDescription, CMTime, bool> AudioDataBlock { get; set; }

        // @property (copy, nonatomic) void (^bgmFinishBlock)();
        [Export("bgmFinishBlock", ArgumentSemantic.Copy)]
        Action BgmFinishBlock { get; set; }

        // @property (readonly, nonatomic) float bgmDuration;
        [Export("bgmDuration")]
        float BgmDuration { get; }

        // @property (readonly, nonatomic) float bgmPlayTime;
        [Export("bgmPlayTime")]
        float BgmPlayTime { get; }

        // @property (readonly, nonatomic) float bgmProcess;
        [Export("bgmProcess")]
        float BgmProcess { get; }

        // @property (readonly, nonatomic) BOOL isRunning;
        [Export("isRunning")]
        bool IsRunning { get; }

        // @property (readonly, nonatomic) OSStatus audioErrorCode;
        [Export("audioErrorCode")]
        int AudioErrorCode { get; }

        // @property (readonly, nonatomic) KSYBgmPlayerState bgmPlayerState;
        [Export("bgmPlayerState")]
        KSYBgmPlayerState BgmPlayerState { get; }

        // @property (assign, nonatomic) BOOL bLoop;
        [Export("bLoop")]
        bool BLoop { get; set; }

        // -(NSString *)getBgmStateName:(KSYBgmPlayerState)stat;
        [Export("getBgmStateName:")]
        string GetBgmStateName(KSYBgmPlayerState stat);

        // -(NSString *)getCurBgmStateName;
        [Export("getCurBgmStateName")]

        string CurBgmStateName { get; }
    }

    

    partial interface Constants
    {
        // extern NSString *const KSYAudioStateDidChangeNotification __attribute__((availability(ios, introduced=7_0)));
        [iOS(7, 0)]
        [Field("KSYAudioStateDidChangeNotification", "__Internal")]
        NSString KSYAudioStateDidChangeNotification { get; }
    }

    // @interface KSYBgmReader : NSObject
    [BaseType(typeof(NSObject))]
    interface KSYBgmReader
    {
        // -(id)initWithFile:(NSString *)path isLoop:(BOOL)loop;
        [Export("initWithFile:isLoop:")]
        IntPtr Constructor(string path, bool loop);

        // -(BOOL)reloadFile:(NSString *)path;
        [Export("reloadFile:")]
        bool ReloadFile(string path);

        // -(void)closeFile;
        [Export("closeFile")]
        void CloseFile();

        // -(BOOL)seekTo:(float)time;
        [Export("seekTo:")]
        bool SeekTo(float time);

        // @property (readonly, nonatomic) AudioStreamBasicDescription bgmFmt;
        [Export("bgmFmt")]
        AudioStreamBasicDescription BgmFmt { get; }

        // -(int)readPCMData:(AudioBufferList *)buf nbSample:(UInt32)cnt;
        [Export("readPCMData:nbSample:")]
        unsafe int ReadPCMData(AudioBuffers buf, uint cnt);

        // -(int)readPCMData:(void *)buf capacity:(UInt32)cap;
        //[Export("readPCMData:capacity:")]
        //unsafe int ReadPCMData(void buf, uint cap);

        // @property (readonly, nonatomic) float bgmDuration;
        [Export("bgmDuration")]
        float BgmDuration { get; }

        // @property (readonly, nonatomic) float bgmPlayTime;
        [Export("bgmPlayTime")]
        float BgmPlayTime { get; }

        // @property (readonly, nonatomic) float bgmProcess;
        [Export("bgmProcess")]
        float BgmProcess { get; }

        // @property (assign, nonatomic) BOOL bLoop;
        [Export("bLoop")]
        bool BLoop { get; set; }
    }

    // @interface KSYSpecialEffects : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface KSYSpecialEffects
    {
        // +(void)showVersion;
        [Static]
        [Export("showVersion")]
        void ShowVersion();

        // -(id)initWithUIImage:(UIImage *)image;
        [Export("initWithUIImage:")]
        IntPtr Constructor(UIImage image);

        // -(id)initWithImageName:(NSString *)name;
        [Export("initWithImageName:")]
        IntPtr Constructor(string name);

        // -(void)setSpecialEffectsUIImage:(UIImage *)image;
        [Export("setSpecialEffectsUIImage:")]
        void SetSpecialEffectsUIImage(UIImage image);

        // @property (readwrite, nonatomic) CGFloat intensity;
        [Export("intensity")]
        nfloat Intensity { get; set; }
    }

    // @interface KSYBuildInSpecialEffects : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface KSYBuildInSpecialEffects
    {
        // -(id)initWithType:(KSYGPUEffectType)type;
        [Export("initWithType:")]
        IntPtr Constructor(KSYGPUEffectType type);

        // @property KSYGPUEffectType effectType;
        [Export("effectType", ArgumentSemantic.Assign)]
        KSYGPUEffectType EffectType { get; set; }

        // -(id)initWithIdx:(NSInteger)idx;
        [Export("initWithIdx:")]
        IntPtr Constructor(nint idx);

        // -(void)setSpecialEffectsIdx:(NSInteger)idx;
        [Export("setSpecialEffectsIdx:")]
        void SetSpecialEffectsIdx(nint idx);

        // @property (readwrite, nonatomic) CGFloat intensity;
        [Export("intensity")]
        nfloat Intensity { get; set; }
    }

    // @interface KSYClipWriter : NSObject
    [BaseType(typeof(NSObject))]
    interface KSYClipWriter
    {
        // -(NSString *)getKSYVersion;
        [Export("getKSYVersion")]

        string KSYVersion { get; }

        // @property (readonly, nonatomic) NSURL * hostURL;
        [Export("hostURL")]
        NSUrl HostURL { get; }

        // @property (assign, nonatomic) int videoFPS;
        [Export("videoFPS")]
        int VideoFPS { get; set; }

        // @property (assign, nonatomic) KSYVideoCodec videoCodec;
        [Export("videoCodec", ArgumentSemantic.Assign)]
        KSYVideoCodec VideoCodec { get; set; }

        // @property (assign, nonatomic) KSYAudioCodec audioCodec;
        [Export("audioCodec", ArgumentSemantic.Assign)]
        KSYAudioCodec AudioCodec { get; set; }

        // @property (assign, nonatomic) int videoInitBitrate;
        [Export("videoInitBitrate")]
        int VideoInitBitrate { get; set; }

        // @property (copy, atomic) NSDictionary * streamMetaData;
        [Export("streamMetaData", ArgumentSemantic.Copy)]
        NSDictionary StreamMetaData { get; set; }

        // @property (copy, atomic) NSDictionary * videoMetaData;
        [Export("videoMetaData", ArgumentSemantic.Copy)]
        NSDictionary VideoMetaData { get; set; }

        // @property (assign, nonatomic) float maxKeyInterval;
        [Export("maxKeyInterval")]
        float MaxKeyInterval { get; set; }

        // @property (assign, nonatomic) int audiokBPS;
        [Export("audiokBPS")]
        int AudiokBPS { get; set; }

        // @property (assign, nonatomic) KSYLiveScene liveScene;
        [Export("liveScene", ArgumentSemantic.Assign)]
        KSYLiveScene LiveScene { get; set; }

        // @property (assign, nonatomic) KSYRecScene recScene;
        [Export("recScene", ArgumentSemantic.Assign)]
        KSYRecScene RecScene { get; set; }

        // @property (assign, nonatomic) int videoCrf;
        [Export("videoCrf")]
        int VideoCrf { get; set; }

        // @property (assign, nonatomic) KSYVideoEncodePerformance videoEncodePerf;
        [Export("videoEncodePerf", ArgumentSemantic.Assign)]
        KSYVideoEncodePerformance VideoEncodePerf { get; set; }

        // @property (assign, nonatomic) BOOL bWithVideo;
        [Export("bWithVideo")]
        bool BWithVideo { get; set; }

        // @property (assign, nonatomic) BOOL bWithAudio;
        [Export("bWithAudio")]
        bool BWithAudio { get; set; }

        // @property (assign, nonatomic) BOOL mp4FastStart;
        [Export("mp4FastStart")]
        bool Mp4FastStart { get; set; }

        // @property (readonly, nonatomic) KSYStreamState writeState;
        [Export("writeState")]
        KSYStreamState WriteState { get; }

        // -(NSString *)getWriteStateName:(KSYStreamState)stat;
        [Export("getWriteStateName:")]
        string GetWriteStateName(KSYStreamState stat);

        // -(NSString *)getCurWriteStateName;
        [Export("getCurWriteStateName")]

        string CurWriteStateName { get; }

        // @property (readonly, nonatomic) KSYStreamErrorCode streamErrorCode;
        [Export("streamErrorCode")]
        KSYStreamErrorCode StreamErrorCode { get; }

        // @property (copy, nonatomic) void (^writeStateChange)(KSYStreamState);
        [Export("writeStateChange", ArgumentSemantic.Copy)]
        Action<KSYStreamState> WriteStateChange { get; set; }

        // -(NSString *)getKSYWriteErrorCodeName:(KSYStreamErrorCode)code;
        [Export("getKSYWriteErrorCodeName:")]
        string GetKSYWriteErrorCodeName(KSYStreamErrorCode code);

        // -(NSString *)getCurKSYWriteErrorCodeName;
        [Export("getCurKSYWriteErrorCodeName")]

        string CurKSYWriteErrorCodeName { get; }

        // @property (copy, nonatomic) void (^videoFPSChange)(int32_t);
        [Export("videoFPSChange", ArgumentSemantic.Copy)]
        Action<int> VideoFPSChange { get; set; }

        // -(void)startWritingWith:(NSURL *)url;
        [Export("startWritingWith:")]
        void StartWritingWith(NSUrl url);

        // -(void)stopWriting;
        [Export("stopWriting")]
        void StopWriting();

        // -(void)stopWriting:(void (^)())complete;
        [Export("stopWriting:")]
        void StopWriting(Action complete);

        // -(void)muteStream:(BOOL)bMute;
        [Export("muteStream:")]
        void MuteStream(bool bMute);

        // -(void)processVideoSampleBuffer:(CMSampleBufferRef)sampleBuffer onComplete:(void (^)(BOOL))completion;
        [Export("processVideoSampleBuffer:onComplete:")]
        void ProcessVideoSampleBuffer(CMSampleBuffer sampleBuffer, Action<bool> completion);

        // -(void)processVideoPixelBuffer:(CVPixelBufferRef)pixelBuffer timeInfo:(CMTime)timeStamp onComplete:(void (^)(BOOL))completion;
        [Export("processVideoPixelBuffer:timeInfo:onComplete:")]
        void ProcessVideoPixelBuffer(CVPixelBuffer pixelBuffer, CMTime timeStamp, Action<bool> completion);

        // -(void)processAudioSampleBuffer:(CMSampleBufferRef)sampleBuffer;
        [Export("processAudioSampleBuffer:")]
        void ProcessAudioSampleBuffer(CMSampleBuffer sampleBuffer);

        // -(BOOL)isWriting;
        [Export("isWriting")]

        bool IsWriting { get; }
        // @property (readonly, nonatomic) double encodeVKbps;
        [Export("encodeVKbps")]
        double EncodeVKbps { get; }

        // @property (readonly, nonatomic) double encodeAKbps;
        [Export("encodeAKbps")]
        double EncodeAKbps { get; }

        // @property (readonly, nonatomic) double encodingFPS;
        [Export("encodingFPS")]
        double EncodingFPS { get; }

        // @property (readonly, nonatomic) int encodedFrames;
        [Export("encodedFrames")]
        int EncodedFrames { get; }

        // @property (copy, nonatomic) void (^logBlock)(NSString *);
        [Export("logBlock", ArgumentSemantic.Copy)]
        Action<NSString> LogBlock { get; set; }

        // @property (assign, nonatomic) BOOL shouldEnableKSYDropModule;
        [Export("shouldEnableKSYDropModule")]
        bool ShouldEnableKSYDropModule { get; set; }
    }

    

    partial interface Constants
    {
        // extern NSString *const KSYWriteStateDidChangeNotification __attribute__((availability(ios, introduced=7_0)));
        [iOS(7, 0)]
        [Field("KSYWriteStateDidChangeNotification", "__Internal")]
        NSString KSYWriteStateDidChangeNotification { get; }
    }

    // @interface KSYDummyAudioSource : NSObject
    [BaseType(typeof(NSObject))]
    interface KSYDummyAudioSource
    {
        // -(id)initWithAudioFmt:(AudioStreamBasicDescription)asbd;
        [Export("initWithAudioFmt:")]
        IntPtr Constructor(AudioStreamBasicDescription asbd);

        // -(BOOL)start;
        [Export("start")]

        bool Start { get; }

        // -(BOOL)startAt:(CMTime)initPts;
        [Export("startAt:")]
        bool StartAt(CMTime initPts);

        // -(void)stop;
        [Export("stop")]
        void Stop();

        // @property (copy, nonatomic) void (^audioProcessingCallback)(CMSampleBufferRef);
        [Export("audioProcessingCallback", ArgumentSemantic.Copy)]
        Action AudioProcessingCallback { get; set; }

        // @property (assign, nonatomic) AudioStreamBasicDescription asbd;
        [Export("asbd", ArgumentSemantic.Assign)]
        AudioStreamBasicDescription Asbd { get; set; }

        // @property (assign, nonatomic) int nbSample;
        [Export("nbSample")]
        int NbSample { get; set; }

        // @property (readonly, nonatomic) BOOL bRunning;
        [Export("bRunning")]
        bool BRunning { get; }
    }

    // @interface KSYGPUFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface KSYGPUFilter
    {
        // -(void)reload:(NSString *)fragmentShaderString;
        [Export("reload:")]
        void Reload(string fragmentShaderString);
    }

    // @interface KSYGPUBeautifyExtFilter : KSYGPUFilter
    [BaseType(typeof(KSYGPUFilter))]
    interface KSYGPUBeautifyExtFilter
    {
        // -(void)setBeautylevel:(int)level;
        [Export("setBeautylevel:")]
        void SetBeautylevel(int level);
    }

    // @interface KSYGPUBeautifyFilter : KSYGPUFilter
    [BaseType(typeof(KSYGPUFilter))]
    interface KSYGPUBeautifyFilter
    {
        // -(void)setBeautylevel:(int)level;
        [Export("setBeautylevel:")]
        void SetBeautylevel(int level);
    }

    // @interface KSYGPUBeautifyPlusFilter : KSYGPUFilter
    [BaseType(typeof(KSYGPUFilter))]
    interface KSYGPUBeautifyPlusFilter
    {
        // -(void)setBeautylevel:(int)level;
        [Export("setBeautylevel:")]
        void SetBeautylevel(int level);
    }

    // @interface KSYGPUBgmStreamerKit
    interface KSYGPUBgmStreamerKit
    {
        // @property (nonatomic, strong) int * ksyBgmPlayer;
        [Export("ksyBgmPlayer", ArgumentSemantic.Strong)]
        unsafe int* KsyBgmPlayer { get; set; }

        // -(void)startPlayBgm:(NSString *)path;
        [Export("startPlayBgm:")]
        void StartPlayBgm(string path);

        // -(void)stopPlayBgm;
        [Export("stopPlayBgm")]
        void StopPlayBgm();

        // -(NSString *)getBgmStateName:(id)stat;
        [Export("getBgmStateName:")]
        string GetBgmStateName(NSObject stat);

        // -(NSString *)getCurBgmStateName;
        [Export("getCurBgmStateName")]

        string CurBgmStateName { get; }

        // @property (readonly, nonatomic) int BgmState;
        [Export("BgmState")]
        int BgmState { get; }
    }

    // @interface KSYGPUBrushStreamerKit
    interface KSYGPUBrushStreamerKit
    {
        // @property (readwrite, nonatomic) CGRect drawPicRect;
        [Export("drawPicRect", ArgumentSemantic.Assign)]
        CGRect DrawPicRect { get; set; }

        // @property (readonly, nonatomic) NSInteger drawLayer;
        [Export("drawLayer")]
        nint DrawLayer { get; }

        // @property (readwrite, nonatomic) int * drawPic;
        [Export("drawPic", ArgumentSemantic.Assign)]
        unsafe int* DrawPic { get; set; }

        // -(void)removeDrawLayer;
        [Export("removeDrawLayer")]
        void RemoveDrawLayer();
    }

    // @interface KSYGPUCamera : GPUImageVideoCamera <AVCaptureVideoDataOutputSampleBufferDelegate, AVCaptureAudioDataOutputSampleBufferDelegate>
    [BaseType(typeof(GPUImageVideoCamera))]
    interface KSYGPUCamera : IAVCaptureVideoDataOutputSampleBufferDelegate, IAVCaptureAudioDataOutputSampleBufferDelegate
    {
        // -(id)initWithSessionPreset:(NSString *)sessionPreset cameraPosition:(AVCaptureDevicePosition)cameraPosition;
        [Export("initWithSessionPreset:cameraPosition:")]
        IntPtr Constructor(string sessionPreset, AVCaptureDevicePosition cameraPosition);

        // -(BOOL)isTorchSupported;
        [Export("isTorchSupported")]

        bool IsTorchSupported { get; }

        // -(void)toggleTorch;
        [Export("toggleTorch")]
        void ToggleTorch();

        // -(void)setTorchMode:(AVCaptureTorchMode)mode;
        [Export("setTorchMode:")]
        void SetTorchMode(AVCaptureTorchMode mode);

        // @property (readonly, nonatomic) BOOL isRunning;
        [Export("isRunning")]
        bool IsRunning { get; }

        // @property (copy, nonatomic) void (^audioProcessingCallback)(CMSampleBufferRef);
        [Export("audioProcessingCallback", ArgumentSemantic.Copy)]
        Action AudioProcessingCallback { get; set; }

        // @property (copy, nonatomic) void (^videoProcessingCallback)(CMSampleBufferRef);
        [Export("videoProcessingCallback", ArgumentSemantic.Copy)]
        Action VideoProcessingCallback { get; set; }

        // +(AVCaptureVideoOrientation)getCapOrientation:(UIInterfaceOrientation)orien;
        [Static]
        [Export("getCapOrientation:")]
        AVCaptureVideoOrientation GetCapOrientation(UIInterfaceOrientation orien);
    }

    // @interface KSYGPUDnoiseFilter : KSYGPUFilter
    [BaseType(typeof(KSYGPUFilter))]
    interface KSYGPUDnoiseFilter
    {
    }

    // @interface KSYGPUPicInput : GPUImageOutput
    [BaseType(typeof(GPUImageOutput))]
    interface KSYGPUPicInput
    {
        // -(id)initWithFmt:(OSType)fmt;
        [Export("initWithFmt:")]
        IntPtr Constructor(uint fmt);

        // @property (readwrite, nonatomic) CGRect cropRegion;
        [Export("cropRegion", ArgumentSemantic.Assign)]
        CGRect CropRegion { get; set; }

        // -(void)forceProcessingAtSize:(CGSize)frameSize;
        [Export("forceProcessingAtSize:")]
        void ForceProcessingAtSize(CGSize frameSize);

        // @property (nonatomic) CGSize outputSize;
        [Export("outputSize", ArgumentSemantic.Assign)]
        CGSize OutputSize { get; set; }

        // @property (assign, nonatomic) GPUImageRotationMode outputRotation;
        [Export("outputRotation", ArgumentSemantic.Assign)]
        GPUImageRotationMode OutputRotation { get; set; }

        // @property (assign, nonatomic) BOOL alwaysDiscardsLateVideoFrames;
        [Export("alwaysDiscardsLateVideoFrames")]
        bool AlwaysDiscardsLateVideoFrames { get; set; }

        // -(void)processSampleBuffer:(CMSampleBufferRef)sampleBuffer;
        [Export("processSampleBuffer:")]
        void ProcessSampleBuffer(CMSampleBuffer sampleBuffer);

        // -(void)processPixelBuffer:(CVPixelBufferRef)pixelBuffer time:(CMTime)timeInfo;
        [Export("processPixelBuffer:time:")]
        void ProcessPixelBuffer(CVPixelBuffer pixelBuffer, CMTime timeInfo);

        // -(void)processPixelData:(void **)pData format:(OSType)pixelFmt width:(size_t)width height:(size_t)height stride:(size_t *)strides time:(CMTime)timeInfo;
        //[Export("processPixelData:format:width:height:stride:time:")]
        //void ProcessPixelData(void** pData, uint pixelFmt, nuint width, nuint height, nuint strides, CMTime timeInfo);
    }

    // @interface KSYGPUYUVInput : KSYGPUPicInput
    [BaseType(typeof(KSYGPUPicInput))]
    interface KSYGPUYUVInput
    {
    }

    // @interface KSYGPUPicMixer : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface KSYGPUPicMixer
    {
        // -(id)initWithOutputSize:(CGSize)sz;
        [Export("initWithOutputSize:")]
        IntPtr Constructor(CGSize sz);

        // @property (assign, nonatomic) NSUInteger masterLayer;
        [Export("masterLayer")]
        nuint MasterLayer { get; set; }

        // -(void)setPicRect:(CGRect)rect ofLayer:(NSInteger)idx;
        [Export("setPicRect:ofLayer:")]
        void SetPicRect(CGRect rect, nint idx);

        // -(CGRect)getPicRectOfLayer:(NSInteger)idx;
        [Export("getPicRectOfLayer:")]
        CGRect GetPicRectOfLayer(nint idx);

        // -(void)setPicAlpha:(CGFloat)alpha ofLayer:(NSInteger)idx;
        [Export("setPicAlpha:ofLayer:")]
        void SetPicAlpha(nfloat alpha, nint idx);

        // -(CGFloat)getPicAlphaOfLayer:(NSInteger)idx;
        [Export("getPicAlphaOfLayer:")]
        nfloat GetPicAlphaOfLayer(nint idx);

        // -(void)setPicRotation:(GPUImageRotationMode)rotation ofLayer:(NSInteger)idx;
        [Export("setPicRotation:ofLayer:")]
        void SetPicRotation(GPUImageRotationMode rotation, nint idx);

        // -(GPUImageRotationMode)getPicRotationOfLayer:(NSInteger)idx;
        [Export("getPicRotationOfLayer:")]
        GPUImageRotationMode GetPicRotationOfLayer(nint idx);

        // -(void)clearPicOfLayer:(NSInteger)index;
        [Export("clearPicOfLayer:")]
        void ClearPicOfLayer(nint index);

        // @property (assign, nonatomic) BOOL clearCanvasBeforeDraw;
        [Export("clearCanvasBeforeDraw")]
        bool ClearCanvasBeforeDraw { get; set; }
    }

    // @interface KSYGPUPicOutput : NSObject <GPUImageInput>
    [BaseType(typeof(NSObject))]
    interface KSYGPUPicOutput : GPUImageInput
    {
        // -(id)initWithOutFmt:(OSType)fmt;
        [Export("initWithOutFmt:")]
        IntPtr Constructor(uint fmt);

        // @property (readonly, nonatomic) OSType outputPixelFormat;
        [Export("outputPixelFormat")]
        uint OutputPixelFormat { get; }

        // @property (nonatomic) BOOL enabled;
        [Export("enabled")]
        bool Enabled { get; set; }

        // @property (assign, nonatomic) BOOL bCustomOutputSize;
        [Export("bCustomOutputSize")]
        bool BCustomOutputSize { get; set; }

        // @property (assign, nonatomic) CGSize outputSize;
        [Export("outputSize", ArgumentSemantic.Assign)]
        CGSize OutputSize { get; set; }

        // @property (readwrite, nonatomic) CGRect cropRegion;
        [Export("cropRegion", ArgumentSemantic.Assign)]
        CGRect CropRegion { get; set; }

        // @property (readonly, nonatomic) CGSize inputSize;
        [Export("inputSize")]
        CGSize InputSize { get; }

        // @property (readwrite, nonatomic) BOOL bAutoRepeat;
        [Export("bAutoRepeat")]
        bool BAutoRepeat { get; set; }

        // @property (readwrite, nonatomic) int targetFps;
        [Export("targetFps")]
        int TargetFps { get; set; }

        // -(GPUImageRotationMode)getInputRotation;
        [Export("getInputRotation")]

        GPUImageRotationMode InputRotation { get; }

        // @property (copy, nonatomic) void (^videoProcessingCallback)(CVPixelBufferRef, CMTime);
        [Export("videoProcessingCallback", ArgumentSemantic.Copy)]
        Action<CMTime> VideoProcessingCallback { get; set; }
    }

    // @interface KSYGPUPicture : GPUImagePicture
    [BaseType(typeof(GPUImagePicture))]
    interface KSYGPUPicture
    {
        // -(id)initWithImageName:(NSString *)name;
        [Export("initWithImageName:")]
        IntPtr Constructor(string name);

        // -(id)initWithImage:(UIImage *)img andOutputSize:(CGSize)size;
        [Export("initWithImage:andOutputSize:")]
        IntPtr Constructor(UIImage img, CGSize size);
    }

    // @interface KSYGPUPipStreamerKit
    interface KSYGPUPipStreamerKit
    {
        // @property (readonly, nonatomic) int pipTrack;
        [Export("pipTrack")]
        int PipTrack { get; }

        // @property (readonly, nonatomic) NSInteger bgPicLayer;
        [Export("bgPicLayer")]
        nint BgPicLayer { get; }

        // @property (readonly, nonatomic) NSInteger pipLayer;
        [Export("pipLayer")]
        nint PipLayer { get; }

        // -(void)startPipWithPlayerUrl:(NSURL * _Nullable)playerUrl bgPic:(NSURL * _Nullable)bgUrl;
        [Export("startPipWithPlayerUrl:bgPic:")]
        void StartPipWithPlayerUrl([NullAllowed] NSUrl playerUrl, [NullAllowed] NSUrl bgUrl);

        // -(void)stopPip;
        [Export("stopPip")]
        void StopPip();

        // @property (readonly, nonatomic) int * _Nonnull player;
        [Export("player")]
        unsafe int* Player { get; }

        // @property (nonatomic, strong) GPUImagePicture * _Nullable bgPic;
        [NullAllowed, Export("bgPic", ArgumentSemantic.Strong)]
        GPUImagePicture BgPic { get; set; }

        // @property (readonly, nonatomic) KSYGPUPicInput * _Nonnull yuvInput;
        [Export("yuvInput")]
        KSYGPUPicInput YuvInput { get; }

        // @property (readwrite, nonatomic) CGRect bgPicRect;
        [Export("bgPicRect", ArgumentSemantic.Assign)]
        CGRect BgPicRect { get; set; }

        // @property (readwrite, nonatomic) CGRect pipRect;
        [Export("pipRect", ArgumentSemantic.Assign)]
        CGRect PipRect { get; set; }

        // @property (readwrite, nonatomic) CGRect cameraRect;
        [Export("cameraRect", ArgumentSemantic.Assign)]
        CGRect CameraRect { get; set; }

        // -(NSString * _Nonnull)getPipStateName:(id)stat;
        [Export("getPipStateName:")]
        string GetPipStateName(NSObject stat);

        // -(NSString * _Nonnull)getCurPipStateName;
        [Export("getCurPipStateName")]

        string CurPipStateName { get; }

        // @property (readonly, nonatomic) int PipState;
        [Export("PipState")]
        int PipState { get; }
    }

    // @interface bgp
    interface bgp
    {
        // @property (retain, nonatomic) KSYGPUPicture * bgPic;
        [Export("bgPic", ArgumentSemantic.Retain)]
        KSYGPUPicture BgPic { get; set; }

        // -(void)updateBgpImage:(UIImage *)img;
        [Export("updateBgpImage:")]
        void UpdateBgpImage(UIImage img);

        // -(BOOL)startBgpPreview:(UIView *)bgView;
        [Export("startBgpPreview:")]
        bool StartBgpPreview(UIView bgView);

        // -(BOOL)startBgpStream:(NSURL *)url;
        [Export("startBgpStream:")]
        bool StartBgpStream(NSUrl url);

        // -(void)stopBgpStream;
        [Export("stopBgpStream")]
        void StopBgpStream();
    }

    // @interface KSYStreamerBase : NSObject
    [BaseType(typeof(NSObject))]
    interface KSYStreamerBase
    {
        // -(NSString *)getKSYVersion;
        [Export("getKSYVersion")]

        string KSYVersion { get; }

        // @property (readonly, nonatomic) NSURL * hostURL;
        [Export("hostURL")]
        NSUrl HostURL { get; }

        // @property (assign, nonatomic) int videoFPS;
        [Export("videoFPS")]
        int VideoFPS { get; set; }

        // @property (assign, nonatomic) int videoMinFPS;
        [Export("videoMinFPS")]
        int VideoMinFPS { get; set; }

        // @property (assign, nonatomic) int videoMaxFPS;
        [Export("videoMaxFPS")]
        int VideoMaxFPS { get; set; }

        // @property (assign, nonatomic) KSYVideoCodec videoCodec;
        [Export("videoCodec", ArgumentSemantic.Assign)]
        KSYVideoCodec VideoCodec { get; set; }

        // @property (assign, nonatomic) KSYAudioCodec audioCodec;
        [Export("audioCodec", ArgumentSemantic.Assign)]
        KSYAudioCodec AudioCodec { get; set; }

        // @property (assign, nonatomic) int videoInitBitrate;
        [Export("videoInitBitrate")]
        int VideoInitBitrate { get; set; }

        // @property (assign, nonatomic) int videoMaxBitrate;
        [Export("videoMaxBitrate")]
        int VideoMaxBitrate { get; set; }

        // @property (assign, nonatomic) int videoMinBitrate;
        [Export("videoMinBitrate")]
        int VideoMinBitrate { get; set; }

        // @property (copy, atomic) NSDictionary * streamMetaData;
        [Export("streamMetaData", ArgumentSemantic.Copy)]
        NSDictionary StreamMetaData { get; set; }

        // @property (copy, atomic) NSDictionary * videoMetaData;
        [Export("videoMetaData", ArgumentSemantic.Copy)]
        NSDictionary VideoMetaData { get; set; }

        // @property (assign, nonatomic) float maxKeyInterval;
        [Export("maxKeyInterval")]
        float MaxKeyInterval { get; set; }

        // @property (assign, nonatomic) int audiokBPS;
        [Export("audiokBPS")]
        int AudiokBPS { get; set; }

        // @property (assign, nonatomic) KSYBWEstimateMode bwEstimateMode;
        [Export("bwEstimateMode", ArgumentSemantic.Assign)]
        KSYBWEstimateMode BwEstimateMode { get; set; }

        // @property (assign, nonatomic) KSYLiveScene liveScene;
        [Export("liveScene", ArgumentSemantic.Assign)]
        KSYLiveScene LiveScene { get; set; }

        // @property (assign, nonatomic) KSYRecScene recScene;
        [Export("recScene", ArgumentSemantic.Assign)]
        KSYRecScene RecScene { get; set; }

        // @property (assign, nonatomic) int videoCrf;
        [Export("videoCrf")]
        int VideoCrf { get; set; }

        // @property (assign, nonatomic) KSYVideoEncodePerformance videoEncodePerf;
        [Export("videoEncodePerf", ArgumentSemantic.Assign)]
        KSYVideoEncodePerformance VideoEncodePerf { get; set; }

        // @property (assign, nonatomic) BOOL bWithVideo;
        [Export("bWithVideo")]
        bool BWithVideo { get; set; }

        // @property (assign, nonatomic) BOOL bWithAudio;
        [Export("bWithAudio")]
        bool BWithAudio { get; set; }

        // @property (assign, nonatomic) BOOL bWithMessage;
        [Export("bWithMessage")]
        bool BWithMessage { get; set; }

        // @property (assign, nonatomic) float scaleRatio;
        [Export("scaleRatio")]
        float ScaleRatio { get; set; }

        // @property (readonly, nonatomic) KSYStreamState streamState;
        [Export("streamState")]
        KSYStreamState StreamState { get; }

        // -(NSString *)getStreamStateName:(KSYStreamState)stat;
        [Export("getStreamStateName:")]
        string GetStreamStateName(KSYStreamState stat);

        // -(NSString *)getCurStreamStateName;
        [Export("getCurStreamStateName")]

        string CurStreamStateName { get; }

        // @property (readonly, nonatomic) KSYStreamErrorCode streamErrorCode;
        [Export("streamErrorCode")]
        KSYStreamErrorCode StreamErrorCode { get; }

        // @property (copy, nonatomic) void (^streamStateChange)(KSYStreamState);
        [Export("streamStateChange", ArgumentSemantic.Copy)]
        Action<KSYStreamState> StreamStateChange { get; set; }

        // -(NSString *)getKSYStreamErrorCodeName:(KSYStreamErrorCode)code;
        [Export("getKSYStreamErrorCodeName:")]
        string GetKSYStreamErrorCodeName(KSYStreamErrorCode code);

        // -(NSString *)getCurKSYStreamErrorCodeName;
        [Export("getCurKSYStreamErrorCodeName")]

        string CurKSYStreamErrorCodeName { get; }

        // @property (readonly, nonatomic) KSYNetStateCode netStateCode;
        [Export("netStateCode")]
        KSYNetStateCode NetStateCode { get; }

        // @property (copy, nonatomic) void (^videoFPSChange)(int32_t);
        [Export("videoFPSChange", ArgumentSemantic.Copy)]
        Action<int> VideoFPSChange { get; set; }

        // -(void)startStream:(NSURL *)url;
        [Export("startStream:")]
        void StartStream(NSUrl url);

        // -(void)stopStream;
        [Export("stopStream")]
        void StopStream();

        // -(void)muteStream:(BOOL)bMute;
        [Export("muteStream:")]
        void MuteStream(bool bMute);

        // -(void)processVideoSampleBuffer:(CMSampleBufferRef)sampleBuffer;
        [Export("processVideoSampleBuffer:")]
        unsafe void ProcessVideoSampleBuffer(CMSampleBuffer sampleBuffer);

        // -(void)processVideoSampleBuffer:(CMSampleBufferRef)sampleBuffer onComplete:(void (^)(BOOL))completion;
        [Export("processVideoSampleBuffer:onComplete:")]
        unsafe void ProcessVideoSampleBuffer(CMSampleBuffer sampleBuffer, Action<bool> completion);

        // -(void)processVideoPixelBuffer:(CVPixelBufferRef)pixelBuffer timeInfo:(CMTime)timeStamp;
        [Export("processVideoPixelBuffer:timeInfo:")]
        void ProcessVideoPixelBuffer(CVPixelBuffer pixelBuffer, CMTime timeStamp);

        // -(void)processVideoPixelBuffer:(CVPixelBufferRef)pixelBuffer timeInfo:(CMTime)timeStamp onComplete:(void (^)(BOOL))completion;
        [Export("processVideoPixelBuffer:timeInfo:onComplete:")]
        void ProcessVideoPixelBuffer(CVPixelBuffer pixelBuffer, CMTime timeStamp, Action<bool> completion);

        // -(void)processAudioSampleBuffer:(CMSampleBufferRef)sampleBuffer;
        [Export("processAudioSampleBuffer:")]
        void ProcessAudioSampleBuffer(CMSampleBuffer sampleBuffer);

        // -(void)processAudioData:(uint8_t **)pData nbSample:(int)len withFormat:(const AudioStreamBasicDescription *)fmt timeinfo:(CMTime *)pts;
        [Export("processAudioData:nbSample:withFormat:timeinfo:")]
        void ProcessAudioData(byte pData, int len, AudioStreamBasicDescription fmt, CMTime pts);

        // -(void)processMessageData:(NSDictionary *)messageData;
        [Export("processMessageData:")]
        void ProcessMessageData(NSDictionary messageData);

        // @property (assign, nonatomic) NSString * clientAk;
        [Export("clientAk")]
        string ClientAk { get; set; }

        // @property (assign, nonatomic) NSDate * expireDate;
        [Export("expireDate", ArgumentSemantic.Assign)]
        NSDate ExpireDate { get; set; }

        // @property (readonly, nonatomic) NSString * streamID;
        [Export("streamID")]
        string StreamID { get; }

        // -(BOOL)isStreaming;
        [Export("isStreaming")]

        bool IsStreaming { get; }

        // @property (readonly, nonatomic) double encodeVKbps;
        [Export("encodeVKbps")]
        double EncodeVKbps { get; }

        // @property (readonly, nonatomic) double encodeAKbps;
        [Export("encodeAKbps")]
        double EncodeAKbps { get; }

        // @property (readonly, nonatomic) int uploadedKByte;
        [Export("uploadedKByte")]
        int UploadedKByte { get; }

        // @property (readonly, nonatomic) double currentUploadingKbps;
        [Export("currentUploadingKbps")]
        double CurrentUploadingKbps { get; }

        // @property (readonly, nonatomic) double encodingFPS;
        [Export("encodingFPS")]
        double EncodingFPS { get; }

        // @property (readonly, nonatomic) int encodedFrames;
        [Export("encodedFrames")]
        int EncodedFrames { get; }

        // @property (readonly, nonatomic) int droppedVideoFrames;
        [Export("droppedVideoFrames")]
        int DroppedVideoFrames { get; }

        // @property (readonly, nonatomic) KSYStreamerQosInfo * qosInfo;
        [Export("qosInfo")]
        unsafe KSYStreamerQosInfo QosInfo { get; }

        // @property (readonly, atomic) NSString * rtmpHostIP;
        [Export("rtmpHostIP")]
        string RtmpHostIP { get; }

        // @property (assign, nonatomic) BOOL shouldEnableKSYStatModule;
        [Export("shouldEnableKSYStatModule")]
        bool ShouldEnableKSYStatModule { get; set; }

        // @property (copy, nonatomic) void (^logBlock)(NSString *);
        [Export("logBlock", ArgumentSemantic.Copy)]
        Action<NSString> LogBlock { get; set; }

        // -(void)takePhotoWithQuality:(CGFloat)jpegCompressionQuality fileName:(NSString *)filename;
        [Export("takePhotoWithQuality:fileName:")]
        void TakePhotoWithQuality(nfloat jpegCompressionQuality, string filename);

        // -(void)getSnapshotWithCompletion:(void (^)(UIImage *))completion;
        [Export("getSnapshotWithCompletion:")]
        void GetSnapshotWithCompletion(Action<UIImage> completion);

        // @property (readonly, nonatomic) NSURL * bypassRecordURL;
        [Export("bypassRecordURL")]
        NSUrl BypassRecordURL { get; }

        // @property (assign, nonatomic) BOOL bypassMp4FastStart;
        [Export("bypassMp4FastStart")]
        bool BypassMp4FastStart { get; set; }

        // -(BOOL)startBypassRecord:(NSURL *)url;
        [Export("startBypassRecord:")]
        bool StartBypassRecord(NSUrl url);

        // -(void)stopBypassRecord;
        [Export("stopBypassRecord")]
        void StopBypassRecord();

        // @property (readonly, nonatomic) double bypassRecordDuration;
        [Export("bypassRecordDuration")]
        double BypassRecordDuration { get; }

        // @property (readonly, nonatomic) KSYRecordState bypassRecordState;
        [Export("bypassRecordState")]
        KSYRecordState BypassRecordState { get; }

        // @property (readonly, nonatomic) KSYRecordError bypassRecordErrorCode;
        [Export("bypassRecordErrorCode")]
        KSYRecordError BypassRecordErrorCode { get; }

        // @property (readonly, nonatomic) NSString * bypassRecordErrorName;
        [Export("bypassRecordErrorName")]
        string BypassRecordErrorName { get; }

        // @property (copy, nonatomic) void (^bypassRecordStateChange)(KSYRecordState);
        [Export("bypassRecordStateChange", ArgumentSemantic.Copy)]
        Action<KSYRecordState> BypassRecordStateChange { get; set; }

        // @property (assign, nonatomic) BOOL shouldEnableKSYDropModule;
        [Export("shouldEnableKSYDropModule")]
        bool ShouldEnableKSYDropModule { get; set; }

        // @property (readonly, nonatomic) KSYReachability * netReachability;
        [Export("netReachability")]
        KSYReachability NetReachability { get; }

        // @property (readonly, nonatomic) KSYNetReachState netReachState;
        [Export("netReachState")]
        KSYNetReachState NetReachState { get; }

        // @property (readwrite, nonatomic) NSString * reachabilityDetectURL;
        [Export("reachabilityDetectURL")]
        string ReachabilityDetectURL { get; set; }
    }

    

    partial interface Constants
    {
        // extern NSString *const KSYStreamStateDidChangeNotification __attribute__((availability(ios, introduced=7_0)));
        [iOS(7, 0)]
        [Field("KSYStreamStateDidChangeNotification", "__Internal")]
        NSString KSYStreamStateDidChangeNotification { get; }

        // extern NSString *const KSYNetStateEventNotification __attribute__((availability(ios, introduced=7_0)));
        [iOS(7, 0)]
        [Field("KSYNetStateEventNotification", "__Internal")]
        NSString KSYNetStateEventNotification { get; }
    }

    // @interface KSYMovieWriter : KSYStreamerBase
    [BaseType(typeof(KSYStreamerBase))]
    interface KSYMovieWriter
    {
        // -(void)startWrite:(NSURL *)filePath;
        [Export("startWrite:")]
        void StartWrite(NSUrl filePath);

        // -(void)stopWrite;
        [Export("stopWrite")]
        void StopWrite();
    }

    // @interface KSYMessage : NSObject
    [BaseType(typeof(NSObject))]
    interface KSYMessage
    {
        // -(BOOL)processMessageData:(NSMutableDictionary *)messageData;
        [Export("processMessageData:")]
        bool ProcessMessageData(NSMutableDictionary messageData);

        // @property (copy, nonatomic) void (^messageProcessingCallback)(NSDictionary *);
        [Export("messageProcessingCallback", ArgumentSemantic.Copy)]
        Action<NSDictionary> MessageProcessingCallback { get; set; }
    }

    // @interface KSYTranscoder : NSObject
    [BaseType(typeof(NSObject))]
    interface KSYTranscoder
    {
        // -(void)startTranscode:(NSURL *)inputFilePath outputFilePath:(NSURL *)outputFilePath;
        [Export("startTranscode:outputFilePath:")]
        void StartTranscode(NSUrl inputFilePath, NSUrl outputFilePath);

        // -(void)stopTranscode;
        [Export("stopTranscode")]
        void StopTranscode();

        // @property (readonly, nonatomic) float duration;
        [Export("duration")]
        float Duration { get; }

        // @property (readonly, nonatomic) float position;
        [Export("position")]
        float Position { get; }

        // @property (readonly, nonatomic) float progress;
        [Export("progress")]
        float Progress { get; }

        // @property (readonly, nonatomic) KSYTranscodeState transcodeState;
        [Export("transcodeState")]
        KSYTranscodeState TranscodeState { get; }

        // @property (readonly, nonatomic) KSYTranscodeErrorCode transcodeErrorCode;
        [Export("transcodeErrorCode")]
        KSYTranscodeErrorCode TranscodeErrorCode { get; }
    }

    

    partial interface Constants
    {
        // extern NSString *const KSYTranscodeStateDidChangeNotification;
        [Field("KSYTranscodeStateDidChangeNotification", "__Internal")]
        NSString KSYTranscodeStateDidChangeNotification { get; }

        // extern NSString *const KSYTranscodeStateUserInfoKey;
        [Field("KSYTranscodeStateUserInfoKey", "__Internal")]
        NSString KSYTranscodeStateUserInfoKey { get; }

        // extern NSString *const KSYTranscodeErrorCodeUserInfoKey;
        [Field("KSYTranscodeErrorCodeUserInfoKey", "__Internal")]
        NSString KSYTranscodeErrorCodeUserInfoKey { get; }
    }

    // @protocol KSYMediaPlayback
    [Protocol, Model]
    interface KSYMediaPlayback
    {
        // @required -(void)prepareToPlay;
        [Abstract]
        [Export("prepareToPlay")]
        void PrepareToPlay();

        // @required @property (readonly, nonatomic) BOOL isPreparedToPlay;
        [Abstract]
        [Export("isPreparedToPlay")]
        bool IsPreparedToPlay { get; }

        // @required -(void)play;
        [Abstract]
        [Export("play")]
        void Play();

        // @required -(void)pause;
        [Abstract]
        [Export("pause")]
        void Pause();

        // @required -(void)stop;
        [Abstract]
        [Export("stop")]
        void Stop();

        // @required @property (nonatomic) NSTimeInterval currentPlaybackTime;
        [Abstract]
        [Export("currentPlaybackTime")]
        double CurrentPlaybackTime { get; set; }
    }

    // @interface KSYQosInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface KSYQosInfo
    {
        // @property (assign, nonatomic) int audioBufferByteLength;
        [Export("audioBufferByteLength")]
        int AudioBufferByteLength { get; set; }

        // @property (assign, nonatomic) int audioBufferTimeLength;
        [Export("audioBufferTimeLength")]
        int AudioBufferTimeLength { get; set; }

        // @property (assign, nonatomic) int64_t audioTotalDataSize;
        [Export("audioTotalDataSize")]
        long AudioTotalDataSize { get; set; }

        // @property (assign, nonatomic) int videoBufferByteLength;
        [Export("videoBufferByteLength")]
        int VideoBufferByteLength { get; set; }

        // @property (assign, nonatomic) int videoBufferTimeLength;
        [Export("videoBufferTimeLength")]
        int VideoBufferTimeLength { get; set; }

        // @property (assign, nonatomic) int64_t videoTotalDataSize;
        [Export("videoTotalDataSize")]
        long VideoTotalDataSize { get; set; }

        // @property (assign, nonatomic) int64_t totalDataSize;
        [Export("totalDataSize")]
        long TotalDataSize { get; set; }

        // @property (assign, nonatomic) float videoDecodeFPS;
        [Export("videoDecodeFPS")]
        float VideoDecodeFPS { get; set; }

        // @property (assign, nonatomic) float videoRefreshFPS;
        [Export("videoRefreshFPS")]
        float VideoRefreshFPS { get; set; }
    }

    

    partial interface Constants
    {
        // extern NSString *const MPMediaPlaybackIsPreparedToPlayDidChangeNotification __attribute__((visibility("default"))) __attribute__((availability(tvos, unavailable))) __attribute__((availability(ios, introduced=3.2, deprecated=9.0)));
        [Introduced(PlatformName.iOS, 3, 2, message: "Use AVPlayerViewController in AVKit.")]
        [Deprecated(PlatformName.iOS, 9, 0, message: "Use AVPlayerViewController in AVKit.")]

        [Field("MPMediaPlaybackIsPreparedToPlayDidChangeNotification", "__Internal")]
        NSString MPMediaPlaybackIsPreparedToPlayDidChangeNotification { get; }

        // extern NSString *const MPMoviePlayerPlaybackStateDidChangeNotification __attribute__((visibility("default"))) __attribute__((availability(tvos, unavailable))) __attribute__((availability(ios, introduced=3.2, deprecated=9.0)));
        [Introduced(PlatformName.iOS, 3, 2, message: "Use AVPlayerViewController in AVKit.")]
        [Deprecated(PlatformName.iOS, 9, 0, message: "Use AVPlayerViewController in AVKit.")]

        [Field("MPMoviePlayerPlaybackStateDidChangeNotification", "__Internal")]
        NSString MPMoviePlayerPlaybackStateDidChangeNotification { get; }

        // extern NSString *const MPMoviePlayerPlaybackDidFinishNotification __attribute__((visibility("default"))) __attribute__((availability(tvos, unavailable))) __attribute__((availability(ios, introduced=2.0, deprecated=9.0)));
        [Introduced(PlatformName.iOS, 2, 0, message: "Use AVPlayerViewController in AVKit.")]
        [Deprecated(PlatformName.iOS, 9, 0, message: "Use AVPlayerViewController in AVKit.")]

        [Field("MPMoviePlayerPlaybackDidFinishNotification", "__Internal")]
        NSString MPMoviePlayerPlaybackDidFinishNotification { get; }

        // extern NSString *const MPMoviePlayerPlaybackDidFinishReasonUserInfoKey __attribute__((visibility("default"))) __attribute__((availability(tvos, unavailable))) __attribute__((availability(ios, introduced=3.2, deprecated=9.0)));
        [Introduced(PlatformName.iOS, 3, 2, message: "Use AVPlayerViewController in AVKit.")]
        [Deprecated(PlatformName.iOS, 9, 0, message: "Use AVPlayerViewController in AVKit.")]

        [Field("MPMoviePlayerPlaybackDidFinishReasonUserInfoKey", "__Internal")]
        NSString MPMoviePlayerPlaybackDidFinishReasonUserInfoKey { get; }

        // extern NSString *const MPMoviePlayerLoadStateDidChangeNotification __attribute__((visibility("default"))) __attribute__((availability(tvos, unavailable))) __attribute__((availability(ios, introduced=3.2, deprecated=9.0)));
        [Introduced(PlatformName.iOS, 3, 2, message: "Use AVPlayerViewController in AVKit.")]
        [Deprecated(PlatformName.iOS, 9, 0, message: "Use AVPlayerViewController in AVKit.")]

        [Field("MPMoviePlayerLoadStateDidChangeNotification", "__Internal")]
        NSString MPMoviePlayerLoadStateDidChangeNotification { get; }

        // extern NSString *const MPMovieNaturalSizeAvailableNotification __attribute__((visibility("default"))) __attribute__((availability(tvos, unavailable))) __attribute__((availability(ios, introduced=3.2, deprecated=9.0)));
        [Introduced(PlatformName.iOS, 3, 2, message: "Use AVPlayerViewController in AVKit.")]
        [Deprecated(PlatformName.iOS, 9, 0, message: "Use AVPlayerViewController in AVKit.")]

        [Field("MPMovieNaturalSizeAvailableNotification", "__Internal")]
        NSString MPMovieNaturalSizeAvailableNotification { get; }

        // extern NSString *const MPMoviePlayerFirstVideoFrameRenderedNotification __attribute__((visibility("default")));
        [Field("MPMoviePlayerFirstVideoFrameRenderedNotification", "__Internal")]
        NSString MPMoviePlayerFirstVideoFrameRenderedNotification { get; }

        // extern NSString *const MPMoviePlayerFirstAudioFrameRenderedNotification __attribute__((visibility("default")));
        [Field("MPMoviePlayerFirstAudioFrameRenderedNotification", "__Internal")]
        NSString MPMoviePlayerFirstAudioFrameRenderedNotification { get; }

        // extern NSString *const MPMoviePlayerSuggestReloadNotification __attribute__((visibility("default")));
        [Field("MPMoviePlayerSuggestReloadNotification", "__Internal")]
        NSString MPMoviePlayerSuggestReloadNotification { get; }

        // extern NSString *const MPMoviePlayerPlaybackStatusNotification __attribute__((visibility("default")));
        [Field("MPMoviePlayerPlaybackStatusNotification", "__Internal")]
        NSString MPMoviePlayerPlaybackStatusNotification { get; }

        // extern NSString *const MPMoviePlayerPlaybackStatusUserInfoKey __attribute__((visibility("default")));
        [Field("MPMoviePlayerPlaybackStatusUserInfoKey", "__Internal")]
        NSString MPMoviePlayerPlaybackStatusUserInfoKey { get; }

        // extern NSString *const MPMoviePlayerNetworkStatusChangeNotification __attribute__((visibility("default")));
        [Field("MPMoviePlayerNetworkStatusChangeNotification", "__Internal")]
        NSString MPMoviePlayerNetworkStatusChangeNotification { get; }

        // extern NSString *const MPMoviePlayerCurrNetworkStatusUserInfoKey __attribute__((visibility("default")));
        [Field("MPMoviePlayerCurrNetworkStatusUserInfoKey", "__Internal")]
        NSString MPMoviePlayerCurrNetworkStatusUserInfoKey { get; }

        // extern NSString *const MPMoviePlayerLastNetworkStatusUserInfoKey __attribute__((visibility("default")));
        [Field("MPMoviePlayerLastNetworkStatusUserInfoKey", "__Internal")]
        NSString MPMoviePlayerLastNetworkStatusUserInfoKey { get; }

        // extern NSString *const MPMoviePlayerSeekCompleteNotification __attribute__((visibility("default")));
        [Field("MPMoviePlayerSeekCompleteNotification", "__Internal")]
        NSString MPMoviePlayerSeekCompleteNotification { get; }

        // extern NSString *const MPMoviePlayerPlaybackTimedTextNotification __attribute__((visibility("default")));
        [Field("MPMoviePlayerPlaybackTimedTextNotification", "__Internal")]
        NSString MPMoviePlayerPlaybackTimedTextNotification { get; }

        // extern NSString *const MPMoviePlayerPlaybackTimedTextUserInfoKey __attribute__((visibility("default")));
        [Field("MPMoviePlayerPlaybackTimedTextUserInfoKey", "__Internal")]
        NSString MPMoviePlayerPlaybackTimedTextUserInfoKey { get; }

        // extern const NSString *const kKSYPLYFormat __attribute__((visibility("default")));
        [Field("kKSYPLYFormat", "__Internal")]
        NSString kKSYPLYFormat { get; }

        // extern const NSString *const kKSYPLYHttpFirstDataTime __attribute__((visibility("default")));
        [Field("kKSYPLYHttpFirstDataTime", "__Internal")]
        NSString kKSYPLYHttpFirstDataTime { get; }

        // extern const NSString *const kKSYPLYHttpAnalyzeDns __attribute__((visibility("default")));
        [Field("kKSYPLYHttpAnalyzeDns", "__Internal")]
        NSString kKSYPLYHttpAnalyzeDns { get; }

        // extern const NSString *const kKSYPLYHttpConnectTime __attribute__((visibility("default")));
        [Field("kKSYPLYHttpConnectTime", "__Internal")]
        NSString kKSYPLYHttpConnectTime { get; }

        // extern const NSString *const kKSYPLYStreams __attribute__((visibility("default")));
        [Field("kKSYPLYStreams", "__Internal")]
        NSString kKSYPLYStreams { get; }

        // extern const NSString *const kKSYPLYStreamType __attribute__((visibility("default")));
        [Field("kKSYPLYStreamType", "__Internal")]
        NSString kKSYPLYStreamType { get; }

        // extern const NSString *const kKSYPLYCodecName __attribute__((visibility("default")));
        [Field("kKSYPLYCodecName", "__Internal")]
        NSString kKSYPLYCodecName { get; }

        // extern const NSString *const kKSYPLYStreamIndex __attribute__((visibility("default")));
        [Field("kKSYPLYStreamIndex", "__Internal")]
        NSString kKSYPLYStreamIndex { get; }

        // extern const NSString *const kKSYPLYVideoWidth __attribute__((visibility("default")));
        [Field("kKSYPLYVideoWidth", "__Internal")]
        NSString kKSYPLYVideoWidth { get; }

        // extern const NSString *const kKSYPLYVideoHeight __attribute__((visibility("default")));
        [Field("kKSYPLYVideoHeight", "__Internal")]
        NSString kKSYPLYVideoHeight { get; }

        // extern const NSString *const kKSYPLYAudioSampleRate __attribute__((visibility("default")));
        [Field("kKSYPLYAudioSampleRate", "__Internal")]
        NSString kKSYPLYAudioSampleRate { get; }

        // extern const NSString *const kKSYPLYAudioChannelLayout __attribute__((visibility("default")));
        [Field("kKSYPLYAudioChannelLayout", "__Internal")]
        NSString kKSYPLYAudioChannelLayout { get; }

        // extern const NSString *const kKSYPLYAudioChannels __attribute__((visibility("default")));
        [Field("kKSYPLYAudioChannels", "__Internal")]
        NSString kKSYPLYAudioChannels { get; }

        // extern NSString *const kKSYReachabilityChangedNotification;
        [Field("kKSYReachabilityChangedNotification", "__Internal")]
        NSString kKSYReachabilityChangedNotification { get; }
    }

    // typedef void (^KSYNetworkReachable)(KSYReachability *);
    delegate void KSYNetworkReachable(KSYReachability arg0);

    // typedef void (^KSYNetworkUnreachable)(KSYReachability *);
    delegate void KSYNetworkUnreachable(KSYReachability arg0);

    // typedef void (^KSYNetworkReachability)(KSYReachability *, SCNetworkConnectionFlags);
    delegate void KSYNetworkReachability(KSYReachability arg0, uint arg1);

    // @interface KSYReachability : NSObject
    [BaseType(typeof(NSObject))]
    interface KSYReachability
    {
        // @property (copy, nonatomic) KSYNetworkReachable reachableBlock;
        [Export("reachableBlock", ArgumentSemantic.Copy)]
        KSYNetworkReachable ReachableBlock { get; set; }

        // @property (copy, nonatomic) KSYNetworkUnreachable unreachableBlock;
        [Export("unreachableBlock", ArgumentSemantic.Copy)]
        KSYNetworkUnreachable UnreachableBlock { get; set; }

        // @property (copy, nonatomic) KSYNetworkReachability reachabilityBlock;
        [Export("reachabilityBlock", ArgumentSemantic.Copy)]
        KSYNetworkReachability ReachabilityBlock { get; set; }

        // @property (assign, nonatomic) BOOL reachableOnWWAN;
        [Export("reachableOnWWAN")]
        bool ReachableOnWWAN { get; set; }

        // +(instancetype)reachabilityWithHostname:(NSString *)hostname;
        [Static]
        [Export("reachabilityWithHostname:")]
        KSYReachability ReachabilityWithHostname(string hostname);

        // +(instancetype)reachabilityWithHostName:(NSString *)hostname;
        [Static]
        [Export("reachabilityWithHostName:")]
        KSYReachability ReachabilityWithHostName(string hostname);

        // +(instancetype)reachabilityForInternetConnection;
        [Static]
        [Export("reachabilityForInternetConnection")]
        KSYReachability ReachabilityForInternetConnection();

        // +(instancetype)reachabilityWithAddress:(void *)hostAddress;
        [Static]
        [Export("reachabilityWithAddress:")]
        unsafe KSYReachability ReachabilityWithAddress(string hostAddress);

        // +(instancetype)reachabilityForLocalWiFi;
        [Static]
        [Export("reachabilityForLocalWiFi")]
        KSYReachability ReachabilityForLocalWiFi();

        // -(instancetype)initWithReachabilityRef:(SCNetworkReachabilityRef)ref;
        [Export("initWithReachabilityRef:")]
        unsafe IntPtr Constructor(KSYNetworkReachability @ref);

        // -(BOOL)startNotifier;
        [Export("startNotifier")]

        bool StartNotifier { get; }

        // -(void)stopNotifier;
        [Export("stopNotifier")]
        void StopNotifier();

        // -(BOOL)isReachable;
        [Export("isReachable")]

        bool IsReachable { get; }

        // -(BOOL)isReachableViaWWAN;
        [Export("isReachableViaWWAN")]

        bool IsReachableViaWWAN { get; }

        // -(BOOL)isReachableViaWiFi;
        [Export("isReachableViaWiFi")]

        bool IsReachableViaWiFi { get; }

        // -(BOOL)isConnectionRequired;
        [Export("isConnectionRequired")]

        bool IsConnectionRequired { get; }

        // -(BOOL)connectionRequired;
        [Export("connectionRequired")]

        bool ConnectionRequired { get; }

        // -(BOOL)isConnectionOnDemand;
        [Export("isConnectionOnDemand")]

        bool IsConnectionOnDemand { get; }

        // -(BOOL)isInterventionRequired;
        [Export("isInterventionRequired")]

        bool IsInterventionRequired { get; }

        // -(KSYNetworkStatus)currentReachabilityStatus;
        [Export("currentReachabilityStatus")]

        KSYNetworkStatus CurrentReachabilityStatus { get; }

        // -(SCNetworkReachabilityFlags)reachabilityFlags;
        [Export("reachabilityFlags")]

        KSYNetworkReachability ReachabilityFlags { get; }

        // -(NSString *)currentReachabilityString;
        [Export("currentReachabilityString")]

        string CurrentReachabilityString { get; }

        // -(NSString *)currentReachabilityFlags;
        [Export("currentReachabilityFlags")]

        string CurrentReachabilityFlags { get; }
    }

    // typedef void (^KSYPlyVideoDataBlock)(CMSampleBufferRef);
    delegate void KSYPlyVideoDataBlock();

    // typedef void (^KSYPlyAudioDataBlock)(CMSampleBufferRef);
    delegate void KSYPlyAudioDataBlock();

    // typedef void (^KSYPlyMessageDataBlock)(NSDictionary *, int64_t, int64_t);
    delegate void KSYPlyMessageDataBlock(NSDictionary arg0, long arg1, long arg2);

    // typedef void (^KSYPlyTextureBlock)(GLuint, int, int, double);
    delegate void KSYPlyTextureBlock(uint arg0, int arg1, int arg2, double arg3);

    // @interface KSYMoviePlayerController : NSObject <KSYMediaPlayback>
    [BaseType(typeof(NSObject))]
    interface KSYMoviePlayerController : KSYMediaPlayback
    {
        // -(instancetype)initWithContentURL:(NSURL *)url;
        [Export("initWithContentURL:")]
        IntPtr Constructor(NSUrl url);

        // -(instancetype)initWithContentURL:(NSURL *)url sharegroup:(EAGLSharegroup *)sharegroup;
        [Export("initWithContentURL:sharegroup:")]
        IntPtr Constructor(NSUrl url, EAGLSharegroup sharegroup);

        // -(instancetype)initWithContentURL:(NSURL *)url fileList:(NSArray *)fileList sharegroup:(EAGLSharegroup *)sharegroup __attribute__((objc_designated_initializer));
        [Export("initWithContentURL:fileList:sharegroup:")]
        [DesignatedInitializer]

        IntPtr Constructor(NSUrl url, NSObject[] fileList, EAGLSharegroup sharegroup);

        // @property (readonly, nonatomic) NSURL * contentURL;
        [Export("contentURL")]
        NSUrl ContentURL { get; }

        // @property (readonly, nonatomic) NSArray * fileList;
        [Export("fileList")]

        NSObject[] FileList { get; }

        // @property (readonly, nonatomic) UIView * view;
        [Export("view")]
        UIView View { get; }

        // @property (nonatomic) MPMovieControlStyle controlStyle;
        [Export("controlStyle", ArgumentSemantic.Assign)]
        MPMovieControlStyle ControlStyle { get; set; }

        // @property (readonly, nonatomic) MPMoviePlaybackState playbackState;
        [Export("playbackState")]
        MPMoviePlaybackState PlaybackState { get; }

        // @property (readonly, nonatomic) MPMovieLoadState loadState;
        [Export("loadState")]
        MPMovieLoadState LoadState { get; }

        // @property (nonatomic) BOOL shouldAutoplay;
        [Export("shouldAutoplay")]
        bool ShouldAutoplay { get; set; }

        // @property (nonatomic) MPMovieScalingMode scalingMode;
        [Export("scalingMode", ArgumentSemantic.Assign)]
        MPMovieScalingMode ScalingMode { get; set; }

        // @property (readonly, nonatomic) NSTimeInterval duration;
        [Export("duration")]
        double Duration { get; }

        // @property (readonly, nonatomic) NSTimeInterval playableDuration;
        [Export("playableDuration")]
        double PlayableDuration { get; }

        // @property (assign, nonatomic) BOOL shouldEnableKSYStatModule;
        [Export("shouldEnableKSYStatModule")]
        bool ShouldEnableKSYStatModule { get; set; }

        // @property (readonly, nonatomic) CGSize naturalSize;
        [Export("naturalSize")]
        CGSize NaturalSize { get; }

        // @property (readonly, nonatomic) NSInteger naturalRotate;
        [Export("naturalRotate")]
        nint NaturalRotate { get; }

        // @property (copy, nonatomic) void (^logBlock)(NSString *);
        [Export("logBlock", ArgumentSemantic.Copy)]
        Action<NSString> LogBlock { get; set; }

        // @property NSTimeInterval bufferTimeMax;
        [Export("bufferTimeMax")]
        double BufferTimeMax { get; set; }

        // @property NSUInteger bufferSizeMax;
        [Export("bufferSizeMax")]
        nuint BufferSizeMax { get; set; }

        // @property (readonly, nonatomic) double readSize;
        [Export("readSize")]
        double ReadSize { get; }

        // @property (readonly, nonatomic) NSTimeInterval bufferEmptyDuration;
        [Export("bufferEmptyDuration")]
        double BufferEmptyDuration { get; }

        // @property (readonly, nonatomic) NSInteger bufferEmptyCount;
        [Export("bufferEmptyCount")]
        nint BufferEmptyCount { get; }

        // @property (readonly, nonatomic) NSString * serverAddress;
        [Export("serverAddress")]
        string ServerAddress { get; }

        // @property (readonly, nonatomic) NSString * clientIP;
        [Export("clientIP")]
        string ClientIP { get; }

        // @property (readonly, nonatomic) NSString * localDNSIP;
        [Export("localDNSIP")]
        string LocalDNSIP { get; }

        // @property (nonatomic, strong) KSYQosInfo * qosInfo;
        [Export("qosInfo", ArgumentSemantic.Strong)]
        KSYQosInfo QosInfo { get; set; }

        // -(UIImage *)thumbnailImageAtCurrentTime;
        [Export("thumbnailImageAtCurrentTime")]

        UIImage ThumbnailImageAtCurrentTime { get; }

        // @property (nonatomic) BOOL shouldEnableVideoPostProcessing;
        [Export("shouldEnableVideoPostProcessing")]
        bool ShouldEnableVideoPostProcessing { get; set; }

        // @property (assign, nonatomic) MPMovieVideoDecoderMode videoDecoderMode;
        [Export("videoDecoderMode", ArgumentSemantic.Assign)]
        MPMovieVideoDecoderMode VideoDecoderMode { get; set; }

        // @property (nonatomic) BOOL shouldMute;
        [Export("shouldMute")]
        bool ShouldMute { get; set; }

        // @property (nonatomic) BOOL shouldHideVideo;
        [Export("shouldHideVideo")]
        bool ShouldHideVideo { get; set; }

        // @property (nonatomic) BOOL shouldLoop;
        [Export("shouldLoop")]
        bool ShouldLoop { get; set; }

        // @property (copy, nonatomic) KSYPlyVideoDataBlock videoDataBlock;
        [Export("videoDataBlock", ArgumentSemantic.Copy)]
        KSYPlyVideoDataBlock VideoDataBlock { get; set; }

        // @property (copy, nonatomic) KSYPlyAudioDataBlock audioDataBlock;
        [Export("audioDataBlock", ArgumentSemantic.Copy)]
        KSYPlyAudioDataBlock AudioDataBlock { get; set; }

        // @property (copy, nonatomic) KSYPlyMessageDataBlock messageDataBlock;
        [Export("messageDataBlock", ArgumentSemantic.Copy)]
        KSYPlyMessageDataBlock MessageDataBlock { get; set; }

        // @property (copy, nonatomic) KSYPlyTextureBlock textureBlock;
        [Export("textureBlock", ArgumentSemantic.Copy)]
        KSYPlyTextureBlock TextureBlock { get; set; }

        // @property (nonatomic) int rotateDegress;
        [Export("rotateDegress")]
        int RotateDegress { get; set; }

        // @property (nonatomic) BOOL mirror;
        [Export("mirror")]
        bool Mirror { get; set; }

        // @property (nonatomic) BOOL superFastPlay;
        [Export("superFastPlay")]
        bool SuperFastPlay { get; set; }

        // @property (nonatomic) MPMovieVideoDeinterlaceMode deinterlaceMode;
        [Export("deinterlaceMode", ArgumentSemantic.Assign)]
        MPMovieVideoDeinterlaceMode DeinterlaceMode { get; set; }

        // @property (nonatomic) BOOL bInterruptOtherAudio;
        [Export("bInterruptOtherAudio")]
        bool BInterruptOtherAudio();

        // @property (nonatomic) float audioPan;
        [Export("audioPan")]
        float AudioPan { get; set; }

        // @property (readwrite, nonatomic) NSString * networkDetectURL;
        [Export("networkDetectURL")]
        string NetworkDetectURL { get; set; }

        // @property (readonly, nonatomic) KSYNetworkStatus networkStatus;
        [Export("networkStatus")]
        KSYNetworkStatus NetworkStatus { get; }

        // @property (nonatomic) float playbackSpeed;
        [Export("playbackSpeed")]
        float PlaybackSpeed { get; set; }

        // -(void)setTimeout:(int)prepareTimeout readTimeout:(int)readTimeout;
        [Export("setTimeout:readTimeout:")]
        void SetTimeout(int prepareTimeout, int readTimeout);

        // -(void)setVolume:(float)leftVolume rigthVolume:(float)rightVolume;
        [Export("setVolume:rigthVolume:")]
        void SetVolume(float leftVolume, float rightVolume);

        // -(NSString *)getVersion;
        [Export("getVersion")]

        string Version { get; }

        // -(NSDictionary *)getMetadata;
        [Export("getMetadata")]

        NSDictionary Metadata { get; }

        // -(NSDictionary *)getMetadata:(MPMovieMetaType)metaType;
        [Export("getMetadata:")]
        NSDictionary GetMetadata(MPMovieMetaType metaType);

        // -(BOOL)isPlaying;
        [Export("isPlaying")]

        bool IsPlaying { get; }

        // -(void)reload:(NSURL *)aUrl;
        [Export("reload:")]
        void Reload(NSUrl aUrl);

        // -(void)reload:(NSURL *)aUrl flush:(BOOL)flush;
        [Export("reload:flush:")]
        void Reload(NSUrl aUrl, bool flush);

        // -(void)reload:(NSURL *)aUrl flush:(_Bool)flush mode:(MPMovieReloadMode)mode;
        [Export("reload:flush:mode:")]
        void Reload(NSUrl aUrl, bool flush, MPMovieReloadMode mode);

        // -(NSTimeInterval)getCurrentPts;
        [Export("getCurrentPts")]

        double CurrentPts { get; }

        // -(void)setUrl:(NSURL *)url;
        [Export("setUrl:")]
        void SetUrl(NSUrl url);

        // -(void)setUrl:(NSURL *)url fileList:(NSArray *)fileList;
        [Export("setUrl:fileList:")]

        void SetUrl(NSUrl url, NSObject[] fileList);

        // -(void)reset:(BOOL)holdLastPic;
        [Export("reset:")]
        void Reset(bool holdLastPic);

        // -(void)seekTo:(double)pos accurate:(BOOL)isAccurate;
        [Export("seekTo:accurate:")]
        void SeekTo(double pos, bool isAccurate);

        // -(void)setHttpHeaders:(NSDictionary *)headers;
        [Export("setHttpHeaders:")]
        void SetHttpHeaders(NSDictionary headers);

        // -(void)setTrackSelected:(NSInteger)trackIndex selected:(BOOL)selected;
        [Export("setTrackSelected:selected:")]
        void SetTrackSelected(nint trackIndex, bool selected);

        // -(void)setExtSubtitleFilePath:(NSString *)subtitleFilePath;
        [Export("setExtSubtitleFilePath:")]
        void SetExtSubtitleFilePath(string subtitleFilePath);
    }

    // @interface KSYVideoInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface KSYVideoInfo
    {
        // @property (nonatomic) MEDIAINFO_CODEC_ID vcodec;
        [Export("vcodec", ArgumentSemantic.Assign)]
        MediainfoCodecId Vcodec { get; set; }

        // @property (assign, nonatomic) int32_t frame_width;
        [Export("frame_width")]
        int Frame_width { get; set; }

        // @property (assign, nonatomic) int32_t frame_height;
        [Export("frame_height")]
        int Frame_height { get; set; }
    }

    // @interface KSYAudioInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface KSYAudioInfo
    {
        // @property (nonatomic) MEDIAINFO_CODEC_ID acodec;
        [Export("acodec", ArgumentSemantic.Assign)]
        MediainfoCodecId Acodec { get; set; }

        // @property (nonatomic) NSString * language;
        [Export("language")]
        string Language { get; set; }

        // @property (assign, nonatomic) int64_t bitrate;
        [Export("bitrate")]
        long Bitrate { get; set; }

        // @property (assign, nonatomic) int32_t channels;
        [Export("channels")]
        int Channels { get; set; }

        // @property (assign, nonatomic) int32_t samplerate;
        [Export("samplerate")]
        int Samplerate { get; set; }

        // @property (assign, nonatomic) MEDIAINFO_SAMPLE_FMT sample_format;
        [Export("sample_format", ArgumentSemantic.Assign)]
        MediainfoSampleFmt Sample_format { get; set; }

        // @property (assign, nonatomic) int32_t framesize;
        [Export("framesize")]
        int Framesize { get; set; }
    }

    // @interface KSYMediaInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface KSYMediaInfo
    {
        // @property (nonatomic) MEDIAINFO_MUX_TYPE type;
        [Export("type", ArgumentSemantic.Assign)]
        MediainfoMuxType Type { get; set; }

        // @property (assign, nonatomic) int64_t bitrate;
        [Export("bitrate")]
        long Bitrate { get; set; }

        // @property (assign, nonatomic) NSTimeInterval duration;
        [Export("duration")]
        double Duration { get; set; }

        // @property (nonatomic) NSMutableArray * videos;
        [Export("videos", ArgumentSemantic.Assign)]
        NSMutableArray Videos { get; set; }

        // @property (nonatomic) NSMutableArray * audios;
        [Export("audios", ArgumentSemantic.Assign)]
        NSMutableArray Audios { get; set; }
    }

    // @interface KSYMediaInfoProber : NSObject
    [BaseType(typeof(NSObject))]
    interface KSYMediaInfoProber
    {
        // -(instancetype)initWithContentURL:(NSURL *)url __attribute__((objc_designated_initializer));
        [Export("initWithContentURL:")]
        [DesignatedInitializer]
        IntPtr Constructor(NSUrl url);

        // @property (nonatomic) NSTimeInterval timeout;
        [Export("timeout")]
        double Timeout { get; set; }

        // @property (nonatomic) BOOL bAccelerate;
        [Export("bAccelerate")]
        bool BAccelerate { get; set; }

        // -(void)setHttpHeaders:(NSDictionary *)headers;
        [Export("setHttpHeaders:")]
        void SetHttpHeaders(NSDictionary headers);

        // @property (copy, nonatomic) NSURL * url;
        [Export("url", ArgumentSemantic.Copy)]
        NSUrl Url { get; set; }

        // @property (readonly, nonatomic) BOOL bH264Codec;
        [Export("bH264Codec")]
        bool BH264Codec { get; }

        // @property (readonly, nonatomic) BOOL bHEVCCodec;
        [Export("bHEVCCodec")]
        bool BHEVCCodec { get; }

        // @property (readonly, nonatomic) BOOL bAACCodec;
        [Export("bAACCodec")]
        bool BAACCodec { get; }

        // @property (readonly, nonatomic) BOOL bMP3Codec;
        [Export("bMP3Codec")]
        bool BMP3Codec { get; }

        // @property (nonatomic, strong) KSYMediaInfo * ksyMediaInfo;
        [Export("ksyMediaInfo", ArgumentSemantic.Strong)]
        KSYMediaInfo KsyMediaInfo { get; set; }

        // -(UIImage *)getVideoThumbnailImageAtTime:(NSTimeInterval)seekTime width:(int)width height:(int)height;
        [Export("getVideoThumbnailImageAtTime:width:height:")]
        UIImage GetVideoThumbnailImageAtTime(double seekTime, int width, int height);

        // -(UIImage *)getVideoThumbnailImageAtTime:(NSTimeInterval)seekTime width:(int)width height:(int)height accurate:(BOOL)accurate;
        [Export("getVideoThumbnailImageAtTime:width:height:accurate:")]
        UIImage GetVideoThumbnailImageAtTime(double seekTime, int width, int height, bool accurate);
    }

    

    partial interface Constants
    {
        // extern NSString *const _Nonnull KSYNetTrackerOnceDoneNotification;
        [Field("KSYNetTrackerOnceDoneNotification", "__Internal")]
        NSString KSYNetTrackerOnceDoneNotification { get; }

        // extern NSString *const _Nonnull KSYNetTrackerFinishedNotification;
        [Field("KSYNetTrackerFinishedNotification", "__Internal")]
        NSString KSYNetTrackerFinishedNotification { get; }

        // extern NSString *const _Nonnull KSYNetTrackerErrorNotification;
        [Field("KSYNetTrackerErrorNotification", "__Internal")]
        NSString KSYNetTrackerErrorNotification { get; }
    }

    // @interface KSYNetRouterInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface KSYNetRouterInfo
    {
        // @property (readonly, nonatomic) NSMutableArray * _Nullable ips;
        [NullAllowed, Export("ips")]
        NSMutableArray Ips { get; }

        // @property (readonly, nonatomic) float tmax;
        [Export("tmax")]
        float Tmax { get; }

        // @property (readonly, nonatomic) float tmin;
        [Export("tmin")]
        float Tmin { get; }

        // @property (readonly, nonatomic) float tavg;
        [Export("tavg")]
        float Tavg { get; }

        // @property (readonly, nonatomic) float tdev;
        [Export("tdev")]
        float Tdev { get; }

        // @property (readonly, nonatomic) float loss;
        [Export("loss")]
        float Loss { get; }

        // @property (readonly, nonatomic) int number;
        [Export("number")]
        int Number { get; }
    }

    // @interface KSYNetTracker : NSObject
    [BaseType(typeof(NSObject))]
    interface KSYNetTracker
    {
        // -(int)start:(NSString * _Nonnull)domain;
        [Export("start:")]
        int Start(string domain);

        // -(void)stop;
        [Export("stop")]
        void Stop();

        // @property (assign, nonatomic) KSY_NETTRACKER_ACTION action;
        [Export("action", ArgumentSemantic.Assign)]
        KsyNettrackerAction Action { get; set; }

        // @property (assign, nonatomic) int timeout;
        [Export("timeout")]
        int Timeout { get; set; }

        // @property (assign, nonatomic) int maxttl;
        [Export("maxttl")]
        int Maxttl { get; set; }

        // @property (assign, nonatomic) int number;
        [Export("number")]
        int Number { get; set; }

        // @property (readonly, nonatomic) NSMutableArray * _Nullable routerInfo;
        [NullAllowed, Export("routerInfo")]
        NSMutableArray RouterInfo { get; }
    }

    // @interface KSYGPUViewCapture : GPUImageOutput
    [BaseType(typeof(GPUImageOutput))]
    interface KSYGPUViewCapture
    {
        // -(id)initWithView:(UIView *)inputView;
        [Export("initWithView:")]
        IntPtr Constructor(UIView inputView);

        // -(id)initWithLayer:(CALayer *)inputLayer;
        [Export("initWithLayer:")]
        IntPtr Constructor(CALayer inputLayer);

        // -(CGSize)layerSizeInPixels;
        [Export("layerSizeInPixels")]

        CGSize LayerSizeInPixels { get; }

        // -(void)update;
        [Export("update")]
        void Update();

        // -(void)updateUsingCurrentTime;
        [Export("updateUsingCurrentTime")]
        void UpdateUsingCurrentTime();

        // -(void)updateWithTimestamp:(CMTime)frameTime;
        [Export("updateWithTimestamp:")]
        void UpdateWithTimestamp(CMTime frameTime);

        // @property int updateFps;
        [Export("updateFps")]
        int UpdateFps { get; set; }

        // -(void)start;
        [Export("start")]
        void Start();

        // -(void)stop;
        [Export("stop")]
        void Stop();

        // @property BOOL paused;
        [Export("paused")]
        bool Paused { get; set; }
    }

    // @interface KSYGPUView : UIView <GPUImageInput>
    [BaseType(typeof(UIView))]
    interface KSYGPUView : GPUImageInput
    {
        // @property (readwrite, nonatomic) GPUImageFillModeType fillMode;
        [Export("fillMode", ArgumentSemantic.Assign)]
        GPUImageFillModeType FillMode { get; set; }

        // @property (readonly, nonatomic) CGSize sizeInPixels;
        [Export("sizeInPixels")]
        CGSize SizeInPixels { get; }

        // @property (nonatomic) BOOL enabled;
        [Export("enabled")]
        bool Enabled { get; set; }

        // -(void)setBackgroundColorRed:(GLfloat)redComponent green:(GLfloat)greenComponent blue:(GLfloat)blueComponent alpha:(GLfloat)alphaComponent;
        [Export("setBackgroundColorRed:green:blue:alpha:")]
        void SetBackgroundColorRed(float redComponent, float greenComponent, float blueComponent, float alphaComponent);

        // -(void)setCurrentlyReceivingMonochromeInput:(BOOL)newValue;
        [Export("setCurrentlyReceivingMonochromeInput:")]
        void SetCurrentlyReceivingMonochromeInput(bool newValue);
    }

    //// @interface KSYWeakProxy : NSProxy
    //[BaseType(typeof(CFProxy))]
    //interface KSYWeakProxy
    //{
    //    // @property (readonly, nonatomic, weak) id _Nullable target;
    //    [NullAllowed, Export("target", ArgumentSemantic.Weak)]
    //    NSObject Target { get; }

    //    // -(instancetype _Nonnull)initWithTarget:(id _Nonnull)target;
    //    [Export("initWithTarget:")]
    //    IntPtr Constructor(NSObject target);

    //    // +(instancetype _Nonnull)proxyWithTarget:(id _Nonnull)target;
    //    [Static]
    //    [Export("proxyWithTarget:")]
    //    KSYWeakProxy ProxyWithTarget(NSObject target);
    //}

    // @interface KSYGPUTwoInputFiter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface KSYGPUTwoInputFiter
    {
        // -(void)reload:(NSString *)fragmentShaderString;
        [Export("reload:")]
        void Reload(string fragmentShaderString);

        // -(void)reloadVS:(NSString *)vertexShaderString andFS:(NSString *)fragmentShaderString;
        [Export("reloadVS:andFS:")]
        void ReloadVS(string vertexShaderString, string fragmentShaderString);
    }

    // @interface KSYMvEffect : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface KSYMvEffect
    {
        // @property (assign, nonatomic) CGFloat timeInfo;
        [Export("timeInfo")]
        nfloat TimeInfo { get; set; }

        // -(instancetype)initWithEffectShader:(NSString *)effectShader durationTime:(CGFloat)durTime;
        [Export("initWithEffectShader:durationTime:")]
        IntPtr Constructor(string effectShader, nfloat durTime);
    }

    // @interface KSYMvFilter : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface KSYMvFilter
    {
        // -(id)initWithPath:(NSURL *)mp4URL shouldRepeat:(BOOL)bRepeat;
        [Export("initWithPath:shouldRepeat:")]
        IntPtr Constructor(NSUrl mp4URL, bool bRepeat);

        // -(void)MvPause;
        [Export("MvPause")]
        void MvPause();

        // -(void)MvResume;
        [Export("MvResume")]
        void MvResume();

        // -(void)closeMvFilter;
        [Export("closeMvFilter")]
        void CloseMvFilter();
    }

    // @interface KSYShakeFilter : KSYGPUFilter
    [BaseType(typeof(KSYGPUFilter))]
    interface KSYShakeFilter
    {
        // -(instancetype)initWithType:(KSYShakeType)type;
        [Export("initWithType:")]
        IntPtr Constructor(KSYShakeType type);
    }

    // @protocol KSYTransition <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface KSYTransition
    {
        // @required -(void)setDuration:(int)dur;
        [Abstract]
        [Export("setDuration:")]
        void SetDuration(int dur);
    }

    // @interface KSYTransitionFilter : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface KSYTransitionFilter
    {
        // -(instancetype)initWithType:(KSYTransitionType)type andOverlay:(KSYOverlapType)overlap;
        [Export("initWithType:andOverlay:")]
        IntPtr Constructor(KSYTransitionType type, KSYOverlapType overlap);

        // @property (readonly, atomic) KSYTransitionType transitionType;
        [Export("transitionType")]
        KSYTransitionType TransitionType { get; }

        // @property (readonly, atomic) KSYOverlapType overlapType;
        [Export("overlapType")]
        KSYOverlapType OverlapType { get; }

        // @property (readwrite, nonatomic) int duration;
        [Export("duration")]
        int Duration { get; set; }

        // @property (readwrite, nonatomic) int frameIdx;
        [Export("frameIdx")]
        int FrameIdx { get; set; }
    }

    // @interface KSYTransitionFadesInOutFilter : KSYGPUTwoInputFiter <KSYTransition>
    [BaseType(typeof(KSYGPUTwoInputFiter))]
    interface KSYTransitionFadesInOutFilter : KSYTransition
    {
        // @property (readwrite, nonatomic) NSInteger masterLayer;
        [Export("masterLayer")]
        nint MasterLayer { get; set; }

        // @property (readwrite, nonatomic) BOOL bReverse;
        [Export("bReverse")]
        bool BReverse { get; set; }

        // @property (readwrite, nonatomic) int duration;
        [Export("fadesInOutFilterDuration")]
        int FadesInOutFilterDuration { get; set; }

        // @property (readwrite, nonatomic) int frameIdx;
        [Export("frameIdx")]
        int FrameIdx { get; set; }
    }

    // @interface KSYTransitionFlashFilter : KSYGPUFilter <KSYTransition>
    [BaseType(typeof(KSYGPUFilter))]
    interface KSYTransitionFlashFilter : KSYTransition
    {
        // @property (readwrite, nonatomic) int duration;
        [Export("flashFilterDuration")]
        int FlashFilterDuration { get; set; }

        // @property (readwrite, nonatomic) int frameIdx;
        [Export("frameIdx")]
        int FrameIdx { get; set; }
    }

    // @interface KSYTransitionBlurFilter : KSYGPUFilter <KSYTransition>
    [BaseType(typeof(KSYGPUFilter))]
    interface KSYTransitionBlurFilter : KSYTransition
    {
        // @property (readwrite, nonatomic) BOOL bToBlur;
        [Export("bToBlur")]
        bool BToBlur { get; set; }

        // @property (readwrite, nonatomic) int duration;
        [Export("blurFilterDuration")]
        int BlurFilterDuration { get; set; }

        // @property (readwrite, nonatomic) int frameIdx;
        [Export("frameIdx")]
        int FrameIdx { get; set; }
    }

    // @interface KSYTransitionPushFilter : KSYGPUTwoInputFiter <KSYTransition>
    [BaseType(typeof(KSYGPUTwoInputFiter))]
    interface KSYTransitionPushFilter : KSYTransition
    {
        // @property (readwrite, nonatomic) NSInteger masterLayer;
        [Export("masterLayer")]
        nint MasterLayer { get; set; }

        // @property (readwrite, nonatomic) int duration;
        [Export("pushFilterDuration")]
        int PushFilterDuration { get; set; }

        // @property (readwrite, nonatomic) int frameIdx;
        [Export("frameIdx")]
        int FrameIdx { get; set; }

        // @property (readwrite, nonatomic) KSYTPushDirection direction;
        [Export("direction", ArgumentSemantic.Assign)]
        KSYTPushDirection Direction { get; set; }
    }

    // @interface KSYGPUStreamerKit : NSObject
    [BaseType(typeof(NSObject))]
    interface KSYGPUStreamerKit
    {
        // -(instancetype)initWithDefaultCfg
        //[Export("initWithDefaultCfg")]
        //IntPtr Constructor();

        // -(NSString *)getKSYVersion;
        [Export("getKSYVersion")]
        string KSYVersion { get; }

        // @property (readonly, nonatomic) KSYAVFCapture * vCapDev;
        [Export("vCapDev")]
        KSYAVFCapture VCapDev { get; }

        // @property (readonly, nonatomic) GPUImageOutput<GPUImageInput> * filter;
        [Export("filter")]
        GPUImageInput Filter { get; }

        // @property (readonly, nonatomic) KSYGPUPicMixer * vPreviewMixer;
        [Export("vPreviewMixer")]
        KSYGPUPicMixer VPreviewMixer { get; }

        // @property (readonly, nonatomic) KSYGPUPicMixer * vStreamMixer;
        [Export("vStreamMixer")]
        KSYGPUPicMixer VStreamMixer { get; }

        // @property (readonly, nonatomic) KSYGPUView * preview;
        [Export("preview")]
        KSYGPUView Preview { get; }

        // @property (readonly, nonatomic) KSYGPUPicInput * capToGpu;
        [Export("capToGpu")]
        KSYGPUPicInput CapToGpu { get; }

        // @property (readonly, nonatomic) KSYGPUPicOutput * gpuToStr;
        [Export("gpuToStr")]
        KSYGPUPicOutput GpuToStr { get; }

        // @property (readonly, nonatomic) KSYAUAudioCapture * aCapDev;
        [Export("aCapDev")]
        KSYAUAudioCapture ACapDev { get; }

        // @property (readonly, nonatomic) KSYBgmPlayer * bgmPlayer;
        [Export("bgmPlayer")]
        KSYBgmPlayer BgmPlayer { get; }

        // @property (readonly, nonatomic) KSYAudioMixer * aMixer;
        [Export("aMixer")]
        KSYAudioMixer AMixer { get; }

        // @property (assign, nonatomic) KSYAudioCapType audioCaptureType;
        [Export("audioCaptureType", ArgumentSemantic.Assign)]
        KSYAudioCapType AudioCaptureType { get; set; }

        // @property (readonly, nonatomic) KSYMessage * msgStreamer;
        [Export("msgStreamer")]
        KSYMessage MsgStreamer { get; }

        // @property (readonly, nonatomic) KSYStreamerBase * streamerBase;
        [Export("streamerBase")]
        KSYStreamerBase StreamerBase { get; }

        // @property (assign, nonatomic) int maxAutoRetry;
        [Export("maxAutoRetry")]
        int MaxAutoRetry { get; set; }

        // @property (assign, nonatomic) double autoRetryDelay;
        [Export("autoRetryDelay")]
        double AutoRetryDelay { get; set; }

        // @property (readonly, nonatomic) NSInteger cameraLayer;
        [Export("cameraLayer")]
        nint CameraLayer { get; }

        // @property (readonly, nonatomic) NSInteger logoPicLayer;
        [Export("logoPicLayer")]
        nint LogoPicLayer { get; }

        // @property (readonly, nonatomic) NSInteger logoTxtLayer;
        [Export("logoTxtLayer")]
        nint LogoTxtLayer { get; }

        // @property (readonly, nonatomic) NSInteger aeLayer;
        [Export("aeLayer")]
        nint AeLayer { get; }

        // @property (readonly, nonatomic) int micTrack;
        [Export("micTrack")]
        int MicTrack { get; }

        // @property (readonly, nonatomic) int bgmTrack;
        [Export("bgmTrack")]
        int BgmTrack { get; }

        // @property (readonly, nonatomic) KSYCaptureState captureState;
        [Export("captureState")]
        KSYCaptureState CaptureState { get; }

        // -(NSString *)getCaptureStateName:(KSYCaptureState)stat;
        [Export("getCaptureStateName:")]
        string GetCaptureStateName(KSYCaptureState stat);

        // -(NSString *)getCurCaptureStateName;
        [Export("getCurCaptureStateName")]

        string CurCaptureStateName { get; }

        // -(void)startPreview:(UIView *)view;
        [Export("startPreview:")]
        void StartPreview(UIView view);

        // -(BOOL)startVideoCap;
        [Export("startVideoCap")]

        bool StartVideoCap { get; }

        // -(BOOL)startAudioCap;
        [Export("startAudioCap")]

        bool StartAudioCap { get; }

        // -(void)stopPreview;
        [Export("stopPreview")]
        void StopPreview();

        // -(void)appEnterBackground;
        [Export("appEnterBackground")]
        void AppEnterBackground();

        // -(void)appBecomeActive;
        [Export("appBecomeActive")]
        void AppBecomeActive();

        // @property (assign, nonatomic) NSString * capPreset;
        [Export("capPreset")]
        string CapPreset { get; set; }

        // -(CGSize)captureDimension;
        [Export("captureDimension")]

        CGSize CaptureDimension { get; }

        // @property (assign, nonatomic) CGSize previewDimension;
        [Export("previewDimension", ArgumentSemantic.Assign)]
        CGSize PreviewDimension { get; set; }

        // @property (assign, nonatomic) CGSize streamDimension;
        [Export("streamDimension", ArgumentSemantic.Assign)]
        CGSize StreamDimension { get; set; }

        // @property (assign, nonatomic) OSType capturePixelFormat;
        [Export("capturePixelFormat")]
        uint CapturePixelFormat { get; set; }

        // @property (assign, nonatomic) OSType gpuOutputPixelFormat;
        [Export("gpuOutputPixelFormat")]
        uint GpuOutputPixelFormat { get; set; }

        // @property (assign, nonatomic) int videoFPS;
        [Export("videoFPS")]
        int VideoFPS { get; set; }

        // @property (assign, nonatomic) AVCaptureDevicePosition cameraPosition;
        [Export("cameraPosition", ArgumentSemantic.Assign)]
        AVCaptureDevicePosition CameraPosition { get; set; }

        // @property (readwrite, nonatomic) UIInterfaceOrientation videoOrientation;
        [Export("videoOrientation", ArgumentSemantic.Assign)]
        UIInterfaceOrientation VideoOrientation { get; set; }

        // @property (assign, nonatomic) BOOL bStereoAudioStream;
        [Export("bStereoAudioStream")]
        bool BStereoAudioStream { get; set; }

        // -(BOOL)switchCamera;
        [Export("switchCamera")]

        bool SwitchCamera { get; }

        // -(BOOL)isTorchSupported;
        [Export("isTorchSupported")]

        bool IsTorchSupported { get; }

        // -(void)toggleTorch;
        [Export("toggleTorch")]
        void ToggleTorch();

        // -(void)setTorchMode:(AVCaptureTorchMode)mode;
        [Export("setTorchMode:")]
        void SetTorchMode(AVCaptureTorchMode mode);

        // -(AVCaptureDevice *)getCurrentCameraDevices;
        [Export("getCurrentCameraDevices")]

        AVCaptureDevice CurrentCameraDevices { get; }

        // @property (copy, nonatomic) void (^videoProcessingCallback)(CMSampleBufferRef);
        [Export("videoProcessingCallback", ArgumentSemantic.Copy)]
        Action VideoProcessingCallback { get; set; }

        // @property (copy, nonatomic) void (^audioProcessingCallback)(CMSampleBufferRef);
        [Export("audioProcessingCallback", ArgumentSemantic.Copy)]
        Action AudioProcessingCallback { get; set; }

        // @property (copy, nonatomic) void (^pcmProcessingCallback)(uint8_t **, int, const AudioStreamBasicDescription *, CMTime);
        [Export("pcmProcessingCallback", ArgumentSemantic.Copy)]
        unsafe Action<byte, int, AudioStreamBasicDescription, CMTime> PcmProcessingCallback { get; set; }

        // @property (assign, nonatomic) KSYAudioDataType audioDataType;
        [Export("audioDataType", ArgumentSemantic.Assign)]
        KSYAudioDataType AudioDataType { get; set; }

        // @property (copy, nonatomic) void (^interruptCallback)(BOOL);
        [Export("interruptCallback", ArgumentSemantic.Copy)]
        Action<bool> InterruptCallback { get; set; }

        // -(void)setupFilter:(GPUImageOutput<GPUImageInput> *)filter;
        [Export("setupFilter:")]
        void SetupFilter(GPUImageInput filter);

        // @property (assign, nonatomic) BOOL previewMirrored;
        [Export("previewMirrored")]
        bool PreviewMirrored { get; set; }

        // @property (assign, nonatomic) BOOL streamerMirrored;
        [Export("streamerMirrored")]
        bool StreamerMirrored { get; set; }

        // @property (assign, nonatomic) BOOL streamerFreezed;
        [Export("streamerFreezed")]
        bool StreamerFreezed { get; set; }

        // @property (assign, nonatomic) UIInterfaceOrientation previewOrientation;
        [Export("previewOrientation", ArgumentSemantic.Assign)]
        UIInterfaceOrientation PreviewOrientation { get; set; }

        // @property (assign, nonatomic) UIInterfaceOrientation streamOrientation;
        [Export("streamOrientation", ArgumentSemantic.Assign)]
        UIInterfaceOrientation StreamOrientation { get; set; }

        // -(void)rotatePreviewTo:(UIInterfaceOrientation)orie;
        [Export("rotatePreviewTo:")]
        void RotatePreviewTo(UIInterfaceOrientation orie);

        // -(void)rotateStreamTo:(UIInterfaceOrientation)orie;
        [Export("rotateStreamTo:")]
        void RotateStreamTo(UIInterfaceOrientation orie);

        // @property (readwrite, nonatomic) KSYGPUPicture * logoPic;
        [Export("logoPic", ArgumentSemantic.Assign)]
        KSYGPUPicture LogoPic { get; set; }

        // -(void)setLogoOrientaion:(UIImageOrientation)orien;
        [Export("setLogoOrientaion:")]
        void SetLogoOrientaion(UIImageOrientation orien);

        // -(void)setOrientaion:(UIImageOrientation)orien ofLayer:(NSInteger)idx;
        [Export("setOrientaion:ofLayer:")]
        void SetOrientaion(UIImageOrientation orien, nint idx);

        // -(void)setRect:(CGRect)rect ofLayer:(NSInteger)idx;
        [Export("setRect:ofLayer:")]
        void SetRect(CGRect rect, nint idx);

        // @property (readwrite, nonatomic) KSYGPUPicture * textPic;
        [Export("textPic", ArgumentSemantic.Assign)]
        KSYGPUPicture TextPic { get; set; }

        // @property (readwrite, nonatomic) GPUImageUIElement * aePic;
        [Export("aePic", ArgumentSemantic.Assign)]
        GPUImageUIElement AePic { get; set; }

        // @property (readwrite, nonatomic) CGRect logoRect;
        [Export("logoRect", ArgumentSemantic.Assign)]
        CGRect LogoRect { get; set; }

        // @property (readwrite, nonatomic) CGFloat logoAlpha;
        [Export("logoAlpha")]
        nfloat LogoAlpha { get; set; }

        // @property (readwrite, nonatomic) UILabel * textLabel;
        [Export("textLabel", ArgumentSemantic.Assign)]
        UILabel TextLabel { get; set; }

        // @property (readwrite, nonatomic) CGRect textRect;
        [Export("textRect", ArgumentSemantic.Assign)]
        CGRect TextRect { get; set; }

        // -(void)updateTextLabel;
        [Export("updateTextLabel")]
        void UpdateTextLabel();

        // -(BOOL)focusAtPoint:(CGPoint)point;
        [Export("focusAtPoint:")]
        bool FocusAtPoint(CGPoint point);

        // -(BOOL)exposureAtPoint:(CGPoint)point;
        [Export("exposureAtPoint:")]
        bool ExposureAtPoint(CGPoint point);

        // @property (assign, nonatomic) CGFloat pinchZoomFactor;
        [Export("pinchZoomFactor")]
        nfloat PinchZoomFactor { get; set; }

        // @property (assign, nonatomic) AVCaptureVideoStabilizationMode stabilizationMode;
        [Export("stabilizationMode", ArgumentSemantic.Assign)]
        AVCaptureVideoStabilizationMode StabilizationMode { get; set; }

        // @property (assign, nonatomic) KSYStreamerProfile streamerProfile;
        [Export("streamerProfile", ArgumentSemantic.Assign)]
        KSYStreamerProfile StreamerProfile { get; set; }

        // -(BOOL)processMessageData:(NSDictionary *)messageData;
        [Export("processMessageData:")]
        bool ProcessMessageData(NSDictionary messageData);
    }

    

    partial interface Constants
    {
        // extern NSString *const KSYCaptureStateDidChangeNotification __attribute__((availability(ios, introduced=7_0)));
        [iOS(7, 0)]
        [Field("KSYCaptureStateDidChangeNotification", "__Internal")]
        NSString KSYCaptureStateDidChangeNotification { get; }
    }

    // @interface KSYUIRecorderKit : NSObject
    [BaseType(typeof(NSObject))]
    interface KSYUIRecorderKit
    {
        // -(instancetype)initWithScheme:(KSYPlayRecordScheme)scheme;
        [Export("initWithScheme:")]
        IntPtr Constructor(KSYPlayRecordScheme scheme);

        // @property (readwrite, nonatomic) UIView * contentView;
        [Export("contentView", ArgumentSemantic.Assign)]
        UIView ContentView { get; set; }

        // -(void)processWithTextureId:(GLuint)InputTexture TextureSize:(CGSize)TextureSize Time:(CMTime)time;
        [Export("processWithTextureId:TextureSize:Time:")]
        void ProcessWithTextureId(uint InputTexture, CGSize TextureSize, CMTime time);

        // -(void)processAudioSampleBuffer:(CMSampleBufferRef)buf;
        [Export("processAudioSampleBuffer:")]
        void ProcessAudioSampleBuffer(CMSampleBuffer buf);

        // -(void)processVideoSampleBuffer:(CVPixelBufferRef)pixelBuffer timeInfo:(CMTime)timeStamp;
        [Export("processVideoSampleBuffer:timeInfo:")]
        void ProcessVideoSampleBuffer(CVPixelBuffer pixelBuffer, CMTime timeStamp);

        // -(void)startRecord:(NSURL *)path;
        [Export("startRecord:")]
        void StartRecord(NSUrl path);

        // -(void)stopRecord;
        [Export("stopRecord")]
        void StopRecord();

        // @property BOOL bPlayRecord;
        [Export("bPlayRecord")]
        bool BPlayRecord { get; set; }

        // @property (readwrite, nonatomic) KSYMovieWriter * writer;
        [Export("writer", ArgumentSemantic.Assign)]
        KSYMovieWriter Writer { get; set; }
    }
}
