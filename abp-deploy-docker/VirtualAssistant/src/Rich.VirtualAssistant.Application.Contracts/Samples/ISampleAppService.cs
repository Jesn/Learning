using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Rich.VirtualAssistant.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}
