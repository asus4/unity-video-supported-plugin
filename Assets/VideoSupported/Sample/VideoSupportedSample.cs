using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using AppKit;

public class VideoSupportedSample : MonoBehaviour
{
    [SerializeField]
    Text label;

    void Start()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendFormat("FullHD Supported: {0}\n", VideoSupported.IsSupported(1920, 1080, 29.97f));
        sb.AppendFormat("4K Supported: {0}\n", VideoSupported.IsSupported(3840, 1920, 29.97f));
        label.text = sb.ToString();
    }
}
