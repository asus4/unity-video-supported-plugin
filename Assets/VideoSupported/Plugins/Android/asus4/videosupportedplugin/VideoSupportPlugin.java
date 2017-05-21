package asus4.videosupportedplugin;

import android.media.MediaCodecInfo;
import android.media.MediaCodecList;

/**
 * Created by ibu on 2017/03/12.
 */

public final class VideoSupportedPlugin {
    public static boolean isVideoSupportedFormat(int width, int height, float framerate) {

        MediaCodecList allCodecs = new MediaCodecList(MediaCodecList.ALL_CODECS);
        MediaCodecInfo[] infos = allCodecs.getCodecInfos();

        for (MediaCodecInfo info : infos) {
            for (String type : info.getSupportedTypes()) {
                MediaCodecInfo.CodecCapabilities caps = info.getCapabilitiesForType(type);
                MediaCodecInfo.VideoCapabilities vcaps = caps.getVideoCapabilities();
                if (vcaps == null) {
                    continue;
                }
                if (vcaps.areSizeAndRateSupported(width, height, framerate)) {
                    return true;
                }
            }
        }
        return false;
    }
}
