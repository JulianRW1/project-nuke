using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceLogic : MonoBehaviour
{
    public int wood = 0;
    public int stone = 0;
    public int uranium235 = 0;

    public Text text;
    [ContextMenu("wood+1")]
    public void addWood()
    {
        wood++;
        updateText();
    }
    [ContextMenu("stone+1")]
    public void addStone()
    {
        stone++;
        updateText();
    }
    [ContextMenu("uranium235+1")]
    public void addUranium235()
    {
        uranium235++;
        updateText();
    }
    private void updateText()
    {
        text.text = "Wood: " + wood.ToString() + " Stone: " + stone.ToString() + " Uranium-235: " + uranium235.ToString();

    }

}
