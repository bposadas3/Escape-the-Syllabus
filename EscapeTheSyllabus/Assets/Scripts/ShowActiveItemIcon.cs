using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowActiveItemIcon : MonoBehaviour
{
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = UserData.instance.getActiveItem().icon;
    }
}
