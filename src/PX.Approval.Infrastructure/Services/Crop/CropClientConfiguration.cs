using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PX.Approval.Infrastructure.Services.Crop
{
    public class CropClientConfiguration
    {
        public const string CropClientOptions = "CropClientOptions";

        public string GrpcUrl { get; set; } = string.Empty;
    }
}
