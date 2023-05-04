namespace PX.Approval.Application.Common.Interfaces;

public interface IPDFFileService
{
    Task<byte[]> ApplyWaterMarkAsync(MemoryStream fileStream, string fileName, string userName, string userCwid, DateTime lastDownloadDate, string imagePath);

}
