using System;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public TabButtonC[] leftTabs;
    public TabButtonC[] rightTabs;
    public int selectedTabIndex;
    private int _totalTabs;
    
    public Sprite tabIdleL;
    public Sprite tabIdleR;
    public Sprite tabHoverL;
    public Sprite tabHoverR;
    public Sprite tabActive;
    
    public List<GameObject> pages;

    public void Awake()
    {
        _totalTabs = leftTabs.Length;
        selectedTabIndex = 0;
    }
    
    public void OnTabEnter(TabButtonC button)
    {
        ResetTabs();

        button.Background.sprite = button.rightTab switch
        {
            true when Array.IndexOf(rightTabs, button) != selectedTabIndex => tabHoverR,
            false => tabHoverL,
            _ => button.Background.sprite
        };
    }
    
    public void OnTabExit()
    {
        ResetTabs();
    }   
    
    public void OnTabSelected(TabButtonC button)
    {
        selectedTabIndex = Array.IndexOf(button.rightTab ? rightTabs : leftTabs, button);
        rightTabs[selectedTabIndex].Background.sprite = tabActive;
        
        ResetTabs();
        
        for (int i = 0; i < pages.Count; i++)
            if (i == selectedTabIndex)
                pages[i].SetActive(true);
    }

    private void ResetTabs()
    {
        for (int i = 0; i < selectedTabIndex; i++)
        {
            rightTabs[i].Show(false);
            
            leftTabs[i].Show(true);
            leftTabs[i].Background.sprite = tabIdleL;
        }

        if (selectedTabIndex < 0) return;

        for (int i = selectedTabIndex; i < _totalTabs; i++)
        {
            rightTabs[i].Show(true);
            rightTabs[i].Background.sprite = tabIdleR;
            
            leftTabs[i].Show(false);
        }
    }
}
