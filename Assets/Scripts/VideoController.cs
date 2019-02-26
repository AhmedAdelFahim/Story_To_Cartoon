using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class NewBehaviourScript
{
    private PlayableGraph PlayableGraph;
    private List<Video> Videos;
    public void CreateVideo()
    {
        PlayableGraph = PlayableGraph.Create();
    }

    public void AddTrack(Video video)
    {
        Playable owner = Playable.Create(PlayableGraph);
        owner.SetInputCount(1);
        AnimationMixerPlayable mixer = AnimationMixerPlayable.Create(PlayableGraph, video.Clips.Count);
        PlayableGraph.Connect(mixer, 0, owner, 0);
        owner.SetInputWeight(0, 1);
        
        for (int clipIndex = 0 ; clipIndex < mixer.GetInputCount() ; ++clipIndex)
        {
            PlayableGraph.Connect(AnimationClipPlayable.Create(PlayableGraph, video.Clips[clipIndex]), 0, mixer, clipIndex);

            mixer.SetInputWeight(clipIndex, 1.0f);

        }
        var playableOutput = AnimationPlayableOutput.Create(PlayableGraph, "Animation",video.animator);
        playableOutput.SetSourcePlayable(owner);
        playableOutput.SetSourceInputPort(0);
        video.mixer = mixer;
        Videos.Add(video);
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
