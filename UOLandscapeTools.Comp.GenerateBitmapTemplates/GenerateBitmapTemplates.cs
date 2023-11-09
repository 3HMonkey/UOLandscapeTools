using Serilog;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace UOLandscapeTools.Components.GenerateBitmapTemplates
{
    public sealed class GenerateBitmapTemplates: IGenerateBitmapTemplates
    {
        private readonly ILogger _logger;

        public GenerateBitmapTemplates(ILogger logger)
        {
            _logger = logger;
        }

        public void MakeTerrainMap(int xSize, int ySize, string DefaultTerrain)
        {
            string filename = "Data/Output/Terrain.bmp";
            
            using (var image = new Image<SixLabors.ImageSharp.PixelFormats.Rgba32>(xSize, ySize))
            {
                image.Mutate(imageContext =>
                {
                    // draw background
                    var bgColor = SixLabors.ImageSharp.PixelFormats.Rgba32.ParseHex(DefaultTerrain);
                    imageContext.BackgroundColor(bgColor);
                });
                               
               
                _logger.Information($"Writing file: {filename}...");
                Directory.CreateDirectory("Data/Output");
                FileStream fs = File.Create(filename);
                image.SaveAsBmp(fs);
                fs.Dispose();
                fs.Close();
                _logger.Information($"Writing file: {filename}...Done");


            }
             
        }


    }
}
