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

    // @interface GPUImageFramebuffer : NSObject
    [BaseType(typeof(NSObject))]
    interface GPUImageFramebuffer
    {
        // @property (readonly) CGSize size;
        [Export("size")]
        CGSize Size { get; }

        // @property (readonly) GPUTextureOptions textureOptions;
        [Export("textureOptions")]
        GPUTextureOptions TextureOptions { get; }

        // @property (readonly) GLuint texture;
        [Export("texture")]
        uint Texture { get; }

        // @property (readonly) BOOL missingFramebuffer;
        [Export("missingFramebuffer")]
        bool MissingFramebuffer { get; }

        // -(id)initWithSize:(CGSize)framebufferSize;
        [Export("initWithSize:")]
        IntPtr Constructor(CGSize framebufferSize);

        // -(id)initWithSize:(CGSize)framebufferSize textureOptions:(GPUTextureOptions)fboTextureOptions onlyTexture:(BOOL)onlyGenerateTexture;
        [Export("initWithSize:textureOptions:onlyTexture:")]
        IntPtr Constructor(CGSize framebufferSize, GPUTextureOptions fboTextureOptions, bool onlyGenerateTexture);

        // -(id)initWithSize:(CGSize)framebufferSize overriddenTexture:(GLuint)inputTexture;
        [Export("initWithSize:overriddenTexture:")]
        IntPtr Constructor(CGSize framebufferSize, uint inputTexture);

        // -(void)activateFramebuffer;
        [Export("activateFramebuffer")]
        void ActivateFramebuffer();

        // -(void)lock;
        [Export("lock")]
        void Lock();

        // -(void)unlock;
        [Export("unlock")]
        void Unlock();

        // -(void)clearAllLocks;
        [Export("clearAllLocks")]
        void ClearAllLocks();

        // -(void)disableReferenceCounting;
        [Export("disableReferenceCounting")]
        void DisableReferenceCounting();

        // -(void)enableReferenceCounting;
        [Export("enableReferenceCounting")]
        void EnableReferenceCounting();

        // -(CGImageRef)newCGImageFromFramebufferContents;
        [Export("newCGImageFromFramebufferContents")]

        unsafe CGImage NewCGImageFromFramebufferContents { get; }

        // -(void)restoreRenderTarget;
        [Export("restoreRenderTarget")]
        void RestoreRenderTarget();

        // -(void)lockForReading;
        [Export("lockForReading")]
        void LockForReading();

        // -(void)unlockAfterReading;
        [Export("unlockAfterReading")]
        void UnlockAfterReading();

        // -(NSUInteger)bytesPerRow;
        [Export("bytesPerRow")]

        nuint BytesPerRow { get; }

        // -(GLubyte *)byteBuffer;
        [Export("byteBuffer")]

        unsafe byte ByteBuffer { get; }
    }

    // @interface GPUImageFramebufferCache : NSObject
    [BaseType(typeof(NSObject))]
    interface GPUImageFramebufferCache
    {
        // -(GPUImageFramebuffer *)fetchFramebufferForSize:(CGSize)framebufferSize textureOptions:(GPUTextureOptions)textureOptions onlyTexture:(BOOL)onlyTexture;
        [Export("fetchFramebufferForSize:textureOptions:onlyTexture:")]
        GPUImageFramebuffer FetchFramebufferForSize(CGSize framebufferSize, GPUTextureOptions textureOptions, bool onlyTexture);

        // -(GPUImageFramebuffer *)fetchFramebufferForSize:(CGSize)framebufferSize onlyTexture:(BOOL)onlyTexture;
        [Export("fetchFramebufferForSize:onlyTexture:")]
        GPUImageFramebuffer FetchFramebufferForSize(CGSize framebufferSize, bool onlyTexture);

        // -(void)returnFramebufferToCache:(GPUImageFramebuffer *)framebuffer;
        [Export("returnFramebufferToCache:")]
        void ReturnFramebufferToCache(GPUImageFramebuffer framebuffer);

        // -(void)purgeAllUnassignedFramebuffers;
        [Export("purgeAllUnassignedFramebuffers")]
        void PurgeAllUnassignedFramebuffers();

        // -(void)addFramebufferToActiveImageCaptureList:(GPUImageFramebuffer *)framebuffer;
        [Export("addFramebufferToActiveImageCaptureList:")]
        void AddFramebufferToActiveImageCaptureList(GPUImageFramebuffer framebuffer);

        // -(void)removeFramebufferFromActiveImageCaptureList:(GPUImageFramebuffer *)framebuffer;
        [Export("removeFramebufferFromActiveImageCaptureList:")]
        void RemoveFramebufferFromActiveImageCaptureList(GPUImageFramebuffer framebuffer);
    }

    // @interface GPUImageContext : NSObject
    [BaseType(typeof(NSObject))]
    interface GPUImageContext
    {
        // @property (readonly, nonatomic) dispatch_queue_t contextQueue;
        [Export("contextQueue")]
        DispatchQueue ContextQueue { get; }

        // @property (readwrite, retain, nonatomic) GLProgram * currentShaderProgram;
        [Export("currentShaderProgram", ArgumentSemantic.Retain)]
        GLProgram CurrentShaderProgram { get; set; }

        // @property (readonly, retain, nonatomic) EAGLContext * context;
        [Export("context", ArgumentSemantic.Retain)]
        EAGLContext Context { get; }

        // @property (readonly) CVOpenGLESTextureCacheRef coreVideoTextureCache;
        //[Export("coreVideoTextureCache")]
        //unsafe CVMetalTextureCache CoreVideoTextureCache { get; }

        // @property (readonly) GPUImageFramebufferCache * framebufferCache;
        [Export("framebufferCache")]
        GPUImageFramebufferCache FramebufferCache { get; }

        // +(void *)contextKey;
        [Static]
        [Export("contextKey")]
        unsafe void ContextKey();

        // +(GPUImageContext *)sharedImageProcessingContext;
        [Static]
        [Export("sharedImageProcessingContext")]

        GPUImageContext SharedImageProcessingContext { get; }

        // +(dispatch_queue_t)sharedContextQueue;
        [Static]
        [Export("sharedContextQueue")]

        DispatchQueue SharedContextQueue { get; }

        // +(GPUImageFramebufferCache *)sharedFramebufferCache;
        [Static]
        [Export("sharedFramebufferCache")]

        GPUImageFramebufferCache SharedFramebufferCache { get; }

        // +(void)useImageProcessingContext;
        [Static]
        [Export("useImageProcessingContext")]
        void UseImageProcessingContext();

        // -(void)useAsCurrentContext;
        [Export("useAsCurrentContext")]
        void UseAsCurrentContext();

        // +(void)setActiveShaderProgram:(GLProgram *)shaderProgram;
        [Static]
        [Export("setActiveShaderProgram:")]
        void SetActiveShaderProgram(GLProgram shaderProgram);

        // -(void)setContextShaderProgram:(GLProgram *)shaderProgram;
        [Export("setContextShaderProgram:")]
        void SetContextShaderProgram(GLProgram shaderProgram);

        // +(GLint)maximumTextureSizeForThisDevice;
        [Static]
        [Export("maximumTextureSizeForThisDevice")]

        int MaximumTextureSizeForThisDevice { get; }

        // +(GLint)maximumTextureUnitsForThisDevice;
        [Static]
        [Export("maximumTextureUnitsForThisDevice")]

        int MaximumTextureUnitsForThisDevice { get; }

        // +(GLint)maximumVaryingVectorsForThisDevice;
        [Static]
        [Export("maximumVaryingVectorsForThisDevice")]

        int MaximumVaryingVectorsForThisDevice { get; }

        // +(BOOL)deviceSupportsOpenGLESExtension:(NSString *)extension;
        [Static]
        [Export("deviceSupportsOpenGLESExtension:")]
        bool DeviceSupportsOpenGLESExtension(string extension);

        // +(BOOL)deviceSupportsRedTextures;
        [Static]
        [Export("deviceSupportsRedTextures")]

        bool DeviceSupportsRedTextures { get; }

        // +(BOOL)deviceSupportsFramebufferReads;
        [Static]
        [Export("deviceSupportsFramebufferReads")]

        bool DeviceSupportsFramebufferReads { get; }

        // +(CGSize)sizeThatFitsWithinATextureForSize:(CGSize)inputSize;
        [Static]
        [Export("sizeThatFitsWithinATextureForSize:")]
        CGSize SizeThatFitsWithinATextureForSize(CGSize inputSize);

        // -(void)presentBufferForDisplay;
        [Export("presentBufferForDisplay")]
        void PresentBufferForDisplay();

        // -(GLProgram *)programForVertexShaderString:(NSString *)vertexShaderString fragmentShaderString:(NSString *)fragmentShaderString;
        [Export("programForVertexShaderString:fragmentShaderString:")]
        GLProgram ProgramForVertexShaderString(string vertexShaderString, string fragmentShaderString);

        // -(void)useSharegroup:(EAGLSharegroup *)sharegroup;
        [Export("useSharegroup:")]
        void UseSharegroup(EAGLSharegroup sharegroup);

        // +(BOOL)supportsFastTextureUpload;
        [Static]
        [Export("supportsFastTextureUpload")]

        bool SupportsFastTextureUpload { get; }
    }

    // @protocol GPUImageInput <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface GPUImageInput
    {
        // @required -(void)newFrameReadyAtTime:(CMTime)frameTime atIndex:(NSInteger)textureIndex;
        [Abstract]
        [Export("newFrameReadyAtTime:atIndex:")]
        void NewFrameReadyAtTime(CMTime frameTime, nint textureIndex);

        // @required -(void)setInputFramebuffer:(GPUImageFramebuffer *)newInputFramebuffer atIndex:(NSInteger)textureIndex;
        [Abstract]
        [Export("setInputFramebuffer:atIndex:")]
        void SetInputFramebuffer(GPUImageFramebuffer newInputFramebuffer, nint textureIndex);

        // @required -(NSInteger)nextAvailableTextureIndex;
        [Abstract]
        [Export("nextAvailableTextureIndex")]

        nint NextAvailableTextureIndex { get; }

        // @required -(void)setInputSize:(CGSize)newSize atIndex:(NSInteger)textureIndex;
        [Abstract]
        [Export("setInputSize:atIndex:")]
        void SetInputSize(CGSize newSize, nint textureIndex);

        // @required -(void)setInputRotation:(GPUImageRotationMode)newInputRotation atIndex:(NSInteger)textureIndex;
        [Abstract]
        [Export("setInputRotation:atIndex:")]
        void SetInputRotation(GPUImageRotationMode newInputRotation, nint textureIndex);

        // @required -(CGSize)maximumOutputSize;
        [Abstract]
        [Export("maximumOutputSize")]

        CGSize MaximumOutputSize { get; }

        // @required -(void)endProcessing;
        [Abstract]
        [Export("endProcessing")]
        void EndProcessing();

        // @required -(BOOL)shouldIgnoreUpdatesToThisTarget;
        [Abstract]
        [Export("shouldIgnoreUpdatesToThisTarget")]

        bool ShouldIgnoreUpdatesToThisTarget { get; }

        // @required -(BOOL)enabled;
        [Abstract]
        [Export("enabled")]

        bool Enabled { get; }

        // @required -(BOOL)wantsMonochromeInput;
        [Abstract]
        [Export("wantsMonochromeInput")]

        bool WantsMonochromeInput { get; }

        // @required -(void)setCurrentlyReceivingMonochromeInput:(BOOL)newValue;
        [Abstract]
        [Export("setCurrentlyReceivingMonochromeInput:")]
        void SetCurrentlyReceivingMonochromeInput(bool newValue);
    }

    // @interface GPUImageOutput : NSObject
    [BaseType(typeof(NSObject))]
    interface GPUImageOutput
    {
        // @property (readwrite, nonatomic) BOOL shouldSmoothlyScaleOutput;
        [Export("shouldSmoothlyScaleOutput")]
        bool ShouldSmoothlyScaleOutput { get; set; }

        // @property (readwrite, nonatomic) BOOL shouldIgnoreUpdatesToThisTarget;
        [Export("shouldIgnoreUpdatesToThisTarget")]
        bool ShouldIgnoreUpdatesToThisTarget { get; set; }

        // @property (readwrite, retain, nonatomic) GPUImageMovieWriter * audioEncodingTarget;
        [Export("audioEncodingTarget", ArgumentSemantic.Retain)]
        GPUImageMovieWriter AudioEncodingTarget { get; set; }

        // @property (readwrite, nonatomic, unsafe_unretained) id<GPUImageInput> targetToIgnoreForUpdates;
        [Export("targetToIgnoreForUpdates", ArgumentSemantic.Assign)]
        GPUImageInput TargetToIgnoreForUpdates { get; set; }

        // @property (copy, nonatomic) void (^frameProcessingCompletionBlock)(GPUImageOutput *, CMTime);
        [Export("frameProcessingCompletionBlock", ArgumentSemantic.Copy)]
        Action<GPUImageOutput, CMTime> FrameProcessingCompletionBlock { get; set; }

        // @property (nonatomic) BOOL enabled;
        [Export("enabled")]
        bool Enabled { get; set; }

        // @property (readwrite, nonatomic) GPUTextureOptions outputTextureOptions;
        [Export("outputTextureOptions", ArgumentSemantic.Assign)]
        GPUTextureOptions OutputTextureOptions { get; set; }

        // -(void)setInputFramebufferForTarget:(id<GPUImageInput>)target atIndex:(NSInteger)inputTextureIndex;
        [Export("setInputFramebufferForTarget:atIndex:")]
        void SetInputFramebufferForTarget(GPUImageInput target, nint inputTextureIndex);

        // -(GPUImageFramebuffer *)framebufferForOutput;
        [Export("framebufferForOutput")]

        GPUImageFramebuffer FramebufferForOutput { get; }

        // -(void)removeOutputFramebuffer;
        [Export("removeOutputFramebuffer")]
        void RemoveOutputFramebuffer();

        // -(void)notifyTargetsAboutNewOutputTexture;
        [Export("notifyTargetsAboutNewOutputTexture")]
        void NotifyTargetsAboutNewOutputTexture();

        // -(NSArray *)targets;
        [Export("targets")]
        NSObject[] Targets { get; }

        // -(void)addTarget:(id<GPUImageInput>)newTarget;
        [Export("addTarget:")]
        void AddTarget(GPUImageInput newTarget);

        // -(void)addTarget:(id<GPUImageInput>)newTarget atTextureLocation:(NSInteger)textureLocation;
        [Export("addTarget:atTextureLocation:")]
        void AddTarget(GPUImageInput newTarget, nint textureLocation);

        // -(void)removeTarget:(id<GPUImageInput>)targetToRemove;
        [Export("removeTarget:")]
        void RemoveTarget(GPUImageInput targetToRemove);

        // -(void)removeAllTargets;
        [Export("removeAllTargets")]
        void RemoveAllTargets();

        // -(void)forceProcessingAtSize:(CGSize)frameSize;
        [Export("forceProcessingAtSize:")]
        void ForceProcessingAtSize(CGSize frameSize);

        // -(void)forceProcessingAtSizeRespectingAspectRatio:(CGSize)frameSize;
        [Export("forceProcessingAtSizeRespectingAspectRatio:")]
        void ForceProcessingAtSizeRespectingAspectRatio(CGSize frameSize);

        // -(void)useNextFrameForImageCapture;
        [Export("useNextFrameForImageCapture")]
        void UseNextFrameForImageCapture();

        // -(CGImageRef)newCGImageFromCurrentlyProcessedOutput;
        [Export("newCGImageFromCurrentlyProcessedOutput")]

        unsafe CGImage NewCGImageFromCurrentlyProcessedOutput { get; }

        // -(CGImageRef)newCGImageByFilteringCGImage:(CGImageRef)imageToFilter;
        [Export("newCGImageByFilteringCGImage:")]
        unsafe CGImage NewCGImageByFilteringCGImage(CGImage imageToFilter);

        // -(UIImage *)imageFromCurrentFramebuffer;
        [Export("imageFromCurrentFramebuffer")]

        UIImage ImageFromCurrentFramebuffer { get; }

        // -(UIImage *)imageFromCurrentFramebufferWithOrientation:(UIImageOrientation)imageOrientation;
        [Export("imageFromCurrentFramebufferWithOrientation:")]
        UIImage ImageFromCurrentFramebufferWithOrientation(UIImageOrientation imageOrientation);

        // -(UIImage *)imageByFilteringImage:(UIImage *)imageToFilter;
        [Export("imageByFilteringImage:")]
        UIImage ImageByFilteringImage(UIImage imageToFilter);

        // -(CGImageRef)newCGImageByFilteringImage:(UIImage *)imageToFilter;
        [Export("newCGImageByFilteringImage:")]
        unsafe CGImage NewCGImageByFilteringImage(UIImage imageToFilter);

        // -(BOOL)providesMonochromeOutput;
        [Export("providesMonochromeOutput")]

        bool ProvidesMonochromeOutput { get; }
    }

    // @interface GPUImageView : UIView <GPUImageInput>
    [BaseType(typeof(UIView))]
    interface GPUImageView : GPUImageInput
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

    partial interface Constants
    {
        // extern const GLfloat [] kColorConversion601;
        [Field("kColorConversion601", "__Internal")]
        float[] kColorConversion601 { get; }

        // extern const GLfloat [] kColorConversion601FullRange;
        [Field("kColorConversion601FullRange", "__Internal")]
        float[] kColorConversion601FullRange { get; }

        // extern const GLfloat [] kColorConversion709;
        [Field("kColorConversion709", "__Internal")]
        float[] kColorConversion709 { get; }

        // extern NSString *const kGPUImageYUVVideoRangeConversionForRGFragmentShaderString;
        [Field("kGPUImageYUVVideoRangeConversionForRGFragmentShaderString", "__Internal")]
        NSString kGPUImageYUVVideoRangeConversionForRGFragmentShaderString { get; }

        // extern NSString *const kGPUImageYUVFullRangeConversionForLAFragmentShaderString;
        [Field("kGPUImageYUVFullRangeConversionForLAFragmentShaderString", "__Internal")]
        NSString kGPUImageYUVFullRangeConversionForLAFragmentShaderString { get; }

        // extern NSString *const kGPUImageYUVVideoRangeConversionForLAFragmentShaderString;
        [Field("kGPUImageYUVVideoRangeConversionForLAFragmentShaderString", "__Internal")]
        NSString kGPUImageYUVVideoRangeConversionForLAFragmentShaderString { get; }
    }

    // @protocol GPUImageVideoCameraDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface GPUImageVideoCameraDelegate
    {
        // @optional -(void)willOutputSampleBuffer:(CMSampleBufferRef)sampleBuffer;
        [Export("willOutputSampleBuffer:")]
        void WillOutputSampleBuffer(CMSampleBuffer sampleBuffer);
    }

    // @interface GPUImageVideoCamera : GPUImageOutput <AVCaptureVideoDataOutputSampleBufferDelegate, AVCaptureAudioDataOutputSampleBufferDelegate>
    [BaseType(typeof(GPUImageOutput))]
    interface GPUImageVideoCamera : IAVCaptureVideoDataOutputSampleBufferDelegate, IAVCaptureAudioDataOutputSampleBufferDelegate
    {
        // @property (readonly, retain, nonatomic) AVCaptureSession * captureSession;
        [Export("captureSession", ArgumentSemantic.Retain)]
        AVCaptureSession CaptureSession { get; }

        // @property (readwrite, copy, nonatomic) NSString * captureSessionPreset;
        [Export("captureSessionPreset")]
        string CaptureSessionPreset { get; set; }

        // @property (readwrite) int32_t frameRate;
        [Export("frameRate")]
        int FrameRate { get; set; }

        // @property (readonly, getter = isFrontFacingCameraPresent) BOOL frontFacingCameraPresent;
        [Export("frontFacingCameraPresent")]
        bool FrontFacingCameraPresent { [Bind("isFrontFacingCameraPresent")] get; }

        // @property (readonly, getter = isBackFacingCameraPresent) BOOL backFacingCameraPresent;
        [Export("backFacingCameraPresent")]
        bool BackFacingCameraPresent { [Bind("isBackFacingCameraPresent")] get; }

        // @property (readwrite, nonatomic) BOOL runBenchmark;
        [Export("runBenchmark")]
        bool RunBenchmark { get; set; }

        // @property (readonly) AVCaptureDevice * inputCamera;
        [Export("inputCamera")]
        AVCaptureDevice InputCamera { get; }

        // @property (readwrite, nonatomic) UIInterfaceOrientation outputImageOrientation;
        [Export("outputImageOrientation", ArgumentSemantic.Assign)]
        UIInterfaceOrientation OutputImageOrientation { get; set; }

        // @property (readwrite, nonatomic) BOOL horizontallyMirrorFrontFacingCamera;
        [Export("horizontallyMirrorFrontFacingCamera")]
        bool HorizontallyMirrorFrontFacingCamera { get; set; }

        // @property (readwrite, nonatomic) BOOL horizontallyMirrorRearFacingCamera;
        [Export("horizontallyMirrorRearFacingCamera")]
        bool HorizontallyMirrorRearFacingCamera { get; set; }

        [Wrap("WeakDelegate")]
        GPUImageVideoCameraDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<GPUImageVideoCameraDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

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

        // -(void)processVideoSampleBuffer:(CMSampleBufferRef)sampleBuffer;
        [Export("processVideoSampleBuffer:")]
        void ProcessVideoSampleBuffer(CMSampleBuffer sampleBuffer);

        // -(void)processAudioSampleBuffer:(CMSampleBufferRef)sampleBuffer;
        [Export("processAudioSampleBuffer:")]
        void ProcessAudioSampleBuffer(CMSampleBuffer sampleBuffer);

        // -(AVCaptureDevicePosition)cameraPosition;
        [Export("cameraPosition")]

        AVCaptureDevicePosition CameraPosition { get; }

        // -(AVCaptureConnection *)videoCaptureConnection;
        [Export("videoCaptureConnection")]

        AVCaptureConnection VideoCaptureConnection { get; }

        // -(void)rotateCamera;
        [Export("rotateCamera")]
        void RotateCamera();

        // -(CGFloat)averageFrameDurationDuringCapture;
        [Export("averageFrameDurationDuringCapture")]

        nfloat AverageFrameDurationDuringCapture { get; }

        // -(void)resetBenchmarkAverage;
        [Export("resetBenchmarkAverage")]
        void ResetBenchmarkAverage();

        // +(BOOL)isBackFacingCameraPresent;
        [Static]
        [Export("isBackFacingCameraPresent")]

        bool IsBackFacingCameraPresent { get; }

        // +(BOOL)isFrontFacingCameraPresent;
        [Static]
        [Export("isFrontFacingCameraPresent")]

        bool IsFrontFacingCameraPresent { get; }
    }

    // @interface GPUImageStillCamera : GPUImageVideoCamera
    [BaseType(typeof(GPUImageVideoCamera))]
    interface GPUImageStillCamera
    {
        // @property CGFloat jpegCompressionQuality;
        [Export("jpegCompressionQuality")]
        nfloat JpegCompressionQuality { get; set; }

        // @property (readonly) NSDictionary * currentCaptureMetadata;
        [Export("currentCaptureMetadata")]
        NSDictionary CurrentCaptureMetadata { get; }

        // -(void)capturePhotoAsSampleBufferWithCompletionHandler:(void (^)(CMSampleBufferRef, NSError *))block;
        [Export("capturePhotoAsSampleBufferWithCompletionHandler:")]
        void CapturePhotoAsSampleBufferWithCompletionHandler(Action<NSError> block);

        // -(void)capturePhotoAsImageProcessedUpToFilter:(GPUImageOutput<GPUImageInput> *)finalFilterInChain withCompletionHandler:(void (^)(UIImage *, NSError *))block;
        [Export("capturePhotoAsImageProcessedUpToFilter:withCompletionHandler:")]
        void CapturePhotoAsImageProcessedUpToFilter(GPUImageInput finalFilterInChain, Action<UIImage, NSError> block);

        // -(void)capturePhotoAsImageProcessedUpToFilter:(GPUImageOutput<GPUImageInput> *)finalFilterInChain withOrientation:(UIImageOrientation)orientation withCompletionHandler:(void (^)(UIImage *, NSError *))block;
        [Export("capturePhotoAsImageProcessedUpToFilter:withOrientation:withCompletionHandler:")]
        void CapturePhotoAsImageProcessedUpToFilter(GPUImageInput finalFilterInChain, UIImageOrientation orientation, Action<UIImage, NSError> block);

        // -(void)capturePhotoAsJPEGProcessedUpToFilter:(GPUImageOutput<GPUImageInput> *)finalFilterInChain withCompletionHandler:(void (^)(NSData *, NSError *))block;
        [Export("capturePhotoAsJPEGProcessedUpToFilter:withCompletionHandler:")]
        void CapturePhotoAsJPEGProcessedUpToFilter(GPUImageInput finalFilterInChain, Action<NSData, NSError> block);

        // -(void)capturePhotoAsJPEGProcessedUpToFilter:(GPUImageOutput<GPUImageInput> *)finalFilterInChain withOrientation:(UIImageOrientation)orientation withCompletionHandler:(void (^)(NSData *, NSError *))block;
        [Export("capturePhotoAsJPEGProcessedUpToFilter:withOrientation:withCompletionHandler:")]
        void CapturePhotoAsJPEGProcessedUpToFilter(GPUImageInput finalFilterInChain, UIImageOrientation orientation, Action<NSData, NSError> block);

        // -(void)capturePhotoAsPNGProcessedUpToFilter:(GPUImageOutput<GPUImageInput> *)finalFilterInChain withCompletionHandler:(void (^)(NSData *, NSError *))block;
        [Export("capturePhotoAsPNGProcessedUpToFilter:withCompletionHandler:")]
        void CapturePhotoAsPNGProcessedUpToFilter(GPUImageInput finalFilterInChain, Action<NSData, NSError> block);

        // -(void)capturePhotoAsPNGProcessedUpToFilter:(GPUImageOutput<GPUImageInput> *)finalFilterInChain withOrientation:(UIImageOrientation)orientation withCompletionHandler:(void (^)(NSData *, NSError *))block;
        [Export("capturePhotoAsPNGProcessedUpToFilter:withOrientation:withCompletionHandler:")]
        void CapturePhotoAsPNGProcessedUpToFilter(GPUImageInput finalFilterInChain, UIImageOrientation orientation, Action<NSData, NSError> block);
    }

    // @protocol GPUImageMovieDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface GPUImageMovieDelegate
    {
        // @required -(void)didCompletePlayingMovie;
        [Abstract]
        [Export("didCompletePlayingMovie")]
        void DidCompletePlayingMovie();
    }

    // @interface GPUImageMovie : GPUImageOutput
    [BaseType(typeof(GPUImageOutput))]
    interface GPUImageMovie
    {
        // @property (readwrite, retain) AVAsset * asset;
        [Export("asset", ArgumentSemantic.Retain)]
        AVAsset Asset { get; set; }

        // @property (readwrite, retain) AVPlayerItem * playerItem;
        [Export("playerItem", ArgumentSemantic.Retain)]
        AVPlayerItem PlayerItem { get; set; }

        // @property (readwrite, retain) NSURL * url;
        [Export("url", ArgumentSemantic.Retain)]
        NSUrl Url { get; set; }

        // @property (readwrite, nonatomic) BOOL runBenchmark;
        [Export("runBenchmark")]
        bool RunBenchmark { get; set; }

        // @property (readwrite, nonatomic) BOOL playAtActualSpeed;
        [Export("playAtActualSpeed")]
        bool PlayAtActualSpeed { get; set; }

        // @property (readwrite, nonatomic) BOOL shouldRepeat;
        [Export("shouldRepeat")]
        bool ShouldRepeat { get; set; }

        // @property (readonly, nonatomic) float progress;
        [Export("progress")]
        float Progress { get; }

        [Wrap("WeakDelegate")]
        GPUImageMovieDelegate Delegate { get; set; }

        // @property (assign, readwrite, nonatomic) id<GPUImageMovieDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic) AVAssetReader * assetReader;
        [Export("assetReader")]
        AVAssetReader AssetReader { get; }

        // @property (readonly, nonatomic) BOOL audioEncodingIsFinished;
        [Export("audioEncodingIsFinished")]
        bool AudioEncodingIsFinished { get; }

        // @property (readonly, nonatomic) BOOL videoEncodingIsFinished;
        [Export("videoEncodingIsFinished")]
        bool VideoEncodingIsFinished { get; }

        // -(id)initWithAsset:(AVAsset *)asset;
        [Export("initWithAsset:")]
        IntPtr Constructor(AVAsset asset);

        // -(id)initWithPlayerItem:(AVPlayerItem *)playerItem;
        [Export("initWithPlayerItem:")]
        IntPtr Constructor(AVPlayerItem playerItem);

        // -(id)initWithURL:(NSURL *)url;
        [Export("initWithURL:")]
        IntPtr Constructor(NSUrl url);

        // -(void)yuvConversionSetup;
        [Export("yuvConversionSetup")]
        void YuvConversionSetup();

        // -(void)enableSynchronizedEncodingUsingMovieWriter:(GPUImageMovieWriter *)movieWriter;
        [Export("enableSynchronizedEncodingUsingMovieWriter:")]
        void EnableSynchronizedEncodingUsingMovieWriter(GPUImageMovieWriter movieWriter);

        // -(BOOL)readNextVideoFrameFromOutput:(AVAssetReaderOutput *)readerVideoTrackOutput;
        [Export("readNextVideoFrameFromOutput:")]
        bool ReadNextVideoFrameFromOutput(AVAssetReaderOutput readerVideoTrackOutput);

        // -(BOOL)readNextAudioSampleFromOutput:(AVAssetReaderOutput *)readerAudioTrackOutput;
        [Export("readNextAudioSampleFromOutput:")]
        bool ReadNextAudioSampleFromOutput(AVAssetReaderOutput readerAudioTrackOutput);

        // -(void)startProcessing;
        [Export("startProcessing")]
        void StartProcessing();

        // -(void)endProcessing;
        [Export("endProcessing")]
        void EndProcessing();

        // -(void)cancelProcessing;
        [Export("cancelProcessing")]
        void CancelProcessing();

        // -(void)processMovieFrame:(CMSampleBufferRef)movieSampleBuffer;
        [Export("processMovieFrame:")]
        void ProcessMovieFrame(CMSampleBuffer movieSampleBuffer);
    }

    // @interface GPUImagePicture : GPUImageOutput
    [BaseType(typeof(GPUImageOutput))]
    interface GPUImagePicture
    {
        // -(id)initWithURL:(NSURL *)url;
        [Export("initWithURL:")]
        IntPtr Constructor(NSUrl url);

        // -(id)initWithImage:(UIImage *)newImageSource;
        [Export("initWithImage:")]
        IntPtr Constructor(UIImage newImageSource);

        // -(id)initWithCGImage:(CGImageRef)newImageSource;
        [Export("initWithCGImage:")]
        unsafe IntPtr Constructor(CGImage newImageSource);

        // -(id)initWithImage:(UIImage *)newImageSource smoothlyScaleOutput:(BOOL)smoothlyScaleOutput;
        [Export("initWithImage:smoothlyScaleOutput:")]
        IntPtr Constructor(UIImage newImageSource, bool smoothlyScaleOutput);

        // -(id)initWithCGImage:(CGImageRef)newImageSource smoothlyScaleOutput:(BOOL)smoothlyScaleOutput;
        [Export("initWithCGImage:smoothlyScaleOutput:")]
        unsafe IntPtr Constructor(CGImage newImageSource, bool smoothlyScaleOutput);

        // -(void)processImage;
        [Export("processImage")]
        void ProcessImage();

        // -(CGSize)outputImageSize;
        [Export("outputImageSize")]

        CGSize OutputImageSize { get; }

        // -(BOOL)processImageWithCompletionHandler:(void (^)(void))completion;
        [Export("processImageWithCompletionHandler:")]
        bool ProcessImageWithCompletionHandler(Action completion);

        // -(void)processImageUpToFilter:(GPUImageOutput<GPUImageInput> *)finalFilterInChain withCompletionHandler:(void (^)(UIImage *))block;
        [Export("processImageUpToFilter:withCompletionHandler:")]
        void ProcessImageUpToFilter(GPUImageInput finalFilterInChain, Action<UIImage> block);
    }

    // @interface GPUImageRawDataInput : GPUImageOutput
    [BaseType(typeof(GPUImageOutput))]
    interface GPUImageRawDataInput
    {
        // -(id)initWithBytes:(GLubyte *)bytesToUpload size:(CGSize)imageSize;
        [Export("initWithBytes:size:")]
        unsafe IntPtr Constructor(byte bytesToUpload, CGSize imageSize);

        // -(id)initWithBytes:(GLubyte *)bytesToUpload size:(CGSize)imageSize pixelFormat:(GPUPixelFormat)pixelFormat;
        [Export("initWithBytes:size:pixelFormat:")]
        unsafe IntPtr Constructor(byte bytesToUpload, CGSize imageSize, GPUPixelFormat pixelFormat);

        // -(id)initWithBytes:(GLubyte *)bytesToUpload size:(CGSize)imageSize pixelFormat:(GPUPixelFormat)pixelFormat type:(GPUPixelType)pixelType;
        [Export("initWithBytes:size:pixelFormat:type:")]
        unsafe IntPtr Constructor(byte bytesToUpload, CGSize imageSize, GPUPixelFormat pixelFormat, GPUPixelType pixelType);

        // @property (readwrite, nonatomic) GPUPixelFormat pixelFormat;
        [Export("pixelFormat", ArgumentSemantic.Assign)]
        GPUPixelFormat PixelFormat { get; set; }

        // @property (readwrite, nonatomic) GPUPixelType pixelType;
        [Export("pixelType", ArgumentSemantic.Assign)]
        GPUPixelType PixelType { get; set; }

        // -(void)updateDataFromBytes:(GLubyte *)bytesToUpload size:(CGSize)imageSize;
        [Export("updateDataFromBytes:size:")]
        unsafe void UpdateDataFromBytes(byte bytesToUpload, CGSize imageSize);

        // -(void)processData;
        [Export("processData")]
        void ProcessData();

        // -(void)processDataForTimestamp:(CMTime)frameTime;
        [Export("processDataForTimestamp:")]
        void ProcessDataForTimestamp(CMTime frameTime);

        // -(CGSize)outputImageSize;
        [Export("outputImageSize")]

        CGSize OutputImageSize { get; }
    }

    // @interface GPUImageRawDataOutput : NSObject <GPUImageInput>
    [BaseType(typeof(NSObject))]
    interface GPUImageRawDataOutput : GPUImageInput
    {
        // @property (readonly) GLubyte * rawBytesForImage;
        [Export("rawBytesForImage")]
        unsafe byte RawBytesForImage { get; }

        // @property (copy, nonatomic) void (^newFrameAvailableBlock)();
        [Export("newFrameAvailableBlock", ArgumentSemantic.Copy)]
        Action NewFrameAvailableBlock { get; set; }

        // @property (nonatomic) BOOL enabled;
        [Export("enabled")]
        bool Enabled { get; set; }

        // -(id)initWithImageSize:(CGSize)newImageSize resultsInBGRAFormat:(BOOL)resultsInBGRAFormat;
        [Export("initWithImageSize:resultsInBGRAFormat:")]
        IntPtr Constructor(CGSize newImageSize, bool resultsInBGRAFormat);

        // -(GPUByteColorVector)colorAtLocation:(CGPoint)locationInImage;
        [Export("colorAtLocation:")]
        GPUByteColorVector ColorAtLocation(CGPoint locationInImage);

        // -(NSUInteger)bytesPerRowInOutput;
        [Export("bytesPerRowInOutput")]

        nuint BytesPerRowInOutput { get; }

        // -(void)setImageSize:(CGSize)newImageSize;
        [Export("setImageSize:")]
        void SetImageSize(CGSize newImageSize);

        // -(void)lockFramebufferForReading;
        [Export("lockFramebufferForReading")]
        void LockFramebufferForReading();

        // -(void)unlockFramebufferAfterReading;
        [Export("unlockFramebufferAfterReading")]
        void UnlockFramebufferAfterReading();
    }

    partial interface Constants
    {
        // extern NSString *const kGPUImageColorSwizzlingFragmentShaderString;
        [Field("kGPUImageColorSwizzlingFragmentShaderString", "__Internal")]
        NSString kGPUImageColorSwizzlingFragmentShaderString { get; }
    }

    // @protocol GPUImageMovieWriterDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface GPUImageMovieWriterDelegate
    {
        // @optional -(void)movieRecordingCompleted;
        [Export("movieRecordingCompleted")]
        void MovieRecordingCompleted();

        // @optional -(void)movieRecordingFailedWithError:(NSError *)error;
        [Export("movieRecordingFailedWithError:")]
        void MovieRecordingFailedWithError(NSError error);
    }

    // @interface GPUImageMovieWriter : NSObject <GPUImageInput>
    [BaseType(typeof(NSObject))]
    interface GPUImageMovieWriter : GPUImageInput
    {
        // @property (readwrite, nonatomic) BOOL hasAudioTrack;
        [Export("hasAudioTrack")]
        bool HasAudioTrack { get; set; }

        // @property (readwrite, nonatomic) BOOL shouldPassthroughAudio;
        [Export("shouldPassthroughAudio")]
        bool ShouldPassthroughAudio { get; set; }

        // @property (readwrite, nonatomic) BOOL shouldInvalidateAudioSampleWhenDone;
        [Export("shouldInvalidateAudioSampleWhenDone")]
        bool ShouldInvalidateAudioSampleWhenDone { get; set; }

        // @property (copy, nonatomic) void (^completionBlock)();
        [Export("completionBlock", ArgumentSemantic.Copy)]
        Action CompletionBlock { get; set; }

        // @property (copy, nonatomic) void (^failureBlock)(NSError *);
        [Export("failureBlock", ArgumentSemantic.Copy)]
        Action<NSError> FailureBlock { get; set; }

        [Wrap("WeakDelegate")]
        GPUImageMovieWriterDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<GPUImageMovieWriterDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // @property (readwrite, nonatomic) BOOL encodingLiveVideo;
        [Export("encodingLiveVideo")]
        bool EncodingLiveVideo { get; set; }

        // @property (copy, nonatomic) BOOL (^videoInputReadyCallback)();
        [Export("videoInputReadyCallback", ArgumentSemantic.Copy)]
        Func<bool> VideoInputReadyCallback { get; set; }

        // @property (copy, nonatomic) BOOL (^audioInputReadyCallback)();
        [Export("audioInputReadyCallback", ArgumentSemantic.Copy)]
        Func<bool> AudioInputReadyCallback { get; set; }

        // @property (copy, nonatomic) void (^audioProcessingCallback)(SInt16 **, CMItemCount);
        [Export("audioProcessingCallback", ArgumentSemantic.Copy)]
        unsafe Action<short, nint> AudioProcessingCallback { get; set; }

        // @property (nonatomic) BOOL enabled;
        [Export("enabled")]
        bool Enabled { get; set; }

        // @property (readonly, nonatomic) AVAssetWriter * assetWriter;
        [Export("assetWriter")]
        AVAssetWriter AssetWriter { get; }

        // @property (readonly, nonatomic) CMTime duration;
        [Export("duration")]
        CMTime Duration { get; }

        // @property (assign, nonatomic) CGAffineTransform transform;
        [Export("transform", ArgumentSemantic.Assign)]
        CGAffineTransform Transform { get; set; }

        // @property (copy, nonatomic) NSArray * metaData;
        [Export("metaData", ArgumentSemantic.Copy)]

        NSObject[] MetaData { get; set; }

        // @property (getter = isPaused, assign, nonatomic) BOOL paused;
        [Export("paused")]
        bool Paused { [Bind("isPaused")] get; set; }

        // @property (retain, nonatomic) GPUImageContext * movieWriterContext;
        [Export("movieWriterContext", ArgumentSemantic.Retain)]
        GPUImageContext MovieWriterContext { get; set; }

        // -(id)initWithMovieURL:(NSURL *)newMovieURL size:(CGSize)newSize;
        [Export("initWithMovieURL:size:")]
        IntPtr Constructor(NSUrl newMovieURL, CGSize newSize);

        // -(id)initWithMovieURL:(NSURL *)newMovieURL size:(CGSize)newSize fileType:(NSString *)newFileType outputSettings:(NSDictionary *)outputSettings;
        [Export("initWithMovieURL:size:fileType:outputSettings:")]
        IntPtr Constructor(NSUrl newMovieURL, CGSize newSize, string newFileType, NSDictionary outputSettings);

        // -(void)setHasAudioTrack:(BOOL)hasAudioTrack audioSettings:(NSDictionary *)audioOutputSettings;
        [Export("setHasAudioTrack:audioSettings:")]
        void SetHasAudioTrack(bool hasAudioTrack, NSDictionary audioOutputSettings);

        // -(void)startRecording;
        [Export("startRecording")]
        void StartRecording();

        // -(void)startRecordingInOrientation:(CGAffineTransform)orientationTransform;
        [Export("startRecordingInOrientation:")]
        void StartRecordingInOrientation(CGAffineTransform orientationTransform);

        // -(void)finishRecording;
        [Export("finishRecording")]
        void FinishRecording();

        // -(void)finishRecordingWithCompletionHandler:(void (^)(void))handler;
        [Export("finishRecordingWithCompletionHandler:")]
        void FinishRecordingWithCompletionHandler(Action handler);

        // -(void)cancelRecording;
        [Export("cancelRecording")]
        void CancelRecording();

        // -(void)processAudioBuffer:(CMSampleBufferRef)audioBuffer;
        [Export("processAudioBuffer:")]
        void ProcessAudioBuffer(CMSampleBuffer audioBuffer);

        // -(void)enableSynchronizationCallbacks;
        [Export("enableSynchronizationCallbacks")]
        void EnableSynchronizationCallbacks();
    }

    // @interface GPUImageFilterPipeline : NSObject
    [BaseType(typeof(NSObject))]
    interface GPUImageFilterPipeline
    {
        // @property (strong) NSMutableArray * filters;
        [Export("filters", ArgumentSemantic.Strong)]
        NSMutableArray Filters { get; set; }

        // @property (strong) GPUImageOutput * input;
        [Export("input", ArgumentSemantic.Strong)]
        GPUImageOutput Input { get; set; }

        // @property (strong) id<GPUImageInput> output;
        [Export("output", ArgumentSemantic.Strong)]
        GPUImageInput Output { get; set; }

        // -(id)initWithOrderedFilters:(NSArray *)filters input:(GPUImageOutput *)input output:(id<GPUImageInput>)output;
        [Export("initWithOrderedFilters:input:output:")]

        IntPtr Constructor(NSObject[] filters, GPUImageOutput input, GPUImageInput output);

        // -(id)initWithConfiguration:(NSDictionary *)configuration input:(GPUImageOutput *)input output:(id<GPUImageInput>)output;
        [Export("initWithConfiguration:input:output:")]
        IntPtr Constructor(NSDictionary configuration, GPUImageOutput input, GPUImageInput output);

        // -(id)initWithConfigurationFile:(NSURL *)configuration input:(GPUImageOutput *)input output:(id<GPUImageInput>)output;
        [Export("initWithConfigurationFile:input:output:")]
        IntPtr Constructor(NSUrl configuration, GPUImageOutput input, GPUImageInput output);

        // -(void)addFilter:(GPUImageOutput<GPUImageInput> *)filter;
        [Export("addFilter:")]
        void AddFilter(GPUImageInput filter);

        // -(void)addFilter:(GPUImageOutput<GPUImageInput> *)filter atIndex:(NSUInteger)insertIndex;
        [Export("addFilter:atIndex:")]
        void AddFilter(GPUImageInput filter, nuint insertIndex);

        // -(void)replaceFilterAtIndex:(NSUInteger)index withFilter:(GPUImageOutput<GPUImageInput> *)filter;
        [Export("replaceFilterAtIndex:withFilter:")]
        void ReplaceFilterAtIndex(nuint index, GPUImageInput filter);

        // -(void)replaceAllFilters:(NSArray *)newFilters;
        [Export("replaceAllFilters:")]

        void ReplaceAllFilters(NSObject[] newFilters);

        // -(void)removeFilter:(GPUImageOutput<GPUImageInput> *)filter;
        [Export("removeFilter:")]
        void RemoveFilter(GPUImageInput filter);

        // -(void)removeFilterAtIndex:(NSUInteger)index;
        [Export("removeFilterAtIndex:")]
        void RemoveFilterAtIndex(nuint index);

        // -(void)removeAllFilters;
        [Export("removeAllFilters")]
        void RemoveAllFilters();

        // -(UIImage *)currentFilteredFrame;
        [Export("currentFilteredFrame")]

        UIImage CurrentFilteredFrame { get; }

        // -(UIImage *)currentFilteredFrameWithOrientation:(UIImageOrientation)imageOrientation;
        [Export("currentFilteredFrameWithOrientation:")]
        UIImage CurrentFilteredFrameWithOrientation(UIImageOrientation imageOrientation);

        // -(CGImageRef)newCGImageFromCurrentFilteredFrame;
        [Export("newCGImageFromCurrentFilteredFrame")]

        unsafe CGImage NewCGImageFromCurrentFilteredFrame { get; }
    }

    // @interface GPUImageTextureOutput : NSObject <GPUImageInput>
    [BaseType(typeof(NSObject))]
    interface GPUImageTextureOutput : GPUImageInput
    {
        [Wrap("WeakDelegate")]
        GPUImageTextureOutputDelegate Delegate { get; set; }

        // @property (readwrite, nonatomic, unsafe_unretained) id<GPUImageTextureOutputDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly) GLuint texture;
        [Export("texture")]
        uint Texture { get; }

        // @property (nonatomic) BOOL enabled;
        [Export("enabled")]
        bool Enabled { get; set; }

        // -(void)doneWithTexture;
        [Export("doneWithTexture")]
        void DoneWithTexture();
    }

    // @protocol GPUImageTextureOutputDelegate
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    partial interface GPUImageTextureOutputDelegate
    {
        // @required -(void)newFrameReadyFromTextureOutput:(GPUImageTextureOutput *)callbackTextureOutput;
        [Abstract]
        [Export("newFrameReadyFromTextureOutput:")]
        void NewFrameReadyFromTextureOutput(GPUImageTextureOutput callbackTextureOutput);
    }

    partial interface Constants
    {
        // extern NSString *const kGPUImageVertexShaderString;
        [Field("kGPUImageVertexShaderString", "__Internal")]
        NSString kGPUImageVertexShaderString { get; }

        // extern NSString *const kGPUImagePassthroughFragmentShaderString;
        [Field("kGPUImagePassthroughFragmentShaderString", "__Internal")]
        NSString kGPUImagePassthroughFragmentShaderString { get; }
    }

    // @interface GPUImageFilter : GPUImageOutput <GPUImageInput>
    [BaseType(typeof(GPUImageOutput))]
    interface GPUImageFilter : GPUImageInput
    {
        // @property (readonly) CVPixelBufferRef renderTarget;
        [Export("renderTarget")]
        CVPixelBuffer RenderTarget { get; }

        // @property (readwrite, nonatomic) BOOL preventRendering;
        [Export("preventRendering")]
        bool PreventRendering { get; set; }

        // @property (readwrite, nonatomic) BOOL currentlyReceivingMonochromeInput;
        [Export("currentlyReceivingMonochromeInput")]
        bool CurrentlyReceivingMonochromeInput { get;}

        // -(id)initWithVertexShaderFromString:(NSString *)vertexShaderString fragmentShaderFromString:(NSString *)fragmentShaderString;
        [Export("initWithVertexShaderFromString:fragmentShaderFromString:")]
        IntPtr Constructor(string vertexShaderString, string fragmentShaderString);

        // -(id)initWithFragmentShaderFromString:(NSString *)fragmentShaderString;
        [Export("initWithFragmentShaderFromString:")]
        IntPtr ConstructorFromString(string fragmentShaderString);

        // -(id)initWithFragmentShaderFromFile:(NSString *)fragmentShaderFilename;
        [Export("initWithFragmentShaderFromFile:")]
        IntPtr ConstructorFromFile(string fragmentShaderFilename);

        // -(void)initializeAttributes;
        [Export("initializeAttributes")]
        void InitializeAttributes();

        // -(void)setupFilterForSize:(CGSize)filterFrameSize;
        [Export("setupFilterForSize:")]
        void SetupFilterForSize(CGSize filterFrameSize);

        // -(CGSize)rotatedSize:(CGSize)sizeToRotate forIndex:(NSInteger)textureIndex;
        [Export("rotatedSize:forIndex:")]
        CGSize RotatedSize(CGSize sizeToRotate, nint textureIndex);

        // -(CGPoint)rotatedPoint:(CGPoint)pointToRotate forRotation:(GPUImageRotationMode)rotation;
        [Export("rotatedPoint:forRotation:")]
        CGPoint RotatedPoint(CGPoint pointToRotate, GPUImageRotationMode rotation);

        // -(CGSize)sizeOfFBO;
        [Export("sizeOfFBO")]

        CGSize SizeOfFBO { get; }

        // +(const GLfloat *)textureCoordinatesForRotation:(GPUImageRotationMode)rotationMode;
        [Static]
        [Export("textureCoordinatesForRotation:")]
        unsafe float TextureCoordinatesForRotation(GPUImageRotationMode rotationMode);

        // -(void)renderToTextureWithVertices:(const GLfloat *)vertices textureCoordinates:(const GLfloat *)textureCoordinates;
        [Export("renderToTextureWithVertices:textureCoordinates:")]
        unsafe void RenderToTextureWithVertices(float vertices, float textureCoordinates);

        // -(void)informTargetsAboutNewFrameAtTime:(CMTime)frameTime;
        [Export("informTargetsAboutNewFrameAtTime:")]
        void InformTargetsAboutNewFrameAtTime(CMTime frameTime);

        // -(CGSize)outputFrameSize;
        [Export("outputFrameSize")]

        CGSize OutputFrameSize { get; }

        // -(void)setBackgroundColorRed:(GLfloat)redComponent green:(GLfloat)greenComponent blue:(GLfloat)blueComponent alpha:(GLfloat)alphaComponent;
        [Export("setBackgroundColorRed:green:blue:alpha:")]
        void SetBackgroundColorRed(float redComponent, float greenComponent, float blueComponent, float alphaComponent);

        // -(void)setInteger:(GLint)newInteger forUniformName:(NSString *)uniformName;
        [Export("setInteger:forUniformName:")]
        void SetInteger(int newInteger, string uniformName);

        // -(void)setFloat:(GLfloat)newFloat forUniformName:(NSString *)uniformName;
        [Export("setFloat:forUniformName:")]
        void SetFloat(float newFloat, string uniformName);

        // -(void)setSize:(CGSize)newSize forUniformName:(NSString *)uniformName;
        [Export("setSize:forUniformName:")]
        void SetSize(CGSize newSize, string uniformName);

        // -(void)setPoint:(CGPoint)newPoint forUniformName:(NSString *)uniformName;
        [Export("setPoint:forUniformName:")]
        void SetPoint(CGPoint newPoint, string uniformName);

        // -(void)setFloatVec3:(GPUVector3)newVec3 forUniformName:(NSString *)uniformName;
        [Export("setFloatVec3:forUniformName:")]
        void SetFloatVec3(GPUVector3 newVec3, string uniformName);

        // -(void)setFloatVec4:(GPUVector4)newVec4 forUniform:(NSString *)uniformName;
        [Export("setFloatVec4:forUniform:")]
        void SetFloatVec4(GPUVector4 newVec4, string uniformName);

        // -(void)setFloatArray:(GLfloat *)array length:(GLsizei)count forUniform:(NSString *)uniformName;
        [Export("setFloatArray:length:forUniform:")]
        unsafe void SetFloatArray(float array, int count, string uniformName);

        // -(void)setMatrix3f:(GPUMatrix3x3)matrix forUniform:(GLint)uniform program:(GLProgram *)shaderProgram;
        [Export("setMatrix3f:forUniform:program:")]
        void SetMatrix3f(GPUMatrix3x3 matrix, int uniform, GLProgram shaderProgram);

        // -(void)setMatrix4f:(GPUMatrix4x4)matrix forUniform:(GLint)uniform program:(GLProgram *)shaderProgram;
        [Export("setMatrix4f:forUniform:program:")]
        void SetMatrix4f(GPUMatrix4x4 matrix, int uniform, GLProgram shaderProgram);

        // -(void)setFloat:(GLfloat)floatValue forUniform:(GLint)uniform program:(GLProgram *)shaderProgram;
        [Export("setFloat:forUniform:program:")]
        void SetFloat(float floatValue, int uniform, GLProgram shaderProgram);

        // -(void)setPoint:(CGPoint)pointValue forUniform:(GLint)uniform program:(GLProgram *)shaderProgram;
        [Export("setPoint:forUniform:program:")]
        void SetPoint(CGPoint pointValue, int uniform, GLProgram shaderProgram);

        // -(void)setSize:(CGSize)sizeValue forUniform:(GLint)uniform program:(GLProgram *)shaderProgram;
        [Export("setSize:forUniform:program:")]
        void SetSize(CGSize sizeValue, int uniform, GLProgram shaderProgram);

        // -(void)setVec3:(GPUVector3)vectorValue forUniform:(GLint)uniform program:(GLProgram *)shaderProgram;
        [Export("setVec3:forUniform:program:")]
        void SetVec3(GPUVector3 vectorValue, int uniform, GLProgram shaderProgram);

        // -(void)setVec4:(GPUVector4)vectorValue forUniform:(GLint)uniform program:(GLProgram *)shaderProgram;
        [Export("setVec4:forUniform:program:")]
        void SetVec4(GPUVector4 vectorValue, int uniform, GLProgram shaderProgram);

        // -(void)setFloatArray:(GLfloat *)arrayValue length:(GLsizei)arrayLength forUniform:(GLint)uniform program:(GLProgram *)shaderProgram;
        [Export("setFloatArray:length:forUniform:program:")]
        unsafe void SetFloatArray(float arrayValue, int arrayLength, int uniform, GLProgram shaderProgram);

        // -(void)setInteger:(GLint)intValue forUniform:(GLint)uniform program:(GLProgram *)shaderProgram;
        [Export("setInteger:forUniform:program:")]
        void SetInteger(int intValue, int uniform, GLProgram shaderProgram);

        // -(void)setAndExecuteUniformStateCallbackAtIndex:(GLint)uniform forProgram:(GLProgram *)shaderProgram toBlock:(dispatch_block_t)uniformStateBlock;
        [Export("setAndExecuteUniformStateCallbackAtIndex:forProgram:toBlock:")]
        void SetAndExecuteUniformStateCallbackAtIndex(int uniform, GLProgram shaderProgram, Action uniformStateBlock);

        // -(void)setUniformsForProgramAtIndex:(NSUInteger)programIndex;
        [Export("setUniformsForProgramAtIndex:")]
        void SetUniformsForProgramAtIndex(nuint programIndex);
    }

    // @interface GPUImageFilterGroup : GPUImageOutput <GPUImageInput>
    [BaseType(typeof(GPUImageOutput))]
    interface GPUImageFilterGroup : GPUImageInput
    {
        // @property (readwrite, nonatomic, strong) GPUImageOutput<GPUImageInput> * terminalFilter;
        [Export("terminalFilter", ArgumentSemantic.Strong)]
        GPUImageInput TerminalFilter { get; set; }

        // @property (readwrite, nonatomic, strong) NSArray * initialFilters;
        [Export("initialFilters", ArgumentSemantic.Strong)]

        NSObject[] InitialFilters { get; set; }

        // @property (readwrite, nonatomic, strong) GPUImageOutput<GPUImageInput> * inputFilterToIgnoreForUpdates;
        [Export("inputFilterToIgnoreForUpdates", ArgumentSemantic.Strong)]
        GPUImageInput InputFilterToIgnoreForUpdates { get; set; }

        // -(void)addFilter:(GPUImageOutput<GPUImageInput> *)newFilter;
        [Export("addFilter:")]
        void AddFilter(GPUImageInput newFilter);

        // -(GPUImageOutput<GPUImageInput> *)filterAtIndex:(NSUInteger)filterIndex;
        [Export("filterAtIndex:")]
        GPUImageInput FilterAtIndex(nuint filterIndex);

        // -(NSUInteger)filterCount;
        [Export("filterCount")]

        nuint FilterCount { get; }
    }

    // @interface GPUImageTextureInput : GPUImageOutput
    [BaseType(typeof(GPUImageOutput))]
    interface GPUImageTextureInput
    {
        // -(id)initWithTexture:(GLuint)newInputTexture size:(CGSize)newTextureSize;
        [Export("initWithTexture:size:")]
        IntPtr Constructor(uint newInputTexture, CGSize newTextureSize);

        // -(void)processTextureWithFrameTime:(CMTime)frameTime;
        [Export("processTextureWithFrameTime:")]
        void ProcessTextureWithFrameTime(CMTime frameTime);
    }

    // @interface GPUImageUIElement : GPUImageOutput
    [BaseType(typeof(GPUImageOutput))]
    interface GPUImageUIElement
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
    }

    // @interface GPUImageBuffer : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageBuffer
    {
        // @property (readwrite, nonatomic) NSUInteger bufferSize;
        [Export("bufferSize")]
        nuint BufferSize { get; set; }
    }


    partial interface Constants
    {
        // extern NSString *const kGPUImageTwoInputTextureVertexShaderString;
        [Field("kGPUImageTwoInputTextureVertexShaderString", "__Internal")]
        NSString kGPUImageTwoInputTextureVertexShaderString { get; }
    }

    // @interface GPUImageTwoInputFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageTwoInputFilter
    {
        // -(void)disableFirstFrameCheck;
        [Export("disableFirstFrameCheck")]
        void DisableFirstFrameCheck();

        // -(void)disableSecondFrameCheck;
        [Export("disableSecondFrameCheck")]
        void DisableSecondFrameCheck();
    }

    // @interface GPUImagePixellateFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImagePixellateFilter
    {
        // @property (readwrite, nonatomic) CGFloat fractionalWidthOfAPixel;
        [Export("fractionalWidthOfAPixel")]
        nfloat FractionalWidthOfAPixel { get; set; }
    }

    // @interface GPUImagePixellatePositionFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImagePixellatePositionFilter
    {
        // @property (readwrite, nonatomic) CGFloat fractionalWidthOfAPixel;
        [Export("fractionalWidthOfAPixel")]
        nfloat FractionalWidthOfAPixel { get; set; }

        // @property (readwrite, nonatomic) CGPoint center;
        [Export("center", ArgumentSemantic.Assign)]
        CGPoint Center { get; set; }

        // @property (readwrite, nonatomic) CGFloat radius;
        [Export("radius")]
        nfloat Radius { get; set; }
    }

    // @interface GPUImageColorMatrixFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageColorMatrixFilter
    {
        // @property (readwrite, nonatomic) GPUMatrix4x4 colorMatrix;
        [Export("colorMatrix", ArgumentSemantic.Assign)]
        GPUMatrix4x4 ColorMatrix { get; set; }

        // @property (readwrite, nonatomic) CGFloat intensity;
        [Export("intensity")]
        nfloat Intensity { get; set; }
    }

    // @interface GPUImageSepiaFilter : GPUImageColorMatrixFilter
    [BaseType(typeof(GPUImageColorMatrixFilter))]
    interface GPUImageSepiaFilter
    {
    }

    // @interface GPUImageColorInvertFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageColorInvertFilter
    {
    }

    // @interface GPUImageSaturationFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageSaturationFilter
    {
        // @property (readwrite, nonatomic) CGFloat saturation;
        [Export("saturation")]
        nfloat Saturation { get; set; }
    }

    // @interface GPUImageContrastFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageContrastFilter
    {
        // @property (readwrite, nonatomic) CGFloat contrast;
        [Export("contrast")]
        nfloat Contrast { get; set; }
    }

    // @interface GPUImageExposureFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageExposureFilter
    {
        // @property (readwrite, nonatomic) CGFloat exposure;
        [Export("exposure")]
        nfloat Exposure { get; set; }
    }

    // @interface GPUImageBrightnessFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageBrightnessFilter
    {
        // @property (readwrite, nonatomic) CGFloat brightness;
        [Export("brightness")]
        nfloat Brightness { get; set; }
    }

    // @interface GPUImageLevelsFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageLevelsFilter
    {
        // -(void)setRedMin:(CGFloat)min gamma:(CGFloat)mid max:(CGFloat)max minOut:(CGFloat)minOut maxOut:(CGFloat)maxOut;
        [Export("setRedMin:gamma:max:minOut:maxOut:")]
        void SetRedMin(nfloat min, nfloat mid, nfloat max, nfloat minOut, nfloat maxOut);

        // -(void)setRedMin:(CGFloat)min gamma:(CGFloat)mid max:(CGFloat)max;
        [Export("setRedMin:gamma:max:")]
        void SetRedMin(nfloat min, nfloat mid, nfloat max);

        // -(void)setGreenMin:(CGFloat)min gamma:(CGFloat)mid max:(CGFloat)max minOut:(CGFloat)minOut maxOut:(CGFloat)maxOut;
        [Export("setGreenMin:gamma:max:minOut:maxOut:")]
        void SetGreenMin(nfloat min, nfloat mid, nfloat max, nfloat minOut, nfloat maxOut);

        // -(void)setGreenMin:(CGFloat)min gamma:(CGFloat)mid max:(CGFloat)max;
        [Export("setGreenMin:gamma:max:")]
        void SetGreenMin(nfloat min, nfloat mid, nfloat max);

        // -(void)setBlueMin:(CGFloat)min gamma:(CGFloat)mid max:(CGFloat)max minOut:(CGFloat)minOut maxOut:(CGFloat)maxOut;
        [Export("setBlueMin:gamma:max:minOut:maxOut:")]
        void SetBlueMin(nfloat min, nfloat mid, nfloat max, nfloat minOut, nfloat maxOut);

        // -(void)setBlueMin:(CGFloat)min gamma:(CGFloat)mid max:(CGFloat)max;
        [Export("setBlueMin:gamma:max:")]
        void SetBlueMin(nfloat min, nfloat mid, nfloat max);

        // -(void)setMin:(CGFloat)min gamma:(CGFloat)mid max:(CGFloat)max minOut:(CGFloat)minOut maxOut:(CGFloat)maxOut;
        [Export("setMin:gamma:max:minOut:maxOut:")]
        void SetMin(nfloat min, nfloat mid, nfloat max, nfloat minOut, nfloat maxOut);

        // -(void)setMin:(CGFloat)min gamma:(CGFloat)mid max:(CGFloat)max;
        [Export("setMin:gamma:max:")]
        void SetMin(nfloat min, nfloat mid, nfloat max);
    }

    // @interface GPUImageSharpenFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageSharpenFilter
    {
        // @property (readwrite, nonatomic) CGFloat sharpness;
        [Export("sharpness")]
        nfloat Sharpness { get; set; }
    }

    // @interface GPUImageGammaFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageGammaFilter
    {
        // @property (readwrite, nonatomic) CGFloat gamma;
        [Export("gamma")]
        nfloat Gamma { get; set; }
    }

    // @interface GPUImageTwoPassFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageTwoPassFilter
    {
        // -(id)initWithFirstStageVertexShaderFromString:(NSString *)firstStageVertexShaderString firstStageFragmentShaderFromString:(NSString *)firstStageFragmentShaderString secondStageVertexShaderFromString:(NSString *)secondStageVertexShaderString secondStageFragmentShaderFromString:(NSString *)secondStageFragmentShaderString;
        [Export("initWithFirstStageVertexShaderFromString:firstStageFragmentShaderFromString:secondStageVertexShaderFromString:secondStageFragmentShaderFromString:")]
        IntPtr Constructor(string firstStageVertexShaderString, string firstStageFragmentShaderString, string secondStageVertexShaderString, string secondStageFragmentShaderString);

        // -(id)initWithFirstStageFragmentShaderFromString:(NSString *)firstStageFragmentShaderString secondStageFragmentShaderFromString:(NSString *)secondStageFragmentShaderString;
        [Export("initWithFirstStageFragmentShaderFromString:secondStageFragmentShaderFromString:")]
        IntPtr Constructor(string firstStageFragmentShaderString, string secondStageFragmentShaderString);

        // -(void)initializeSecondaryAttributes;
        [Export("initializeSecondaryAttributes")]
        void InitializeSecondaryAttributes();
    }

    // @interface GPUImageSobelEdgeDetectionFilter : GPUImageTwoPassFilter
    [BaseType(typeof(GPUImageTwoPassFilter))]
    interface GPUImageSobelEdgeDetectionFilter
    {
        // @property (readwrite, nonatomic) CGFloat texelWidth;
        [Export("texelWidth")]
        nfloat TexelWidth { get; set; }

        // @property (readwrite, nonatomic) CGFloat texelHeight;
        [Export("texelHeight")]
        nfloat TexelHeight { get; set; }

        // @property (readwrite, nonatomic) CGFloat edgeStrength;
        [Export("edgeStrength")]
        nfloat EdgeStrength { get; set; }
    }

    // @interface GPUImageSketchFilter : GPUImageSobelEdgeDetectionFilter
    [BaseType(typeof(GPUImageSobelEdgeDetectionFilter))]
    interface GPUImageSketchFilter
    {
    }


    partial interface Constants
    {
        // extern NSString *const kGPUImageNearbyTexelSamplingVertexShaderString;
        [Field("kGPUImageNearbyTexelSamplingVertexShaderString", "__Internal")]
        NSString kGPUImageNearbyTexelSamplingVertexShaderString { get; }
    }

    // @interface GPUImage3x3TextureSamplingFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImage3x3TextureSamplingFilter
    {
        // @property (readwrite, nonatomic) CGFloat texelWidth;
        [Export("texelWidth")]
        nfloat TexelWidth { get; set; }

        // @property (readwrite, nonatomic) CGFloat texelHeight;
        [Export("texelHeight")]
        nfloat TexelHeight { get; set; }
    }

    // @interface GPUImageToonFilter : GPUImage3x3TextureSamplingFilter
    [BaseType(typeof(GPUImage3x3TextureSamplingFilter))]
    interface GPUImageToonFilter
    {
        // @property (readwrite, nonatomic) CGFloat threshold;
        [Export("threshold")]
        nfloat Threshold { get; set; }

        // @property (readwrite, nonatomic) CGFloat quantizationLevels;
        [Export("quantizationLevels")]
        nfloat QuantizationLevels { get; set; }
    }

    // @interface GPUImageSmoothToonFilter : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface GPUImageSmoothToonFilter
    {
        // @property (readwrite, nonatomic) CGFloat texelWidth;
        [Export("texelWidth")]
        nfloat TexelWidth { get; set; }

        // @property (readwrite, nonatomic) CGFloat texelHeight;
        [Export("texelHeight")]
        nfloat TexelHeight { get; set; }

        // @property (readwrite, nonatomic) CGFloat blurRadiusInPixels;
        [Export("blurRadiusInPixels")]
        nfloat BlurRadiusInPixels { get; set; }

        // @property (readwrite, nonatomic) CGFloat threshold;
        [Export("threshold")]
        nfloat Threshold { get; set; }

        // @property (readwrite, nonatomic) CGFloat quantizationLevels;
        [Export("quantizationLevels")]
        nfloat QuantizationLevels { get; set; }
    }

    // @interface GPUImageMultiplyBlendFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageMultiplyBlendFilter
    {
    }

    // @interface GPUImageDissolveBlendFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageDissolveBlendFilter
    {
        // @property (readwrite, nonatomic) CGFloat mix;
        [Export("mix")]
        nfloat Mix { get; set; }
    }

    // @interface GPUImageKuwaharaFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageKuwaharaFilter
    {
        // @property (readwrite, nonatomic) NSUInteger radius;
        [Export("radius")]
        nuint Radius { get; set; }
    }

    // @interface GPUImageKuwaharaRadius3Filter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageKuwaharaRadius3Filter
    {
    }

    // @interface GPUImageVignetteFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageVignetteFilter
    {
        // @property (readwrite, nonatomic) CGPoint vignetteCenter;
        [Export("vignetteCenter", ArgumentSemantic.Assign)]
        CGPoint VignetteCenter { get; set; }

        // @property (readwrite, nonatomic) GPUVector3 vignetteColor;
        [Export("vignetteColor", ArgumentSemantic.Assign)]
        GPUVector3 VignetteColor { get; set; }

        // @property (readwrite, nonatomic) CGFloat vignetteStart;
        [Export("vignetteStart")]
        nfloat VignetteStart { get; set; }

        // @property (readwrite, nonatomic) CGFloat vignetteEnd;
        [Export("vignetteEnd")]
        nfloat VignetteEnd { get; set; }
    }

    // @interface GPUImageTwoPassTextureSamplingFilter : GPUImageTwoPassFilter
    [BaseType(typeof(GPUImageTwoPassFilter))]
    interface GPUImageTwoPassTextureSamplingFilter
    {
        // @property (readwrite, nonatomic) CGFloat verticalTexelSpacing;
        [Export("verticalTexelSpacing")]
        nfloat VerticalTexelSpacing { get; set; }

        // @property (readwrite, nonatomic) CGFloat horizontalTexelSpacing;
        [Export("horizontalTexelSpacing")]
        nfloat HorizontalTexelSpacing { get; set; }
    }

    // @interface GPUImageGaussianBlurFilter : GPUImageTwoPassTextureSamplingFilter
    [BaseType(typeof(GPUImageTwoPassTextureSamplingFilter))]
    interface GPUImageGaussianBlurFilter
    {
        // @property (readwrite, nonatomic) CGFloat texelSpacingMultiplier;
        [Export("texelSpacingMultiplier")]
        nfloat TexelSpacingMultiplier { get; set; }

        // @property (readwrite, nonatomic) CGFloat blurRadiusInPixels;
        [Export("blurRadiusInPixels")]
        nfloat BlurRadiusInPixels { get; set; }

        // @property (readwrite, nonatomic) CGFloat blurRadiusAsFractionOfImageWidth;
        [Export("blurRadiusAsFractionOfImageWidth")]
        nfloat BlurRadiusAsFractionOfImageWidth { get; set; }

        // @property (readwrite, nonatomic) CGFloat blurRadiusAsFractionOfImageHeight;
        [Export("blurRadiusAsFractionOfImageHeight")]
        nfloat BlurRadiusAsFractionOfImageHeight { get; set; }

        // @property (readwrite, nonatomic) NSUInteger blurPasses;
        [Export("blurPasses")]
        nuint BlurPasses { get; set; }

        // +(NSString *)vertexShaderForStandardBlurOfRadius:(NSUInteger)blurRadius sigma:(CGFloat)sigma;
        [Static]
        [Export("vertexShaderForStandardBlurOfRadius:sigma:")]
        string VertexShaderForStandardBlurOfRadius(nuint blurRadius, nfloat sigma);

        // +(NSString *)fragmentShaderForStandardBlurOfRadius:(NSUInteger)blurRadius sigma:(CGFloat)sigma;
        [Static]
        [Export("fragmentShaderForStandardBlurOfRadius:sigma:")]
        string FragmentShaderForStandardBlurOfRadius(nuint blurRadius, nfloat sigma);

        // +(NSString *)vertexShaderForOptimizedBlurOfRadius:(NSUInteger)blurRadius sigma:(CGFloat)sigma;
        [Static]
        [Export("vertexShaderForOptimizedBlurOfRadius:sigma:")]
        string VertexShaderForOptimizedBlurOfRadius(nuint blurRadius, nfloat sigma);

        // +(NSString *)fragmentShaderForOptimizedBlurOfRadius:(NSUInteger)blurRadius sigma:(CGFloat)sigma;
        [Static]
        [Export("fragmentShaderForOptimizedBlurOfRadius:sigma:")]
        string FragmentShaderForOptimizedBlurOfRadius(nuint blurRadius, nfloat sigma);

        // -(void)switchToVertexShader:(NSString *)newVertexShader fragmentShader:(NSString *)newFragmentShader;
        [Export("switchToVertexShader:fragmentShader:")]
        void SwitchToVertexShader(string newVertexShader, string newFragmentShader);
    }

    // @interface GPUImageGaussianBlurPositionFilter : GPUImageTwoPassTextureSamplingFilter
    [BaseType(typeof(GPUImageTwoPassTextureSamplingFilter))]
    interface GPUImageGaussianBlurPositionFilter
    {
        // @property (readwrite, nonatomic) CGFloat blurSize;
        [Export("blurSize")]
        nfloat BlurSize { get; set; }

        // @property (readwrite, nonatomic) CGPoint blurCenter;
        [Export("blurCenter", ArgumentSemantic.Assign)]
        CGPoint BlurCenter { get; set; }

        // @property (readwrite, nonatomic) CGFloat blurRadius;
        [Export("blurRadius")]
        nfloat BlurRadius { get; set; }
    }

    // @interface GPUImageGaussianSelectiveBlurFilter : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface GPUImageGaussianSelectiveBlurFilter
    {
        // @property (readwrite, nonatomic) CGFloat excludeCircleRadius;
        [Export("excludeCircleRadius")]
        nfloat ExcludeCircleRadius { get; set; }

        // @property (readwrite, nonatomic) CGPoint excludeCirclePoint;
        [Export("excludeCirclePoint", ArgumentSemantic.Assign)]
        CGPoint ExcludeCirclePoint { get; set; }

        // @property (readwrite, nonatomic) CGFloat excludeBlurSize;
        [Export("excludeBlurSize")]
        nfloat ExcludeBlurSize { get; set; }

        // @property (readwrite, nonatomic) CGFloat blurRadiusInPixels;
        [Export("blurRadiusInPixels")]
        nfloat BlurRadiusInPixels { get; set; }

        // @property (readwrite, nonatomic) CGFloat aspectRatio;
        [Export("aspectRatio")]
        nfloat AspectRatio { get; set; }
    }

    // @interface GPUImageOverlayBlendFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageOverlayBlendFilter
    {
    }

    // @interface GPUImageDarkenBlendFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageDarkenBlendFilter
    {
    }

    // @interface GPUImageLightenBlendFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageLightenBlendFilter
    {
    }

    // @interface GPUImageSwirlFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageSwirlFilter
    {
        // @property (readwrite, nonatomic) CGPoint center;
        [Export("center", ArgumentSemantic.Assign)]
        CGPoint Center { get; set; }

        // @property (readwrite, nonatomic) CGFloat radius;
        [Export("radius")]
        nfloat Radius { get; set; }

        // @property (readwrite, nonatomic) CGFloat angle;
        [Export("angle")]
        nfloat Angle { get; set; }
    }

    // @interface GPUImageSourceOverBlendFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageSourceOverBlendFilter
    {
    }

    // @interface GPUImageColorBurnBlendFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageColorBurnBlendFilter
    {
    }

    // @interface GPUImageColorDodgeBlendFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageColorDodgeBlendFilter
    {
    }

    // @interface GPUImageScreenBlendFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageScreenBlendFilter
    {
    }

    // @interface GPUImageExclusionBlendFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageExclusionBlendFilter
    {
    }

    // @interface GPUImageDifferenceBlendFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageDifferenceBlendFilter
    {
    }

    // @interface GPUImageSubtractBlendFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageSubtractBlendFilter
    {
    }

    // @interface GPUImageHardLightBlendFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageHardLightBlendFilter
    {
    }

    // @interface GPUImageSoftLightBlendFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageSoftLightBlendFilter
    {
    }

    // @interface GPUImageColorBlendFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageColorBlendFilter
    {
    }

    // @interface GPUImageHueBlendFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageHueBlendFilter
    {
    }

    // @interface GPUImageSaturationBlendFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageSaturationBlendFilter
    {
    }

    // @interface GPUImageLuminosityBlendFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageLuminosityBlendFilter
    {
    }

    // @interface GPUImageCropFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageCropFilter
    {
        // @property (readwrite, nonatomic) CGRect cropRegion;
        [Export("cropRegion", ArgumentSemantic.Assign)]
        CGRect CropRegion { get; set; }

        // -(id)initWithCropRegion:(CGRect)newCropRegion;
        [Export("initWithCropRegion:")]
        IntPtr Constructor(CGRect newCropRegion);
    }


    partial interface Constants
    {
        // extern NSString *const kGPUImageLuminanceFragmentShaderString;
        [Field("kGPUImageLuminanceFragmentShaderString", "__Internal")]
        NSString kGPUImageLuminanceFragmentShaderString { get; }
    }

    // @interface GPUImageGrayscaleFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageGrayscaleFilter
    {
    }

    // @interface GPUImageTransformFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageTransformFilter
    {
        // @property (readwrite, nonatomic) CGAffineTransform affineTransform;
        [Export("affineTransform", ArgumentSemantic.Assign)]
        CGAffineTransform AffineTransform { get; set; }

        // @property (readwrite, nonatomic) CATransform3D transform3D;
        [Export("transform3D", ArgumentSemantic.Assign)]
        CATransform3D Transform3D { get; set; }

        // @property (readwrite, nonatomic) BOOL ignoreAspectRatio;
        [Export("ignoreAspectRatio")]
        bool IgnoreAspectRatio { get; set; }

        // @property (readwrite, nonatomic) BOOL anchorTopLeft;
        [Export("anchorTopLeft")]
        bool AnchorTopLeft { get; set; }
    }

    // @interface GPUImageChromaKeyBlendFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageChromaKeyBlendFilter
    {
        // @property (readwrite, nonatomic) CGFloat thresholdSensitivity;
        [Export("thresholdSensitivity")]
        nfloat ThresholdSensitivity { get; set; }

        // @property (readwrite, nonatomic) CGFloat smoothing;
        [Export("smoothing")]
        nfloat Smoothing { get; set; }

        // -(void)setColorToReplaceRed:(GLfloat)redComponent green:(GLfloat)greenComponent blue:(GLfloat)blueComponent;
        [Export("setColorToReplaceRed:green:blue:")]
        void SetColorToReplaceRed(float redComponent, float greenComponent, float blueComponent);
    }

    // @interface GPUImageHazeFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageHazeFilter
    {
        // @property (readwrite, nonatomic) CGFloat distance;
        [Export("distance")]
        nfloat Distance { get; set; }

        // @property (readwrite, nonatomic) CGFloat slope;
        [Export("slope")]
        nfloat Slope { get; set; }
    }

    // @interface GPUImageLuminanceThresholdFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageLuminanceThresholdFilter
    {
        // @property (readwrite, nonatomic) CGFloat threshold;
        [Export("threshold")]
        nfloat Threshold { get; set; }
    }

    // @interface GPUImagePosterizeFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImagePosterizeFilter
    {
        // @property (readwrite, nonatomic) NSUInteger colorLevels;
        [Export("colorLevels")]
        nuint ColorLevels { get; set; }
    }

    // @interface GPUImageBoxBlurFilter : GPUImageGaussianBlurFilter
    [BaseType(typeof(GPUImageGaussianBlurFilter))]
    interface GPUImageBoxBlurFilter
    {
    }

    // @interface GPUImageAdaptiveThresholdFilter : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface GPUImageAdaptiveThresholdFilter
    {
        // @property (readwrite, nonatomic) CGFloat blurRadiusInPixels;
        [Export("blurRadiusInPixels")]
        nfloat BlurRadiusInPixels { get; set; }
    }

    // @interface GPUImageUnsharpMaskFilter : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface GPUImageUnsharpMaskFilter
    {
        // @property (readwrite, nonatomic) CGFloat blurRadiusInPixels;
        [Export("blurRadiusInPixels")]
        nfloat BlurRadiusInPixels { get; set; }

        // @property (readwrite, nonatomic) CGFloat intensity;
        [Export("intensity")]
        nfloat Intensity { get; set; }
    }

    // @interface GPUImageBulgeDistortionFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageBulgeDistortionFilter
    {
        // @property (readwrite, nonatomic) CGPoint center;
        [Export("center", ArgumentSemantic.Assign)]
        CGPoint Center { get; set; }

        // @property (readwrite, nonatomic) CGFloat radius;
        [Export("radius")]
        nfloat Radius { get; set; }

        // @property (readwrite, nonatomic) CGFloat scale;
        [Export("scale")]
        nfloat Scale { get; set; }
    }

    // @interface GPUImagePinchDistortionFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImagePinchDistortionFilter
    {
        // @property (readwrite, nonatomic) CGPoint center;
        [Export("center", ArgumentSemantic.Assign)]
        CGPoint Center { get; set; }

        // @property (readwrite, nonatomic) CGFloat radius;
        [Export("radius")]
        nfloat Radius { get; set; }

        // @property (readwrite, nonatomic) CGFloat scale;
        [Export("scale")]
        nfloat Scale { get; set; }
    }

    // @interface GPUImageCrosshatchFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageCrosshatchFilter
    {
        // @property (readwrite, nonatomic) CGFloat crossHatchSpacing;
        [Export("crossHatchSpacing")]
        nfloat CrossHatchSpacing { get; set; }

        // @property (readwrite, nonatomic) CGFloat lineWidth;
        [Export("lineWidth")]
        nfloat LineWidth { get; set; }
    }

    // @interface GPUImageCGAColorspaceFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageCGAColorspaceFilter
    {
    }

    // @interface GPUImagePolarPixellateFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImagePolarPixellateFilter
    {
        // @property (readwrite, nonatomic) CGPoint center;
        [Export("center", ArgumentSemantic.Assign)]
        CGPoint Center { get; set; }

        // @property (readwrite, nonatomic) CGSize pixelSize;
        [Export("pixelSize", ArgumentSemantic.Assign)]
        CGSize PixelSize { get; set; }
    }

    // @interface GPUImageStretchDistortionFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageStretchDistortionFilter
    {
        // @property (readwrite, nonatomic) CGPoint center;
        [Export("center", ArgumentSemantic.Assign)]
        CGPoint Center { get; set; }
    }

    // @interface GPUImagePerlinNoiseFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImagePerlinNoiseFilter
    {
        // @property (readwrite, nonatomic) GPUVector4 colorStart;
        [Export("colorStart", ArgumentSemantic.Assign)]
        GPUVector4 ColorStart { get; set; }

        // @property (readwrite, nonatomic) GPUVector4 colorFinish;
        [Export("colorFinish", ArgumentSemantic.Assign)]
        GPUVector4 ColorFinish { get; set; }

        // @property (readwrite, nonatomic) float scale;
        [Export("scale")]
        float Scale { get; set; }
    }

    // @interface GPUImageJFAVoronoiFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageJFAVoronoiFilter
    {
        // @property (readwrite, nonatomic) CGSize sizeInPixels;
        [Export("sizeInPixels", ArgumentSemantic.Assign)]
        CGSize SizeInPixels { get; set; }
    }

    // @interface GPUImageVoronoiConsumerFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageVoronoiConsumerFilter
    {
        // @property (readwrite, nonatomic) CGSize sizeInPixels;
        [Export("sizeInPixels", ArgumentSemantic.Assign)]
        CGSize SizeInPixels { get; set; }
    }

    // @interface GPUImageMosaicFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageMosaicFilter
    {
        // @property (readwrite, nonatomic) CGSize inputTileSize;
        [Export("inputTileSize", ArgumentSemantic.Assign)]
        CGSize InputTileSize { get; set; }

        // @property (readwrite, nonatomic) float numTiles;
        [Export("numTiles")]
        float NumTiles { get; set; }

        // @property (readwrite, nonatomic) CGSize displayTileSize;
        [Export("displayTileSize", ArgumentSemantic.Assign)]
        CGSize DisplayTileSize { get; set; }

        // @property (readwrite, nonatomic) BOOL colorOn;
        [Export("colorOn")]
        bool ColorOn { get; set; }

        // @property (readwrite, copy, nonatomic) NSString * tileSet;
        [Export("tileSet")]
        string TileSet { get; set; }
    }

    // @interface GPUImageTiltShiftFilter : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface GPUImageTiltShiftFilter
    {
        // @property (readwrite, nonatomic) CGFloat blurRadiusInPixels;
        [Export("blurRadiusInPixels")]
        nfloat BlurRadiusInPixels { get; set; }

        // @property (readwrite, nonatomic) CGFloat topFocusLevel;
        [Export("topFocusLevel")]
        nfloat TopFocusLevel { get; set; }

        // @property (readwrite, nonatomic) CGFloat bottomFocusLevel;
        [Export("bottomFocusLevel")]
        nfloat BottomFocusLevel { get; set; }

        // @property (readwrite, nonatomic) CGFloat focusFallOffRate;
        [Export("focusFallOffRate")]
        nfloat FocusFallOffRate { get; set; }
    }

    // @interface GPUImage3x3ConvolutionFilter : GPUImage3x3TextureSamplingFilter
    [BaseType(typeof(GPUImage3x3TextureSamplingFilter))]
    interface GPUImage3x3ConvolutionFilter
    {
        // @property (readwrite, nonatomic) GPUMatrix3x3 convolutionKernel;
        [Export("convolutionKernel", ArgumentSemantic.Assign)]
        GPUMatrix3x3 ConvolutionKernel { get; set; }
    }

    // @interface GPUImageEmbossFilter : GPUImage3x3ConvolutionFilter
    [BaseType(typeof(GPUImage3x3ConvolutionFilter))]
    interface GPUImageEmbossFilter
    {
        // @property (readwrite, nonatomic) CGFloat intensity;
        [Export("intensity")]
        nfloat Intensity { get; set; }
    }

    // @interface GPUImageCannyEdgeDetectionFilter : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface GPUImageCannyEdgeDetectionFilter
    {
        // @property (readwrite, nonatomic) CGFloat texelWidth;
        [Export("texelWidth")]
        nfloat TexelWidth { get; set; }

        // @property (readwrite, nonatomic) CGFloat texelHeight;
        [Export("texelHeight")]
        nfloat TexelHeight { get; set; }

        // @property (readwrite, nonatomic) CGFloat blurRadiusInPixels;
        [Export("blurRadiusInPixels")]
        nfloat BlurRadiusInPixels { get; set; }

        // @property (readwrite, nonatomic) CGFloat blurTexelSpacingMultiplier;
        [Export("blurTexelSpacingMultiplier")]
        nfloat BlurTexelSpacingMultiplier { get; set; }

        // @property (readwrite, nonatomic) CGFloat upperThreshold;
        [Export("upperThreshold")]
        nfloat UpperThreshold { get; set; }

        // @property (readwrite, nonatomic) CGFloat lowerThreshold;
        [Export("lowerThreshold")]
        nfloat LowerThreshold { get; set; }
    }

    // @interface GPUImageThresholdEdgeDetectionFilter : GPUImageSobelEdgeDetectionFilter
    [BaseType(typeof(GPUImageSobelEdgeDetectionFilter))]
    interface GPUImageThresholdEdgeDetectionFilter
    {
        // @property (readwrite, nonatomic) CGFloat threshold;
        [Export("threshold")]
        nfloat Threshold { get; set; }
    }

    // @interface GPUImageMaskFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageMaskFilter
    {
    }

    // @interface GPUImageHistogramFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageHistogramFilter
    {
        // @property (readwrite, nonatomic) NSUInteger downsamplingFactor;
        [Export("downsamplingFactor")]
        nuint DownsamplingFactor { get; set; }

        // -(id)initWithHistogramType:(GPUImageHistogramType)newHistogramType;
        [Export("initWithHistogramType:")]
        IntPtr Constructor(GPUImageHistogramType newHistogramType);

        // -(void)initializeSecondaryAttributes;
        [Export("initializeSecondaryAttributes")]
        void InitializeSecondaryAttributes();
    }

    // @interface GPUImageHistogramGenerator : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageHistogramGenerator
    {
    }

    // @interface GPUImageHistogramEqualizationFilter : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface GPUImageHistogramEqualizationFilter
    {
        // @property (readwrite, nonatomic) NSUInteger downsamplingFactor;
        [Export("downsamplingFactor")]
        nuint DownsamplingFactor { get; set; }

        // -(id)initWithHistogramType:(GPUImageHistogramType)newHistogramType;
        [Export("initWithHistogramType:")]
        IntPtr Constructor(GPUImageHistogramType newHistogramType);
    }

    // @interface GPUImagePrewittEdgeDetectionFilter : GPUImageSobelEdgeDetectionFilter
    [BaseType(typeof(GPUImageSobelEdgeDetectionFilter))]
    interface GPUImagePrewittEdgeDetectionFilter
    {
    }

    // @interface GPUImageXYDerivativeFilter : GPUImageSobelEdgeDetectionFilter
    [BaseType(typeof(GPUImageSobelEdgeDetectionFilter))]
    interface GPUImageXYDerivativeFilter
    {
    }

    // @interface GPUImageHarrisCornerDetectionFilter : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface GPUImageHarrisCornerDetectionFilter
    {
        // @property (readwrite, nonatomic) CGFloat blurRadiusInPixels;
        [Export("blurRadiusInPixels")]
        nfloat BlurRadiusInPixels { get; set; }

        // @property (readwrite, nonatomic) CGFloat sensitivity;
        [Export("sensitivity")]
        nfloat Sensitivity { get; set; }

        // @property (readwrite, nonatomic) CGFloat threshold;
        [Export("threshold")]
        nfloat Threshold { get; set; }

        // @property (copy, nonatomic) void (^cornersDetectedBlock)(GLfloat *, NSUInteger, CMTime);
        [Export("cornersDetectedBlock", ArgumentSemantic.Copy)]
        unsafe Action<float, nuint, CMTime> CornersDetectedBlock { get; set; }

        // @property (readonly, nonatomic, strong) NSMutableArray * intermediateImages;
        [Export("intermediateImages", ArgumentSemantic.Strong)]
        NSMutableArray IntermediateImages { get; }

        // -(id)initWithCornerDetectionFragmentShader:(NSString *)cornerDetectionFragmentShader;
        [Export("initWithCornerDetectionFragmentShader:")]
        IntPtr Constructor(string cornerDetectionFragmentShader);
    }

    // @interface GPUImageAlphaBlendFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageAlphaBlendFilter
    {
        // @property (readwrite, nonatomic) CGFloat mix;
        [Export("mix")]
        nfloat Mix { get; set; }
    }

    // @interface GPUImageNormalBlendFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageNormalBlendFilter
    {
    }

    // @interface GPUImageNonMaximumSuppressionFilter : GPUImage3x3TextureSamplingFilter
    [BaseType(typeof(GPUImage3x3TextureSamplingFilter))]
    interface GPUImageNonMaximumSuppressionFilter
    {
    }

    // @interface GPUImageRGBFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageRGBFilter
    {
        // @property (readwrite, nonatomic) CGFloat red;
        [Export("red")]
        nfloat Red { get; set; }

        // @property (readwrite, nonatomic) CGFloat green;
        [Export("green")]
        nfloat Green { get; set; }

        // @property (readwrite, nonatomic) CGFloat blue;
        [Export("blue")]
        nfloat Blue { get; set; }
    }

    // @interface GPUImageMedianFilter : GPUImage3x3TextureSamplingFilter
    [BaseType(typeof(GPUImage3x3TextureSamplingFilter))]
    interface GPUImageMedianFilter
    {
    }

    // @interface GPUImageBilateralFilter : GPUImageGaussianBlurFilter
    [BaseType(typeof(GPUImageGaussianBlurFilter))]
    interface GPUImageBilateralFilter
    {
        // @property (readwrite, nonatomic) CGFloat distanceNormalizationFactor;
        [Export("distanceNormalizationFactor")]
        nfloat DistanceNormalizationFactor { get; set; }
    }

    // @interface GPUImageCrosshairGenerator : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageCrosshairGenerator
    {
        // @property (readwrite, nonatomic) CGFloat crosshairWidth;
        [Export("crosshairWidth")]
        nfloat CrosshairWidth { get; set; }

        // -(void)setCrosshairColorRed:(GLfloat)redComponent green:(GLfloat)greenComponent blue:(GLfloat)blueComponent;
        [Export("setCrosshairColorRed:green:blue:")]
        void SetCrosshairColorRed(float redComponent, float greenComponent, float blueComponent);

        // -(void)renderCrosshairsFromArray:(GLfloat *)crosshairCoordinates count:(NSUInteger)numberOfCrosshairs frameTime:(CMTime)frameTime;
        [Export("renderCrosshairsFromArray:count:frameTime:")]
        unsafe void RenderCrosshairsFromArray(float crosshairCoordinates, nuint numberOfCrosshairs, CMTime frameTime);
    }

    // @interface GPUImageToneCurveFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageToneCurveFilter
    {
        // @property (readwrite, copy, nonatomic) NSArray * redControlPoints;
        [Export("redControlPoints", ArgumentSemantic.Copy)]

        NSObject[] RedControlPoints { get; set; }

        // @property (readwrite, copy, nonatomic) NSArray * greenControlPoints;
        [Export("greenControlPoints", ArgumentSemantic.Copy)]

        NSObject[] GreenControlPoints { get; set; }

        // @property (readwrite, copy, nonatomic) NSArray * blueControlPoints;
        [Export("blueControlPoints", ArgumentSemantic.Copy)]

        NSObject[] BlueControlPoints { get; set; }

        // @property (readwrite, copy, nonatomic) NSArray * rgbCompositeControlPoints;
        [Export("rgbCompositeControlPoints", ArgumentSemantic.Copy)]

        NSObject[] RgbCompositeControlPoints { get; set; }

        // -(id)initWithACVData:(NSData *)data;
        [Export("initWithACVData:")]
        IntPtr Constructor(NSData data);

        // -(id)initWithACV:(NSString *)curveFilename;
        [Export("initWithACV:")]
        IntPtr Constructor(string curveFilename);

        // -(id)initWithACVURL:(NSURL *)curveFileURL;
        [Export("initWithACVURL:")]
        IntPtr Constructor(NSUrl curveFileURL);

        // -(void)setRGBControlPoints:(NSArray *)points __attribute__((deprecated("")));
        [Export("setRGBControlPoints:")]

        void SetRGBControlPoints(NSObject[] points);

        // -(void)setPointsWithACV:(NSString *)curveFilename;
        [Export("setPointsWithACV:")]
        void SetPointsWithACV(string curveFilename);

        // -(void)setPointsWithACVURL:(NSURL *)curveFileURL;
        [Export("setPointsWithACVURL:")]
        void SetPointsWithACVURL(NSUrl curveFileURL);

        // -(NSMutableArray *)getPreparedSplineCurve:(NSArray *)points;
        [Export("getPreparedSplineCurve:")]

        NSMutableArray GetPreparedSplineCurve(NSObject[] points);

        // -(NSMutableArray *)splineCurve:(NSArray *)points;
        [Export("splineCurve:")]

        NSMutableArray SplineCurve(NSObject[] points);

        // -(NSMutableArray *)secondDerivative:(NSArray *)cgPoints;
        [Export("secondDerivative:")]

        NSMutableArray SecondDerivative(NSObject[] cgPoints);

        // -(void)updateToneCurveTexture;
        [Export("updateToneCurveTexture")]
        void UpdateToneCurveTexture();
    }

    // @interface GPUImageNobleCornerDetectionFilter : GPUImageHarrisCornerDetectionFilter
    [BaseType(typeof(GPUImageHarrisCornerDetectionFilter))]
    interface GPUImageNobleCornerDetectionFilter
    {
    }

    // @interface GPUImageShiTomasiFeatureDetectionFilter : GPUImageHarrisCornerDetectionFilter
    [BaseType(typeof(GPUImageHarrisCornerDetectionFilter))]
    interface GPUImageShiTomasiFeatureDetectionFilter
    {
    }

    // @interface GPUImageErosionFilter : GPUImageTwoPassTextureSamplingFilter
    [BaseType(typeof(GPUImageTwoPassTextureSamplingFilter))]
    interface GPUImageErosionFilter
    {
        // -(id)initWithRadius:(NSUInteger)erosionRadius;
        [Export("initWithRadius:")]
        IntPtr Constructor(nuint erosionRadius);
    }

    // @interface GPUImageRGBErosionFilter : GPUImageTwoPassTextureSamplingFilter
    [BaseType(typeof(GPUImageTwoPassTextureSamplingFilter))]
    interface GPUImageRGBErosionFilter
    {
        // -(id)initWithRadius:(NSUInteger)erosionRadius;
        [Export("initWithRadius:")]
        IntPtr Constructor(nuint erosionRadius);
    }


    partial interface Constants
    {
        // extern NSString *const kGPUImageDilationRadiusOneVertexShaderString;
        [Field("kGPUImageDilationRadiusOneVertexShaderString", "__Internal")]
        NSString kGPUImageDilationRadiusOneVertexShaderString { get; }

        // extern NSString *const kGPUImageDilationRadiusTwoVertexShaderString;
        [Field("kGPUImageDilationRadiusTwoVertexShaderString", "__Internal")]
        NSString kGPUImageDilationRadiusTwoVertexShaderString { get; }

        // extern NSString *const kGPUImageDilationRadiusThreeVertexShaderString;
        [Field("kGPUImageDilationRadiusThreeVertexShaderString", "__Internal")]
        NSString kGPUImageDilationRadiusThreeVertexShaderString { get; }

        // extern NSString *const kGPUImageDilationRadiusFourVertexShaderString;
        [Field("kGPUImageDilationRadiusFourVertexShaderString", "__Internal")]
        NSString kGPUImageDilationRadiusFourVertexShaderString { get; }
    }

    // @interface GPUImageDilationFilter : GPUImageTwoPassTextureSamplingFilter
    [BaseType(typeof(GPUImageTwoPassTextureSamplingFilter))]
    interface GPUImageDilationFilter
    {
        // -(id)initWithRadius:(NSUInteger)dilationRadius;
        [Export("initWithRadius:")]
        IntPtr Constructor(nuint dilationRadius);
    }

    // @interface GPUImageRGBDilationFilter : GPUImageTwoPassTextureSamplingFilter
    [BaseType(typeof(GPUImageTwoPassTextureSamplingFilter))]
    interface GPUImageRGBDilationFilter
    {
        // -(id)initWithRadius:(NSUInteger)dilationRadius;
        [Export("initWithRadius:")]
        IntPtr Constructor(nuint dilationRadius);
    }

    // @interface GPUImageOpeningFilter : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface GPUImageOpeningFilter
    {
        // @property (readwrite, nonatomic) CGFloat verticalTexelSpacing;
        [Export("verticalTexelSpacing")]
        nfloat VerticalTexelSpacing { get; set; }

        // @property (readwrite, nonatomic) CGFloat horizontalTexelSpacing;
        [Export("horizontalTexelSpacing")]
        nfloat HorizontalTexelSpacing { get; set; }

        // -(id)initWithRadius:(NSUInteger)radius;
        [Export("initWithRadius:")]
        IntPtr Constructor(nuint radius);
    }

    // @interface GPUImageRGBOpeningFilter : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface GPUImageRGBOpeningFilter
    {
        // -(id)initWithRadius:(NSUInteger)radius;
        [Export("initWithRadius:")]
        IntPtr Constructor(nuint radius);
    }

    // @interface GPUImageClosingFilter : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface GPUImageClosingFilter
    {
        // @property (readwrite, nonatomic) CGFloat verticalTexelSpacing;
        [Export("verticalTexelSpacing")]
        nfloat VerticalTexelSpacing { get; set; }

        // @property (readwrite, nonatomic) CGFloat horizontalTexelSpacing;
        [Export("horizontalTexelSpacing")]
        nfloat HorizontalTexelSpacing { get; set; }

        // -(id)initWithRadius:(NSUInteger)radius;
        [Export("initWithRadius:")]
        IntPtr Constructor(nuint radius);
    }

    // @interface GPUImageRGBClosingFilter : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface GPUImageRGBClosingFilter
    {
        // -(id)initWithRadius:(NSUInteger)radius;
        [Export("initWithRadius:")]
        IntPtr Constructor(nuint radius);
    }

    // @interface GPUImageColorPackingFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageColorPackingFilter
    {
    }

    // @interface GPUImageSphereRefractionFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageSphereRefractionFilter
    {
        // @property (readwrite, nonatomic) CGPoint center;
        [Export("center", ArgumentSemantic.Assign)]
        CGPoint Center { get; set; }

        // @property (readwrite, nonatomic) CGFloat radius;
        [Export("radius")]
        nfloat Radius { get; set; }

        // @property (readwrite, nonatomic) CGFloat refractiveIndex;
        [Export("refractiveIndex")]
        nfloat RefractiveIndex { get; set; }
    }

    // @interface GPUImageMonochromeFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageMonochromeFilter
    {
        // @property (readwrite, nonatomic) CGFloat intensity;
        [Export("intensity")]
        nfloat Intensity { get; set; }

        // @property (readwrite, nonatomic) GPUVector4 color;
        [Export("color", ArgumentSemantic.Assign)]
        GPUVector4 Color { get; set; }

        // -(void)setColorRed:(GLfloat)redComponent green:(GLfloat)greenComponent blue:(GLfloat)blueComponent;
        [Export("setColorRed:green:blue:")]
        void SetColorRed(float redComponent, float greenComponent, float blueComponent);
    }

    // @interface GPUImageOpacityFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageOpacityFilter
    {
        // @property (readwrite, nonatomic) CGFloat opacity;
        [Export("opacity")]
        nfloat Opacity { get; set; }
    }

    // @interface GPUImageHighlightShadowFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageHighlightShadowFilter
    {
        // @property (readwrite, nonatomic) CGFloat shadows;
        [Export("shadows")]
        nfloat Shadows { get; set; }

        // @property (readwrite, nonatomic) CGFloat highlights;
        [Export("highlights")]
        nfloat Highlights { get; set; }
    }

    // @interface GPUImageFalseColorFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageFalseColorFilter
    {
        // @property (readwrite, nonatomic) GPUVector4 firstColor;
        [Export("firstColor", ArgumentSemantic.Assign)]
        GPUVector4 FirstColor { get; set; }

        // @property (readwrite, nonatomic) GPUVector4 secondColor;
        [Export("secondColor", ArgumentSemantic.Assign)]
        GPUVector4 SecondColor { get; set; }

        // -(void)setFirstColorRed:(GLfloat)redComponent green:(GLfloat)greenComponent blue:(GLfloat)blueComponent;
        [Export("setFirstColorRed:green:blue:")]
        void SetFirstColorRed(float redComponent, float greenComponent, float blueComponent);

        // -(void)setSecondColorRed:(GLfloat)redComponent green:(GLfloat)greenComponent blue:(GLfloat)blueComponent;
        [Export("setSecondColorRed:green:blue:")]
        void SetSecondColorRed(float redComponent, float greenComponent, float blueComponent);
    }

    // @interface GPUImageHSBFilter : GPUImageColorMatrixFilter
    [BaseType(typeof(GPUImageColorMatrixFilter))]
    interface GPUImageHSBFilter
    {
        // -(void)reset;
        [Export("reset")]
        void Reset();

        // -(void)rotateHue:(float)h;
        [Export("rotateHue:")]
        void RotateHue(float h);

        // -(void)adjustSaturation:(float)s;
        [Export("adjustSaturation:")]
        void AdjustSaturation(float s);

        // -(void)adjustBrightness:(float)b;
        [Export("adjustBrightness:")]
        void AdjustBrightness(float b);
    }

    // @interface GPUImageHueFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageHueFilter
    {
        // @property (readwrite, nonatomic) CGFloat hue;
        [Export("hue")]
        nfloat Hue { get; set; }
    }

    // @interface GPUImageGlassSphereFilter : GPUImageSphereRefractionFilter
    [BaseType(typeof(GPUImageSphereRefractionFilter))]
    interface GPUImageGlassSphereFilter
    {
    }

    // @interface GPUImageLookupFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageLookupFilter
    {
        // @property (readwrite, nonatomic) CGFloat intensity;
        [Export("intensity")]
        nfloat Intensity { get; set; }
    }

    // @interface GPUImageAmatorkaFilter : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface GPUImageAmatorkaFilter
    {
    }

    // @interface GPUImageMissEtikateFilter : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface GPUImageMissEtikateFilter
    {
    }

    // @interface GPUImageSoftEleganceFilter : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface GPUImageSoftEleganceFilter
    {
    }

    // @interface GPUImageAddBlendFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageAddBlendFilter
    {
    }

    // @interface GPUImageDivideBlendFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageDivideBlendFilter
    {
    }

    // @interface GPUImagePolkaDotFilter : GPUImagePixellateFilter
    [BaseType(typeof(GPUImagePixellateFilter))]
    interface GPUImagePolkaDotFilter
    {
        // @property (readwrite, nonatomic) CGFloat dotScaling;
        [Export("dotScaling")]
        nfloat DotScaling { get; set; }
    }

    // @interface GPUImageLocalBinaryPatternFilter : GPUImage3x3TextureSamplingFilter
    [BaseType(typeof(GPUImage3x3TextureSamplingFilter))]
    interface GPUImageLocalBinaryPatternFilter
    {
    }

    // @interface GPUImageLanczosResamplingFilter : GPUImageTwoPassTextureSamplingFilter
    [BaseType(typeof(GPUImageTwoPassTextureSamplingFilter))]
    interface GPUImageLanczosResamplingFilter
    {
        // @property (readwrite, nonatomic) CGSize originalImageSize;
        [Export("originalImageSize", ArgumentSemantic.Assign)]
        CGSize OriginalImageSize { get; set; }
    }

    partial interface Constants
    {
        // extern NSString *const kGPUImageColorAveragingVertexShaderString;
        [Field("kGPUImageColorAveragingVertexShaderString", "__Internal")]
        NSString kGPUImageColorAveragingVertexShaderString { get; }
    }

    // @interface GPUImageAverageColor : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageAverageColor
    {
        // @property (copy, nonatomic) void (^colorAverageProcessingFinishedBlock)(CGFloat, CGFloat, CGFloat, CGFloat, CMTime);
        [Export("colorAverageProcessingFinishedBlock", ArgumentSemantic.Copy)]
        Action<nfloat, nfloat, nfloat, nfloat, CMTime> ColorAverageProcessingFinishedBlock { get; set; }

        // -(void)extractAverageColorAtFrameTime:(CMTime)frameTime;
        [Export("extractAverageColorAtFrameTime:")]
        void ExtractAverageColorAtFrameTime(CMTime frameTime);
    }

    // @interface GPUImageSolidColorGenerator : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageSolidColorGenerator
    {
        // @property (readwrite, nonatomic) GPUVector4 color;
        [Export("color", ArgumentSemantic.Assign)]
        GPUVector4 Color { get; set; }

        // @property (assign, readwrite, nonatomic) BOOL useExistingAlpha;
        [Export("useExistingAlpha")]
        bool UseExistingAlpha { get; set; }

        // -(void)setColorRed:(CGFloat)redComponent green:(CGFloat)greenComponent blue:(CGFloat)blueComponent alpha:(CGFloat)alphaComponent;
        [Export("setColorRed:green:blue:alpha:")]
        void SetColorRed(nfloat redComponent, nfloat greenComponent, nfloat blueComponent, nfloat alphaComponent);
    }

    // @interface GPUImageLuminosity : GPUImageAverageColor
    [BaseType(typeof(GPUImageAverageColor))]
    interface GPUImageLuminosity
    {
        // @property (copy, nonatomic) void (^luminosityProcessingFinishedBlock)(CGFloat, CMTime);
        [Export("luminosityProcessingFinishedBlock", ArgumentSemantic.Copy)]
        Action<nfloat, CMTime> LuminosityProcessingFinishedBlock { get; set; }

        // -(void)extractLuminosityAtFrameTime:(CMTime)frameTime;
        [Export("extractLuminosityAtFrameTime:")]
        void ExtractLuminosityAtFrameTime(CMTime frameTime);

        // -(void)initializeSecondaryAttributes;
        [Export("initializeSecondaryAttributes")]
        void InitializeSecondaryAttributes();
    }

    // @interface GPUImageAverageLuminanceThresholdFilter : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface GPUImageAverageLuminanceThresholdFilter
    {
        // @property (readwrite, nonatomic) CGFloat thresholdMultiplier;
        [Export("thresholdMultiplier")]
        nfloat ThresholdMultiplier { get; set; }
    }

    // @interface GPUImageWhiteBalanceFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageWhiteBalanceFilter
    {
        // @property (readwrite, nonatomic) CGFloat temperature;
        [Export("temperature")]
        nfloat Temperature { get; set; }

        // @property (readwrite, nonatomic) CGFloat tint;
        [Export("tint")]
        nfloat Tint { get; set; }
    }

    // @interface GPUImageChromaKeyFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageChromaKeyFilter
    {
        // @property (readwrite, nonatomic) CGFloat thresholdSensitivity;
        [Export("thresholdSensitivity")]
        nfloat ThresholdSensitivity { get; set; }

        // @property (readwrite, nonatomic) CGFloat smoothing;
        [Export("smoothing")]
        nfloat Smoothing { get; set; }

        // -(void)setColorToReplaceRed:(GLfloat)redComponent green:(GLfloat)greenComponent blue:(GLfloat)blueComponent;
        [Export("setColorToReplaceRed:green:blue:")]
        void SetColorToReplaceRed(float redComponent, float greenComponent, float blueComponent);
    }

    // @interface GPUImageLowPassFilter : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface GPUImageLowPassFilter
    {
        // @property (readwrite, nonatomic) CGFloat filterStrength;
        [Export("filterStrength")]
        nfloat FilterStrength { get; set; }
    }

    // @interface GPUImageHighPassFilter : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface GPUImageHighPassFilter
    {
        // @property (readwrite, nonatomic) CGFloat filterStrength;
        [Export("filterStrength")]
        nfloat FilterStrength { get; set; }
    }

    // @interface GPUImageMotionDetector : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface GPUImageMotionDetector
    {
        // @property (readwrite, nonatomic) CGFloat lowPassFilterStrength;
        [Export("lowPassFilterStrength")]
        nfloat LowPassFilterStrength { get; set; }

        // @property (copy, nonatomic) void (^motionDetectionBlock)(CGPoint, CGFloat, CMTime);
        [Export("motionDetectionBlock", ArgumentSemantic.Copy)]
        Action<CGPoint, nfloat, CMTime> MotionDetectionBlock { get; set; }
    }

    // @interface GPUImageHalftoneFilter : GPUImagePixellateFilter
    [BaseType(typeof(GPUImagePixellateFilter))]
    interface GPUImageHalftoneFilter
    {
    }

    // @interface GPUImageThresholdedNonMaximumSuppressionFilter : GPUImage3x3TextureSamplingFilter
    [BaseType(typeof(GPUImage3x3TextureSamplingFilter))]
    interface GPUImageThresholdedNonMaximumSuppressionFilter
    {
        // @property (readwrite, nonatomic) CGFloat threshold;
        [Export("threshold")]
        nfloat Threshold { get; set; }

        // -(id)initWithPackedColorspace:(BOOL)inputUsesPackedColorspace;
        [Export("initWithPackedColorspace:")]
        IntPtr Constructor(bool inputUsesPackedColorspace);
    }

    // @interface GPUImageParallelCoordinateLineTransformFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageParallelCoordinateLineTransformFilter
    {
    }

    // @interface GPUImageHoughTransformLineDetector : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface GPUImageHoughTransformLineDetector
    {
        // @property (readwrite, nonatomic) CGFloat edgeThreshold;
        [Export("edgeThreshold")]
        nfloat EdgeThreshold { get; set; }

        // @property (readwrite, nonatomic) CGFloat lineDetectionThreshold;
        [Export("lineDetectionThreshold")]
        nfloat LineDetectionThreshold { get; set; }

        // @property (copy, nonatomic) void (^linesDetectedBlock)(GLfloat *, NSUInteger, CMTime);
        [Export("linesDetectedBlock", ArgumentSemantic.Copy)]
        unsafe Action<float, nuint, CMTime> LinesDetectedBlock { get; set; }

        // @property (readonly, nonatomic, strong) NSMutableArray * intermediateImages;
        [Export("intermediateImages", ArgumentSemantic.Strong)]
        NSMutableArray IntermediateImages { get; }
    }

    // @interface GPUImageThresholdSketchFilter : GPUImageThresholdEdgeDetectionFilter
    [BaseType(typeof(GPUImageThresholdEdgeDetectionFilter))]
    interface GPUImageThresholdSketchFilter
    {
    }

    // @interface GPUImageLineGenerator : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageLineGenerator
    {
        // @property (readwrite, nonatomic) CGFloat lineWidth;
        [Export("lineWidth")]
        nfloat LineWidth { get; set; }

        // -(void)setLineColorRed:(GLfloat)redComponent green:(GLfloat)greenComponent blue:(GLfloat)blueComponent;
        [Export("setLineColorRed:green:blue:")]
        void SetLineColorRed(float redComponent, float greenComponent, float blueComponent);

        // -(void)renderLinesFromArray:(GLfloat *)lineSlopeAndIntercepts count:(NSUInteger)numberOfLines frameTime:(CMTime)frameTime;
        [Export("renderLinesFromArray:count:frameTime:")]
        unsafe void RenderLinesFromArray(float lineSlopeAndIntercepts, nuint numberOfLines, CMTime frameTime);
    }

    // @interface GPUImageLinearBurnBlendFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageLinearBurnBlendFilter
    {
    }

    // @interface GPUImageTwoInputCrossTextureSamplingFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageTwoInputCrossTextureSamplingFilter
    {
        // @property (readwrite, nonatomic) CGFloat texelWidth;
        [Export("texelWidth")]
        nfloat TexelWidth { get; set; }

        // @property (readwrite, nonatomic) CGFloat texelHeight;
        [Export("texelHeight")]
        nfloat TexelHeight { get; set; }
    }

    // @interface GPUImagePoissonBlendFilter : GPUImageTwoInputCrossTextureSamplingFilter
    [BaseType(typeof(GPUImageTwoInputCrossTextureSamplingFilter))]
    interface GPUImagePoissonBlendFilter
    {
        // @property (readwrite, nonatomic) CGFloat mix;
        [Export("mix")]
        nfloat Mix { get; set; }

        // @property (readwrite, nonatomic) NSUInteger numIterations;
        [Export("numIterations")]
        nuint NumIterations { get; set; }
    }

    // @interface GPUImageMotionBlurFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageMotionBlurFilter
    {
        // @property (readwrite, nonatomic) CGFloat blurSize;
        [Export("blurSize")]
        nfloat BlurSize { get; set; }

        // @property (readwrite, nonatomic) CGFloat blurAngle;
        [Export("blurAngle")]
        nfloat BlurAngle { get; set; }
    }

    // @interface GPUImageZoomBlurFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageZoomBlurFilter
    {
        // @property (readwrite, nonatomic) CGFloat blurSize;
        [Export("blurSize")]
        nfloat BlurSize { get; set; }

        // @property (readwrite, nonatomic) CGPoint blurCenter;
        [Export("blurCenter", ArgumentSemantic.Assign)]
        CGPoint BlurCenter { get; set; }
    }

    // @interface GPUImageLaplacianFilter : GPUImage3x3ConvolutionFilter
    [BaseType(typeof(GPUImage3x3ConvolutionFilter))]
    interface GPUImageLaplacianFilter
    {
    }

    // @interface GPUImageiOSBlurFilter : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface GPUImageiOSBlurFilter
    {
        // @property (readwrite, nonatomic) CGFloat blurRadiusInPixels;
        [Export("blurRadiusInPixels")]
        nfloat BlurRadiusInPixels { get; set; }

        // @property (readwrite, nonatomic) CGFloat saturation;
        [Export("saturation")]
        nfloat Saturation { get; set; }

        // @property (readwrite, nonatomic) CGFloat downsampling;
        [Export("downsampling")]
        nfloat Downsampling { get; set; }

        // @property (readwrite, nonatomic) CGFloat rangeReductionFactor;
        [Export("rangeReductionFactor")]
        nfloat RangeReductionFactor { get; set; }
    }

    // @interface GPUImageLuminanceRangeFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageLuminanceRangeFilter
    {
        // @property (readwrite, nonatomic) CGFloat rangeReductionFactor;
        [Export("rangeReductionFactor")]
        nfloat RangeReductionFactor { get; set; }
    }

    // @interface GPUImageDirectionalNonMaximumSuppressionFilter : GPUImageFilter
    [BaseType(typeof(GPUImageFilter))]
    interface GPUImageDirectionalNonMaximumSuppressionFilter
    {
        // @property (readwrite, nonatomic) CGFloat texelWidth;
        [Export("texelWidth")]
        nfloat TexelWidth { get; set; }

        // @property (readwrite, nonatomic) CGFloat texelHeight;
        [Export("texelHeight")]
        nfloat TexelHeight { get; set; }

        // @property (readwrite, nonatomic) CGFloat upperThreshold;
        [Export("upperThreshold")]
        nfloat UpperThreshold { get; set; }

        // @property (readwrite, nonatomic) CGFloat lowerThreshold;
        [Export("lowerThreshold")]
        nfloat LowerThreshold { get; set; }
    }

    // @interface GPUImageDirectionalSobelEdgeDetectionFilter : GPUImage3x3TextureSamplingFilter
    [BaseType(typeof(GPUImage3x3TextureSamplingFilter))]
    interface GPUImageDirectionalSobelEdgeDetectionFilter
    {
    }

    // @interface GPUImageSingleComponentGaussianBlurFilter : GPUImageGaussianBlurFilter
    [BaseType(typeof(GPUImageGaussianBlurFilter))]
    interface GPUImageSingleComponentGaussianBlurFilter
    {
    }

    partial interface Constants
    {
        // extern NSString *const kGPUImageThreeInputTextureVertexShaderString;
        [Field("kGPUImageThreeInputTextureVertexShaderString", "__Internal")]
        NSString kGPUImageThreeInputTextureVertexShaderString { get; }
    }

    // @interface GPUImageThreeInputFilter : GPUImageTwoInputFilter
    [BaseType(typeof(GPUImageTwoInputFilter))]
    interface GPUImageThreeInputFilter
    {
        // -(void)disableThirdFrameCheck;
        [Export("disableThirdFrameCheck")]
        void DisableThirdFrameCheck();
    }

    // @interface GPUImageWeakPixelInclusionFilter : GPUImage3x3TextureSamplingFilter
    [BaseType(typeof(GPUImage3x3TextureSamplingFilter))]
    interface GPUImageWeakPixelInclusionFilter
    {
    }

    // @interface GPUImageFASTCornerDetectionFilter : GPUImageFilterGroup
    [BaseType(typeof(GPUImageFilterGroup))]
    interface GPUImageFASTCornerDetectionFilter
    {
        // -(id)initWithFASTDetectorVariant:(GPUImageFASTDetectorType)detectorType;
        [Export("initWithFASTDetectorVariant:")]
        IntPtr Constructor(GPUImageFASTDetectorType detectorType);
    }

    // @interface GPUImageMovieComposition : GPUImageMovie
    [BaseType(typeof(GPUImageMovie))]
    interface GPUImageMovieComposition
    {
        // @property (readwrite, retain) AVComposition * compositon;
        [Export("compositon", ArgumentSemantic.Retain)]
        AVComposition Compositon { get; set; }

        // @property (readwrite, retain) AVVideoComposition * videoComposition;
        [Export("videoComposition", ArgumentSemantic.Retain)]
        AVVideoComposition VideoComposition { get; set; }

        // @property (readwrite, retain) AVAudioMix * audioMix;
        [Export("audioMix", ArgumentSemantic.Retain)]
        AVAudioMix AudioMix { get; set; }

        // -(id)initWithComposition:(AVComposition *)compositon andVideoComposition:(AVVideoComposition *)videoComposition andAudioMix:(AVAudioMix *)audioMix;
        [Export("initWithComposition:andVideoComposition:andAudioMix:")]
        IntPtr Constructor(AVComposition compositon, AVVideoComposition videoComposition, AVAudioMix audioMix);
    }

    // @interface TextureSubimage (GPUImagePicture)
    [Category]
    [BaseType(typeof(GPUImagePicture))]
    interface GPUImagePicture_TextureSubimage
    {
        // -(void)replaceTextureWithSubimage:(UIImage *)subimage;
        [Export("replaceTextureWithSubimage:")]
        void ReplaceTextureWithSubimage(UIImage subimage);

        // -(void)replaceTextureWithSubCGImage:(CGImageRef)subimageSource;
        [Export("replaceTextureWithSubCGImage:")]
        unsafe void ReplaceTextureWithSubCGImage(CGImage subimageSource);

        // -(void)replaceTextureWithSubimage:(UIImage *)subimage inRect:(CGRect)subRect;
        [Export("replaceTextureWithSubimage:inRect:")]
        void ReplaceTextureWithSubimage(UIImage subimage, CGRect subRect);

        // -(void)replaceTextureWithSubCGImage:(CGImageRef)subimageSource inRect:(CGRect)subRect;
        [Export("replaceTextureWithSubCGImage:inRect:")]
        unsafe void ReplaceTextureWithSubCGImage(CGImage subimageSource, CGRect subRect);
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
