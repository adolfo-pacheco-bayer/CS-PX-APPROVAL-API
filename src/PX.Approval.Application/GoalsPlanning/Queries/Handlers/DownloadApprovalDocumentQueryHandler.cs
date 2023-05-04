using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PX.Approval.Application.Common.Interfaces;
using PX.Library.Common.Extensions;

namespace PX.Approval.Application.GoalsPlanning.Queries.Handlers;

public class DownloadApprovalDocumentQueryHandler : IRequestHandler<DownloadApprovalDocumentQuery, IActionResult>
{
    private IBlobStorageService _blobStorageService;
    private IPDFFileService _pdfFileService;
    private IHttpContextAccessor _httpContextAccessor;

    public DownloadApprovalDocumentQueryHandler(IBlobStorageService blobStorageService,
                                                IPDFFileService pdfFileService,
                                                IHttpContextAccessor httpContextAccessor)
    {
        _blobStorageService = blobStorageService;
        _pdfFileService = pdfFileService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IActionResult> Handle(DownloadApprovalDocumentQuery request, CancellationToken cancellationToken)
    {
        var user = _httpContextAccessor.HttpContext.GetUser();

        var result = await _blobStorageService.ReadFileAsync(request.GoalsPlanningIntegrationId.ToString(), request.FileName);

        var memoryStream = new MemoryStream();
        result.FileStream.CopyTo(memoryStream);

        byte[] outfileByteArray = await _pdfFileService.ApplyWaterMarkAsync(memoryStream, result.FileDownloadName, user.NameUser, user.Cwid, DateTime.UtcNow.Date, "Images\\watermark.png");
        Stream stream = new MemoryStream(outfileByteArray);
        return new FileStreamResult(stream, "application/octet-stream") { FileDownloadName = result.FileDownloadName };
    }
}
