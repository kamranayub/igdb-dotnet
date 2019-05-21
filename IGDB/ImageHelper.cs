using System;
using System.Collections.Generic;

namespace IGDB
{
    public static class ImageHelper
    {
        /// <summary>
        /// IGDB image raw template URL
        /// </summary>
        public const string IGDB_IMAGE_TEMPLATE = "//images.igdb.com/igdb/image/upload/t_{size}/{hash}.jpg";

        /// <summary>
        /// A dictionary of ImageSize to constant string
        /// </summary>
        /// <typeparam name="ImageSize"></typeparam>
        /// <typeparam name="string"></typeparam>
        /// <returns></returns>
        public static IDictionary<ImageSize, string> ImageSizeMap = new Dictionary<ImageSize, string>() {
          {ImageSize.CoverSmall, "cover_small"}
        };

        /// <summary>
        /// Generates a IGDB image URL for the provided image hash and size. 
        /// See: https://api-docs.igdb.com/#images
        /// </summary>
        /// <param name="imageId">The image hash ID from IGDB</param>
        /// <param name="size">The requested size</param>
        /// <param name="retina">Whether or not to request a retina (2X) size</param>
        /// <returns>Image URL with requested parameters filled in</returns>
        public static string GetSizedImage(string imageId, ImageSize size = ImageSize.Thumb, bool retina = false)
        {
            if (ImageSizeMap.ContainsKey(size))
            {
                return IGDB_IMAGE_TEMPLATE
                  .Replace("{hash}", imageId)
                  .Replace("{size}", ImageSizeMap[size] + (retina ? "_2x" : ""));
            }
            else
            {
                throw new ArgumentException("ImageSize unknown", nameof(size));
            }
        }
    }

    /// <summary>
    /// Supported image sizes. See: https://api-docs.igdb.com/#images
    /// </summary>
    public enum ImageSize
    {
        CoverSmall = 0,
        ScreenshotMed = 1,
        CoverBig = 2,
        LogoMed = 3,
        ScreenshotBig = 4,
        ScreenshotHuge = 5,
        Thumb = 6,
        Micro = 7,
        HD720 = 8,
        HD1080 = 9
    }
}