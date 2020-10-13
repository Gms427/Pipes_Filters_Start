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

            IFilter filterPublish = new FilterPublishPicture();
            IPipe thirdPipeSerial = new PipeSerial(filterPublish, pipeNull);

            IPipe secondPipeSerialSave = new PipeSerial(filterSavePicture, thirdPipeSerial);

            IFilter filterNegative = new FilterNegative();
            IPipe secondPipeSerial = new PipeSerial(filterNegative, secondPipeSerialSave);
            
            IPipe firstPipeSerialSave = new PipeSerial(filterSavePicture, secondPipeSerial);

            IFilter filterGreyScale = new FilterGreyscale();

            IPipe pipeConditional = new PipeConditionalBifurcation(thirdPipeSerial, secondPipeSerial);
            IPipe pipeSerial = new PipeSerial(filterGreyScale, firstPipeSerialSave);

            IPicture newPicture = pipeSerial.Send(picture);
        }
    }
}