﻿// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using SharpGen.Runtime;
using SharpGen.Runtime.Win32;
using Vortice.Multimedia;

namespace Vortice.MediaFoundation;

public partial class MediaFactory
{
    public static Result MFStartup(bool useLightVersion = false) => MFStartup(Version, useLightVersion ? 1 : 0);

    public static IMFMediaSession MFCreateMediaSession(IMFAttributes configuration)
    {
        MFCreateMediaSession(configuration, out IMFMediaSession session).CheckError();
        return session;
    }

    public static IMFSourceResolver MFCreateSourceResolver()
    {
        MFCreateSourceResolver(out IMFSourceResolver sourceResolver).CheckError();
        return sourceResolver;
    }

    public static IMFMediaSource MFCreateDeviceSource(IMFAttributes attributes)
    {
        MFCreateDeviceSource(attributes, out IMFMediaSource mediaSource).CheckError();
        return mediaSource;
    }

    public static IMFDXGIDeviceManager MFCreateDXGIDeviceManager()
    {
        MFCreateDXGIDeviceManager(out int resetToken, out IMFDXGIDeviceManager deviceManager).CheckError();
        deviceManager.ResetToken = resetToken;
        return deviceManager;
    }

    public static IMFPresentationClock MFCreatePresentationClock()
    {
        MFCreatePresentationClock(out IMFPresentationClock presentationClock).CheckError();
        return presentationClock;
    }

    public static IMFTopology MFCreateTopology()
    {
        MFCreateTopology(out IMFTopology topology).CheckError();
        return topology;
    }

    public static IMFTopologyNode MFCreateTopologyNode(TopologyType nodeType)
    {
        MFCreateTopologyNode(nodeType, out IMFTopologyNode node).CheckError();
        return node;
    }

    public static IMFPresentationTimeSource MFCreateSystemTimeSource()
    {
        MFCreateSystemTimeSource(out IMFPresentationTimeSource systemTimeSource).CheckError();
        return systemTimeSource;
    }

    public static IMFMediaTypeHandler MFCreateSimpleTypeHandler()
    {
        MFCreateSimpleTypeHandler(out IMFMediaTypeHandler handler).CheckError();
        return handler;
    }

    public static IMFMediaSink MFCreateAudioRenderer(IMFAttributes audioAttributes)
    {
        MFCreateAudioRenderer(audioAttributes, out IMFMediaSink sink).CheckError();
        return sink;
    }

    public static IMFActivate MFCreateAudioRendererActivate()
    {
        MFCreateAudioRendererActivate(out IMFActivate activate).CheckError();
        return activate;
    }

    public static IMFActivate MFCreateVideoRendererActivate(IntPtr hwndVideo)
    {
        MFCreateVideoRendererActivate(hwndVideo, out IMFActivate activate).CheckError();
        return activate;
    }

    public static unsafe IMFActivateCollection MFEnumDeviceSources(IMFAttributes attributes)
    {
        MFEnumDeviceSources(attributes, out IntPtr pSourceActivate, out int count).CheckError();
        return new(pSourceActivate, count);
    }

    public static unsafe IMFActivateCollection MFEnumAudioDeviceSources()
    {
        using IMFAttributes attributes = MFCreateAttributes(1);
        attributes.SourceType = CaptureDeviceAttributeKeys.SourceTypeAudcap;
        MFEnumDeviceSources(attributes, out IntPtr pSourceActivate, out int count).CheckError();
        return new(pSourceActivate, count);
    }

    public static unsafe IMFActivateCollection MFEnumAudioDeviceSources(AudioEndpointRole audioEndpointRole)
    {
        using IMFAttributes attributes = MFCreateAttributes(2);
        attributes.SourceType = CaptureDeviceAttributeKeys.SourceTypeAudcap;
        attributes.AudioEndpointRole = audioEndpointRole;
        MFEnumDeviceSources(attributes, out IntPtr pSourceActivate, out int count).CheckError();
        return new(pSourceActivate, count);
    }

    public static unsafe IMFActivateCollection MFEnumVideoDeviceSources()
    {
        using IMFAttributes attributes = MFCreateAttributes(1);
        attributes.SourceType = CaptureDeviceAttributeKeys.SourceTypeVidcap;
        MFEnumDeviceSources(attributes, out IntPtr pSourceActivate, out int count).CheckError();
        return new(pSourceActivate, count);
    }

    public static unsafe IMFActivateCollection MFEnumVideoDeviceSources(Guid videoDeviceCategory)
    {
        using IMFAttributes attributes = MFCreateAttributes(2);
        attributes.SourceType = CaptureDeviceAttributeKeys.SourceTypeVidcap;
        attributes.VideoDeviceCategory = videoDeviceCategory;
        MFEnumDeviceSources(attributes, out IntPtr pSourceActivate, out int count).CheckError();
        return new(pSourceActivate, count);
    }

    public static unsafe IStream MFCreateStreamOnMFByteStream(IMFByteStream byteStream)
    {
        MFCreateStreamOnMFByteStream(byteStream, out IStream stream).CheckError();
        return stream;
    }
}
