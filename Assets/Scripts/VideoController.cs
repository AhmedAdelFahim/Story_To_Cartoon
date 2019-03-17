using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class VideoController
{
    private PlayableGraph PlayableGraph;
    private List<Track> Videos = new List<Track>();
    public void CreateVideo()
    {
        PlayableGraph = PlayableGraph.Create();
    }

    public void AddTrack(Track track)
    {
        Playable owner = Playable.Create(PlayableGraph);
        owner.SetInputCount(1);
        AnimationMixerPlayable mixer = AnimationMixerPlayable.Create(PlayableGraph, track.Clips.Count);
        PlayableGraph.Connect(mixer, 0, owner, 0);
        owner.SetInputWeight(0, 1);
        
        for (int clipIndex = 0 ; clipIndex < mixer.GetInputCount() ; ++clipIndex)
        {
            PlayableGraph.Connect(AnimationClipPlayable.Create(PlayableGraph, track.Clips[clipIndex]), 0, mixer, clipIndex);

            mixer.SetInputWeight(clipIndex, 1.0f);

        }
        var playableOutput = AnimationPlayableOutput.Create(PlayableGraph, "Animation",track.animator);
        playableOutput.SetSourcePlayable(owner);
        playableOutput.SetSourceInputPort(0);
        track.mixer = mixer;
        Videos.Add(track);
    }

    public void UpdateClips()
    {
        for (int i = 0; i < Videos.Count; i++)
        {
            Videos[i].UpdateClips();
        }
    }

    public void MatchOffsetsWithPrevious()
    {
        for (int i = 0; i < Videos.Count; i++)
        {
            Videos[i].MatchOffsetWithPrevious();
        }
    }


    public void Play()
    {
        PlayableGraph.Play();
    }

    public void Destroy()
    {
        PlayableGraph.Destroy();
    }
}
