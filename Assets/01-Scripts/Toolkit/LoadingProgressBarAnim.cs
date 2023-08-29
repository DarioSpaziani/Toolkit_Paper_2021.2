using System;
using DG.Tweening;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UIElements;

namespace _01_Scripts.Toolkit
{
    public class LoadingProgressBarAnim : MonoBehaviour
    {
        private VisualElement _mRoot;
        private VisualElement _mLoadingProgressBar;
        private Label _mLoadingPercentageText;
        private AnimatorController _animator;
        public float duration;

        void Start()
        {
            _mRoot = GetComponent<UIDocument>().rootVisualElement;

            _mLoadingProgressBar = _mRoot.Q<VisualElement>("bar_Progress");
            _mLoadingPercentageText = _mRoot.Q<Label>("txt_Percentage");

            Invoke(nameof(AnimateLoadingBar), 2f);
        }

        private void AnimateLoadingBar()
        {
            //Grab the final width of the progress bar based on the parent and
            //remove 25px to account for margins
            float endWidth = _mLoadingProgressBar.parent.worldBound.width - 25;
            DOTween.To(() => 5, x => _mLoadingPercentageText.text = $"{x}%",
                100, duration).SetEase(Ease.Linear);

            DOTween.To(() => _mLoadingProgressBar.worldBound.width, x =>
                _mLoadingProgressBar.style.width = x, endWidth, duration).SetEase(Ease.Linear);
        }
    }
}