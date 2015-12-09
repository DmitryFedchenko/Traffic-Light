using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Traffic_Light.Modules;

namespace Traffic_Light
{
    public class PedTrLight : Modules.TrafficLight
    {
        public PedTrLight( int lampTopX, int lampTopY, int lampBottomX, int lampBottomY)
        {
            posittionTrLight = new Dictionary<PositionTrLightEnum, int>();
            posittionTrLight.Add(PositionTrLightEnum.TopX, lampTopX);
            posittionTrLight.Add(PositionTrLightEnum.TopY, lampTopY);
            posittionTrLight.Add(PositionTrLightEnum.BottomX, lampBottomX);
            posittionTrLight.Add(PositionTrLightEnum.BottomY, lampBottomY);
        }
    }
}