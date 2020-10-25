namespace PostOfficeManager.Models
{
    public readonly struct ParcelSize
    {
        public ParcelSize(int length, int width, int height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public int Length { get; }

        public int Width { get; }

        public int Height { get; }

    }
}
