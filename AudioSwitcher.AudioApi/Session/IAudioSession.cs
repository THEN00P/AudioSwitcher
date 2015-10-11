﻿using System;

namespace AudioSwitcher.AudioApi.Session
{
    public interface IAudioSession : IDisposable
    {
        string Id { get; }

        int ProcessId { get; }

        string DisplayName { get; }

        string ExecutablePath { get; }

        bool IsSystemSession { get; }

        double Volume { get; set; }

        bool IsMuted { get; set; }

        AudioSessionState SessionState { get; }

        IObservable<SessionVolumeChangedArgs> VolumeChanged { get; }

        IObservable<SessionMuteChangedArgs> MuteChanged { get; }

        IObservable<SessionStateChangedArgs> StateChanged { get; }

        IObservable<SessionDisconnectedArgs> Disconnected { get; }

    }
}