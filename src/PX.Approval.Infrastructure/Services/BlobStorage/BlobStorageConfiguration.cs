using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PX.Approval.Infrastructure.Services.BlobStorage;

public class BlobStorageConfiguration
{
    public const string BlobStorageOptions = "BlobStorageOptions";

    public string BaseAddress { get; set; } = string.Empty;
    public string DownloadApprovalFileEndPoint { get; set; } = string.Empty;
}
