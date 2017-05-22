# unity-video-supported-plugin
Check iOS/Android  supported video format from unity



```cs
// FullHD, NTSC support?
bool isFullHDSupported = VideoSupported.IsSupported(1920, 1080, 29.97f);

// 4K, NTSC support?
bool is4kSupported = VideoSupported.IsSupported(3840, 1920, 29.97f);
```