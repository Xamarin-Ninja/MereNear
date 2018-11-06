using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace MereNear.CustomControl
{
    public class ExtendedMap : Map
    {
        public ExtendedMap()
        {
            
            
        }
        public Func<Position> NativeGetMapCenterLocation { get; set; }

        public Position GetMapCenterLocation()
        {
            if (NativeGetMapCenterLocation != null)
            {
                return NativeGetMapCenterLocation();
            }
            else
            {
                return new Position(0, 0);
            }
        }
    }
}
