﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTCP1.Model
{
    public class JudgementView 
    {
        public int Pos { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }
        public string CameraCheckpoint { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string AreaInspection { get; set; } = string.Empty;

        public string Judgement { get; set; } = string.Empty;
    }
}
