using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {

            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture("../../assets/yacht.jpg");

            IPipe pipeNull = new PipeNull();
            IFilter filterSavePicture = new FilterSavePicture();

            IPipe secondPipeSerialSave = new PipeSerial(filterSavePicture, pipeNull);

            IFilter filterNegative = new FilterNegative();
            IPipe secondPipeSerial = new PipeSerial(filterNegative, secondPipeSerialSave);

            
            IPipe firstPipeSerialSave = new PipeSerial(filterSavePicture, secondPipeSerial);

            IFilter filterGreyScale = new FilterGreyscale();
            IPipe pipeSerial = new PipeSerial(filterGreyScale, firstPipeSerialSave);

            IPicture newPicture = pipeSerial.Send(picture);
            provider.SavePicture(newPicture, "picture.jpg");

            IFilter filterPublish = new FilterPublishPicture();
            filterPublish.Filter(picture);
            
        }
    }
}