using DataAccess;
using Entities;
using System;

namespace Service
{
    public class PictureService : IPictureService
    {
        public IPictureDataAccess PictureDataAccess { get; set; }

        public PictureService(IPictureDataAccess pictureDataAccess)
        {
            PictureDataAccess = pictureDataAccess;
        }

        public Guid Create(PictureDTO pictureDTO)
        {
            if (pictureDTO.Identifier.HasValue)
            {
                throw new ParameterException("Picture guid should not be declared");
            }

            var picture = new Picture()
            {
                Identifier = pictureDTO.Identifier,
                ImageBase64 = pictureDTO.PictureBase64
            };


            return PictureDataAccess.Create(picture);
        }
        public PictureDTO Read(Guid guid)
        {
            var picture = PictureDataAccess.Read(guid);

            if (picture == null)
            {
                throw new NotFoundException($"Picture not found");
            }

            var pictureDTO = new PictureDTO()
            {
                Identifier = picture.Identifier,
                PictureBase64 = picture.ImageBase64
            };

            return pictureDTO;
        }

        public void Update(PictureDTO pictureDTO)
        {
            if (!pictureDTO.Identifier.HasValue)
            {
                throw new ParameterException("User guid should not be declared");
            }

            var savedPicure = PictureDataAccess.Read(pictureDTO.Identifier.Value);

            if (savedPicure == null)
            {
                throw new NotFoundException($"Picture not found");
            }

            savedPicure.Identifier = savedPicure.Identifier;
            savedPicure.ImageBase64 = savedPicure.ImageBase64;

            PictureDataAccess.Update(savedPicure);
        }

        public bool Delete(Guid guid)
        {
            return PictureDataAccess.Delete(guid);
        }

    }
}
