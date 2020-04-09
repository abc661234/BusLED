using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.IO;

public class move : MonoBehaviour
{
    Text label1;
    int status = 0, busStop, read;
    string chinese, english, fullwidthChinese;
    int chineseLength, englishLength;
    bool locate = false;
    double duration, soundStartTime;
    string vendor;

    void Start()
    {
        StreamReader sr = new StreamReader(@".\Resource\info.txt");
        Screen.SetResolution(1366, 768, true);
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
        busStop = int.Parse(sr.ReadLine());
        vendor = sr.ReadLine();
        read = busStop;
    }

    void initialize()
    {
        StreamReader sr = new StreamReader(@".\Resource\info.txt");
        for (int i = 0; i < (read - busStop) * 3 + 2; i++)
        {
            sr.ReadLine();
        }
        chinese = sr.ReadLine();
        english = sr.ReadLine();
        StartCoroutine(play(sr.ReadLine()));
        sr.Close();
        soundStartTime = Time.time;
        status = 1;
    }

    void Update()
    {
        if (vendor.Substring(0, 2) == "銓鼎")
        {
            if (busStop > 0)
            {
                if (status == 0)
                {
                    initialize();
                    chineseLength = 0;
                    englishLength = 0;
                    for (int i = 0; i < chinese.Length; i++)
                    {
                        if ((int)System.Convert.ToChar(chinese.Substring(i, 1)) <= 122)
                        {
                            chineseLength += 1;
                        }
                        else
                        {
                            chineseLength += 2;
                        }
                    }
                    englishLength = english.Length;
                }
                if (status == 1) //下一站
                {
                    label1 = GetComponent<Text>();
                    if (vendor.Substring(3, 2) == "下一")
                    {
                        label1.text = "下一站";
                    }
                    else
                    {
                        label1.text = "即將抵達";
                    }
                    label1.alignment = TextAnchor.MiddleCenter;
                    GetComponent<RectTransform>().transform.localPosition = new Vector2(1, -300);
                    status = 2;
                }
                if (status == 2)
                {
                    up();
                }
                if (status == 3) //中文
                {
                    if (chineseLength <= 16)
                    {
                        label1.text = chinese;
                    }
                    else
                    {
                        label1.text = chinese.Substring(0, 8) + "  " + chinese.Substring(8, chinese.Length - 8);
                    }
                    label1.alignment = TextAnchor.MiddleLeft;
                    if (chineseLength <= 16)
                    {
                        status = 4;
                        duration -= 1.3;
                    }
                    else
                    {
                        status = 41;
                    }
                }
                if (status == 4)
                {
                    up();
                }
                if (status == 41)
                {
                    leftMaxWin(chineseLength);
                }
                if (status == 5) //英文
                {
                    label1.text = english;
                    if (englishLength <= 16)
                    {
                        status = 6;
                        duration -= 1.3;
                    }
                    else
                    {
                        status = 61;
                    }
                }
                if (status == 6)
                {
                    up();
                }
                if (status == 61)
                {
                    leftMaxWin(englishLength);
                }
                if (status == 7) //中文
                {
                    if (chineseLength <= 16)
                    {
                        label1.text = chinese;
                        status = 8;
                        duration -= 1.3;
                    }
                    else
                    {
                        label1.text = chinese.Substring(0, 8) + "  " + chinese.Substring(8, chinese.Length - 8);
                        status = 81;
                    }
                }
                if (status == 8)
                {
                    up();
                }
                if (status == 81)
                {
                    leftMaxWin(chineseLength);
                }
                if (status == 9)
                {
                    if (Time.time > soundStartTime + duration)
                    {
                        status = 0;
                        busStop--;
                    }
                }
            }
            else
            {
                Thread.Sleep(3000);
                Application.Quit();
            }
        }
        else if (vendor.Substring(0, 2) == "北圜")
        {
            if (busStop > 0)
            {
                if (status == 0)
                {
                    initialize();
                    fullwidthChinese = "";
                }
                if (status == 1)
                {
                    label1 = GetComponent<Text>();
                    label1.alignment = TextAnchor.MiddleLeft;
                    getFullwidthChinese();
                    if (vendor.Substring(3, 2) == "下一")
                    {
                        if (fullwidthChinese.Length <= 8)
                        {
                            label1.text = "  　　下一站　　　" + fullwidthChinese + "　" + english + "　　　　　" + fullwidthChinese;
                        }
                        else
                        {
                            label1.text = "  　　下一站　　　" + fullwidthChinese.Substring(0, 8) + "  " + fullwidthChinese.Substring(8, fullwidthChinese.Length - 8) + "　" + english + "　　　　　" + fullwidthChinese.Substring(0, 8);
                        }
                    }
                    else
                    {
                        if (fullwidthChinese.Length <= 8)
                        {
                            label1.text = " 　　即將抵達 　　" + fullwidthChinese + "　" + english + "　　　　　" + fullwidthChinese;
                        }
                        else
                        {
                            label1.text = " 　　即將抵達 　　" + fullwidthChinese.Substring(0, 8) + "  " + fullwidthChinese.Substring(8, fullwidthChinese.Length - 8) + "　" + english + "　　　　　" + fullwidthChinese.Substring(0, 8);
                        }
                    }
                    GetComponent<RectTransform>().transform.localPosition = new Vector2(1, -300);
                    status = 2;
                }
                if (status == 2)
                {
                    up();
                }
                if (status == 3)
                {
                    leftLuckyYu();
                }
                if (status == 4)
                {
                    leftLuckyYu2();
                }
                if (status == 5)
                {
                    status = 0;
                    busStop--;
                }
            }
            else
            {
                Thread.Sleep(2000);
                Application.Quit();
            }
        }
        else if (vendor.Substring(0, 2) == "寶錄")
        {
            if (busStop > 0)
            {
                if (status == 0)
                {
                    initialize();
                    fullwidthChinese = "";
                }
                if (status == 1)
                {
                    label1 = GetComponent<Text>();
                    label1.alignment = TextAnchor.MiddleLeft;
                    getFullwidthChinese();
                    if (vendor.Substring(3, 2) == "下一")
                    {
                        label1.text = "下一站  " + chinese + "  " + english;
                        status = 2;
                    }
                    else
                    {
                        label1.text = chinese + "  到了  " + english;
                        status = 21;
                    }
                    GetComponent<RectTransform>().transform.localPosition = new Vector2(1250, 1);
                }
                if (status == 2)
                {
                    leftBaoruh();
                }
                if (status == 21)
                {
                    leftBaoruh();
                }
                if (status == 22)
                {
                    if (chinese.Length <= 8)
                    {
                        label1.text = fullwidthChinese;
                    }
                    else
                    {
                        label1.text = fullwidthChinese.Substring(0, 8);
                    }
                    GetComponent<RectTransform>().transform.localPosition = new Vector2(1250, 1);
                    status = 23;
                    duration -= 2.5;
                }
                if (status == 23)
                {
                    leftLuckyYu();
                }
                if (status == 3)
                {
                    if (Time.time > soundStartTime + duration)
                    {
                        status = 0;
                        busStop--;
                    }
                }
            }
            else
            {
                Thread.Sleep(2000);
                Application.Quit();
            }
        } 
        else if (vendor.Substring(0, 2) == "立皓")
        {
            if (busStop > 0)
            {
                if (status == 0)
                {
                    initialize();
                    fullwidthChinese = "";
                }
                if (status == 1)
                {
                    label1 = GetComponent<Text>();
                    label1.alignment = TextAnchor.MiddleLeft;
                    getFullwidthChinese();
                    if (vendor.Substring(3, 2) == "下一")
                    {
                        label1.text = "下一站:" + chinese + "  " + english;
                        status = 2;
                    }
                    else
                    {
                        label1.text = "即將抵達:" + chinese + "  " + english;
                        status = 21;
                    }
                    GetComponent<RectTransform>().transform.localPosition = new Vector2(1250, 1);
                }
                if (status == 2)
                {
                    leftBaoruh();
                }
                if (status == 21)
                {
                    leftBaoruh();
                }
                if (status == 22)
                {
                    if (chinese.Length <= 8)
                    {
                        label1.text = fullwidthChinese;
                    }
                    else
                    {
                        label1.text = fullwidthChinese.Substring(0, 8);
                    }
                    GetComponent<RectTransform>().transform.localPosition = new Vector2(1250, 1);
                    status = 23;
                    duration -= 2.5;
                }
                if (status == 23)
                {
                    leftLuckyYu();
                }
                if (status == 3)
                {
                    if (Time.time > soundStartTime + duration)
                    {
                        status = 0;
                        busStop--;
                    }
                }
            }
            else
            {
                Thread.Sleep(2000);
                Application.Quit();
            }
        }
    }

    void up()
    {
        if (locate == false)
        {
            GetComponent<RectTransform>().transform.localPosition = new Vector2(20, -150);
            locate = true;
        }
        RectTransform rt = GetComponent<RectTransform>();
        if (rt.transform.localPosition.y < -1)
        {
            rt.transform.localPosition += new Vector3(0, 10, 0);
        }
        else
        {
            if (status > 10)
            {
                status /= 10;
            }
            status ++;
            locate = false;
            if (status == 3)
            {
                Thread.Sleep(1000);
            }
            else if (status == 8)
            {
                Thread.Sleep(2500);
            }
            else
            {
                Thread.Sleep(1300);
            }
        }
    }

    void leftMaxWin(int textLength)
    {
        if (locate == false)
        {
            GetComponent<RectTransform>().transform.localPosition = new Vector2(1250, 1);
            locate = true;
        }
        RectTransform rt = GetComponent<RectTransform>();
        if (rt.transform.localPosition.x > -textLength* 60)
        {
            rt.transform.localPosition += new Vector3(-15, 0, 0);
        }
        else
        {
            if (status > 10)
            {
                status /= 10;
            }
            status++;
            locate = false;
        }
    }

    void leftLuckyYu()
    {
        RectTransform rt = GetComponent<RectTransform>();
        if (chinese.Length <= 8)
        {
            chineseLength = chinese.Length;
        }
        else
        {
            chineseLength = 8;
        }
        if (rt.transform.localPosition.x+label1.preferredWidth > 154 * chineseLength)
        {
            rt.transform.localPosition += new Vector3(-15, 0, 0);
        }
        else
        {
            Thread.Sleep(2500);
            if (status > 10)
            {
                status /= 10;
            }
            status++;
        }
    }

    void leftLuckyYu2()
    {
        RectTransform rt = GetComponent<RectTransform>();
        if (rt.transform.localPosition.x + label1.preferredWidth > 0)
        {
            rt.transform.localPosition += new Vector3(-15, 0, 0);
        }
        else if(Time.time + 3 > soundStartTime + duration)
        {
            status++;
        }
    }

    void leftBaoruh()
    {
        RectTransform rt = GetComponent<RectTransform>();
        if (rt.transform.localPosition.x + label1.preferredWidth > 0)
        {
            rt.transform.localPosition += new Vector3(-15, 0, 0);
        }
        else
        {
            Thread.Sleep(1000);
            status++;
        }
    }

    void getFullwidthChinese()
    {
        for (int i = 0; i < chinese.Length; i++)
        {
            if (chinese.Substring(i, 1) == "(")
            {
                fullwidthChinese += "（";
            }
            else if (chinese.Substring(i, 1) == ")")
            {
                fullwidthChinese += "）";
            }
            else if (chinese.Substring(i, 1) == "/")
            {
                fullwidthChinese += "／";
            }
            else if (chinese.Substring(i, 1) == "0")
            {
                fullwidthChinese += "０";
            }
            else if (chinese.Substring(i, 1) == "1")
            {
                fullwidthChinese += "１";
            }
            else if (chinese.Substring(i, 1) == "2")
            {
                fullwidthChinese += "２";
            }
            else if (chinese.Substring(i, 1) == "3")
            {
                fullwidthChinese += "３";
            }
            else if (chinese.Substring(i, 1) == "4")
            {
                fullwidthChinese += "４";
            }
            else if (chinese.Substring(i, 1) == "5")
            {
                fullwidthChinese += "５";
            }
            else if (chinese.Substring(i, 1) == "6")
            {
                fullwidthChinese += "６";
            }
            else if (chinese.Substring(i, 1) == "7")
            {
                fullwidthChinese += "７";
            }
            else if (chinese.Substring(i, 1) == "8")
            {
                fullwidthChinese += "８";
            }
            else if (chinese.Substring(i, 1) == "9")
            {
                fullwidthChinese += "９";
            }
            else
            {
                fullwidthChinese += chinese.Substring(i, 1);
            }
        }
    }

    IEnumerator play(string path)
    {
        WWW www = new WWW(@path);
        yield return www;
        GetComponent<AudioSource>().clip = www.GetAudioClip();
        GetComponent<AudioSource>().Play();
        duration = GetComponent<AudioSource>().clip.length;
    }
}
