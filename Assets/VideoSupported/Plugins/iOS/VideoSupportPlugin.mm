//
//  VideoSupportPlugin.m
//  VideoSupportiOS
//
//  Created by Koki Ibukuro on 2017/03/12.
//  Copyright © 2017 Koki Ibukuro. All rights reserved.
//

#import <AVFoundation/AVFoundation.h>


extern "C" {
    BOOL isVideoSupportedFormat(int width, int height, float framerate) {
        AVCaptureDevice *device = [AVCaptureDevice defaultDeviceWithMediaType:AVMediaTypeVideo];
        for(AVCaptureDeviceFormat *format in device.formats) {
            CMVideoDimensions dim = format.highResolutionStillImageDimensions;
            if(dim.width < width || dim.height < height)
            {
                continue;
            }
            for(AVFrameRateRange *range in format.videoSupportedFrameRateRanges) {
                // NSLog(@"\t %f - %f", range.minFrameRate, range.maxFrameRate);
                if(range.minFrameRate <= framerate && framerate <= range.maxFrameRate) {
                    return YES;
                }
            }
        }
        return NO;
    }
}
