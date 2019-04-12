﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;
using System.IO;

namespace EXIFGeotaggerv0._1
{
    class MarkerTag
    {
        private string icon;
        private int size; //size in pixels of icon
        //private Bitmap bitmap;

        Assembly assembly = Assembly.GetExecutingAssembly();

        public MarkerTag()
        {

        }

        public MarkerTag(String color, int size)
        {
            this.Color = color;
            this.size = size;
            this.icon = ColorTable.ColorTableDict[this.Color] + "_" + size.ToString() + "px.png";
        }

        public String Color { get; set; }



        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                if (icon != null)
                {
                    icon = null;
                }
                this.size = value;
                this.icon = ColorTable.ColorTableDict[this.Color] + "_" + size.ToString() + "px.png";
            }
        }

        //public string Bitmap { get; set; } 

        public Bitmap Bitmap
        {
            get
            {
                Stream stream = assembly.GetManifestResourceStream(icon);
                return (Bitmap)Image.FromStream(stream);
            }         
        }
    }
}
