using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario
{
    public class Camera
    {
       
        public int cameraPositionX;
        public int cameraPositionY;
        public bool disableCamera = false;
        int rightBound = 6350;
        int halfScreenWidth = 400;
        public Camera()
        {
            this.cameraPositionX = 0;
            this.cameraPositionY = 0;
        }

        public void UpdateX(int MarioPositionX )
        {
            if (!disableCamera)
            {
                if (MarioPositionX < rightBound)
                {
                    if (MarioPositionX > cameraPositionX + halfScreenWidth)
                    {
                        this.cameraPositionX += MarioPositionX - (cameraPositionX + halfScreenWidth);
                    }
                    if (MarioPositionX < cameraPositionX + halfScreenWidth && cameraPositionX > (cameraPositionX + halfScreenWidth) - MarioPositionX)
                    {
                        this.cameraPositionX -= (cameraPositionX + halfScreenWidth) - MarioPositionX;
                    }
                }
            }
        }
        
        public void SetPositionZero()
        {
            this.cameraPositionX = 0;
        }
    }
}
