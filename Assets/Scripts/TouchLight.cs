/*
 * 鼠标移动到可建造炮台的位置发光
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;

public class TouchLight : MonoBehaviour
{
    private Highlighter highligter = null;
    private void Awake()
    {
        highligter = gameObject.AddComponent<Highlighter>();
        if (highligter == null)
        {
            highligter = gameObject.AddComponent<Highlighter>();
        }
    }
    private void OnMouseEnter()
    {
        highligter.ConstantOn(new Color32(98, 35, 255, 255));
    }
    private void OnMouseExit()
    {
        highligter.Off();
    }
}
