using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class Video
{
    private bool animation_started = false; // This var will determine if the animation is finished
    private bool animation_finished = true; // This var will determine if the animation is finished
    private int m_CurrentClipIndex = -1;
    private float m_TimeToNextClip;
    public Animator animator;
    private Vector3 currPos = Vector3.zero;
    public List<AnimationClip> Clips;


    public AnimationMixerPlayable mixer;

    public Video(Animator animator)
    {
        this.animator = animator;
        //Clips = new List<AnimationClip>();
    }


    /*
     * play next clip
     */
    public void UpdateClips()
    {
        if (mixer.GetInputCount() == 0)
            return;

        // Advance to next clip if necessary
        m_TimeToNextClip -= (float) Time.deltaTime;
        animation_started = true;
        animation_finished = false;

        if (m_TimeToNextClip <= 0.0f)

        {
            currPos = animator.transform.position;
            //belly.transform.position = x;
            animation_finished = true;
            m_CurrentClipIndex++;

            if (m_CurrentClipIndex >= mixer.GetInputCount())
                return;
            //m_CurrentClipIndex = 0;
            var currentClip = (AnimationClipPlayable) mixer.GetInput(m_CurrentClipIndex);
            // Reset the time so that the next clip starts at the correct position
            currentClip.SetTime(0);
            m_TimeToNextClip = currentClip.GetAnimationClip().length;
        }

        // Adjust the weight of the inputs

        for (int clipIndex = 0; clipIndex < mixer.GetInputCount(); ++clipIndex)
        {
            if (clipIndex == m_CurrentClipIndex)

                mixer.SetInputWeight(clipIndex, 1.0f);

            else

                mixer.SetInputWeight(clipIndex, 0.0f);
        }
    }

    public void MatchOffsetWithPrevious()
    {
        if(animation_finished && animation_started) {
            // set the flag
            animation_started = false;
            // update the parent position
            animator.transform.position = currPos;
            // update the box position to zero inside the parent
            currPos = Vector3.zero;
        }
    }
}