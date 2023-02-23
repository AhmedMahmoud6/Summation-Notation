using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

public class SystemEvent : MonoBehaviour
{
    public TextMeshProUGUI message;
    public TextMeshProUGUI finnalOutput;
    public TextMeshProUGUI xvalue;
    public TextMeshProUGUI yvalue;
    public TMP_InputField inputField;


    int intializeDone = 0;
    int indexCount = 0;
    int n = 0;
    int arrX = 0;
    int arrY = 0;
    double[,] arr;

    //Summition of x and y
    double xSum = 0;
    double ySum = 0;

    //Results
    double Multiplication_Result = 0;
    double xPower2 = 0;

    //Laws
    double bLaw;
    double aLaw;
    double yLaw;

    double xVar;

    bool done = false;
    bool valueReady = false;
    bool appFinish = false;

    void Update()
    {
        if (n == 0)
        {
            message.text = "Enter the value of n";
        }
        if (intializeDone == 1)
        {
            message.text = "Enter x and y values";
        }
        if (valueReady)
        {
            message.text = "Enter predict x value";
        }
        if (appFinish)
        {
            finnalOutput.text = $"bLaw : {bLaw}\naLaw : {aLaw}\ny : {yLaw}\nxSum : {xSum}\nySum : {ySum}\nSum x power 2 : {xPower2}\nSum xy value : {Multiplication_Result}";
        }
        onEnter();
    }
    void onEnter()
    {
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            if (n == 0)
            {
                n = int.Parse(inputField.text);
                arr = new double[n, 2];
                intializeDone = 1;
                inputField.text = "";
            }
            if (intializeDone == 1)
            {
                arr.SetValue(Convert.ToDouble(inputField.text), arrY, arrX);
                arrY++;
                indexCount++;

                if (indexCount == (n * 2))
                {
                    intializeDone = 0;
                    valueReady = true;

                }
                if (arrY == n)
                {
                    arrY = 0;
                    arrX = 1;
                }
                if (indexCount <= n)
                {
                    xvalue.text += $"{inputField.text} ";
                }
                if (indexCount > n)
                {
                    yvalue.text += $"{inputField.text} ";

                }
                inputField.text = "";
            }
            if (valueReady)
            {
                xVar = double.Parse(inputField.text);

                if (xVar > 0)
                {
                    done = true;
                }
                if (done)
                {
                    math();
                    done = false;
                }

                appFinish = true;
            }
            inputField.text = "";
        }
    }
    void math()
    {
        for (int i = 0; i < n; i++)
        {
            xSum += arr[i, 0];
            ySum += arr[i, 1];
            xPower2 += (arr[i, 0] * arr[i, 0]);
            Multiplication_Result += (arr[i, 0] * arr[i, 1]);
        }
        bLaw = ((n * Multiplication_Result) - (xSum * ySum)) / ((n * xPower2) - (xSum * xSum));
        aLaw = (ySum - (bLaw * xSum)) / (n);
        yLaw = aLaw + (bLaw * xVar);
    }

}
