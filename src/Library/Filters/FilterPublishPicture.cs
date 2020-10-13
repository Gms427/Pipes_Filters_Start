using System;
using System.Collections.Generic;
using System.Text;
using CompAndDel;
using System.Drawing;
using System.Diagnostics;

namespace CompAndDel.Filters
{
    public class FilterPublishPicture: IFilter
    {
        private int imageCounter = 0;
        public IPicture Filter(IPicture image)
        {
            TwitterPublisher twitter= new TwitterPublisher();
            twitter.PublishPicture(image.Path);
            return image;
        }
    }
}