using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PX.Approval.Application.Common.Interfaces;
using PX.Library.Common.Tools.BlobStorageHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PX.Approval.Infrastructure.Services.BlobStorage;

public class BlobStorageService : IBlobStorageService
{        
    private readonly ILogger<BlobStorageService> _logger;
    private readonly ApprovalDocumentManagement _documentsManagement;

    public BlobStorageService(IOptions<BlobStorageConfiguration> options, ILogger<BlobStorageService> logger)
    {            
        _logger = logger;
        _documentsManagement = new ApprovalDocumentManagement(options.Value.BaseAddress, options.Value.DownloadApprovalFileEndPoint);
    }

    public async Task<FileStreamResult> ReadFileAsync(string goalsPlanningIntegrationId, string fileName)
    {
        _logger.LogInformation($"Getting file {fileName} from blob storage");

        var file = await _documentsManagement.ReadFileAsync(goalsPlanningIntegrationId, fileName);
        file.EnsureSuccessStatusCode();

        _logger.LogInformation($"File read : {fileName}");
        var memoryStream = new MemoryStream();
        _ = file.Content.CopyToAsync(memoryStream);
        memoryStream.Position = 0;
        return new FileStreamResult(memoryStream, "application/octet-stream") { FileDownloadName = $"{fileName}.pdf" };
    }
}
