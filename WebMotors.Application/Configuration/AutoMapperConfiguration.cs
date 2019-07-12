using AutoMapper;
using AutoMapper.Configuration.Conventions;
using AutoMapper.Mappers;

namespace WebMotors.Application.Configuration
{
    public class AutoMapperConfiguration
    {
        private bool isInitialized = false;
        public void Configure()
        {
            if (isInitialized)
                return;

            Mapper.Initialize(x =>
            {
                x.AddProfile<ToViewModel>();
                x.AddProfile<FromViewModel>();
                x.AddProfile<FromTotalVoiceDto>();
            });
            isInitialized = true;
        }
    }

    // Flattens with NameSplitMember
    // Only applies to types that have same name with destination ending with Dto
    // Only applies Dto post fixes to the source properties
    internal class ToViewModel : Profile
    {
        public ToViewModel()
        {
            AddMemberConfiguration().AddMember<NameSplitMember>().AddName<PrePostfixName>(
                   _ => _.AddStrings(p => p.Postfixes, "ViewModel"));
            AddConditionalObjectMapper().Where((s, d) => s.Name == d.Name + "ViewModel");
        }

    }
    // Doesn't Flatten Objects
    // Only applies to types that have same name with source ending with Dto
    // Only applies Dto post fixes to the destination properties
    public class FromViewModel : Profile
    {
        public FromViewModel()
        {
            AddMemberConfiguration().AddName<PrePostfixName>(
                    _ => _.AddStrings(p => p.DestinationPostfixes, "ViewModel"));
            AddConditionalObjectMapper().Where((s, d) => d.Name == s.Name + "ViewModel");
        }
    }

    public class FromTotalVoiceDto : Profile
    {
        public FromTotalVoiceDto()
        {
            AddMemberConfiguration().AddName<PrePostfixName>(
                    _ => _.AddStrings(p => p.DestinationPostfixes, "Dto"));
            AddConditionalObjectMapper().Where((s, d) => d.Name == s.Name + "Dto");
        }
    }
}
