using System;

namespace Service
{
    public class PictureDTO
    {
        public Guid? Identifier { get; set; }

        public string PictureBase64 { get; set; }
    }
}
