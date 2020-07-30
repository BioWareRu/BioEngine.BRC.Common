using BioEngine.BRC.Common.Components;

namespace BioEngine.BRC.Common.Entities.Blocks
{
    [Entity("iframeblock")]
    public class IframeBlock : ContentBlock<IframeBlockData>
    {
        public override string? TypeTitle { get; set; } = "Iframe";
        
        public override string ToString()
        {
            return $"Frame: {Data.Src}";
        }
    }

    public class IframeBlockData : ContentBlockData
    {
        public string Src { get; set; } = "";
        public int Width { get; set; } = 0;
        public int Height { get; set; } = 0;
    }
}
