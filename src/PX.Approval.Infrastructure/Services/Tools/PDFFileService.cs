using PX.Approval.Application.Common.Interfaces;
using PX.Library.Common.Tools.PDF;

namespace PX.Approval.Infrastructure.Services.Tools;

public class PDFFileService : IPDFFileService
{
    public async Task<byte[]> ApplyWaterMarkAsync(MemoryStream fileStream, string fileName, string userName, string userCwid, DateTime lastDownloadDate, string imagePath)
    {
        byte[] byteArray = fileStream.ToArray();
        var overlayImage = new OverlayImage();

        (byte[] outbyteArray, string fileNameo, string error) = await overlayImage.ApplyWaterMarkAsync(byteArray, fileName, userName, userCwid, lastDownloadDate, imagePath);
        if (string.IsNullOrEmpty(error) && outbyteArray != null)
        {
            return outbyteArray;
        }

        return null;
    }
}
