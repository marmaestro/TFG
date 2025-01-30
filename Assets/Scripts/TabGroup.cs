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
            rightTabs[i].gameObject.SetActive(false);
            
            leftTabs[i].gameObject.SetActive(true);
            leftTabs[i].Background.sprite = tabIdleL;
        }

        if (selectedTabIndex <= 0) return;
        leftTabs[selectedTabIndex].gameObject.SetActive(false);

        for (int i = selectedTabIndex + 1; i < _totalTabs; selectedTabIndex++)
        {
            rightTabs[i].gameObject.SetActive(true);
            rightTabs[i].Background.sprite = tabIdleR;
            
            leftTabs[i].gameObject.SetActive(false); 
        }
    }
}
