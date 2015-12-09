using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Traffic_Light.Modules;

namespace Traffic_Light
{
    public class CarTrLight : TrafficLight
    {
        public CarTrLight(int lampTopX, int lampTopY, int lampMiddleX, int lampMiddleY, int lampBottomX, int lampBottomY)
        {
           posittionTrLight = new Dictionary<PositionTrLightEnum, int>();
            posittionTrLight.Add(PositionTrLightEnum.TopX, lampTopX);
            posittionTrLight.Add(PositionTrLightEnum.TopY, lampTopY);
            posittionTrLight.Add(PositionTrLightEnum.MiddleX, lampMiddleX);
            posittionTrLight.Add(PositionTrLightEnum.MiddleY, lampMiddleY);
            posittionTrLight.Add(PositionTrLightEnum.BottomX, lampBottomX);
            posittionTrLight.Add(PositionTrLightEnum.BottomY, lampBottomY);
        }

    }
}