using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Pinzar_Catalin_Lab10
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<SResponse> SendStatus(SRequest request, ServerCallContext context)
        {
            List<StatusInfo> statusList = StatusRepo();
            SResponse sRes = new SResponse();
            sRes.StatusInfo.AddRange(statusList.Skip(request.No - 1).Take(1));
            return Task.FromResult(sRes);
        }
        public List<StatusInfo> StatusRepo()
        {
            List<StatusInfo> statusList = new List<StatusInfo> {
                new StatusInfo { Author = "Randy", Description = "Task 1 in progess"},
                new StatusInfo { Author = "John", Description = "Task 1 just started"},
                new StatusInfo { Author = "Miriam", Description = "Finished all tasks"},
                new StatusInfo { Author = "Petra", Description = "Task 2 finished"},
                new StatusInfo { Author = "Steve", Description = "Task 2 in progress"}
            };
            return statusList;
        }
    }
}
