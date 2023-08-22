using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

public class LoadingProgressBarAnim : MonoBehaviour
{
    private VisualElement m_Root;
    private VisualElement m_LoadingProgressBar;
    private Label m_LoadingPercentageText;
    
    void Start()
    {
        m_Root = GetComponent<UIDocument>().rootVisualElement;

        m_LoadingProgressBar = m_Root.Q<VisualElement>("bar_Progress");
        m_LoadingPercentageText = m_Root.Q<Label>("txt_Percentage");
        
        AnimateLoadingBar();
    }

    private void AnimateLoadingBar()
    {
        //Grab the final width of the progress bar based on the parent and
        //remove 25px to account for margins
        float endWidth = m_LoadingProgressBar.parent.worldBound.width - 25;
        DOTween.To(() => 5, x=> m_LoadingPercentageText.text = $"{x}%", 
            100, 5f).SetEase(Ease.Linear);
    
        DOTween.To(() => m_LoadingProgressBar.worldBound.width, x =>
            m_LoadingProgressBar.style.width = x, endWidth, 5f).SetEase(Ease.Linear);
    }
}