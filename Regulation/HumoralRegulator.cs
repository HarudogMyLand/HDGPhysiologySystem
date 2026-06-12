using System;
using System.Collections.Generic;
using System.Text;
using Physiology.Core;

namespace Physiology.Regulation
{
    public class HumoralRegulator
    {
        GlobalPhysiologyBoard MyBoard;
        public HumoralRegulator(GlobalPhysiologyBoard board) { 
            MyBoard = board;
        }

        public void Update(double deltaTime)
        {

        }

    }
}
