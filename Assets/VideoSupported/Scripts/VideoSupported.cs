using UnityEngine;
using System.Runtime.InteropServices;

namespace AppKit
{
    public static class VideoSupported
    {
        public static bool IsSupported(int width, int height, float framerate)
        {
#if UNITY_EDITOR
            return true;
#elif UNITY_IPHONE
			return isVideoSupportedFormat(width, height, framerate);
#elif UNITY_ANDROID
			var jo = new UnityEngine.AndroidJavaObject("asus4.videosupportedplugin.VideoSupportedPlugin");
			return jo.CallStatic<bool>("isVideoSupportedFormat", width, height, framerate);
#else
			Debug.LogError("Not supported platform");
            return false;
#endif
        }

        public static bool Is4KSupported()
        {
            return IsSupported(3840, 1920, 29.97f);
        }

#if UNITY_IPHONE
		[DllImport("__Internal")]
		private static extern bool isVideoSupportedFormat(int width, int heigt, float framerate);
#endif
    }
}