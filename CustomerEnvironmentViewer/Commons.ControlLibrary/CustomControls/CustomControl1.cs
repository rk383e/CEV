﻿using System.Windows;
using System.Windows.Controls;

namespace Commons.ControlLibrary.CustomControls
{
    public class CustomControl1 : Control
    {
        static CustomControl1()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl1), new FrameworkPropertyMetadata(typeof(CustomControl1)));
        }
    }
}
