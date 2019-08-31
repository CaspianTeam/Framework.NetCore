using CaspianTeam.Framework.NetCore.Enums.Services;
using ImageMagick;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaspianTeam.Framework.NetCore.Services
{
    public interface IImageService
    {
        ImageType GetImageType(byte[] imageData);
        string GetImageContentType(ImageType imageType);
        bool CheckIfImageFile(IFormFile file);
        Task<byte[]> GetBytesArrayFromUploadedImage(IFormFile uploadedImageFile, bool compress = true);
        MemoryStream CompressImage(MemoryStream stream);
        byte[] ResizeImage(byte[] imageData, int width, int height, bool ignoreAspectRatio);
    }
    public class ImageService : IImageService
    {
        /// <summary>
        /// Method to get format of image
        /// </summary>
        /// <param name="imageData"></param>
        /// <returns></returns>
        public ImageType GetImageType(byte[] imageData)
        {
            var bmp = Encoding.ASCII.GetBytes("BM");     // BMP
            var gif = Encoding.ASCII.GetBytes("GIF");    // GIF
            var png = new byte[] { 137, 80, 78, 71 };              // PNG
            var tiff = new byte[] { 73, 73, 42 };                  // TIFF
            var tiff2 = new byte[] { 77, 77, 42 };                 // TIFF
            var jpeg = new byte[] { 255, 216, 255, 224 };          // jpeg
            var jpeg2 = new byte[] { 255, 216, 255, 225 };         // jpeg canon

            if (bmp.SequenceEqual(imageData.Take(bmp.Length)))
                return ImageType.bmp;

            if (gif.SequenceEqual(imageData.Take(gif.Length)))
                return ImageType.gif;

            if (png.SequenceEqual(imageData.Take(png.Length)))
                return ImageType.png;

            if (tiff.SequenceEqual(imageData.Take(tiff.Length)))
                return ImageType.tiff;

            if (tiff2.SequenceEqual(imageData.Take(tiff2.Length)))
                return ImageType.tiff;

            if (jpeg.SequenceEqual(imageData.Take(jpeg.Length)))
                return ImageType.jpeg;

            if (jpeg2.SequenceEqual(imageData.Take(jpeg2.Length)))
                return ImageType.jpeg;

            return ImageType.unknown;
        }

        /// <summary>
        /// Method to check if file is image file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public bool CheckIfImageFile(IFormFile file)
        {
            if (file == null) return false;
            if (file.Length == 0) return false;
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            return GetImageType(fileBytes) != ImageType.unknown;
        }

        /// <summary>
        /// Method to get content type of an image file ("image/png" for example)
        /// </summary>
        /// <param name="imageType"></param>
        /// <returns></returns>
        public string GetImageContentType(ImageType imageType)
        {
            var contentTypes = new Dictionary<ImageType, string>
            {
                {ImageType.png, "image/png"},
                {ImageType.jpg, "image/jpeg"},
                {ImageType.jpeg, "image/jpeg"},
                {ImageType.gif, "image/gif"}
            };

            return contentTypes[imageType];
        }

        /// <summary>
        /// Compress an image
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public MemoryStream CompressImage(MemoryStream stream)
        {
            var optimizer = new ImageOptimizer();
            optimizer.Compress(stream);
            return stream;
        }

        /// <summary>
        /// Method to convert uploaded image to bytes array 
        /// </summary>
        /// <param name="uploadedImageFile"></param>
        /// <param name="compress">Compress image by MagickImage Nuget</param>
        /// <returns></returns>
        public async Task<byte[]> GetBytesArrayFromUploadedImage(IFormFile uploadedImageFile, bool compress = true)
        {
            using (var stream = new MemoryStream())
            {
                await uploadedImageFile.CopyToAsync(stream);
                stream.Seek(0, SeekOrigin.Begin);
                if (compress)
                {
                    //var optimizer = new ImageOptimizer();
                    //optimizer.Compress(stream);
                    CompressImage(stream);
                }

                return stream.ToArray();
            }
        }

        /// <summary>
        /// Method to resize an image
        /// </summary>
        /// <param name="imageData"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="ignoreAspectRatio">Normally an image will be resized to fit inside the specified size.</param>
        /// <returns></returns>
        public byte[] ResizeImage(byte[] imageData, int width, int height, bool ignoreAspectRatio)
        {
            using (var magickImage = new MagickImage(imageData))
            {
                var size = new MagickGeometry(width, height) { IgnoreAspectRatio = ignoreAspectRatio };
                magickImage.Resize(size);
                return magickImage.ToByteArray();
            }
        }

    }
}
