using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMGUI : MonoBehaviour {
    public float health;
    private float change_health;
    private Rect blood_rec;
    private Rect blood_inc;
    private Rect blood_dec;

    private int blood_rec_x;
    private int blood_rec_y;
    private int blood_rec_len;
    private int blood_rec_height;
    private float blood_unit;

    void Start() {
        health = 0;
        change_health = 0;
        blood_unit = 0.2f;
        blood_rec_x = 700;
        blood_rec_y = 270;
        blood_rec_len = 300;
        blood_rec_height = 30;

        blood_rec = new Rect(blood_rec_x, blood_rec_y, blood_rec_len, blood_rec_height);
        blood_inc = new Rect(blood_rec_x, blood_rec_y - 33, 80, 20);
        blood_dec = new Rect(blood_rec_x + 100, blood_rec_y - 33, 80, 20);
    }

    void OnGUI() {
        if (GUI.Button(blood_inc, "increase")) {
            change_health = change_health + blood_unit > 1.0f ? 1.0f : change_health + blood_unit;
        }
        if (GUI.Button(blood_dec, "decrease")) {
            change_health = change_health - blood_unit < 0.0f ? 0.0f : change_health - blood_unit;
        }
        health = Mathf.Lerp(health, change_health, 0.05f);
        GUI.HorizontalScrollbar(blood_rec, 0.0f, health, 0.0f, 1.0f);
    }

    private void Update() {
        
    }
}
