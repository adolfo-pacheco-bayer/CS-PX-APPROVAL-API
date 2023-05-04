using Microsoft.AspNetCore.Mvc;

namespace PX.Approval.Application.Common.Interfaces;

public interface IBlobStorageService
{
    Task<FileStreamResult> ReadFileAsync(string goalsPlaninngIntegrationId, string fileName);
}
