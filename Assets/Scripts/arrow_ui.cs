using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arrow_ui : MonoBehaviour
{
    public traffic_light traffic_light;
    public Color Green;
    public Color Yellow;
    public Color Red;
    public Image stem;
    public Image head1;
    public Image head2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (traffic_light.state == "Green")
        {
            stem.color = Green;
            head1.color = Green;
            head2.color = Green;
        }
        if (traffic_light.state == "Yellow")
        {
            stem.color = Yellow;
            head1.color = Yellow;
            head2.color = Yellow;
        }
        if(traffic_light.state == "Red")
        {
            stem.color = Red;
            head1.color = Red;
            head2.color = Red;
        }
    }
}
