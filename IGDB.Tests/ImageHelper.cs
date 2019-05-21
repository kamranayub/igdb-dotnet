using Xunit;
using static IGDB.ImageHelper;

namespace IGDB.Tests
{
  public class ImageHelper
  {
    private const string TestImageId = "abcxyz123";

    [Fact]
    public void ImageHelper_Should_Default_To_Thumbnail_NoRetina()
    {
      var imageUrl = GetImageUrl(TestImageId);

      Assert.Contains("/t_thumb/", imageUrl);
    }

    [Fact]
    public void ImageHelper_Should_Support_Thumbnail()
    {
      Assert.Contains("/t_thumb/", GetImageUrl(TestImageId, ImageSize.Thumb));
      Assert.Contains("/t_thumb_2x/", GetImageUrl(TestImageId, ImageSize.Thumb, true));
    }

    [Fact]
    public void ImageHelper_Should_Support_Cover_Small()
    {
      Assert.Contains("/t_cover_small/", GetImageUrl(TestImageId, ImageSize.CoverSmall));
      Assert.Contains("/t_cover_small_2x/", GetImageUrl(TestImageId, ImageSize.CoverSmall, true));
    }

    [Fact]
    public void ImageHelper_Should_Support_Cover_Big()
    {
      Assert.Contains("/t_cover_big/", GetImageUrl(TestImageId, ImageSize.CoverBig));
      Assert.Contains("/t_cover_big_2x/", GetImageUrl(TestImageId, ImageSize.CoverBig, true));
    }

    [Fact]
    public void ImageHelper_Should_Support_Screenshot_Med()
    {
      Assert.Contains("/t_screenshot_med/", GetImageUrl(TestImageId, ImageSize.ScreenshotMed));
      Assert.Contains("/t_screenshot_med_2x/", GetImageUrl(TestImageId, ImageSize.ScreenshotMed, true));
    }

    [Fact]
    public void ImageHelper_Should_Support_ScreenshotBig()
    {
      Assert.Contains("/t_screenshot_big/", GetImageUrl(TestImageId, ImageSize.ScreenshotBig));
      Assert.Contains("/t_screenshot_big_2x/", GetImageUrl(TestImageId, ImageSize.ScreenshotBig, true));
    }

    [Fact]
    public void ImageHelper_Should_Support_ScreenshotHuge()
    {
      Assert.Contains("/t_screenshot_huge/", GetImageUrl(TestImageId, ImageSize.ScreenshotHuge));
      Assert.Contains("/t_screenshot_huge_2x/", GetImageUrl(TestImageId, ImageSize.ScreenshotHuge, true));
    }

    [Fact]
    public void ImageHelper_Should_Support_Logo_Med()
    {
      Assert.Contains("/t_logo_med/", GetImageUrl(TestImageId, ImageSize.LogoMed));
      Assert.Contains("/t_logo_med_2x/", GetImageUrl(TestImageId, ImageSize.LogoMed, true));
    }

    [Fact]
    public void ImageHelper_Should_Support_Micro()
    {
      Assert.Contains("/t_micro/", GetImageUrl(TestImageId, ImageSize.Micro));
      Assert.Contains("/t_micro_2x/", GetImageUrl(TestImageId, ImageSize.Micro, true));
    }

    [Fact]
    public void ImageHelper_Should_Support_720p()
    {
      Assert.Contains("/t_720p/", GetImageUrl(TestImageId, ImageSize.HD720));
      Assert.Contains("/t_720p_2x/", GetImageUrl(TestImageId, ImageSize.HD720, true));
    }

    [Fact]
    public void ImageHelper_Should_Support_1080p()
    {
      Assert.Contains("/t_1080p/", GetImageUrl(TestImageId, ImageSize.HD1080));
      Assert.Contains("/t_1080p_2x/", GetImageUrl(TestImageId, ImageSize.HD1080, true));
    }
  }
}